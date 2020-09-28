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
    class Interior
    {
        Model model = new Model();

        OracleConnection connn = Form1.conn;

        public DataTable GetInteriorRel(decimal mod, decimal inter) // Используется, чтобы получить предметы интерьера по модели и типу интерьера
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.GET_INT_REL";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("MODEL_ID", OracleDbType.Decimal).Value = mod;
            cmd.Parameters.Add("INT_ID", OracleDbType.Decimal).Value = inter;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public IList<string> IntSalonTables() // Получить список обивок салона в интерьере
        {
            List<string> tables = new List<string>();
            foreach (DataRow row in GetInteriorRel(model.ModChoice(), 1).Rows)
            {
                string tablename7 = (string)row[1];
                tables.Add(tablename7);
                Console.WriteLine(tablename7);
            }
            return tables;
        }

        public IList<string> IntPlankTables() //Получить список декоративных планок в интерьере
        {
            List<string> tables = new List<string>();
            foreach (DataRow row in GetInteriorRel(model.ModChoice(), 2).Rows)
            {
                string tablename8 = (string)row[1];
                tables.Add(tablename8);
                Console.WriteLine(tablename8);
            }
            return tables;
        }

        public decimal Int1Choice() // Используется для определения обивки салона в интерьере
        {
            foreach (DataRow row in GetInteriorRel(model.ModChoice(), 1).Rows)
            {
                string tablename = (string)row[1];
                if (Form2.selectedState6 == tablename)
                {
                    Form2.int1 = (decimal)row[0];
                }
            }
            if (Form2.int1 != 0)
            {
                return Form2.int1;
            }
            else
            {
                Form2.int1 = 1;
                return Form2.int1;
            }
        }

        public decimal Int2Choice() // Используется для определния декоративных планок в интерьере
        {
            foreach (DataRow row in GetInteriorRel(model.ModChoice(), 2).Rows)
            {
                string tablename = (string)row[1];
                if (Form2.selectedState7 == tablename)
                {
                    Form2.int2 = (decimal)row[0];
                }
            }
            if (Form2.int2 != 0)
            {
                return Form2.int2;
            }
            else
            {
                Form2.int2 = 1;
                return Form2.int2;
            }
        }
    }
}
