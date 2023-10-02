using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Naidis_Form
{
    public partial class TreeForm : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;

        bool isBtnVisible = false;  
        bool isLblVisible= false;

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



            tree.Nodes.Add(treeNode);
            this.Controls.Add(tree);
            this.Controls.Add(btn);
            this.Controls.Add(lbl);
            lbl.Visible= false;
            btn.Visible = false;

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
            else if (e.Node.Text == "Silt-Label")
            {
                tree.SelectedNode = null;
                isLblVisible= !isLblVisible;
                lbl.Visible= !isLblVisible;
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
