namespace Bus_bookig.Forms
{
    partial class frmdashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmdashboard));
            this.chartExpense = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbltotalbus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbltotalemployee = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnDashboard = new System.Windows.Forms.Button();
            this.lbltotalearn = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lbltotalexpense = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartExpense)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // chartExpense
            // 
            chartArea3.Name = "ChartArea1";
            this.chartExpense.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chartExpense.Legends.Add(legend3);
            this.chartExpense.Location = new System.Drawing.Point(24, 225);
            this.chartExpense.Name = "chartExpense";
            series5.ChartArea = "ChartArea1";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "CurrentYear";
            series6.ChartArea = "ChartArea1";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "PriorYear";
            this.chartExpense.Series.Add(series5);
            this.chartExpense.Series.Add(series6);
            this.chartExpense.Size = new System.Drawing.Size(517, 333);
            this.chartExpense.TabIndex = 0;
            this.chartExpense.Text = "Expense";
            this.chartExpense.Click += new System.EventHandler(this.chartExpense_Click);
            // 
            // chartRevenue
            // 
            chartArea4.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend4);
            this.chartRevenue.Location = new System.Drawing.Point(663, 225);
            this.chartRevenue.Name = "chartRevenue";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "CurrentYear";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "PriorYear";
            this.chartRevenue.Series.Add(series7);
            this.chartRevenue.Series.Add(series8);
            this.chartRevenue.Size = new System.Drawing.Size(454, 333);
            this.chartRevenue.TabIndex = 1;
            this.chartRevenue.Text = "Revenue";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Fuchsia;
            this.panel1.Controls.Add(this.lbltotalbus);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(21, 62);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(232, 88);
            this.panel1.TabIndex = 2;
            // 
            // lbltotalbus
            // 
            this.lbltotalbus.AutoSize = true;
            this.lbltotalbus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalbus.Location = new System.Drawing.Point(51, 45);
            this.lbltotalbus.Name = "lbltotalbus";
            this.lbltotalbus.Size = new System.Drawing.Size(63, 20);
            this.lbltotalbus.TabIndex = 1;
            this.lbltotalbus.Text = "000000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Total Bus";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Yellow;
            this.panel2.Controls.Add(this.lbltotalemployee);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(309, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(232, 88);
            this.panel2.TabIndex = 3;
            // 
            // lbltotalemployee
            // 
            this.lbltotalemployee.AutoSize = true;
            this.lbltotalemployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalemployee.Location = new System.Drawing.Point(71, 45);
            this.lbltotalemployee.Name = "lbltotalemployee";
            this.lbltotalemployee.Size = new System.Drawing.Size(63, 20);
            this.lbltotalemployee.TabIndex = 1;
            this.lbltotalemployee.Text = "000000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Total Employee";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.btnDashboard);
            this.panel3.Controls.Add(this.lbltotalearn);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(598, 62);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(232, 88);
            this.panel3.TabIndex = 4;
            // 
            // btnDashboard
            // 
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDashboard.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDashboard.Image = ((System.Drawing.Image)(resources.GetObject("btnDashboard.Image")));
            this.btnDashboard.Location = new System.Drawing.Point(150, 11);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(67, 68);
            this.btnDashboard.TabIndex = 15;
            this.btnDashboard.UseVisualStyleBackColor = true;
            // 
            // lbltotalearn
            // 
            this.lbltotalearn.AutoSize = true;
            this.lbltotalearn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalearn.Location = new System.Drawing.Point(81, 45);
            this.lbltotalearn.Name = "lbltotalearn";
            this.lbltotalearn.Size = new System.Drawing.Size(63, 20);
            this.lbltotalearn.TabIndex = 1;
            this.lbltotalearn.Text = "000000";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Total Earning";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Cyan;
            this.panel4.Controls.Add(this.button1);
            this.panel4.Controls.Add(this.lbltotalexpense);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Location = new System.Drawing.Point(885, 62);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(232, 88);
            this.panel4.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Gainsboro;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(154, 11);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.button1.Size = new System.Drawing.Size(67, 68);
            this.button1.TabIndex = 16;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lbltotalexpense
            // 
            this.lbltotalexpense.AutoSize = true;
            this.lbltotalexpense.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltotalexpense.Location = new System.Drawing.Point(79, 45);
            this.lbltotalexpense.Name = "lbltotalexpense";
            this.lbltotalexpense.Size = new System.Drawing.Size(63, 20);
            this.lbltotalexpense.TabIndex = 1;
            this.lbltotalexpense.Text = "000000";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "Total Expense";
            // 
            // frmdashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 570);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chartRevenue);
            this.Controls.Add(this.chartExpense);
            this.Name = "frmdashboard";
            this.Text = "DashBoard Information";
            this.Load += new System.EventHandler(this.frmdashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartExpense)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartExpense;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbltotalbus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lbltotalemployee;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbltotalearn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbltotalexpense;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDashboard;
        private System.Windows.Forms.Button button1;
    }
}