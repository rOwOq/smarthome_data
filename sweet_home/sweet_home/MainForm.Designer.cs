namespace sweet_home
{
    partial class MainForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lblVr = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblTemp = new System.Windows.Forms.Label();
            this.lblHum = new System.Windows.Forms.Label();
            this.lblLight = new System.Windows.Forms.Label();
            this.lblAir = new System.Windows.Forms.Label();
            this.lblPir = new System.Windows.Forms.Label();
            this.btnFanOn = new System.Windows.Forms.Button();
            this.btnFanOff = new System.Windows.Forms.Button();
            this.btnDoorOpen = new System.Windows.Forms.Button();
            this.btnDoorClose = new System.Windows.Forms.Button();
            this.btnBuzzerOn = new System.Windows.Forms.Button();
            this.btnBuzzerOff = new System.Windows.Forms.Button();
            this.trackServo = new System.Windows.Forms.TrackBar();
            this.btnCeilingOn = new System.Windows.Forms.Button();
            this.btnCeilingOff = new System.Windows.Forms.Button();
            this.lblBuzzerStatus = new System.Windows.Forms.Label();
            this.lblServoStatus = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.trackServo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblVr
            // 
            this.lblVr.AutoSize = true;
            this.lblVr.Location = new System.Drawing.Point(42, 186);
            this.lblVr.Name = "lblVr";
            this.lblVr.Size = new System.Drawing.Size(41, 18);
            this.lblVr.TabIndex = 0;
            this.lblVr.Text = "lblVr";
            // 
            // lblTemp
            // 
            this.lblTemp.AutoSize = true;
            this.lblTemp.Location = new System.Drawing.Point(42, 50);
            this.lblTemp.Name = "lblTemp";
            this.lblTemp.Size = new System.Drawing.Size(69, 18);
            this.lblTemp.TabIndex = 1;
            this.lblTemp.Text = "lblTemp";
            // 
            // lblHum
            // 
            this.lblHum.AutoSize = true;
            this.lblHum.Location = new System.Drawing.Point(262, 50);
            this.lblHum.Name = "lblHum";
            this.lblHum.Size = new System.Drawing.Size(60, 18);
            this.lblHum.TabIndex = 2;
            this.lblHum.Text = "lblHum";
            // 
            // lblLight
            // 
            this.lblLight.AutoSize = true;
            this.lblLight.Location = new System.Drawing.Point(42, 115);
            this.lblLight.Name = "lblLight";
            this.lblLight.Size = new System.Drawing.Size(61, 18);
            this.lblLight.TabIndex = 3;
            this.lblLight.Text = "lblLight";
            // 
            // lblAir
            // 
            this.lblAir.AutoSize = true;
            this.lblAir.Location = new System.Drawing.Point(263, 115);
            this.lblAir.Name = "lblAir";
            this.lblAir.Size = new System.Drawing.Size(45, 18);
            this.lblAir.TabIndex = 4;
            this.lblAir.Text = "lblAir";
            // 
            // lblPir
            // 
            this.lblPir.AutoSize = true;
            this.lblPir.Location = new System.Drawing.Point(263, 186);
            this.lblPir.Name = "lblPir";
            this.lblPir.Size = new System.Drawing.Size(44, 18);
            this.lblPir.TabIndex = 5;
            this.lblPir.Text = "lblPir";
            // 
            // btnFanOn
            // 
            this.btnFanOn.Location = new System.Drawing.Point(45, 338);
            this.btnFanOn.Name = "btnFanOn";
            this.btnFanOn.Size = new System.Drawing.Size(100, 50);
            this.btnFanOn.TabIndex = 6;
            this.btnFanOn.Text = "btnFanOn";
            this.btnFanOn.UseVisualStyleBackColor = true;
            this.btnFanOn.Click += new System.EventHandler(this.btnFanOn_Click);
            // 
            // btnFanOff
            // 
            this.btnFanOff.Location = new System.Drawing.Point(265, 338);
            this.btnFanOff.Name = "btnFanOff";
            this.btnFanOff.Size = new System.Drawing.Size(100, 50);
            this.btnFanOff.TabIndex = 7;
            this.btnFanOff.Text = "btnFanOff";
            this.btnFanOff.UseVisualStyleBackColor = true;
            this.btnFanOff.Click += new System.EventHandler(this.btnFanOff_Click);
            // 
            // btnDoorOpen
            // 
            this.btnDoorOpen.Location = new System.Drawing.Point(45, 407);
            this.btnDoorOpen.Name = "btnDoorOpen";
            this.btnDoorOpen.Size = new System.Drawing.Size(130, 50);
            this.btnDoorOpen.TabIndex = 8;
            this.btnDoorOpen.Text = "btnDoorOpen";
            this.btnDoorOpen.UseVisualStyleBackColor = true;
            this.btnDoorOpen.Click += new System.EventHandler(this.btnDoorOpen_Click);
            // 
            // btnDoorClose
            // 
            this.btnDoorClose.Location = new System.Drawing.Point(266, 407);
            this.btnDoorClose.Name = "btnDoorClose";
            this.btnDoorClose.Size = new System.Drawing.Size(130, 50);
            this.btnDoorClose.TabIndex = 9;
            this.btnDoorClose.Text = "btnDoorClose";
            this.btnDoorClose.UseVisualStyleBackColor = true;
            this.btnDoorClose.Click += new System.EventHandler(this.btnDoorClose_Click);
            // 
            // btnBuzzerOn
            // 
            this.btnBuzzerOn.Location = new System.Drawing.Point(45, 489);
            this.btnBuzzerOn.Name = "btnBuzzerOn";
            this.btnBuzzerOn.Size = new System.Drawing.Size(100, 50);
            this.btnBuzzerOn.TabIndex = 10;
            this.btnBuzzerOn.Text = "btnBuzzerOn";
            this.btnBuzzerOn.UseVisualStyleBackColor = true;
            this.btnBuzzerOn.Click += new System.EventHandler(this.btnBuzzerOn_Click);
            // 
            // btnBuzzerOff
            // 
            this.btnBuzzerOff.Location = new System.Drawing.Point(266, 489);
            this.btnBuzzerOff.Name = "btnBuzzerOff";
            this.btnBuzzerOff.Size = new System.Drawing.Size(100, 50);
            this.btnBuzzerOff.TabIndex = 11;
            this.btnBuzzerOff.Text = "btnBuzzerOff";
            this.btnBuzzerOff.UseVisualStyleBackColor = true;
            this.btnBuzzerOff.Click += new System.EventHandler(this.btnBuzzerOff_Click);
            // 
            // trackServo
            // 
            this.trackServo.Location = new System.Drawing.Point(45, 687);
            this.trackServo.Name = "trackServo";
            this.trackServo.Size = new System.Drawing.Size(351, 69);
            this.trackServo.TabIndex = 12;
            this.trackServo.Scroll += new System.EventHandler(this.trackServo_Scroll);
            // 
            // btnCeilingOn
            // 
            this.btnCeilingOn.Location = new System.Drawing.Point(45, 586);
            this.btnCeilingOn.Name = "btnCeilingOn";
            this.btnCeilingOn.Size = new System.Drawing.Size(100, 50);
            this.btnCeilingOn.TabIndex = 13;
            this.btnCeilingOn.Text = "btnCeilingOn";
            this.btnCeilingOn.UseVisualStyleBackColor = true;
            this.btnCeilingOn.Click += new System.EventHandler(this.btnCeilingOn_Click);
            // 
            // btnCeilingOff
            // 
            this.btnCeilingOff.Location = new System.Drawing.Point(266, 586);
            this.btnCeilingOff.Name = "btnCeilingOff";
            this.btnCeilingOff.Size = new System.Drawing.Size(100, 50);
            this.btnCeilingOff.TabIndex = 14;
            this.btnCeilingOff.Text = "btnCeilingOff";
            this.btnCeilingOff.UseVisualStyleBackColor = true;
            this.btnCeilingOff.Click += new System.EventHandler(this.btnCeilingOff_Click);
            // 
            // lblBuzzerStatus
            // 
            this.lblBuzzerStatus.AutoSize = true;
            this.lblBuzzerStatus.Location = new System.Drawing.Point(42, 232);
            this.lblBuzzerStatus.Name = "lblBuzzerStatus";
            this.lblBuzzerStatus.Size = new System.Drawing.Size(130, 18);
            this.lblBuzzerStatus.TabIndex = 15;
            this.lblBuzzerStatus.Text = "lblBuzzerStatus";
            // 
            // lblServoStatus
            // 
            this.lblServoStatus.AutoSize = true;
            this.lblServoStatus.Location = new System.Drawing.Point(42, 282);
            this.lblServoStatus.Name = "lblServoStatus";
            this.lblServoStatus.Size = new System.Drawing.Size(123, 18);
            this.lblServoStatus.TabIndex = 16;
            this.lblServoStatus.Text = "lblServoStatus";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(436, 50);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(594, 671);
            this.chart1.TabIndex = 17;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 768);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.lblServoStatus);
            this.Controls.Add(this.lblBuzzerStatus);
            this.Controls.Add(this.btnCeilingOff);
            this.Controls.Add(this.btnCeilingOn);
            this.Controls.Add(this.trackServo);
            this.Controls.Add(this.btnBuzzerOff);
            this.Controls.Add(this.btnBuzzerOn);
            this.Controls.Add(this.btnDoorClose);
            this.Controls.Add(this.btnDoorOpen);
            this.Controls.Add(this.btnFanOff);
            this.Controls.Add(this.btnFanOn);
            this.Controls.Add(this.lblPir);
            this.Controls.Add(this.lblAir);
            this.Controls.Add(this.lblLight);
            this.Controls.Add(this.lblHum);
            this.Controls.Add(this.lblTemp);
            this.Controls.Add(this.lblVr);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackServo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVr;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblTemp;
        private System.Windows.Forms.Label lblHum;
        private System.Windows.Forms.Label lblLight;
        private System.Windows.Forms.Label lblAir;
        private System.Windows.Forms.Label lblPir;
        private System.Windows.Forms.Button btnFanOn;
        private System.Windows.Forms.Button btnFanOff;
        private System.Windows.Forms.Button btnDoorOpen;
        private System.Windows.Forms.Button btnDoorClose;
        private System.Windows.Forms.Button btnBuzzerOn;
        private System.Windows.Forms.Button btnBuzzerOff;
        private System.Windows.Forms.TrackBar trackServo;
        private System.Windows.Forms.Button btnCeilingOn;
        private System.Windows.Forms.Button btnCeilingOff;
        private System.Windows.Forms.Label lblBuzzerStatus;
        private System.Windows.Forms.Label lblServoStatus;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}