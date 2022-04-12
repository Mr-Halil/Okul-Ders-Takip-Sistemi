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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        OleDbConnection bagla = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\DersProg.accdb");


        private void Form6_Load(object sender, EventArgs e)
        {
            listele();
            listele2();
            listele3();
        }

        private void listele()
        {
            try
            {
                bagla.Open();

                OleDbDataAdapter listele = new OleDbDataAdapter("Select * from ogrenci", bagla);
                DataSet ds = new DataSet();
                listele.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

                bagla.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 anasayfa = new Form2();
            this.Close();
            anasayfa.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();

                OleDbCommand ekle = new OleDbCommand("insert into ogrenci(Ad,Soyad,Tc,Dyeri,Ders_id,Bolum_id) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox5.Text + "','"+textBox4.Text+"','"+comboBox1.Text+"','"+comboBox2.Text+"')", bagla);
                ekle.ExecuteNonQuery();

                bagla.Close();

                listele();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();

                OleDbCommand sil = new OleDbCommand("update ogrenci Set Ad='" + textBox1.Text + "',Soyad='"+textBox2.Text+"',Dyeri='"+textBox4.Text+"',Ders_id='"+comboBox1.Text+"',Bolum_id='"+comboBox2.Text+"' where Tc='" + textBox5.Text + "'", bagla);
                sil.ExecuteNonQuery();

                bagla.Close();

                MessageBox.Show("Güncellendi");

                listele();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();

                OleDbCommand sil = new OleDbCommand("Delete from ogrenci where Tc='" + textBox5.Text + "'", bagla);
                sil.ExecuteNonQuery();

                bagla.Close();

                MessageBox.Show("Silindi");

                listele();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void listele2()
        {
            try
            {
                bagla.Open();
                OleDbCommand listele = new OleDbCommand("Select Kod from ders", bagla);
                OleDbDataReader reader = listele.ExecuteReader();

                while (reader.Read())
                {
                    comboBox1.Items.Add(reader[0].ToString());
                }

                bagla.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void listele3()
        {
            try
            {
                bagla.Open();
                OleDbCommand listele = new OleDbCommand("Select bolum_adi from bolum", bagla);
                OleDbDataReader reader = listele.ExecuteReader();

                while (reader.Read())
                {
                    comboBox2.Items.Add(reader[0].ToString());
                }

                bagla.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                OleDbCommand listele = new OleDbCommand("Select * from ogrenci where Tc='"+textBox3.Text+"'", bagla);
                OleDbDataReader reader = listele.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[2].ToString() == textBox3.Text)
                    {
                        textBox1.Text = reader[0].ToString();
                        textBox2.Text = reader[1].ToString();
                        textBox5.Text = reader[2].ToString();
                        textBox4.Text = reader[3].ToString();
                    }
                }

                bagla.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
