using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Naidis_Form
{
    public partial class Kolmnurk : Form
    {

        private TextBox txtPointA;
        private TextBox txtPointB;
        private TextBox txtPointC;
        private Button btnDrawTriangle;
        private Label lblHeightResult;
        private Label lblAreaResult;
        private Label lblPerimeterResult;
        private ListBox lstTriangleInfo;

        public Kolmnurk()
        {
            this.Text = "Kolmnurk";
            this.Height = 500;
            this.Width = 500;

            InitializeComponent();
            InitializeUI();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Invalidate();
            lstTriangleInfo.Items.Clear();
        }




        private void InitializeUI()
        {
     
            txtPointA = new TextBox();
            txtPointA.Location = new Point(10, 10);
            txtPointA.Size = new Size(150, 25);
            

            txtPointB = new TextBox();
            txtPointB.Location = new Point(10, 40);
            txtPointB.Size = new Size(150, 25);
       

            txtPointC = new TextBox();
            txtPointC.Location = new Point(10, 70);
            txtPointC.Size = new Size(150, 25);

            btnDrawTriangle = new Button();
            btnDrawTriangle.Text = "Joonista";
            btnDrawTriangle.Width = 100;
            btnDrawTriangle.Location = new Point(10, 100);
            btnDrawTriangle.Click += btnDrawTriangle_Click;

            lblHeightResult = new Label();
            lblHeightResult.Text = "Kõrgus: ";
            lblHeightResult.Location = new Point(10, 220);

            lblAreaResult = new Label();
            lblAreaResult.Text = "Pindala: ";
            lblAreaResult.Location = new Point(10, 250);

            lblPerimeterResult = new Label();
            lblPerimeterResult.Text = "Perimeeter: ";
            lblPerimeterResult.Location = new Point(10, 280);

            lstTriangleInfo = new ListBox();
            lstTriangleInfo.Location = new Point(10, 160);
            lstTriangleInfo.Size = new Size(300, 300);
          


            Controls.Add(lstTriangleInfo);
            Controls.Add(txtPointA);
            Controls.Add(txtPointB);
            Controls.Add(txtPointC);
            Controls.Add(btnDrawTriangle);

        }



        private void btnDrawTriangle_Click(object sender, EventArgs e)
        {
            // Получаем координаты точек из текстовых полей
            double pointA, pointB, pointC;
            if (double.TryParse(txtPointA.Text, out pointA) && double.TryParse(txtPointB.Text, out pointB) && double.TryParse(txtPointC.Text, out pointC))
            {
                // Проверяем, существует ли треугольник
                if (pointA + pointB > pointC && pointA + pointC > pointB && pointB + pointC > pointA)
                {
                    // Расчет координат вершин треугольника
                    double centerX = 500; 
                    double centerY = 150; 

                    double angleA = Math.PI / 2; 
                    double angleB = angleA + Math.Acos((pointA * pointA + pointC * pointC - pointB * pointB) / (2 * pointA * pointC));
                    double angleC = 3 * Math.PI / 2; 

                    double xA = centerX + pointA * Math.Cos(angleA);
                    double yA = centerY - pointA * Math.Sin(angleA);

                    double xB = centerX + pointB * Math.Cos(angleB);
                    double yB = centerY - pointB * Math.Sin(angleB);

                    double xC = centerX + pointC * Math.Cos(angleC);
                    double yC = centerY - pointC * Math.Sin(angleC);

                    // Рисуем треугольник на форме
                    Graphics graphics = CreateGraphics();
                    Pen pen = new Pen(Color.Black);
                    graphics.DrawLine(pen, (float)xA, (float)yA, (float)xB, (float)yB);
                    graphics.DrawLine(pen, (float)xB, (float)yB, (float)xC, (float)yC);
                    graphics.DrawLine(pen, (float)xC, (float)yC, (float)xA, (float)yA);


                    Triangle triangle = new Triangle(pointA, pointB, pointC);

                    lstTriangleInfo.Items.Clear();
                    lstTriangleInfo.Items.Add($"Külg A: {pointA}");
                    lstTriangleInfo.Items.Add($"Külg B: {pointB}");
                    lstTriangleInfo.Items.Add($"Külg C: {pointC}");
                    lstTriangleInfo.Items.Add($"Primeter: {triangle.Perimeter()}");
                    lstTriangleInfo.Items.Add($"Pindala: {triangle.Surface()}");
                    lstTriangleInfo.Items.Add($"Mediaan: {triangle.OutputMA()}");
                    lstTriangleInfo.Items.Add($"Kõrgus: {triangle.OutputH()}");
                    lstTriangleInfo.Items.Add($"Olemas?: {triangle.ExistTriangle}");
                    lstTriangleInfo.Items.Add($"Võrdkülne: {triangle.IsEquilateral()}");
                    lstTriangleInfo.Items.Add($"Võrdhaarne: {triangle.IsIsosceles()}");
                    lstTriangleInfo.Items.Add($"Erikülne: {triangle.IsScalene()}");
                }
                else
                {
                    MessageBox.Show("не существует.");
                }
            }
            else
            {
                MessageBox.Show("введите корректные значения сторон треугольника.");
            }   
        }
        

    }
}
