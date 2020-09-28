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
    class Series
    {
        OracleConnection connn = Form1.conn;
        // Инициализация
        // Можно сделать GET_Series_All - он не будет принимать параметры и будет выводить всю таблицу (для разработчика)
        public DataTable GetSeries() // Используется, чтобы получить список серий.
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.GET_SERIES_1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Инициализация
        public IList<string> ListTables() // Получить список серий для заполнения.
        {
            List<string> tables = new List<string>();
            foreach (DataRow row in GetSeries().Rows)
            {
                string tablename = (string)row[1];
                //if (tablename == "BMW 1 серии")
                //{
                tables.Add(tablename);
                Console.WriteLine(tablename);
                //}
            }
            return tables;
        }

        // Button 3. Вкладка: Серия
        public decimal SerChoice() // Используется, чтобы получить выбранную серию из comboBox1. 
        {
            foreach (DataRow row in GetSeries().Rows)
            {
                string tablename1 = (string)row[1];
                if (Form2.selectedState == tablename1)
                {
                    Form2.sel = (decimal)row[0];
                }
            }
            if (Form2.sel != 0)
            {
                return Form2.sel;
            }
            else
            {
                Form2.sel = 1;
                return Form2.sel;
            }
        }
    }
}
