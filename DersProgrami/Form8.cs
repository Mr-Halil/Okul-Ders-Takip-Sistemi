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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        OleDbConnection bagla = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\DersProg.accdb");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();

                OleDbCommand ekle = new OleDbCommand("insert into bolum(bolum_adi,sinif,ogrenci_id,ogretmen_id) values('" + textBox1.Text + "','" + comboBox2.Text + "','" + comboBox1.Text + "','" + comboBox3.Text + "')", bagla);
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

                OleDbDataAdapter listele = new OleDbDataAdapter("Select * from bolum", bagla);
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

        private void Form8_Load(object sender, EventArgs e)
        {
            listele();
            listele2();
            listele3();
            listele4();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();

                OleDbCommand sil = new OleDbCommand("UPDATE bolum Set sinif='" + comboBox2.Text + "',ogrenci_id='" + comboBox1.Text + "',ogretmen_id='" + comboBox3.Text + "' where bolum_adi='" + textBox1.Text + "'", bagla);
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

                OleDbCommand sil = new OleDbCommand("Delete from bolum where bolum_adi='" + textBox1.Text + "'", bagla);
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

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 anasayfa = new Form2();
            this.Close();
            anasayfa.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listele2()
        {
            try
            {
                bagla.Open();
                OleDbCommand listele = new OleDbCommand("Select Ad from ogrenci", bagla);
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
                OleDbCommand listele = new OleDbCommand("Select Ad from ogretmen", bagla);
                OleDbDataReader reader = listele.ExecuteReader();

                while (reader.Read())
                {
                    comboBox3.Items.Add(reader[0].ToString());
                }

                bagla.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void listele4()
        {
            try
            {
                bagla.Open();
                OleDbCommand listele = new OleDbCommand("Select sube from sinif", bagla);
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                OleDbCommand listele = new OleDbCommand("Select * from bolum where bolum_adi='" + textBox3.Text + "'", bagla);
                OleDbDataReader reader = listele.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[0].ToString() == textBox3.Text)
                    {
                        textBox1.Text = reader[0].ToString();
                        comboBox2.Text = reader[1].ToString();
                        comboBox1.Text = reader[2].ToString();
                        comboBox3.Text = reader[3].ToString();
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
