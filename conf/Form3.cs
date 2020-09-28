using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;

namespace conf
{
    public partial class Form3 : Form
    {
        OracleConnection connn;
        static public string selectedState1 { get; set; }
        static public string selectedState2 { get; set; }
        static public string selectedState3 { get; set; }
        static public string selectedState4 { get; set; }

        Developer developer = new Developer();

        public Form3()
        {
            InitializeComponent();
            connn = Form1.conn;

            IList<string> a;
            a = developer.Tables();

            IList<string> b;
            b = developer.TablesOrder();

            IList<string> c;
            c = developer.TablesLogs();

            comboBox1.Items.Clear();
            for (int i = 0; i < a.Count; i++)
                comboBox1.Items.Add(a[i]);

            comboBox2.Items.Clear();
            for (int i = 0; i < a.Count; i++)
                comboBox2.Items.Add(a[i]);

            comboBox3.Items.Clear();
            for (int i = 0; i < b.Count; i++)
                comboBox3.Items.Add(b[i]);

            comboBox4.Items.Clear();
            for (int i = 0; i < c.Count; i++)
                comboBox4.Items.Add(c[i]);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedState1 = comboBox1.SelectedItem.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.DataSource = developer.GetTables(selectedState1);
            }
            catch (OracleException)
            {
                MessageBox.Show("Выберите таблицу");
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                developer.DelOrd(selectedState1, dataGridView1.SelectedCells[0].OwningColumn.Name, dataGridView1.SelectedCells[0].Value.ToString());
                Console.WriteLine(dataGridView1.SelectedCells[0]);
                Console.WriteLine(dataGridView1.SelectedCells[0].OwningColumn.Name);
                Console.WriteLine(dataGridView1.SelectedCells[0].Value.ToString());
            }
            catch (OracleException exc)
            {
                string errorMessage = "Code: " + exc.ErrorCode + "\n" +
      "Message: " + exc.Message;
                MessageBox.Show(errorMessage);
                Console.WriteLine("An exception occurred. Please contact your system administrator.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                developer.UpdOrd(selectedState1, dataGridView1.CurrentCell.OwningColumn.Name, textBox1.Text, dataGridView1.SelectedCells[0].OwningColumn.Name, dataGridView1.SelectedCells[0].Value.ToString());
            }
            catch (OracleException exc)
            {
                string errorMessage = "Code: " + exc.ErrorCode + "\n" +
                      "Message: " + exc.Message;
                MessageBox.Show(errorMessage);
                Console.WriteLine("An exception occurred. Please contact your system administrator.");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label7_MouseMove(object sender, MouseEventArgs e)
        {
            label7.ForeColor = Color.Red;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Snow;
        }

        // Перемещение окна
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form3_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        OracleCommandBuilder commandBuilder;
        OracleDataAdapter adapter;
        DataSet ds;
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                adapter = new OracleDataAdapter("select * from " + selectedState2, connn);
                commandBuilder = new OracleCommandBuilder(adapter);
                //adapter.Fill(ds, selectedState2);

                adapter.Update(ds.Tables[selectedState2]);
            }
            catch (OracleException exc)
            {
                string errorMessage = "Code: " + exc.ErrorCode + "\n" +
                      "Message: " + exc.Message;
                MessageBox.Show(errorMessage);
                Console.WriteLine("An exception occurred. Please contact your system administrator.");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedState2 = comboBox2.SelectedItem.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                ds = new DataSet();
                adapter = new OracleDataAdapter("select * from " + selectedState2, connn);
                OracleCommandBuilder ob = new OracleCommandBuilder(adapter);
                adapter.Fill(ds, selectedState2);

                dataGridView2.DataSource = ds.Tables[selectedState2];
            }
            catch (OracleException)
            {
                MessageBox.Show("Выберите таблицу");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView3.DataSource = developer.GetTables(selectedState3);
            }
            catch (OracleException)
            {
                MessageBox.Show("Выберите таблицу");
            }
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedState3 = comboBox3.SelectedItem.ToString();
        }

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("Неверный формат данных, исправьте пожалуйста.");
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedState4 = comboBox4.SelectedItem.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView4.DataSource = developer.GetTables(selectedState4);
            }
            catch (OracleException)
            {
                MessageBox.Show("Выберите таблицу");
            }
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
