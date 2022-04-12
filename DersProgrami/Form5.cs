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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        OleDbConnection bagla = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\DersProg.accdb");

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                OleDbCommand listele = new OleDbCommand("Select * from ders where ad='" + textBox3.Text + "'", bagla);
                OleDbDataReader reader = listele.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[0].ToString() == textBox3.Text)
                    {
                        textBox1.Text = reader[0].ToString();
                        textBox2.Text = reader[1].ToString();
                        comboBox1.Text = reader[2].ToString();
                    }
                }

                bagla.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();

                OleDbCommand ekle = new OleDbCommand("insert into ders(ad,Kod,id) values('" + textBox1.Text + "','" + textBox2.Text + "','"+comboBox1.Text+"')", bagla);
                ekle.ExecuteNonQuery();

                bagla.Close();

                listele();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void listele()
        {
            try
            {
                bagla.Open();

                OleDbDataAdapter listele = new OleDbDataAdapter("Select * from ders", bagla);
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();

                OleDbCommand sil = new OleDbCommand("UPDATE ders Set id='" + comboBox1.Text + "', Ad='"+textBox1.Text+"' where Kod='" + textBox2.Text + "'", bagla);
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

                OleDbCommand sil = new OleDbCommand("Delete from ders where Kod='" + textBox2.Text + "'", bagla);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            listele();
            listele2();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 anasayfa = new Form2();
            this.Close();
            anasayfa.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void listele2()
        {
            try
            {
                bagla.Open();
                OleDbCommand listele = new OleDbCommand("Select Sinif_id from okul", bagla);
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
    }
}
