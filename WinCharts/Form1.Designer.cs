﻿namespace WinCharts
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.dataTypeCombo = new System.Windows.Forms.ComboBox();
            this.button8 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.realtimeUpdatesButton = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.seriesTypeCombo = new System.Windows.Forms.ComboBox();
            this.log = new System.Windows.Forms.TextBox();
            this.layoutConverter1 = new DevExpress.XtraLayout.Converter.LayoutConverter(this.components);
            this.Form1layoutControl1ConvertedLayout = new DevExpress.XtraLayout.LayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.textBox1item = new DevExpress.XtraLayout.LayoutControlItem();
            this.flowLayoutPanel1item = new DevExpress.XtraLayout.LayoutControlItem();
            this.chartControl1item = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Form1layoutControl1ConvertedLayout)).BeginInit();
            this.Form1layoutControl1ConvertedLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flowLayoutPanel1item)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1item)).BeginInit();
            this.SuspendLayout();
            // 
            // chartControl1
            // 
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.EnableAxisXScrolling = true;
            xyDiagram1.EnableAxisXZooming = true;
            xyDiagram1.EnableAxisYScrolling = true;
            xyDiagram1.EnableAxisYZooming = true;
            this.chartControl1.Diagram = xyDiagram1;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(236, 12);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.Size = new System.Drawing.Size(552, 325);
            this.chartControl1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.dataTypeCombo);
            this.flowLayoutPanel1.Controls.Add(this.button8);
            this.flowLayoutPanel1.Controls.Add(this.button5);
            this.flowLayoutPanel1.Controls.Add(this.button1);
            this.flowLayoutPanel1.Controls.Add(this.button9);
            this.flowLayoutPanel1.Controls.Add(this.button10);
            this.flowLayoutPanel1.Controls.Add(this.button2);
            this.flowLayoutPanel1.Controls.Add(this.button3);
            this.flowLayoutPanel1.Controls.Add(this.button11);
            this.flowLayoutPanel1.Controls.Add(this.button4);
            this.flowLayoutPanel1.Controls.Add(this.button6);
            this.flowLayoutPanel1.Controls.Add(this.button12);
            this.flowLayoutPanel1.Controls.Add(this.realtimeUpdatesButton);
            this.flowLayoutPanel1.Controls.Add(this.button7);
            this.flowLayoutPanel1.Controls.Add(this.seriesTypeCombo);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(220, 325);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // dataTypeCombo
            // 
            this.dataTypeCombo.FormattingEnabled = true;
            this.dataTypeCombo.Location = new System.Drawing.Point(3, 3);
            this.dataTypeCombo.Name = "dataTypeCombo";
            this.dataTypeCombo.Size = new System.Drawing.Size(201, 21);
            this.dataTypeCombo.TabIndex = 15;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(3, 30);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(36, 23);
            this.button8.TabIndex = 7;
            this.button8.Text = "10";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.generate10Points);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(45, 30);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(44, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "20K";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.generate_20K);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(95, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "1M";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.generateDataClick);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Yellow;
            this.button9.Location = new System.Drawing.Point(137, 30);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(51, 23);
            this.button9.TabIndex = 8;
            this.button9.Text = "20M";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.generate20MPoints);
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Yellow;
            this.button10.Location = new System.Drawing.Point(3, 59);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(51, 23);
            this.button10.TabIndex = 9;
            this.button10.Text = "120M";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(60, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "ClearData";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.clearDataClick);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Coral;
            this.button3.Location = new System.Drawing.Point(141, 59);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(63, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "BindData";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.bindDataWin);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(3, 88);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(52, 23);
            this.button11.TabIndex = 13;
            this.button11.Text = "x10win";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.x10WinClick);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Coral;
            this.button4.Location = new System.Drawing.Point(61, 88);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "UnBindData";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.unBindDataClick);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Chartreuse;
            this.button6.Location = new System.Drawing.Point(3, 117);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(85, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "BindDataWPF";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.bindDataWpf);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(94, 117);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(51, 23);
            this.button12.TabIndex = 14;
            this.button12.Text = "x10wpf";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.x10WpfClick);
            // 
            // realtimeUpdatesButton
            // 
            this.realtimeUpdatesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.realtimeUpdatesButton.Location = new System.Drawing.Point(3, 146);
            this.realtimeUpdatesButton.Name = "realtimeUpdatesButton";
            this.realtimeUpdatesButton.Size = new System.Drawing.Size(133, 23);
            this.realtimeUpdatesButton.TabIndex = 12;
            this.realtimeUpdatesButton.Text = "Start Realtime Updates";
            this.realtimeUpdatesButton.UseVisualStyleBackColor = false;
            this.realtimeUpdatesButton.Click += new System.EventHandler(this.startRealtimeUpdates);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.Chartreuse;
            this.button7.Location = new System.Drawing.Point(3, 175);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(103, 23);
            this.button7.TabIndex = 6;
            this.button7.Text = "UnBindDataWPF";
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.UnBindDataWpf);
            // 
            // seriesTypeCombo
            // 
            this.seriesTypeCombo.FormattingEnabled = true;
            this.seriesTypeCombo.Location = new System.Drawing.Point(3, 204);
            this.seriesTypeCombo.Name = "seriesTypeCombo";
            this.seriesTypeCombo.Size = new System.Drawing.Size(178, 21);
            this.seriesTypeCombo.TabIndex = 11;
            this.seriesTypeCombo.SelectedIndexChanged += new System.EventHandler(this.seriesTypeCombo_SelectedIndexChanged);
            // 
            // log
            // 
            this.log.Location = new System.Drawing.Point(12, 357);
            this.log.Multiline = true;
            this.log.Name = "log";
            this.log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.log.Size = new System.Drawing.Size(776, 95);
            this.log.TabIndex = 2;
            // 
            // Form1layoutControl1ConvertedLayout
            // 
            this.Form1layoutControl1ConvertedLayout.Controls.Add(this.log);
            this.Form1layoutControl1ConvertedLayout.Controls.Add(this.flowLayoutPanel1);
            this.Form1layoutControl1ConvertedLayout.Controls.Add(this.chartControl1);
            this.Form1layoutControl1ConvertedLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Form1layoutControl1ConvertedLayout.Location = new System.Drawing.Point(0, 0);
            this.Form1layoutControl1ConvertedLayout.Name = "Form1layoutControl1ConvertedLayout";
            this.Form1layoutControl1ConvertedLayout.Root = this.layoutControlGroup1;
            this.Form1layoutControl1ConvertedLayout.Size = new System.Drawing.Size(800, 464);
            this.Form1layoutControl1ConvertedLayout.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.textBox1item,
            this.flowLayoutPanel1item,
            this.chartControl1item});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 464);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // textBox1item
            // 
            this.textBox1item.Control = this.log;
            this.textBox1item.Location = new System.Drawing.Point(0, 329);
            this.textBox1item.Name = "textBox1item";
            this.textBox1item.Size = new System.Drawing.Size(780, 115);
            this.textBox1item.Text = "Memory Consumption Log";
            this.textBox1item.TextLocation = DevExpress.Utils.Locations.Top;
            this.textBox1item.TextSize = new System.Drawing.Size(123, 13);
            // 
            // flowLayoutPanel1item
            // 
            this.flowLayoutPanel1item.Control = this.flowLayoutPanel1;
            this.flowLayoutPanel1item.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1item.Name = "flowLayoutPanel1item";
            this.flowLayoutPanel1item.Size = new System.Drawing.Size(224, 329);
            this.flowLayoutPanel1item.TextSize = new System.Drawing.Size(0, 0);
            this.flowLayoutPanel1item.TextVisible = false;
            // 
            // chartControl1item
            // 
            this.chartControl1item.Control = this.chartControl1;
            this.chartControl1item.Location = new System.Drawing.Point(224, 0);
            this.chartControl1item.Name = "chartControl1item";
            this.chartControl1item.Size = new System.Drawing.Size(556, 329);
            this.chartControl1item.TextSize = new System.Drawing.Size(0, 0);
            this.chartControl1item.TextVisible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 464);
            this.Controls.Add(this.Form1layoutControl1ConvertedLayout);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Form1layoutControl1ConvertedLayout)).EndInit();
            this.Form1layoutControl1ConvertedLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flowLayoutPanel1item)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1item)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraCharts.ChartControl chartControl1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox log;
        private DevExpress.XtraLayout.Converter.LayoutConverter layoutConverter1;
        private DevExpress.XtraLayout.LayoutControl Form1layoutControl1ConvertedLayout;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem textBox1item;
        private DevExpress.XtraLayout.LayoutControlItem flowLayoutPanel1item;
        private DevExpress.XtraLayout.LayoutControlItem chartControl1item;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ComboBox seriesTypeCombo;
        private System.Windows.Forms.Button realtimeUpdatesButton;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.ComboBox dataTypeCombo;
    }
}

