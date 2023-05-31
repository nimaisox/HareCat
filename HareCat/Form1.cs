using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HareCat
{
    public partial class Form1 : Form
    {
        //vorodi haye sabet
        bool goleft = false; // def
        bool goright = false; // def
        bool jumping = false; // def mojo diyat ha be bool keyup

        int jumpSpeed = 10; // soraat
        int force = 8; // godrat ni ro
        int score = 0; // emtiyaz
        // end vorodi ha
        public Form1()
        {
            InitializeComponent();
        }
        // agar dokme feshar dade shode bod 
        private void keydown(object sender, KeyEventArgs e)
        {
            // key chap
            if (e.KeyCode == Keys.Left)
            {
                goleft = true;
            }
            // key rast
            if (e.KeyCode == Keys.Right)
            {
                goright = true;
            }
            // key up bala
            if (e.KeyCode == Keys.Up)
            {
                jumping = true;
            }
        }
        //agar dokme bala bod yani feshar dade nashode bod 
        // event timer haere kat player
        // haleat bool
        private void keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                goleft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goright = false;
            }
            if (jumping)
            {
                jumping = false;
            }
        }

        private void timer(object sender, EventArgs e)
        {// be tor modavem bazi kon raha mishavad
            player.Top += jumpSpeed;
            // baresi bazi kon dar hal paridan
            if (jumping && force < 0)
            {
                jumping = false;
            }
            // agar raftan be chap doros bashad mitavanim caracter ra be chap feshar dahim
            if (goleft)
            {
                player.Left -= 5;
            }
            // agar dorost bashad player ro be samt chap va rust harekat midahim
            if (goright)
            {
                player.Left += 5;
            }
            // agar paresh dorost bashad on ro be -12 tagir midahim va ni ro ra hamon 1 khahesh midahim agar anjam nadahi player fly hack mikonad
            if (jumping)
            {
                jumpSpeed = -12;
                force -= 1;
            }
            // dar ger in sorat hamon 12
            else
            {
                jumpSpeed = 12;
            }

            foreach (Control x in this.Controls)
            {
                //obj haye bazi ke roye on garar migirad
#pragma warning disable CS0252 // baraye fix kardan cod amozeshi vs
                if (x is PictureBox && x.Tag == "obj")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                    {
                        force = 20;
                        player.Top = x.Top - player.Height;
                    }
                }
                // jonz emtiyaz haye zard dakhel bazi
#pragma warning disable CS0252 // baraye fix kardan cod amozeshi vs
                if (x is PictureBox && x.Tag == "jonz")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds) && !jumping)
                    {
                        this.Controls.Remove(x);
                        score++;
                    }
                }
                // bord bazi ba emtiyaz namayesh
                if (player.Bounds.IntersectsWith(door.Bounds))
                {
                    timer1.Stop();
                    MessageBox.Show("Shoma Bordid\nba : "+score+" emtiyaz");
                    System.Windows.Forms.Application.Exit();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            player.ImageLocation = (openFileDialog1.FileName);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }
    }
}

