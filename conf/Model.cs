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
    class Model
    {
        Series series = new Series();

        OracleConnection connn = Form1.conn;
        // Инициализация
        public DataTable GetModel(decimal ser) // Используется, чтобы получить список моделей по выбранной серии.
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.GET_MODEL_1";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SER_ID", OracleDbType.Decimal).Value = ser;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        // Button 3. Вкладка: Серия
        public IList<string> ModelTables() // Получить список моделей
        {
            List<string> tables = new List<string>();
            foreach (DataRow row in GetModel(series.SerChoice()).Rows)
            {
                string tablename3 = (string)row[1];
                tables.Add(tablename3);
                Console.WriteLine(tablename3);
            }
            return tables;
        }

        public decimal ModChoice() // Используется, чтобы получить выбранную модель из comboBox2
        {
            foreach (DataRow row in GetModel(series.SerChoice()).Rows)
            {
                string tablename4 = (string)row[1];
                if (Form2.selectedState2 == tablename4)
                {
                    Form2.modd = (decimal)row[0];
                }
            }
            if (Form2.modd != 0)
            {
                return Form2.modd;
            }
            else
            {
                Form2.modd = 1;
                return Form2.modd;
            }
        }
    }
}
