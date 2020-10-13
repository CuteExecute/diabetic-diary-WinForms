using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySweetControl.Main_classes;
using System.IO;
using System.Text.RegularExpressions;

namespace MySweetControl
{
    public partial class Main_UserControl : UserControl
    {
        Graphic_UserControl thisGraph = null;
        Regex regex = new Regex("^[0-9]*[.][0-9]*$"); // @"^[0-9]*(?:\.[0-9]*)?$" Проверка на ввод значения с плавающей точкой
        public Main_UserControl()
        {
            InitializeComponent();

            SelectPanel();
            GetThisUC();

            DataGridSetting();

            Task LoadingData = new Task(LoadTable);
            LoadingData.Start();
            //LoadTable();
        }

        private void GetThisUC() // Получить текущий юзерконтрол для таблицы
        {
            foreach (var item in panelGraphic.Controls.OfType<Graphic_UserControl>())
            {
                thisGraph = item;
            }
        }

        private void SelectPanel() // Проверка наличия данных для графика
        {
            if (!DataWorker.CheckData(DateTime.Now.ToShortDateString()))
            {
                panelGraphic.Controls.Clear();
                panelGraphic.Controls.Add(new Graphic_UserControl());
                GetThisUC(); // Получаем новый Контрол
            }
            else
            {
                panelGraphic.Controls.Clear();
                panelGraphic.Controls.Add(new NoResult_UserControl());
            }

        }

        private void LoadTable()
        {
            MainDataGridView.Rows.Clear();

            string[] dataArr = File.ReadAllLines("dataResult.txt");

            string[] result = new string[dataArr.Length];
            string[] time = new string[dataArr.Length];
            string[] date = new string[dataArr.Length];

            // Выборка за последний месяц
            IEnumerable<string> query = from data in dataArr
                                        let currMonth = DateTime.Today.Month
                                        let currYear = DateTime.Today.Year
                                        where data.Contains($"{currMonth}.{currYear}")
                                        select data;

            List<string> queryRes = new List<string>();
            foreach (var item in query)
            {
                queryRes.Add(item);
            }

            for (int i = 0; i < queryRes.Count; i++)
            {
                string[] buff = queryRes[i].Split('/');
                result[i] = buff[0];
                time[i] = buff[1];
                date[i] = buff[2];
                MainDataGridView.Rows.Add();
            }

            for (int i = 0; i < queryRes.Count; i++) 
            {
                MainDataGridView.Rows[i].Cells[0].Value = result[i];
                MainDataGridView.Rows[i].Cells[1].Value = time[i];
                MainDataGridView.Rows[i].Cells[2].Value = date[i];
            }

        }

        private void DataGridSetting()
        {
            MainDataGridView.Columns.Add("result", "result");
            MainDataGridView.Columns.Add("time", "time");
            MainDataGridView.Columns.Add("date", "date");

            // Цвета датагрида
            MainDataGridView.GridColor = Color.FromArgb(0, 15, 64);
            MainDataGridView.BackgroundColor = Color.FromArgb(0, 15, 64);
            MainDataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 15, 64);
            MainDataGridView.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            MainDataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            MainDataGridView.EnableHeadersVisualStyles = false;

            MainDataGridView.DefaultCellStyle.SelectionBackColor = Color.White;
            MainDataGridView.DefaultCellStyle.SelectionForeColor = Color.Black;

            MainDataGridView.ColumnHeadersVisible = true;
            MainDataGridView.RowHeadersVisible = false;

            MainDataGridView.AllowUserToResizeColumns = false;
            MainDataGridView.AllowUserToResizeRows = false;

            MainDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.HeaderText = "delete";
            btn.Text = "❌";
            btn.Name = "btn";
            btn.UseColumnTextForButtonValue = true;

            MainDataGridView.Columns.Add(btn);
        }

        private void EnterResultButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (regex.IsMatch(ResultTextBox.Text)) // проверка регулярного выражения
                {
                    DataWorker.NewResult(ResultTextBox.Text, DateTime.Now.ToShortTimeString(), DateTime.Now.ToShortDateString());
                    SelectPanel(); // Обновить панель 
                    thisGraph.AddGraphicResult(DateTime.Now.ToShortDateString()); // Обновить результаты графика по текущей дате
                    ResultTextBox.Clear(); // Очистить текстбокс
                    LoadTable(); // Обновляем таблицу
                }
                else
                {
                    ResultTextBox.Clear();
                    MessageBox.Show("Incorrect value, only floating point values ​​are used!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Field must not be empty!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Main_DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            // Костыльный кусок кода? 
            //thisGraph.AddGraphicResult(Main_DateTimePicker.Value.ToShortDateString()); // Обновить результаты графика по выбранной дате
            if (DataWorker.CheckData(Main_DateTimePicker.Value.ToShortDateString()))
            {
                panelGraphic.Controls.Clear();
                panelGraphic.Controls.Add(new NoResult_UserControl());
            }
            else
            {
                panelGraphic.Controls.Clear();
                panelGraphic.Controls.Add(new Graphic_UserControl());
                GetThisUC(); // Получаем новый Контрол
                thisGraph.AddGraphicResult(Main_DateTimePicker.Value.ToShortDateString());
            }
        }

        private void MainDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                string removable = $"{MainDataGridView.Rows[e.RowIndex].Cells[0].Value}/{MainDataGridView.Rows[e.RowIndex].Cells[1].Value}/{MainDataGridView.Rows[e.RowIndex].Cells[2].Value}";
                FileWorker.DeleteResult(removable);

                // Спросить точно ли хотите удалить результат
                //MessageBox.Show("Удаление завершено");

                // Обновить таблицу
                LoadTable();
                // Обновить график
                SelectPanel();
                GetThisUC();
            }
        }
    }
}
