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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


       public static SqlConnection connect = new SqlConnection("Data Source=DESKTOP-KCH0A99; Initial Catalog=Test; Integrated Security=TRUE");// SQL BAĞLANTI NESNEMİZ VE ADRESİ public static yapıyoruz ki diğer formlarda form1 üzerinden erişelim


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        bool move;
        int mouse_x;// form hareketi için gerekli değişkenleri tanımladık
        int mouse_y;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            move = true;
            mouse_x = e.X;
            mouse_y = e.Y;
        }


        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            move = false;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {

            if (move)
            {
                this.SetDesktopLocation(MousePosition.X - mouse_x, MousePosition.Y - mouse_y);

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)// textbox.1 açıldığında içinde username ve tıklandığında içinde yazanın boşaltılması için 
        {                                                      // actiondan enter ve leave metodları çağırıldı
            if (textBox1.Text == "Username")
            {
                textBox1.Text = "";
            }

        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Username";
            }
        }

        char? none=null;
        
        private void textBox2_Enter(object sender, EventArgs e) // textbox.2 açıldığında içinde username ve tıklandığında içinde yazanın boşaltılması için 
        {                                                       // actiondan enter ve leave metodları çağırıldı
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Silver;
                textBox2.PasswordChar = '*';
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.Silver;
                textBox2.PasswordChar = Convert.ToChar(none);


            }
        }
        bool isThere = false; // sql tarafından okunan veri uyuşuyormu diye evet ya da hayır döndüren bool değişkeni tanımlandı
        private void button2_Click(object sender, EventArgs e)
        {
            String username=textBox1.Text;
            String password=textBox2.Text;

            connect.Open();
            SqlCommand komut = new SqlCommand("Select * from dbtest2", connect);// sqlcommand'dan komut nesnesi tanımlanıp bağlanması gereken db ismi yazıldı
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                if (username == sifreleme.sifreCöz(oku["username"].ToString().TrimEnd(),2) && password==sifreleme.sifreCöz(oku["pass"].ToString().TrimEnd(),2)) // eğer oluşturulan stringler sql'deki username ve pass ile uyuşuyorsa bool değişkeni true ile değiştirildi ve döngü kırıldı
                {
                    isThere = true;             // sifreleme classından sifrecöz metodu ile sqldeki verileri çözerek kıyaslıyoruz 
                    break;
                }
                else
                {
                    isThere = false;
                }

            }

            connect.Close();// kullanıcı hatalı girdiğinde düzeltip tekrar giriş yapması gerekiyor açık olan db kapatıldı çünkü tetiklendiğinde db açılıyor

            if (isThere == true)
            {
                //MessageBox.Show("Giriş Yapıldı","Depo Takip");// Giriş sağlandıysa Kullanıcıya message box gösteri  lir.
                this.Hide();
                Form4 form = new Form4();
                
                form.Show();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı Adı veya Şifre","Depo Takip");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
