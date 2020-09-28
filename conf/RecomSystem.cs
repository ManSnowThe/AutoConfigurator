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
    class RecomSystem
    {
        Series series = new Series();
        Model model = new Model();

        OracleConnection connn = Form1.conn;

        // Для рекоммендаций в моделях ////////////////////////////////////////////////////////////////////
        public DataTable GetModCount()
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.GET_ORDER_AUTO_COUNT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetModel2(decimal mod) // Используется, чтобы получить список моделей по выбранной серии.
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.GET_MODEL_2";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("MOD_ID", OracleDbType.Decimal).Value = mod;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public decimal ModNumb { get; set; }
        public string ModName { get; set; }
        // Функция для рекоммендаций в моделях
        public string RecommendModel()
        {
            foreach (DataRow row in GetModCount().Rows)
            {
                ModNumb = (decimal)row[0];
            }
            foreach (DataRow row in GetModel2(ModNumb).Rows)
            {
                ModName = (string)row[0];
            }
            return ModName;
        }

        /////////////////////////////////////////////////
        //Для рекоммендаций в сериях ////////////////////////
        public DataTable GetSerCount()
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.GET_ORDER_AUTO_COUNT_SER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetSeries2(decimal ser) // Используется, чтобы получить список моделей по выбранной серии.
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.GET_SERIES_2";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("SER_ID", OracleDbType.Decimal).Value = ser;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public decimal SerNumb { get; set; }
        public string SerName { get; set; }

        //Функция рекомендация в сериях
        public string RecommendSeries()
        {
            foreach (DataRow row in GetSerCount().Rows)
            {
                SerNumb = (decimal)row[0];
            }
            foreach (DataRow row in GetSeries2(SerNumb).Rows)
            {
                SerName = (string)row[0];
            }
            return SerName;
        }

        // Для рекоммендаций в экстерьере ////////////////////////////////////////////////////////////////////
        public DataTable GetExtCount()
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.GET_ORDER_AUTO_COUNT_EXT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetExterior2(decimal ext) // Используется, чтобы получить список экстерьеров по выбранной серии.
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.GET_EXTERIOR_2";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("EXT_ID", OracleDbType.Decimal).Value = ext;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public decimal ExtNumb { get; set; }
        public string ExtName { get; set; }
        // Функция для рекоммендаций в экстерьере
        public string RecommendExterior()
        {
            foreach (DataRow row in GetExtCount().Rows)
            {
                ExtNumb = (decimal)row[0];
            }
            foreach (DataRow row in GetExterior2(ExtNumb).Rows)
            {
                ExtName = (string)row[0];
            }
            return ExtName;
        }

        /////////////////////////////////////////////////
        // Для рекоммендаций в интерьере ////////////////////////////////////////////////////////////////////
        public DataTable GetIntCount()
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.GET_ORDER_AUTO_COUNT_INT";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetInterior2(decimal inter) // Используется, чтобы получить список интерьеров по выбранной серии.
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.GET_INTERIOR_2";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("INT_ID", OracleDbType.Decimal).Value = inter;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public decimal IntNumb { get; set; }
        public string IntName { get; set; }
        // Функция для рекоммендаций в интерьере
        public string RecommendInterior()
        {
            foreach (DataRow row in GetIntCount().Rows)
            {
                IntNumb = (decimal)row[0];
            }
            foreach (DataRow row in GetInterior2(IntNumb).Rows)
            {
                IntName = (string)row[0];
            }
            return IntName;
        }

        /////////////////////////////////////////////////
    }
}
