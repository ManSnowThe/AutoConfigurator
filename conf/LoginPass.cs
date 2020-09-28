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
    class LoginPass
    {
        decimal id_ord;
        readonly public string oradb = "User Id = student; Password = 123999; Data Source = localhost/orcl";
        public DataTable Login(string login, string password)
        {
                OracleDataAdapter da = new OracleDataAdapter();
                OracleCommand cmd = new OracleCommand();
                Form1.conn = new OracleConnection(oradb);
                cmd.Connection = Form1.conn;
                cmd.InitialLONGFetchSize = 1000;
                cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.LOGIN2";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("LOG", OracleDbType.Varchar2).Value = login;
                cmd.Parameters.Add("PASS", OracleDbType.Varchar2).Value = password;
                cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
        }

        public void InsClientOrd(decimal client)
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();

            OracleTransaction transaction;

            Form1.conn = new OracleConnection(oradb);
            cmd.Connection = Form1.conn;
            cmd.InitialLONGFetchSize = 1000;

            Form1.conn.Open();

            transaction = Form1.conn.BeginTransaction(IsolationLevel.ReadCommitted);
            cmd.Transaction = transaction;

            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.CONF_ORDER_ADD";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("IN_CLIENT", OracleDbType.Decimal).Value = client;
            //decimal ret = Convert.ToDecimal(cmd.Parameters.Add("OUT_CLIENT", OracleDbType.Decimal).Direction = ParameterDirection.Output);
            //cmd.Parameters.Add("OUT_CLIENT", OracleDbType.Decimal).Direction = ParameterDirection.Output;

            //decimal ret = Convert.ToDecimal(cmd.Parameters["OUT_CLIENT"].Value);

            da.InsertCommand = cmd;
            cmd.ExecuteNonQuery();
            transaction.Commit();

            Form1.conn.Close();
            //return ret;
        }
        public DataTable GetClientOrd()
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();

            Form1.conn = new OracleConnection(oradb);
            cmd.Connection = Form1.conn;
            cmd.InitialLONGFetchSize = 1000;

            Form1.conn.Open();

            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.CONF_ORDER_GET";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public decimal OrdId()
        {
            foreach (DataRow row in GetClientOrd().Rows)
            {
                id_ord = (decimal)row[0];
            }
            return id_ord;
        }
    }
}
