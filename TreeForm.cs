using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Naidis_Form
{
    public partial class TreeForm : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        TextBox txt_box;
        RadioButton r1, r2;
        CheckBox c1, c2;
        PictureBox pb;


        bool isBtnVisible = false;  
        bool isLblVisible= false;
        bool isTxtVisible = false;
        bool isRVisible=false;
        bool isCBVisible= false;
        bool isPBVisible = false;

        public TreeForm() 
        { 
            this.Height= 600;
            this.Width= 800;
            this.Text = "Vorm põhielementidega";
            tree= new TreeView();
            tree.Dock = DockStyle.Left;
            tree.BorderStyle= BorderStyle.Fixed3D;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode treeNode= new TreeNode("Elemendid");
            treeNode.Nodes.Add(new TreeNode("Nupp-Button"));

            btn = new Button();
            btn.Height = 40;
            btn.Width = 100;
            btn.Text = "Valjuta mind!";
            btn.Location = new Point(150, 150);
            btn.Click += Btn_Click;
            btn.MouseHover += Btn_MouseHover;
            btn.MouseDown += new MouseEventHandler(this.Form_MouseDown);
            //Label
            treeNode.Nodes.Add(new TreeNode("Silt-Label"));
            lbl = new Label();
            lbl.Text = "Pealkiri";
            lbl.Location = new Point(tree.Width,0);
            lbl.Size = new Size(this.Width, btn.Location.Y);
            lbl.BackColor= Color.White;
            lbl.BorderStyle= BorderStyle.Fixed3D;
            lbl.Font = new Font("Tahoma",24);
            //Tekstkast
            treeNode.Nodes.Add(new TreeNode("Tekstkast-Texbox"));
            txt_box=new TextBox();
            txt_box.BorderStyle= BorderStyle.Fixed3D;
            txt_box.Height= 50;
            txt_box.Width= 100;
            txt_box.Text = "...";
            txt_box.Location = new Point(tree.Width,btn.Top+btn.Height);
            txt_box.KeyDown += new KeyEventHandler(Txt_box_KeyDown);
              

            //Radiobutton
            treeNode.Nodes.Add(new TreeNode("RadioButton"));
            r1=new RadioButton();
            r1.Text = "Valik 1";
            r1.Location = new Point(tree.Width,txt_box.Location.Y+txt_box.Height);

            r2 = new RadioButton();
            r2.Text = "Valik 2";
            r2.Location = new Point(r1.Location.X+r1.Width, txt_box.Location.Y+txt_box.Height);


            r1.CheckedChanged += new EventHandler(Radiobuttons_Changed);
            r2.CheckedChanged += new EventHandler(Radiobuttons_Changed);

            //CheckBox
            treeNode.Nodes.Add(new TreeNode("CheckBox"));
            c1=new  CheckBox();
            c1.Text = "Valik 1";
            c1.Location = new Point(tree.Width, r1.Location.Y+r1.Height);

            c2 = new CheckBox();
            c2.Text = "Valik 2";
            c2.Location = new Point(tree.Width, c1.Location.Y+ c1.Height);

            c1.CheckedChanged += new EventHandler(CheckBox_Changed);


            //image
            treeNode.Nodes.Add(new TreeNode("PictureBox"));
            pb=new PictureBox();
            pb.Location = new Point(tree.Width, c2.Location.Y + c2.Height);
            pb.Image = new Bitmap("../../../pilt.jpg");
            pb.Size = new Size(200, 200);
            pb.SizeMode=PictureBoxSizeMode.Zoom;
            pb.BorderStyle= BorderStyle.Fixed3D;
          


            tree.Nodes.Add(treeNode);
            this.Controls.Add(txt_box);
            this.Controls.Add(r1);
            this.Controls.Add(r2);
            this.Controls.Add(tree);
            this.Controls.Add(btn);
            this.Controls.Add(lbl);
            this.Controls.Add(c1);
            this.Controls.Add(c2);
            this.Controls.Add(pb);
            txt_box.Visible= false;
            lbl.Visible= false;
            btn.Visible = false;
            r1.Visible= false;
            r2.Visible = false;
            c1.Visible= false;
            c2.Visible = false;
            pb.Visible= false;

        }

        private void Txt_box_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Enter)
            {
                DialogResult result=MessageBox.Show("Kas sa oled kindel?","Küsimus", MessageBoxButtons.YesNo);
                if (result==DialogResult.Yes)
                {
                    txt_box.Enabled=false;
                    this.Text = txt_box.Text;
                }
            }
            else if (e.KeyCode==Keys.Back)
            {
                
                txt_box.Clear();
            }
        }

        private void CheckBox_Changed(object? sender, EventArgs e)
        {

            if (c1.Checked == true && c2.Checked == false)
            {

                tree.SelectedNode = null;
                isPBVisible = !isPBVisible;
                pb.Visible = !isPBVisible;

            }
        }

        private void Radiobuttons_Changed(object? sender, EventArgs e)
        {
            if (r1.Checked)
            {
                this.BackColor = Color.White;
                r1.ForeColor = Color.Black;
                r2.ForeColor = Color.Black;
           
            }
            if (r2.Checked)
            {
                this.BackColor = Color.Black;
                r1.ForeColor= Color.White;
                r2.ForeColor = Color.White;
            }
        }


        private void Btn_MouseHover(object? sender, EventArgs e)
        {
            btn.BackColor = Color.Red;
        }

        private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node.Text== "Nupp-Button")
            {
                tree.SelectedNode = null;
                isBtnVisible = !isBtnVisible;
                btn.Visible = isBtnVisible;
            }
            else if (e.Node.Text == "Silt-Label" )
            {
                tree.SelectedNode = null;
                isLblVisible= !isLblVisible;
                lbl.Visible= !isLblVisible;
            }
            else if (e.Node.Text == "Tekstkast-Texbox")
            {
                tree.SelectedNode= null;
                isTxtVisible =!isTxtVisible;
                txt_box.Visible = !isTxtVisible;

                //txt_box.Visible = false;
            }
            else if (e.Node.Text == "RadioButton")
            {
                tree.SelectedNode = null;
                isRVisible = !isRVisible;
                r1.Visible = !isRVisible;
                r2.Visible = !isRVisible;

                //txt_box.Visible = false;
            }
            else if (e.Node.Text == "CheckBox")
            {
                tree.SelectedNode = null;
                isCBVisible = !isCBVisible;
                c1.Visible = !isCBVisible;
                c2.Visible = !isCBVisible;

              
            }
            else if (e.Node.Text == "PictureBox")
            {
                tree.SelectedNode = null;
                isPBVisible = !isPBVisible;
                pb.Visible = !isPBVisible;


            }
        }



        private void Btn_Click(object? sender, EventArgs e)
        {
            if (btn.BackColor == Color.Aqua)
            {
                btn.BackColor = Color.Chocolate;
            }
            else
            {
                btn.BackColor = Color.Aqua;
            }   
        }
        private void Form_MouseDown(object sender, MouseEventArgs e)
        {

            switch (e.Button)
            {
                case MouseButtons.Left:
                    MessageBox.Show("Left Button Click");
                    btn.BackColor = Color.Chocolate;
                    break;
                case MouseButtons.Right:
                    MessageBox.Show("Right Button Click");
                    btn.BackColor = Color.Aqua;
                    break;
                case MouseButtons.Middle:
                    MessageBox.Show("Middle Button Click");
                    btn.BackColor = Color.Green;
                    break;

                default:
                    break;

            }
        }

    }
}
