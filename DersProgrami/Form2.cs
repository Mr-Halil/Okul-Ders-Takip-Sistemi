using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DersProgrami
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 giris = new Form1();

            giris.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 okul = new Form3();
            this.Hide();
            okul.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 ogrenci = new Form6();
            this.Hide();
            ogrenci.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 ders_saat = new Form4();
            ders_saat.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 ders = new Form5();
            ders.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form7 ogretmen = new Form7();
            ogretmen.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 sinif = new Form9();
            sinif.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 bolum = new Form8();
            bolum.Show();
            this.Hide();
        }
    }
}
