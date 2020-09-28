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
    class Developer
    {
        OracleConnection connn = Form1.conn;
        public DataTable GetTables(string tab) // Получить содержимое выбранной таблицы
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_DEV.GET_TABLE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("IN_NAME", OracleDbType.Varchar2).Value = tab;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetTableNames() // Получить имена существующих таблиц
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_DEV.TABLE_NAMES";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public IList<string> Tables()
        {
            List<string> tables = new List<string>();
            foreach (DataRow row in GetTableNames().Rows)
            {
                string tablename = (string)row[0];
                tables.Add(tablename);
                Console.WriteLine(tablename);
            }
            return tables;
        }

        public void DelOrd(string name, string column, string cond)
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();

            OracleTransaction transaction;

            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;

            transaction = connn.BeginTransaction(IsolationLevel.ReadCommitted);
            cmd.Transaction = transaction;

            cmd.CommandText = "STUDENT.CONF_PKG_DEV.DELETE_ROW";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("IN_NAME", OracleDbType.Varchar2).Value = name;
            cmd.Parameters.Add("IN_COLUMN", OracleDbType.Varchar2).Value = column;
            cmd.Parameters.Add("CONDITION", OracleDbType.Varchar2).Value = cond;

            da.DeleteCommand = cmd;
            cmd.ExecuteNonQuery();
            transaction.Commit();
        }

        OracleTransaction transaction;
        public void UpdOrd(string name, string column, string val, string col1, string cond)
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();

            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;

            try
            {
                transaction = connn.BeginTransaction(IsolationLevel.ReadCommitted);
                cmd.Transaction = transaction;

                cmd.CommandText = "STUDENT.CONF_PKG_DEV.UPDATE_ROW";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("IN_NAME", OracleDbType.Varchar2).Value = name;
                cmd.Parameters.Add("IN_COLUMN", OracleDbType.Varchar2).Value = column;
                cmd.Parameters.Add("IN_VAL", OracleDbType.Varchar2).Value = val;
                cmd.Parameters.Add("IN_COLUMN_1", OracleDbType.Varchar2).Value = col1;
                cmd.Parameters.Add("CONDITION", OracleDbType.Varchar2).Value = cond;

                da.UpdateCommand = cmd;
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (InvalidOperationException exc)
            {
                string errorMessage = "Message: " + exc.Message;
                MessageBox.Show(errorMessage + "\nЗапускается Rollback транзакции, повторите действие снова.");
                transaction.Rollback();
            }
        }

        public DataTable GetTableOrderNames() // Получить имена таблиц с заказами
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_DEV.TABLE_NAMES_ORDER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public IList<string> TablesOrder()
        {
            List<string> tables = new List<string>();
            foreach (DataRow row in GetTableOrderNames().Rows)
            {
                string tablename = (string)row[0];
                tables.Add(tablename);
                Console.WriteLine(tablename);
            }
            return tables;
        }

        public DataTable GetTableLogNames() // Получить имена таблиц с заказами
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_DEV.TABLES_NAMES_LOGS";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public IList<string> TablesLogs()
        {
            List<string> tables = new List<string>();
            foreach (DataRow row in GetTableLogNames().Rows)
            {
                string tablename = (string)row[0];
                tables.Add(tablename);
                Console.WriteLine(tablename);
            }
            return tables;
        }
    }
}
