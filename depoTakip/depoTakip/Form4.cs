using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
namespace depoTakip
{
    public partial class Form4 : Form
    {

        public static SqlConnection connect = new SqlConnection("Data Source=DESKTOP-KCH0A99; Initial Catalog=Test; Integrated Security=TRUE");
        public Form4()
        {
            this.IsMdiContainer = true;
            InitializeComponent();
            verileriAl();
            progressBar1.Value = 65;
            progressBar2.Value = 95;
            progressBar3.Value = 45;
            progressBar4.Value = 55;
            progressBar5.Value = 88;
            progresBarColor();

            label3.Text = "%" + progressBar1.Value.ToString();
            label4.Text = "%" + progressBar2.Value.ToString();
            label5.Text = "%" + progressBar3.Value.ToString();
            label6.Text = "%" + progressBar4.Value.ToString();
            label7.Text = "%" + progressBar5.Value.ToString();

        }
        
        ArrayList arlist = new ArrayList();
        int a;
        String[] split;
        int progres1;
            public void verileriAl()
            {
                connect.Open();
                SqlCommand komut = new SqlCommand("Select * from depoLitre", connect);
                SqlDataReader oku = komut.ExecuteReader();

                while (oku.Read())
                {
                if (oku["BenzinLitre"] != null)
                {
                    
                    arlist.Add(oku["BenzinLitre"]);

                    
                }
               
                }
                
           foreach (var item in arlist)
            {
                Console.WriteLine(item);
              //  int s= Convert.ToInt32(item);
            }
            Console.ReadLine();

        }

        public static void PrintValues(IEnumerable myList)
        {
            foreach (Object obj in myList)
                Console.Write("   {0}", obj);
            Console.WriteLine();
        }

        public void progresBarColor()
            {
           
            if (progressBar1.Value >= 90)
            {
                progressBar1.ForeColor = Color.Red;
            }

            if (progressBar1.Value >= 70 && progressBar1.Value < 90)
            {
                progressBar1.ForeColor = Color.DarkOrange;
            }

            if (progressBar1.Value >= 50 && progressBar1.Value < 70)
            {
                progressBar1.ForeColor = Color.DarkGoldenrod;
            }

            if (progressBar1.Value < 50)
            {
                progressBar1.ForeColor = Color.Yellow;
            }



            if (progressBar2.Value >= 90)
            {
                progressBar2.ForeColor = Color.Red;
            }

            if (progressBar2.Value >= 70 && progressBar2.Value < 90)
            {
                progressBar2.ForeColor = Color.DarkOrange;
            }

            if (progressBar2.Value >= 50 && progressBar2.Value < 70)
            {
                progressBar2.ForeColor = Color.Orange;
            }

            if (progressBar2.Value < 50)
            {
                progressBar2.ForeColor = Color.Yellow;
            }


            if (progressBar3.Value >= 90)
            {
                progressBar3.ForeColor = Color.Red;
            }

            if (progressBar3.Value >= 70 && progressBar3.Value < 90)
            {
                progressBar3.ForeColor = Color.DarkOrange;
            }

            if (progressBar3.Value >= 50 && progressBar3.Value < 70)
            {
                progressBar3.ForeColor = Color.Orange;
            }

            if (progressBar3.Value < 50)
            {
                progressBar3.ForeColor = Color.Yellow;
            }

            if (progressBar4.Value >= 90)
            {
                progressBar4.ForeColor = Color.Red;
            }

            if (progressBar4.Value >= 70 && progressBar4.Value < 90)
            {
                progressBar4.ForeColor = Color.DarkOrange;
            }

            if (progressBar4.Value >= 50 && progressBar4.Value < 70)
            {
                progressBar4.ForeColor = Color.Orange;
            }

            if (progressBar4.Value < 50)
            {
                progressBar4.ForeColor = Color.Yellow;
            }

            if (progressBar5.Value >= 90)
            {
                progressBar5.ForeColor = Color.Red;
            }

            if (progressBar5.Value >= 70 && progressBar5.Value < 90)
            {
                progressBar5.ForeColor = Color.DarkOrange;
            }

            if (progressBar5.Value >= 50 && progressBar5.Value < 70)
            {
                progressBar5.ForeColor = Color.Orange;
            }

            if (progressBar5.Value < 50)
            {
                progressBar5.ForeColor = Color.Yellow;
            }


        }



       

        bool move;
        int mouse_x;// form hareketi için gerekli değişkenleri tanımladık
        int mouse_y;
        private void Form4_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }


        private void Form4_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form4_MouseMove(object sender, MouseEventArgs e)
        {

            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);

            }
        }
        bool sidebar;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (sidebar)
            {
                flowLayoutPanel1.Width -= 10;
                if (flowLayoutPanel1.Width == flowLayoutPanel1.MinimumSize.Width)
                {
                    sidebar = false;
                    timer1.Stop();
                   
                    label8.Visible = true;
                    label9.Visible = true;
                    label10.Visible = true;
                    label11.Visible = true;
                    label12.Visible = true;
                }
            }
            else
            {
                flowLayoutPanel1.Width += 10;
                if (flowLayoutPanel1.Width == flowLayoutPanel1.MaximumSize.Width)
                {
                    sidebar = true;
                    timer1.Stop();
                    label8.Visible = false;
                    label9.Visible = false;
                    label10.Visible = false;
                    label11.Visible = false;
                    label12.Visible = false;
                }
            }
        }

     
        int eklenenBenzin;
        int eklenenMotorin;
        int eklenenMotorin2;
        int eklenenGaz;
        int eklenenFuel;
        public void veriEkle()
        {
            if (textBox1.Text == null)
            {
                eklenenBenzin = 1;
            }
            eklenenBenzin = Convert.ToInt32(textBox1.Text);
            eklenenMotorin = Convert.ToInt32(textBox2.Text);
            eklenenMotorin2 = Convert.ToInt32(textBox3.Text);
            eklenenGaz = Convert.ToInt32(textBox4.Text);
            eklenenFuel = Convert.ToInt32(textBox5.Text);


            if (eklenenBenzin != null && progressBar1.Value + eklenenBenzin <= 100)
            {
                progressBar1.Value = progressBar1.Value + eklenenBenzin;

            }

            else
            {
                 MessageBox.Show("Benzin Deposunda Yer Yok");

            }

            if (progressBar2.Value + eklenenMotorin <= 100)
            {
                progressBar2.Value = progressBar2.Value + eklenenMotorin;

            }

            else
            {
                // MessageBox.Show("Motorin Ultra Deposunda Yer Yok");
            }

            if (progressBar3.Value + eklenenMotorin2 <= 100)
            {
                progressBar3.Value = progressBar3.Value + eklenenMotorin2;

            }

            else
            {
                // MessageBox.Show("Motorin Eco Deposunda Yer Yok");
            }


            if (progressBar4.Value + eklenenGaz <= 100)
            {
                progressBar4.Value = progressBar4.Value + eklenenGaz;

            }

            else
            {
                //  MessageBox.Show("Gazyağı Deposunda Yer Yok");
            }


            if (progressBar5.Value + eklenenFuel <= 100)
            {
                progressBar5.Value = progressBar5.Value + eklenenFuel;

            }

            else
            {
                // MessageBox.Show("Fuel Oil Eco Deposunda Yer Yok");
            }




        }

        int cikanBenzin;
        int cikanMotorin;
        int cikanMotorin2;
        int cikanGaz;
        int cikanFuel;
        public void veriCıkar()
        {
            if (textBox1.Text == null)
            {
                cikanBenzin = 1;
            }
            cikanBenzin = Convert.ToInt32(textBox1.Text);
            cikanMotorin = Convert.ToInt32(textBox2.Text);
            cikanMotorin2 = Convert.ToInt32(textBox3.Text);
            cikanGaz = Convert.ToInt32(textBox4.Text);
            cikanFuel = Convert.ToInt32(textBox5.Text);


            if (cikanBenzin != null && progressBar1.Value - cikanBenzin >=0 )
            {
                progressBar1.Value = progressBar1.Value - cikanBenzin;

            }

            else
            {
                MessageBox.Show("Benzin Deposun Boş");

            }

            if (progressBar2.Value - cikanMotorin >= 0)
            {
                progressBar2.Value = progressBar2.Value - cikanMotorin;

            }

            else
            {
                 MessageBox.Show("Motorin Ultra Deposu Boş");
            }

            if (progressBar3.Value - cikanMotorin2 >= 0)
            {
                progressBar3.Value = progressBar3.Value -cikanMotorin2;

            }

            else
            {
                MessageBox.Show("Motorin Eco Deposu Boş");
            }


            if (progressBar4.Value - cikanGaz >= 0)
            {
                progressBar4.Value = progressBar4.Value - cikanGaz;

            }

            else
            {
                  MessageBox.Show("Gazyağı Deposunda Yer Yok");
            }


            if (progressBar5.Value - cikanFuel >= 0)
            {
                progressBar5.Value = progressBar5.Value - cikanFuel;

            }

            else
            {
                // MessageBox.Show("Fuel Oil Eco Deposunda Yer Yok");
            }




        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            timer1.Start();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {


            if (islem == "EKLEME")
            {
                veriEkle();
            }
            if(islem=="CIKARMA")
            {
                veriCıkar();
            }
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";

            label3.Text = "%" + progressBar1.Value.ToString();
            label4.Text = "%" + progressBar2.Value.ToString();
            label5.Text = "%" + progressBar3.Value.ToString();
            label6.Text = "%" + progressBar4.Value.ToString();
            label7.Text = "%" + progressBar5.Value.ToString();

            progresBarColor();

            if (progressBar1.Value == 100 || progressBar2.Value == 100 || progressBar3.Value == 100 || progressBar4.Value == 100 || progressBar5.Value == 100)
            {
                MessageBox.Show("Depo FULL");
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "0")
            {
                textBox1.Text = "";

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "0";


            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "0")
            {
                textBox2.Text = "";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "0";

            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "0")
            {
                textBox3.Text = "";
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "0";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "0")
            {
                textBox4.Text = "";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "0";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "0")
            {
                textBox5.Text = "";
     
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "0";

            }
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;//panelleri görünmez yaptık
            panel7.Visible = false;
            Form6 form6 = new Form6();
            form6.MdiParent = this;
            form6.Show();

        }
        int x = 0;
        private void button8_Click(object sender, EventArgs e)
        {
            x += 1;
            if (x == 1)
            {
                Form4 form4 = new Form4();
                form4.Show();
                
                x = 0;
            }
            
        }
        string islem;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            islem = comboBox1.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel6.Visible = false;//panelleri görünmez yaptık
            panel7.Visible = false;
           
      
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}