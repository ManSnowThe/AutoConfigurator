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
using System.IO;
using ExcelObj = Microsoft.Office.Interop.Excel;

namespace conf
{
    public partial class Form2 : Form
    {
        DataSet ds = new DataSet();

        OracleConnection connn;
        static public string selectedState { get; set; }
        static public string selectedState2 { get; set; }
        static public string selectedState3 { get; set; }
        static public string selectedState4 { get; set; }
        static public string selectedState5 { get; set; }
        static public string selectedState6 { get; set; }
        static public string selectedState7 { get; set; }
        static public string selectedState8 { get; set; }
        static public string selectedState9 { get; set; }

        static public decimal sel { get; set; }
        static public decimal modd { get; set; }
        static public decimal optt { get; set; }
        static public decimal ext1 { get; set; }
        static public decimal ext2 { get; set; }
        static public decimal int1 { get; set; }
        static public decimal int2 { get; set; }
        static public decimal opt1 { get; set; }
        static public decimal opt2 { get; set; }

        static public decimal clientt { get; set; }

        Series series = new Series();
        Model model = new Model();
        Exterior exterior = new Exterior();
        Interior interior = new Interior();
        Options options = new Options();
        Order order = new Order();
        Info info = new Info();
        RecomSystem recom = new RecomSystem();

        public Form2()
        {
            InitializeComponent();
            connn = Form1.conn;
            clientt = Form1.cliente;

            // Инициализация
            dataGridView1.DataSource = series.GetSeries();
            IList<string> a;
            a = series.ListTables();

            comboBox1.Items.Clear();
            for (int i = 0; i < a.Count; i++)
                comboBox1.Items.Add(a[i]);

            textBox4.Text = "Наши клиенты чаще всего выбирают: " + recom.RecommendSeries().ToString();

            button3.Enabled = true;
            comboBox1.Enabled = true;
        }

        // Button 3. Вкладка: Серия
        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedState != null)
            {
                dataGridView2.DataSource = model.GetModel(series.SerChoice());
                IList<string> a;
                a = model.ModelTables();

                comboBox2.Items.Clear();
                for (int i = 0; i < a.Count; i++)
                    comboBox2.Items.Add(a[i]);

                order.InsOrd(1, series.SerChoice());

                button3.Enabled = false;
                tabControl1.SelectTab(tabPage2);

                button2.Enabled = true;

                comboBox1.Enabled = false;
                comboBox2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Выберите все пункты");
            }

            // Удалить для корректной работы
            try
            {
                pictureBox1.Image = Info.ByteToImage(info.ImageSeries());
            }
            catch (Exception)
            {
                //pictureBox1.Image = Image.FromFile("bmw.png");
                pictureBox1.Image = Properties.Resources.bmw;

            }

            textBox1.Text = "Наши клиенты чаще всего выбирают: " + recom.RecommendModel().ToString();
        }

        // Button 2. Вкладка: Модель
        private void button2_Click(object sender, EventArgs e) // После выбора модели заполняются окна интерьера, экстерьера и опций.
        {
            if (selectedState2 != null)
            {
                dataGridView3.DataSource = exterior.GetExteriorRel(model.ModChoice(), 1);
                dataGridView4.DataSource = exterior.GetExteriorRel(model.ModChoice(), 2);
                dataGridView5.DataSource = interior.GetInteriorRel(model.ModChoice(), 1);
                dataGridView6.DataSource = interior.GetInteriorRel(model.ModChoice(), 2);

                IList<string> a;
                IList<string> b;
                IList<string> c;
                IList<string> d;
                IList<string> ee;

                a = exterior.ExtPaintTables();
                comboBox3.Items.Clear();
                for (int i = 0; i < a.Count; i++)
                    comboBox3.Items.Add(a[i]);

                b = exterior.ExtDiscTables();
                comboBox4.Items.Clear();
                for (int i = 0; i < b.Count; i++)
                    comboBox4.Items.Add(b[i]);

                c = interior.IntSalonTables();
                comboBox5.Items.Clear();
                for (int i = 0; i < c.Count; i++)
                    comboBox5.Items.Add(c[i]);

                d = interior.IntPlankTables();
                comboBox6.Items.Clear();
                for (int i = 0; i < d.Count; i++)
                    comboBox6.Items.Add(d[i]);

                ee = options.OptTypeTables();
                comboBox7.Items.Clear();
                checkedListBox1.Items.Clear();
                listBox2.Items.Clear();
                for (int i = 0; i < ee.Count; i++)
                {
                    comboBox7.Items.Add(ee[i]);
                    checkedListBox1.Items.Add(ee[i]);
                    listBox2.Items.Add(ee[i]);
                }

                order.InsOrd(2, model.ModChoice());

                button2.Enabled = false;
                tabControl1.SelectTab(tabPage3);

                button1.Enabled = true;

                comboBox2.Enabled = false;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
            }
            else
            {
                MessageBox.Show("Выберите все пункты");
            }

            // Удалить для корректной работы
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            try
            {
                pictureBox2.Image = Info.ByteToImage(info.ImageModel());
            }
            catch (Exception)
            {
                //pictureBox2.Image = Image.FromFile("bmw.png");
                pictureBox2.Image = Properties.Resources.bmw;
            }

            textBox18.Text = "Наши клиенты чаще всего выбирают: " + recom.RecommendExterior().ToString();
            textBox19.Text = "Наши клиенты чаще всего выбирают: " + recom.RecommendInterior().ToString();
        }

        // Вкладка Модель
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedState2 = comboBox2.SelectedItem.ToString();
            }
            catch (NullReferenceException)
            {
                selectedState2 = " ";
            }

            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            try
            {
                pictureBox2.Image = Info.ByteToImage(info.ImageModel());
            }
            catch (Exception)
            {
                //pictureBox2.Image = Image.FromFile("bmw.png");
                pictureBox2.Image = Properties.Resources.bmw;
            }

            richTextBox1.Text = info.SpecModel();

            textBox2.Text = info.PriceModel().ToString();
            textBox3.Text = info.NameModel();
        }

        // Вкладка Серия
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedState = comboBox1.SelectedItem.ToString();
            }
            catch (NullReferenceException)
            {
                selectedState = " ";
            }

            try
            {
                pictureBox1.Image = Info.ByteToImage(info.ImageSeries());
            }
            catch (Exception)
            {
                //pictureBox1.Image = Image.FromFile("bmw.png");
                pictureBox1.Image = Properties.Resources.bmw;
            }

            textBox5.Text = info.NameSeries();
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e) // Добавляет данные из выделенного элемента в comboBox8.
        {
            selectedState3 = comboBox7.SelectedItem.ToString();
            IList<string> f;

            f = options.OptionTables();
            checkedListBox2.Items.Clear();

            comboBox8.Items.Clear();

            for (int i = 0; i < f.Count; i++)
            {
                checkedListBox2.Items.Add(f[i]);

                comboBox8.Items.Add(f[i]);
            }
        }


        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e) // Добавляет данные из выделенного элемента в checkedListBox2.
        {
            selectedState3 = checkedListBox1.SelectedItem.ToString();
            IList<string> f;

            f = options.OptionTables();

            checkedListBox2.Items.Clear();
            comboBox8.Items.Clear();

            for (int i = 0; i < f.Count; i++)
            {
                checkedListBox2.Items.Add(f[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e) // Добавляет экстерьер в таблицу
        {
            if (selectedState4 != null && selectedState5 != null)
            {
                order.InsOrd(3, exterior.Ext1Choice());
                order.InsOrd(3, exterior.Ext2Choice());

                button1.Enabled = false;
                tabControl1.SelectTab(tabPage4);

                button4.Enabled = true;

                comboBox3.Enabled = false;
                comboBox4.Enabled = false;
                comboBox5.Enabled = true;
                comboBox6.Enabled = true;
            }
            else
            {
                MessageBox.Show("Выберите все пункты");
            }
           
            try
            {
                pictureBox3.Image = Info.ByteToImage(info.ImageExterior(1));
                pictureBox4.Image = Info.ByteToImage(info.ImageExterior(2));
            }
            catch (Exception)
            {
                //pictureBox3.Image = Image.FromFile("bmw.png");
                //pictureBox4.Image = Image.FromFile("bmw.png");
                pictureBox3.Image = Properties.Resources.bmw;
                pictureBox4.Image = Properties.Resources.bmw;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedState4 = comboBox3.SelectedItem.ToString();
            }
            catch (NullReferenceException)
            {
                selectedState4 = " ";
            }

            try
            {
                pictureBox3.Image = Info.ByteToImage(info.ImageExterior(1));
            }
            catch (Exception)
            {
                //pictureBox3.Image = Image.FromFile("bmw.png");
                pictureBox3.Image = Properties.Resources.bmw;
            }
            textBox6.Text = info.NameExter(1);
            try
            {
                textBox7.Text = info.SpecExter(1);
            }
            catch (Exception)
            {
                textBox7.Text = " ";
            }
            textBox8.Text = info.PriceExter(1).ToString();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedState5 = comboBox4.SelectedItem.ToString();
            }
            catch (NullReferenceException)
            {
                selectedState5 = " ";
            }

            try
            {
                pictureBox4.Image = Info.ByteToImage(info.ImageExterior(2));
            }
            catch (Exception)
            {
                //pictureBox4.Image = Image.FromFile("bmw.png");
                pictureBox4.Image = Properties.Resources.bmw;
            }

            textBox9.Text = info.NameExter(2);
            try
            {
                textBox10.Text = info.SpecExter(2);
            }
            catch
            {
                textBox10.Text = " ";
            }
            textBox11.Text = info.PriceExter(2).ToString();
        }

        private void button4_Click(object sender, EventArgs e) // Добавляет интерьер в таблицу
        {
            if (selectedState6 != null && selectedState7 != null)
            {
                order.InsOrd(4, interior.Int1Choice());
                order.InsOrd(4, interior.Int2Choice());

                button4.Enabled = false;
                tabControl1.SelectTab(tabPage5);

                button5.Enabled = true;

                comboBox5.Enabled = false;
                comboBox6.Enabled = false;
                button7.Enabled = true;
                button8.Enabled = true;
            }
            else
            {
                MessageBox.Show("Выберите все пункты");
            }

            try
            {
                pictureBox5.Image = Info.ByteToImage(info.ImageInterior(1));
                pictureBox6.Image = Info.ByteToImage(info.ImageInterior(2));
            }
            catch (Exception)
            {
                //pictureBox5.Image = Image.FromFile("bmw.png");
                //pictureBox6.Image = Image.FromFile("bmw.png");
                pictureBox5.Image = Properties.Resources.bmw;
                pictureBox6.Image = Properties.Resources.bmw;
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedState6 = comboBox5.SelectedItem.ToString();
            }
            catch (NullReferenceException)
            {
                selectedState6 = " ";
            }

            try
            {
                pictureBox5.Image = Info.ByteToImage(info.ImageInterior(1));
            }
            catch (Exception)
            {
                //pictureBox5.Image = Image.FromFile("bmw.png");
                pictureBox5.Image = Properties.Resources.bmw;
            }

            textBox17.Text = info.NameInter(1);
            textBox16.Text = info.SpecInter(1);
            textBox15.Text = info.PriceInter(1).ToString();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedState7 = comboBox6.SelectedItem.ToString();
            }
            catch (NullReferenceException)
            {
                selectedState7 = " ";
            }

            try
            {
                pictureBox6.Image = Info.ByteToImage(info.ImageInterior(2));
            }
            catch (Exception)
            {
                //pictureBox6.Image = Image.FromFile("bmw.png");
                pictureBox6.Image = Properties.Resources.bmw;
            }

            textBox14.Text = info.NameInter(2);
            textBox13.Text = info.SpecInter(2);
            textBox12.Text = info.PriceInter(2).ToString();
        }

        private void button5_Click(object sender, EventArgs e) // Добавляет опции в таблицу conf_order_auto.
        {
            //InsOrd(5, Opt1Choice());
            for (int d = 0; d < listBox1.Items.Count; d++)
            {
                order.InsOrd(5, Opt2Choice(d));
            }

            button5.Enabled = false;
            tabControl1.SelectTab(tabPage6);

            button6.Enabled = true;
            button7.Enabled = false;
            button8.Enabled = false;

            dataGridView7.DataSource = order.GetOrder();

            textBox23.Text = info.NameSeries();
            textBox24.Text = info.NameModel();
            textBox25.Text = info.NameExter(1);
            textBox26.Text = info.NameExter(2);
            textBox27.Text = info.NameInter(1);
            textBox28.Text = info.NameInter(2);

            foreach (var item in listBox1.Items)
                listBox4.Items.Add(item);

            try
            {
                pictureBox8.Image = Info.ByteToImage(info.ImageModel());
            }
            catch (Exception)
            {
                //pictureBox8.Image = Image.FromFile("bmw.png");
                pictureBox8.Image = Properties.Resources.bmw;
            }

            textBox29.Text = Convert.ToString(Convert.ToDecimal(textBox2.Text) + Convert.ToDecimal(textBox8.Text) + Convert.ToDecimal(textBox11.Text) + Convert.ToDecimal(textBox15.Text)
                + Convert.ToDecimal(textBox12.Text) + Convert.ToDecimal(PriceOption2()));
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedState8 = comboBox8.SelectedItem.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В данный момент функция заказа недоступна.\nФайл с вашими конфигурациями сохранен на компьютере.\nОбратитесь с ним к нашему официальному диллеру.");
            SaveTable(dataGridView7);
            this.Close();
        }

        //Сохранить в excel
        public void SaveTable(DataGridView dgw)
        {
            string path = System.IO.Directory.GetCurrentDirectory() + @"\" + "Configuration.xlsx";

            ExcelObj.Application excelapp = new ExcelObj.Application();
            ExcelObj.Workbook workbook = excelapp.Workbooks.Add();
            ExcelObj.Worksheet worksheet = workbook.ActiveSheet;

            for(int i = 1; i < dgw.RowCount + 1; i++)
            {
                for(int j = 1; j < dgw.ColumnCount + 1; j++)
                {
                    worksheet.Rows[1].Columns[j] = dgw.Columns[j-1].Name;
                    worksheet.Rows[i + 1].Columns[j] = dgw.Rows[i - 1].Cells[j - 1].Value;
                    
                }
            }

            worksheet.Rows[1].Columns[11] = "Цена(Т): " + textBox29.Text;
            worksheet.Rows[2].Columns[11] = textBox23.Text;
            worksheet.Rows[3].Columns[11] = textBox24.Text;
            worksheet.Rows[4].Columns[11] = textBox25.Text;
            worksheet.Rows[5].Columns[11] = textBox26.Text;
            worksheet.Rows[6].Columns[11] = textBox27.Text;
            worksheet.Rows[7].Columns[11] = textBox28.Text;

            for (int i = 0; i < listBox4.Items.Count; i++)
                worksheet.Rows[8 + i].Columns[11] = listBox4.Items[i].ToString();

            excelapp.AlertBeforeOverwriting = false;
            workbook.SaveAs(path);
            excelapp.Quit();
        }

        public double PriceOpt2 { get; set; }
        // Для подсчета суммы всех опций
        public double PriceOption2()
        {
            foreach (DataRow row in options.GetOpt2(model.ModChoice()).Rows)
            {
                string tablename = (string)row[1];
                foreach (string item in listBox4.Items)
                {
                    if (item == tablename)
                    {
                        PriceOpt2 += (double)row[4];
                    }
                }
            }
            return PriceOpt2;
        }


        private void button7_Click(object sender, EventArgs e)
        {
            foreach (string s in checkedListBox2.CheckedItems) 
            {
                if (!listBox1.Items.Contains(s))
                {
                    listBox1.Items.Add(s);
                }
            }

            foreach (string s in listBox3.SelectedItems)
            {
                if (!listBox1.Items.Contains(s))
                {
                    listBox1.Items.Add(s);
                }
            }
        }

        public decimal Opt2Choice(int d) // Используется, чтобы брать все опции из listBox1 и заносить в таблицу. 
        {
            foreach (DataRow row in options.GetOpt2(model.ModChoice()).Rows)
            {
                string tablename = (string)row[1];
                for (int i = d; i < d + 1; i++)
                {
                    if ((string)listBox1.Items[d] == tablename)
                    {
                        opt2 = (decimal)row[0];
                    }
                }
            }
            return opt2;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            order.DelOrd(clientt);

            button2.Enabled = false;
            button1.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;

            comboBox2.Enabled = false;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            comboBox5.Enabled = false;
            comboBox6.Enabled = false;

            button7.Enabled = false;
            button8.Enabled = false;

            button3.Enabled = true;
            comboBox1.Enabled = true;

            tabControl1.SelectTab(tabPage1);

            listBox4.Items.Clear();
            textBox23.Clear();
            textBox24.Clear();
            textBox25.Clear();
            textBox26.Clear();
            textBox27.Clear();
            textBox28.Clear();
            textBox29.Clear();

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //DelOrd(clientt, 1);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            order.DelOrd(clientt, 1);
            this.Close();
        }

        // Перемещение окна.
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        // Подцветка кнопки выхода.
        private void label7_MouseMove(object sender, MouseEventArgs e)
        {
            label7.ForeColor = Color.Red;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Snow;
        }
// Continue

        private void label25_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пасхальное яйцо");
        }

        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedState3 = listBox2.SelectedItem.ToString();
            IList<string> f;

            f = options.OptionTables();
            checkedListBox2.Items.Clear();

            comboBox8.Items.Clear();

            listBox3.Items.Clear();

            /*checkedListBox2.Items.Add(selectedState3);
            int index = checkedListBox2.Items.IndexOf(selectedState3);
            checkedListBox2.SetItemCheckState(index, CheckState.Indeterminate);*/

            for (int i = 0; i < f.Count; i++)
            {
                checkedListBox2.Items.Add(f[i]);

                comboBox8.Items.Add(f[i]);

                listBox3.Items.Add(f[i]);
            }

        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                selectedState9 = listBox3.SelectedItem.ToString();
            }
            catch (NullReferenceException)
            {
                //Вставить что-нибудь
                selectedState9 = " ";
            }
            try
            {
                pictureBox7.Image = Info.ByteToImage(info.ImageOption());
            }
            catch (Exception)
            {
                //pictureBox7.Image = Image.FromFile("optPic.jpg");
                pictureBox7.Image = Properties.Resources.optPic;
            }

            textBox20.Text = info.NameOption();
            try
            {
                textBox21.Text = info.SpecOption();
            }
            catch (Exception)
            {
                textBox21.Text = " ";
                textBox22.Text = " ";
            }
            textBox22.Text = info.PriceOption().ToString();
        }

        private void label34_Click(object sender, EventArgs e)
        {

        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label11_MouseEnter(object sender, EventArgs e)
        {
            label11.ForeColor = Color.Red;
        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            label11.ForeColor = Color.Snow;
        }

        private void label26_MouseEnter(object sender, EventArgs e)
        {
            label26.ForeColor = Color.Red;
        }

        private void label26_MouseLeave(object sender, EventArgs e)
        {
            label26.ForeColor = Color.Snow;
        }

        private void label27_MouseEnter(object sender, EventArgs e)
        {
            label27.ForeColor = Color.Red;
        }

        private void label27_MouseLeave(object sender, EventArgs e)
        {
            label27.ForeColor = Color.Snow;
        }

        private void label12_MouseEnter(object sender, EventArgs e)
        {
            label12.ForeColor = Color.Red;
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            label12.ForeColor = Color.Snow;
        }
    }
}
