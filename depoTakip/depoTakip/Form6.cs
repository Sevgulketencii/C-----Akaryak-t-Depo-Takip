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
    public partial class Form6 : Form
    {
        
        public Form6()
        {

            InitializeComponent();
            verileriAl();
         
        }
        
        public static SqlConnection connect = new SqlConnection("Data Source=DESKTOP-KCH0A99; Initial Catalog=Test; Integrated Security=TRUE");

        public void verileriAl()
        {
            connect.Open();
            SqlCommand komut = new SqlCommand("Select * from depoLitre", connect);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
               
                chart1.Series["Aylar-Benzin"].Points.AddXY(oku["Ay"], oku["BenzinLitre"]);
                chart2.Series["Aylar-Mazot"].Points.AddXY(oku["Ay"], oku["MazotLitre"]);
                chart3.Series["Aylar-Gaz"].Points.AddXY(oku["Ay"], oku["GazLitre"]);
                chart4.Series["Aylar-Fuel"].Points.AddXY(oku["Ay"], oku["FuelLitre"]);
               
               
            }
            connect.Close();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
