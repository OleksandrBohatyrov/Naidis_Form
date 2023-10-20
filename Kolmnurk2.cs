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
    public partial class Kolmnurk2 : Form
    {

        private TextBox txtPointA;
        private TextBox txtPointB;
        private TextBox txtPointC;
        private Button btnDrawTriangle;
        private Label lblHeightResult;
        private Label lblAreaResult;
        private Label lblPerimeterResult;
        private ListBox lstTriangleInfo;
        private Button btnClear;

        PictureBox pb;




        public Kolmnurk2()
        {
            this.Text = "Kolmnurk2";
            this.Height = 700;
            this.Width = 700;
            InitializeComponent();
            InitializeUI();
        }
        private void InitializeUI()
        {

            this.BackColor = Color.FromArgb(54, 50, 49);

            txtPointA = new TextBox();
            txtPointA.PlaceholderText = "Sisesta a pool";
            txtPointA.Location = new Point(10, 10);
            txtPointA.Size = new Size(150, 25);
            txtPointA.BackColor = Color.FromArgb(54, 50, 49);
            txtPointA.ForeColor= Color.White;


            txtPointB = new TextBox();
            txtPointB.PlaceholderText = "Sisesta b pool";
            txtPointB.Location = new Point(10, 40);
            txtPointB.Size = new Size(150, 25);
            txtPointB.BackColor = Color.FromArgb(54, 50, 49);
            txtPointB.ForeColor = Color.White;


            txtPointC = new TextBox();
            txtPointC.PlaceholderText = "Sisesta c pool";
            txtPointC.Location = new Point(10, 70);
            txtPointC.Size = new Size(150, 25);
            txtPointC.BackColor = Color.FromArgb(54, 50, 49);
            txtPointC.ForeColor = Color.White;



            btnDrawTriangle = new Button();
            btnDrawTriangle.Text = "Joonista";
            btnDrawTriangle.Width = 100;
            btnDrawTriangle.Location = new Point(10, 100);
            btnDrawTriangle.Click += btnDrawTriangle_Click;
            btnDrawTriangle.BackColor = Color.Pink;



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
            lstTriangleInfo.BackColor= Color.FromArgb(54, 50, 49);
            lstTriangleInfo.ForeColor = Color.White;

            btnClear = new Button();
            btnClear.Text = "Selge";
            btnClear.Width = 100;
            btnClear.Location = new Point(btnDrawTriangle.Location.X+130, btnDrawTriangle.Top);
            btnClear.Click += btnClear_Click;
            btnClear.BackColor = Color.Pink;



            pb = new PictureBox();
            pb.Location = new Point(350,300);
   
            pb.Size = new Size(200, 140);
            pb.SizeMode = PictureBoxSizeMode.Zoom;
            pb.BorderStyle = BorderStyle.Fixed3D;



            Controls.Add(btnClear);
            Controls.Add(pb);
            Controls.Add(lstTriangleInfo);
            Controls.Add(txtPointA);
            Controls.Add(txtPointB);
            Controls.Add(txtPointC);
            Controls.Add(btnDrawTriangle);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Invalidate();
            lstTriangleInfo.Items.Clear();
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

                    lstTriangleInfo.Items.Clear();

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
                    Pen pen = new Pen(Color.White);
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
                    if (triangle.IsEquilateral() == true)
                    {
                        pb.Image = new Bitmap("../../../stor.png");

                    }

                    lstTriangleInfo.Items.Add($"Võrdhaarne: {triangle.IsIsosceles()}");
                    if (triangle.IsIsosceles()==true)
                    {
                        pb.Image = new Bitmap("../../../ravno.png");

                    }
                    lstTriangleInfo.Items.Add($"Erikülne: {triangle.IsScalene()}");
                    if (triangle.IsScalene() == true)
                    {
                        pb.Image = new Bitmap("../../../eri.png");

                    }
                }
                else
                {
                    MessageBox.Show("Ei ole olemas.");
                }
            }
            else
            {
                MessageBox.Show("Kirjuta kolmnurga külgede korrektsed väärtused.");
            }
        }


    }
}
