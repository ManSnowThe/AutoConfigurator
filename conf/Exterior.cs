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
    class Exterior
    {
        Model model = new Model();

        OracleConnection connn = Form1.conn;
        public DataTable GetExteriorRel(decimal mod, decimal ext) // Используется, чтобы получить предметы экстерьера по модели и типу экстерьера
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.GET_EXT_REL";
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("MODEL_ID", OracleDbType.Decimal).Value = mod;
            cmd.Parameters.Add("EXT_ID", OracleDbType.Decimal).Value = ext;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public IList<string> ExtPaintTables() // Получить список окрасок кузова в экстерьере
        {
            List<string> tables = new List<string>();
            foreach (DataRow row in GetExteriorRel(model.ModChoice(), 1).Rows)
            {
                string tablename5 = (string)row[1];
                tables.Add(tablename5);
                Console.WriteLine(tablename5);
            }
            return tables;
        }

        public IList<string> ExtDiscTables() // Получить список дисков в экстерьере
        {
            List<string> tables = new List<string>();
            foreach (DataRow row in GetExteriorRel(model.ModChoice(), 2).Rows)
            {
                string tablename6 = (string)row[1];
                tables.Add(tablename6);
                Console.WriteLine(tablename6);
            }
            return tables;
        }

        public decimal Ext1Choice() // Используется для определения окраски кузова в экстерьере
        {
            foreach (DataRow row in GetExteriorRel(model.ModChoice(), 1).Rows)
            {
                string tablename = (string)row[1];
                if (Form2.selectedState4 == tablename)
                {
                    Form2.ext1 = (decimal)row[0];
                }
            }
            if (Form2.ext1 != 0)
            {
                return Form2.ext1;
            }
            else
            {
                Form2.ext1 = 1;
                return Form2.ext1;
            }
        }

        public decimal Ext2Choice() // Используется для определения дисков в экстерьере
        {
            foreach (DataRow row in GetExteriorRel(model.ModChoice(), 2).Rows)
            {
                string tablename = (string)row[1];
                if (Form2.selectedState5 == tablename)
                {
                    Form2.ext2 = (decimal)row[0];
                }
            }
            if (Form2.ext2 != 0)
            {
                return Form2.ext2;
            }
            else
            {
                Form2.ext2 = 1;
                return Form2.ext2;
            }
        }
    }
}
