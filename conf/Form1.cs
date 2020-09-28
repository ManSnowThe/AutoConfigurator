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
    public partial class Form1 : Form
    {
        LoginPass LogPas = new LoginPass();

        public Form1()
        {
            InitializeComponent();
        }

        public static OracleConnection conn;
        //readonly public string oradb = "User Id = student; Password = 123999; Data Source = localhost/orcl";
        public static decimal cliente;

        private void button1_Click(object sender, EventArgs e)
        {
            //string oradb = "User Id = student; Password = 1; Data Source = 10.8.26.22:1521/bittl";
            try
            {
                if (LogCheck(1)) // Логин для разработчика
                {
                    conn = new OracleConnection(LogPas.oradb);
                    conn.Open();
                    Console.WriteLine("Connected to Oracle " + conn.ServerVersion);
                    Form3 form = new Form3();
                    form.Show();
                }

                else if (LogCheck(2)) // Логин для пользователя
                {
                    LogPas.InsClientOrd(2);
                    cliente = LogPas.OrdId();
                    Console.WriteLine(cliente);
                    conn = new OracleConnection(LogPas.oradb);
                    conn.Open();
                    Console.WriteLine("Connected to Oracle " + conn.ServerVersion);
                    Form2 form = new Form2();
                    form.Show();
                }
                else
                {
                    textBox3.Text = "Неверный логин или пароль";
                }
            }
            catch (OracleException)
            {
                MessageBox.Show("Произошла ошибка на стороне сервера.");
            }
        }


        public bool LogCheck(decimal logg)
        {
            foreach (DataRow row in LogPas.Login(textBox1.Text.ToString(), textBox2.Text.ToString()).Rows)
            {
                if (logg == (decimal)row[0])
                    return true;
            }
            return false;
        }

        // Перемещение окна
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.ExitThread();
        }

        private void label6_MouseMove(object sender, MouseEventArgs e)
        {
            label6.ForeColor = Color.Red;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Snow;
        }

        private void label27_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Данное программное обеспечение сделано\n" +
                "в рамках дипломного проекта.\n" +
                "Ильин Александр, ВТ-16-4, ФИТ, КарГТУ 2020.");
        }

        private void label27_MouseEnter(object sender, EventArgs e)
        {
            label27.ForeColor = Color.Red;
        }

        private void label27_MouseLeave(object sender, EventArgs e)
        {
            label27.ForeColor = Color.Snow;
        }
    }
}
