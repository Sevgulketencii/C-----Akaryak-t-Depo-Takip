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


namespace depoTakip
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection connection = Form1.connect;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.White;
                textBox2.PasswordChar = '*';

            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.Silver;
               
            }
        }

     
        private void textBox3_Enter_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "Replay Password")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.White;
                textBox3.PasswordChar = '*';

            }
        }

        private void textBox3_Leave_1(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Password";
                textBox3.ForeColor = Color.Silver;

            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "E-mail")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.White;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "E-mail";
                textBox4.ForeColor = Color.Silver;
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Gsm")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.White;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text == "")
            {
                textBox5.Text = "Gsm";
                textBox5.ForeColor = Color.Silver;
            }
        }
        bool move;
        int mouse_x;// form hareketi için gerekli değişkenleri tanımladık
        int mouse_y;
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }


        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {

            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            
            if (textBox2.Text == textBox3.Text)
            {
                connection.Open();
                SqlCommand komut = new SqlCommand("Insert into dbtest2 (username,pass,re_pass,e_mail,gsm) values('" + sifreleme.sifre(textBox1.Text, 2) + "','" + sifreleme.sifre(textBox2.Text, 2) + "','" + sifreleme.sifre(textBox3.Text, 2) + "','" + sifreleme.sifre(textBox4.Text, 2) + "','" + sifreleme.sifre(textBox5.Text, 2) + "')", connection);
                // eklenecek olan verileri sifreleme classından sifre metodunu çağırarak sifreleyerek sql veritabanına ekliyoruz.
                komut.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Kullanıcı Başarı ile kaydedildi");
                this.Hide();
                Form1 form = new Form1();
                form.Show();
            }
            else
            {
                MessageBox.Show("Parolalar Uyuşmuyor");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 form = new Form3();
            form.Show();
        }
    }
}
