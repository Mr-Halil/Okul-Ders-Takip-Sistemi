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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        OleDbConnection bagla = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\DersProg.accdb");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();

                OleDbCommand ekle = new OleDbCommand("insert into sinif(sube,bolum_id) values('" + textBox1.Text + "','" + comboBox2.Text + "')", bagla);
                ekle.ExecuteNonQuery();

                bagla.Close();

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

        private void Form9_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void listele()
        {
            try
            {
                bagla.Open();

                OleDbDataAdapter listele = new OleDbDataAdapter("Select * from sinif", bagla);
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

                OleDbCommand sil = new OleDbCommand("UPDATE sinif Set bolum_id='" + comboBox2.Text + "' where sube='" + textBox1.Text + "'", bagla);
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

                OleDbCommand sil = new OleDbCommand("Delete from sinif where sube='" + textBox1.Text + "'", bagla);
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listele2()
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                OleDbCommand listele = new OleDbCommand("Select * from sinif where sube='" + textBox3.Text + "'", bagla);
                OleDbDataReader reader = listele.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[0].ToString() == textBox3.Text)
                    {
                        textBox1.Text = reader[0].ToString();
                        comboBox2.Text = reader[1].ToString();
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
