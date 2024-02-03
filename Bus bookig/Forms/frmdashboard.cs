using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Bus_bookig.Forms
{
    public partial class frmdashboard : Form
    {
        frmMain frmMain;
        public frmdashboard()
        {
            InitializeComponent();
            this.frmMain = new frmMain();
        }
        void LoadExpenseChart()
        {
            DataTable dtExpense = chart.ExpenseChart(2023);

            chartExpense.Titles.Add("Expense Current vs Pior");
            chartExpense.DataSource = dtExpense;
            chartExpense.ChartAreas.FirstOrDefault().AxisX.Interval = 1;
            chartExpense.Series["CurrentYear"].LegendText = "2023";
            chartExpense.Series["CurrentYear"].XValueMember = "TxnMonth";
            chartExpense.Series["CurrentYear"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartExpense.Series["CurrentYear"].YValueMembers = "Year1";
            chartExpense.Series["CurrentYear"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chartExpense.Series["PriorYear"].LegendText = "2022";
            chartExpense.Series["PriorYear"].XValueMember = "TxnMonth";
            chartExpense.Series["PriorYear"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartExpense.Series["PriorYear"].YValueMembers = "Year2";
            chartExpense.Series["PriorYear"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
        }
        void LoadRevenueChart()
        {
            DataTable dtRevenue = chart.RevenueChart(2023);

            chartRevenue.Titles.Add("Revenue Current vs Pior");
            chartRevenue.DataSource = dtRevenue;
            chartRevenue.ChartAreas.FirstOrDefault().AxisX.Interval = 1;
            chartRevenue.Series["CurrentYear"].LegendText = "2023";
            chartRevenue.Series["CurrentYear"].XValueMember = "TxnMonth";
            chartRevenue.Series["CurrentYear"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartRevenue.Series["CurrentYear"].YValueMembers = "Year1";
            chartRevenue.Series["CurrentYear"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            chartRevenue.Series["PriorYear"].LegendText = "2022";
            chartRevenue.Series["PriorYear"].XValueMember = "TxnMonth";
            chartRevenue.Series["PriorYear"].XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
            chartRevenue.Series["PriorYear"].YValueMembers = "Year2";
            chartRevenue.Series["PriorYear"].YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
        }
        
        void Revenue()
        {
            DataTable dtRevenue = chart.Revenue();
            lbltotalearn.Text = dtRevenue.Rows[0]["Revenue"].ToString();
        }
        void Totalbus()
        {
            DataTable dttotalbus = chart.Totalbus();
            lbltotalbus.Text = dttotalbus.Rows[0]["totalbus"].ToString();
        }
        void Totalemployee()
        {
            DataTable dttotalemployee = chart.Totalemployee();
            lbltotalemployee.Text = dttotalemployee.Rows[0]["totalemployee"].ToString();
        }
        void Totalexpense()
        {
            DataTable dttotalexpense = chart.Totalexpense();
            lbltotalexpense.Text = dttotalexpense.Rows[0]["totalexpense"].ToString();
        }


        private void frmdashboard_Load(object sender, EventArgs e)
        {
            LoadExpenseChart(); 
            LoadRevenueChart();
            Revenue();
            Totalbus();
            Totalemployee();
            Totalexpense();
        }

        private void chartExpense_Click(object sender, EventArgs e)
        {

        }
    }
}
