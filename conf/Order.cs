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
    class Order
    {
        OracleConnection connn = Form1.conn;
        public void InsOrd(decimal choice, decimal insert) // Использует процедуру для вставки строк в табилцу conf_order_auto.
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();

            OracleTransaction transaction;

            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;

            transaction = connn.BeginTransaction(IsolationLevel.ReadCommitted);
            transaction.Save("ord1");
            cmd.Transaction = transaction;

            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.INSERT_ORDER_AUTO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("ID_ORD", OracleDbType.Decimal).Value = Form2.clientt;


            if (choice == 1)
            {
                cmd.Parameters.Add("ID_PRT_SER", OracleDbType.Decimal).Value = insert;
            }
            else
            {
                cmd.Parameters.Add("ID_PRT_SER", OracleDbType.Decimal).Value = null;
            }
            if (choice == 2)
            {
                cmd.Parameters.Add("ID_PRT_MOD", OracleDbType.Decimal).Value = insert;
            }
            else
            {
                cmd.Parameters.Add("ID_PRT_MOD", OracleDbType.Decimal).Value = null;
            }
            if (choice == 3)
            {
                cmd.Parameters.Add("ID_PRT_EXT", OracleDbType.Decimal).Value = insert;
            }
            else
            {
                cmd.Parameters.Add("ID_PRT_EXT", OracleDbType.Decimal).Value = null;
            }
            if (choice == 4)
            {
                cmd.Parameters.Add("ID_PRT_INT", OracleDbType.Decimal).Value = insert;
            }
            else
            {
                cmd.Parameters.Add("ID_PRT_INT", OracleDbType.Decimal).Value = null;
            }
            if (choice == 5)
            {
                cmd.Parameters.Add("ID_PRT_OPT", OracleDbType.Decimal).Value = insert;
            }
            else
            {
                cmd.Parameters.Add("ID_PRT_OPT", OracleDbType.Decimal).Value = null;
            }

            da.InsertCommand = cmd;
            cmd.ExecuteNonQuery();
            transaction.Commit();
        }

        public DataTable GetOrder()
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;
            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.SELECT_ORDER_AUTO";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("IN_CLIENT", OracleDbType.Decimal).Value = Form2.clientt;
            cmd.Parameters.Add("OUT_NAME", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void DelOrd(decimal ord, decimal cond = 0)
        {
            OracleDataAdapter da = new OracleDataAdapter();
            OracleCommand cmd = new OracleCommand();

            OracleTransaction transaction;

            cmd.Connection = connn;
            cmd.InitialLONGFetchSize = 1000;

            transaction = connn.BeginTransaction(IsolationLevel.ReadCommitted);
            cmd.Transaction = transaction;

            cmd.CommandText = "STUDENT.CONF_PKG_USR_SELECT.DELETE_ORDER";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("ID_ORD", OracleDbType.Decimal).Value = ord;
            cmd.Parameters.Add("COND", OracleDbType.Decimal).Value = cond;

            da.DeleteCommand = cmd;
            cmd.ExecuteNonQuery();
            transaction.Commit();
        }
    }
}
