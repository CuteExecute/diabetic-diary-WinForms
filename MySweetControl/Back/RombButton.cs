using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySweetControl.Back
{
    class RombButton : Button
    {
        public RombButton()
        {
            System.Drawing.Drawing2D.GraphicsPath myPath =
               new System.Drawing.Drawing2D.GraphicsPath();
            //Рисуем ромб полигоном
            PointF point1 = new PointF((this.Width / 2), this.Width); // Верхняя
            PointF point2 = new PointF(this.Height, (this.Height / 2)); // Правая
            PointF point3 = new PointF((this.Width / 2), 0); // Нижняя
            PointF point4 = new PointF(0, (this.Height / 2)); // Левая
            PointF[] points = new PointF[] { point1, point2, point3, point4 };
            myPath.AddPolygon(points);

            Region myRegion = new Region(myPath);
            this.Region = myRegion;
        }

        
    }
}
