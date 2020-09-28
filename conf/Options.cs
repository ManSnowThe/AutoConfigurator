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

namespace conf
{
    class Options
    {
        Model model = new Model();

        OracleConnection connn = Form1.conn;

        public DataTable GetTypeName() // Получить имя типа опции
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.GET_OPT_TYPE";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public IList<string> OptTypeTables() // Список типов опций
        {
            List<string> tables = new List<string>();
            foreach (DataRow row in GetTypeName().Rows)
            {
                string tablename9 = (string)row[1];
                tables.Add(tablename9);
                Console.WriteLine(tablename9);
            }
            return tables;
        }

        public DataTable GetOpt(decimal mod, decimal opt) // Используется, чтобы получить опции по модели и типу
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.GET_OPT_REL";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("MODEL_ID", OracleDbType.Decimal).Value = mod;
            cmd.Parameters.Add("OPT_ID", OracleDbType.Decimal).Value = opt;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public decimal OptChoice() // Используется для определения типа опции.
        {
            foreach (DataRow row in GetTypeName().Rows)
            {
                string tablename10 = (string)row[1];
                if (Form2.selectedState3 == tablename10)
                {
                    Form2.optt = (decimal)row[0];
                }
            }
            return Form2.optt;
        }
        public IList<string> OptionTables() // Используется для заполнения checkedListBox2 на основе выбранной модели и типа опции(checkedListBox1)
        {
            List<string> tables = new List<string>();
            foreach (DataRow row in GetOpt(model.ModChoice(), OptChoice()).Rows)
            {
                string tablename11 = (string)row[1];
                tables.Add(tablename11);
                Console.WriteLine(tablename11);
            }
            return tables;
        }

        public decimal Opt1Choice() // Нигде не используется. Использовался для comboBox8.
        {
            foreach (DataRow row in GetOpt(model.ModChoice(), OptChoice()).Rows)
            {
                string tablename = (string)row[1];
                if (Form2.selectedState8 == tablename)
                {
                    Form2.opt1 = (decimal)row[0];
                }
            }
            return Form2.opt1;
        }

        public DataTable GetOpt2(decimal mod) // Используется в Opt2Choice(int d).
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.GET_OPT_REL";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("MODEL_ID", OracleDbType.Decimal).Value = mod;
            cmd.Parameters.Add("OPT_ID", OracleDbType.Decimal).Value = null;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


    }
}
