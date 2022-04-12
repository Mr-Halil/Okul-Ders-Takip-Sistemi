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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }


        OleDbConnection bagla = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0; Data Source=" + Application.StartupPath + "\\DersProg.accdb");


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                
                OleDbCommand sil = new OleDbCommand("UPDATE ders_saat Set tarih='" + maskedTextBox1.Text + "',saat='"+maskedTextBox2.Text+"' where ders_id='" + comboBox1.Text + "'", bagla);
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();

                OleDbCommand ekle = new OleDbCommand("insert into ders_saat(ders_id,tarih,saat) values('" + comboBox1.Text + "','" + maskedTextBox1.Text + "','"+maskedTextBox2.Text+"')", bagla);
                ekle.ExecuteNonQuery();

                bagla.Close();

                listele();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
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

        private void listele()
        {
            try
            {
                bagla.Open();

                OleDbDataAdapter listele = new OleDbDataAdapter("Select * from ders_saat", bagla);
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();

                OleDbCommand sil = new OleDbCommand("Delete from ders_saat where ders_id='" + comboBox1.Text + "'", bagla);
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void listele2()
        {
            try
            {
                bagla.Open();
                OleDbCommand listele = new OleDbCommand("Select kod from ders", bagla);
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                bagla.Open();
                OleDbCommand listele = new OleDbCommand("Select * from ders_saat where ders_id='" + textBox3.Text + "'", bagla);
                OleDbDataReader reader = listele.ExecuteReader();

                while (reader.Read())
                {
                    if (reader[0].ToString() == textBox3.Text)
                    {
                        comboBox1.Text = reader[0].ToString();
                        maskedTextBox1.Text = reader[1].ToString();
                        maskedTextBox2.Text = reader[2].ToString();
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
