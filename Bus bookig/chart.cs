using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace Bus_bookig
{
    internal class chart
    {
        internal static DataTable ExpenseChart(int year)
        {
            OracleDataAdapter dapter = new OracleDataAdapter("SELECT DISTINCT TxnMonth, SUM(Expense1) AS Year1,SUM(Expense2) AS Year2 FROM (SELECT TO_CHAR(EXPDATE,'MM') AS TxnMonth, TO_CHAR(EXPDATE,'YYYY') AS TxnYear, SUM(CASE WHEN TO_CHAR(EXPDATE,'YYYY')='2023' THEN EXPENCE ELSE 0 END) AS Expense1, SUM(CASE WHEN TO_CHAR(EXPDATE,'YYYY')='2022' THEN EXPENCE ELSE 0 END) AS Expense2 FROM tblbusexpense WHERE  TO_CHAR(EXPDATE,'YYYY') = '2023' OR  TO_CHAR(EXPDATE,'YYYY') = '2022' GROUP BY TO_CHAR(EXPDATE,'MM') , TO_CHAR(EXPDATE,'YYYY')) GROUP BY TxnMonth ORDER BY TxnMonth", DBconnection.connect());
            DataTable table = new DataTable();
            dapter.Fill(table);
            return table;
        }


        internal static DataTable RevenueChart(int year)
        {
            OracleDataAdapter dapter = new OracleDataAdapter("SELECT DISTINCT TxnMonth, SUM(Revenue1) AS Year1,SUM(Revenue2) AS Year2 FROM (SELECT TO_CHAR(DEPARTUREDATETIME,'MM') AS TxnMonth, TO_CHAR(DEPARTUREDATETIME,'YYYY') AS TxnYear, SUM(CASE WHEN TO_CHAR(DEPARTUREDATETIME,'YYYY')='2023' THEN PRICE ELSE 0 END) AS Revenue1, SUM(CASE WHEN TO_CHAR(DEPARTUREDATETIME,'YYYY')='2022' THEN PRICE ELSE 0 END) AS Revenue2 FROM viewrevenue WHERE  TO_CHAR(DEPARTUREDATETIME,'YYYY') = '2023' OR  TO_CHAR(DEPARTUREDATETIME,'YYYY') = '2022' GROUP BY TO_CHAR(DEPARTUREDATETIME,'MM') , TO_CHAR(DEPARTUREDATETIME,'YYYY')) GROUP BY TxnMonth ORDER BY TxnMonth", DBconnection.connect());
            DataTable table = new DataTable();
            dapter.Fill(table);
            return table;
        }

        internal static DataTable Revenue()
        {
            OracleDataAdapter dapter = new OracleDataAdapter("select sum(price) as Revenue from (Select TRANTICKETID, Price From tblTranTicket UNION ALL Select TRANGOODID, Price From tblTranGood)", DBconnection.connect());
            DataTable table = new DataTable();
            dapter.Fill(table);
            return table;
        }
        internal static DataTable Totalbus()
        {
            OracleDataAdapter dapter = new OracleDataAdapter("select count (*) as totalbus from tblbus", DBconnection.connect());
            DataTable table = new DataTable();
            dapter.Fill(table);
            return table;
        }
        internal static DataTable Totalemployee()
        {
            OracleDataAdapter dapter = new OracleDataAdapter("select count (*) as totalemployee from tblemployee", DBconnection.connect());
            DataTable table = new DataTable();
            dapter.Fill(table);
            return table;
        }
        internal static DataTable Totalexpense()
        {
            OracleDataAdapter dapter = new OracleDataAdapter("select sum (expence) as totalexpense from tblbusexpense", DBconnection.connect());
            DataTable table = new DataTable();
            dapter.Fill(table);
            return table;
        }
    }
}
