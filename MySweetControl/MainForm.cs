using MySweetControl.Back;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySweetControl
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            BtnStyle();

            // Отображаем контрол на панели
            MainPanel.Controls.Add(new Main_UserControl());

            // Логотип
            pictureBoxLogo.Image = Properties.Resources.SweetControlLogo;
            label_version.Text = "v 1.0";
            timerResMonitor.Enabled = true;
            this.Icon = Properties.Resources.SweetControlIco;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region ButtonExitStyle
        public void BtnStyle()
        {
            System.Drawing.Drawing2D.GraphicsPath myPath =
                new System.Drawing.Drawing2D.GraphicsPath();
            //Рисуем ромб полигоном
            PointF point1 = new PointF((buttonExit.Width / 2), buttonExit.Width); // Верхняя
            PointF point2 = new PointF(buttonExit.Height, (buttonExit.Height / 2)); // Правая
            PointF point3 = new PointF((buttonExit.Width / 2), 0); // Нижняя
            PointF point4 = new PointF(0, (buttonExit.Height / 2)); // Левая
            PointF[] points = new PointF[] { point1, point2, point3, point4 };
            myPath.AddPolygon(points);

            Region myRegion = new Region(myPath);
            buttonExit.Region = myRegion;
        }

        private void buttonExit_MouseEnter(object sender, EventArgs e)
        {
            buttonExit.Text = "◈";
        }

        private void buttonExit_MouseLeave(object sender, EventArgs e)
        {
            buttonExit.Text = "◇";
        }
        #endregion

        private void panelHeader_MouseDown(object sender, MouseEventArgs e)
        {
            panelHeader.Capture = false;
            Message m = Message.Create(Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            WndProc(ref m);
        }

        private void timerResMonitor_Tick(object sender, EventArgs e)
        {
            label_memory.Text = ResourceMonitoring.GetUseMemory();
        }
    }
}
