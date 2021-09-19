using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace serialdr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DataAccess da = new DataAccess();
        DataTable dt = new DataTable();
        prop u = new prop();
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dt = da.Drdetailsall(u);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dt = da.Drdetailsall(u);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Fill All the Info");
            }
            else
            {

                u.Name = textBox1.Text;
                u.Room = textBox3.Text;
                u.PhoneNumber = textBox5.Text;
                u.Catagory = textBox4.Text;
               



                int w = da.Drupdate(u);
                if (w > 0)
                {
                    MessageBox.Show("updated");
                    dt = da.Drdetailsall(u);
                    dataGridView1.DataSource = dt;
                }

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please fill all the information");
            }
            else
            {
                u.Name = textBox1.Text;


                u.Room = textBox3.Text;
                u.PhoneNumber = textBox5.Text;
                u.Patient = "None";
                u.Catagory = textBox4.Text;


                int i = da.DocReg(u);
                if (i > 0)
                {
                    MessageBox.Show("Succesfully Created");
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == ""|| textBox3.Text == "")
            {
                MessageBox.Show("Insert Patient Name Or Select a Doctor");
            }
            else
            {

                u.Room = textBox3.Text;
               
                u.Patient = textBox2.Text;



                int w = da.Patientupdate(u);
                if (w > 0)
                {
                    MessageBox.Show("Patient Added");
                    dt = da.Drdetailsall(u);
                    dataGridView1.DataSource = dt;
                }

            }
        
    }

        private void button2_Click(object sender, EventArgs e)
        {
            u.Room = textBox3.Text;
            int i = da.Delete(u);
            if (i > 0)
            {
                MessageBox.Show("Deleted");

                dt = da.Drdetailsall(u);
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            label4.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();

        }
    }
}
