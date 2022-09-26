using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace depoTakip
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }


        private void textBox1_Enter_1(object sender, EventArgs e)
        {
             if (textBox1.Text == "Your verification code")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.White;
            }
        }

        private void textBox1_Leave_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Your verification code";
            }

        }
        int code;

        private void button1_Click(object sender, EventArgs e)
        {

           

            
            
                MessageBox.Show("Sms doğrulama hatası");
            


        }
    }
}
