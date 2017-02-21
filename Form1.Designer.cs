namespace whazee
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.Check = new System.Windows.Forms.Button();
            this.FiveMinTimer = new System.Windows.Forms.Timer(this.components);
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Direction = new System.Windows.Forms.GroupBox();
            this.Work = new System.Windows.Forms.RadioButton();
            this.Home = new System.Windows.Forms.RadioButton();
            this.TrafficChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Direction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrafficChart)).BeginInit();
            this.SuspendLayout();
            // 
            // Check
            // 
            this.Check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Check.Location = new System.Drawing.Point(866, 578);
            this.Check.Name = "Check";
            this.Check.Size = new System.Drawing.Size(202, 59);
            this.Check.TabIndex = 0;
            this.Check.Text = "Check";
            this.Check.UseVisualStyleBackColor = true;
            this.Check.Click += new System.EventHandler(this.Check_Click);
            // 
            // FiveMinTimer
            // 
            this.FiveMinTimer.Interval = 300000;
            this.FiveMinTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 555);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 21);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "AutoCheck";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // Direction
            // 
            this.Direction.Controls.Add(this.Work);
            this.Direction.Controls.Add(this.Home);
            this.Direction.Location = new System.Drawing.Point(12, 582);
            this.Direction.Name = "Direction";
            this.Direction.Size = new System.Drawing.Size(389, 55);
            this.Direction.TabIndex = 4;
            this.Direction.TabStop = false;
            this.Direction.Text = "Direction";
            // 
            // Work
            // 
            this.Work.AutoSize = true;
            this.Work.Location = new System.Drawing.Point(273, 22);
            this.Work.Name = "Work";
            this.Work.Size = new System.Drawing.Size(62, 21);
            this.Work.TabIndex = 1;
            this.Work.TabStop = true;
            this.Work.Text = "Work";
            this.Work.UseVisualStyleBackColor = true;
            this.Work.CheckedChanged += new System.EventHandler(this.Work_CheckedChanged);
            // 
            // Home
            // 
            this.Home.AutoSize = true;
            this.Home.Location = new System.Drawing.Point(7, 22);
            this.Home.Name = "Home";
            this.Home.Size = new System.Drawing.Size(66, 21);
            this.Home.TabIndex = 0;
            this.Home.TabStop = true;
            this.Home.Text = "Home";
            this.Home.UseVisualStyleBackColor = true;
            this.Home.CheckedChanged += new System.EventHandler(this.Home_CheckedChanged);
            // 
            // TrafficChart
            // 
            chartArea1.Name = "ChartArea1";
            this.TrafficChart.ChartAreas.Add(chartArea1);
            this.TrafficChart.Location = new System.Drawing.Point(12, 13);
            this.TrafficChart.Name = "TrafficChart";
            this.TrafficChart.Size = new System.Drawing.Size(1056, 536);
            this.TrafficChart.TabIndex = 5;
            this.TrafficChart.Text = "TrafficChart";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 649);
            this.Controls.Add(this.TrafficChart);
            this.Controls.Add(this.Direction);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.Check);
            this.Name = "Form1";
            this.Text = "Whazee";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Direction.ResumeLayout(false);
            this.Direction.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrafficChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Check;
        private System.Windows.Forms.Timer FiveMinTimer;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox Direction;
        private System.Windows.Forms.RadioButton Home;
        private System.Windows.Forms.RadioButton Work;
        private System.Windows.Forms.DataVisualization.Charting.Chart TrafficChart;
    }
}

