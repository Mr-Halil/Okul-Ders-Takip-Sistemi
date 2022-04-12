using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DersProgrami
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection bagla = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source="+Application.StartupPath+"\\DersProg.accdb");

        private void button1_Click(object sender, EventArgs e)
        {
            string ad = textBox1.Text;
            string sifre = maskedTextBox1.Text;

            try
            {
                bagla.Open();

                OleDbCommand Ara = new OleDbCommand("Select * from Giris",bagla);
                OleDbDataReader arama = Ara.ExecuteReader();

                while (arama.Read())
                {
                    if (arama[0].ToString() == ad && arama[1].ToString() == sifre)
                    {
                        Form2 anasayfa = new Form2();
                        MessageBox.Show("Giriş Başarılı...");
                        anasayfa.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Hatalı");

                    }
                }

                bagla.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form10 hakkinda = new Form10();
            hakkinda.Show();
            this.Hide();
        }
    }
}
