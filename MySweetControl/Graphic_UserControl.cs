using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace MySweetControl
{
    public partial class Graphic_UserControl : UserControl
    {
        public Graphic_UserControl()
        {
            InitializeComponent();

            ViewSetting();
            AddGraphicResult(DateTime.Now.ToShortDateString());
        }

        private void ViewSetting()
        {
            //float maxY = 25;
            //float minY = 0;

            Axis ax = new Axis();
            Axis ay = new Axis();

            ax.Title = "Time";
            ay.Title = "Result";

            // Делаем подписи осей
            MainChart.ChartAreas[0].AxisX = ax;
            MainChart.ChartAreas[0].AxisY = ay;

            // Настройка цветов графика
            MainChart.BackColor = Color.FromArgb(100, 115, 164); // Color.FromArgb(100, 115, 164); / Color.FromArgb(0, 15, 64);
            MainChart.ChartAreas[0].BackColor = Color.FromArgb(0, 15, 64); //Color.White;
            MainChart.Legends[0].BackColor = Color.FromArgb(100, 115, 164);
            MainChart.Legends[0].ForeColor = Color.White;

            MainChart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(180, 115, 170); //Color.White;
            MainChart.ChartAreas[0].AxisX.LineColor = Color.FromArgb(180, 115, 170); //Color.White; // Цвет оси
            MainChart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(180, 115, 170); //Color.White;
            MainChart.ChartAreas[0].AxisY.LineColor = Color.FromArgb(180, 115, 170); //Color.White; // Цвет оси

            MainChart.ChartAreas[0].AxisX.TitleForeColor = Color.White;
            MainChart.ChartAreas[0].AxisY.TitleForeColor = Color.White;

            MainChart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.White;
            MainChart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.White;

            // Задаем допустимые значения для оси ординат 
            //MainChart.ChartAreas[0].AxisY.Maximum = maxY;
            //MainChart.ChartAreas[0].AxisY.Minimum = minY;

            MainChart.Series[0].Name = "My result";
            MainChart.Series.Add("Normal upper");
            MainChart.Series.Add("Normal lower");

            MainChart.Legends[0].Docking = Docking.Top;

            // Меняем тип графика
            for (int i = 0; i < MainChart.Series.Count; i++)
            {
                MainChart.Series[i].ChartType = SeriesChartType.Line;
                MainChart.Series[i].BorderWidth = 4;
            }
        }

        // Добавление результатов на график
        public void AddGraphicResult(string date)
        {
            MainChart.Series[0].Points.Clear(); // Очистка графика если на нем что то было
            MainChart.Series[1].Points.Clear();
            MainChart.Series[2].Points.Clear();
            MainChart.ChartAreas[0].AxisX.CustomLabels.Clear();

            // Цвета линий
            MainChart.Series[0].Color = Color.FromArgb(253, 209, 102); //Color.Cyan;
            MainChart.Series[1].Color = Color.FromArgb(250, 35, 170); //Color.Red;
            // Цвет третьей линии дефолтный

            // Рисуем график с начала
            int offset = 0;
            const float NormalLevelUpper = 7.8f;
            const float NormalLevelLower = 3.3f;

            // Чтение из файла и запись результатов в график
            string[] dataArr = File.ReadAllLines("dataResult.txt");

            IEnumerable<string> query = from str in dataArr
                                        where str.Contains($"{date}") // DateTime.Now.ToShortDateString() Сортировка по текущей дате
                                        select str;

            List<string> resultList = new List<string>();
            foreach (string str in query)
            {
                resultList.Add(str);
            }

            // Полосы нормаьного результата
            MainChart.Series[1].Points.AddXY(0, NormalLevelUpper);
            MainChart.Series[1].Points.AddXY(resultList.Count - 1, NormalLevelUpper);

            MainChart.Series[2].Points.AddXY(0, NormalLevelLower);
            MainChart.Series[2].Points.AddXY(resultList.Count - 1, NormalLevelLower);

            string[] AxisX = new string[resultList.Count];
            string[] AxisY = new string[resultList.Count];
            for (int i = 0; i < resultList.Count; i++)
            {
                string[] buff = resultList[i].Split('/');
                AxisY[i] = buff[0];
                AxisX[i] = buff[1];
            }

            for (int i = 0; i < AxisX.Length; i++)
            {
                MainChart.ChartAreas[0].AxisX.CustomLabels.Add(offset, offset += 1, AxisX[i]); // Добавить кастом лейблы
                MainChart.Series[0].Points.AddXY(i, AxisY[i]); // Convert.ToInt32(AxisY[i])
            }
        }
    }
}
