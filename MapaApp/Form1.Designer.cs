namespace Mapa
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.gmapControl = new GMap.NET.WindowsForms.GMapControl();
            this.MapTimer = new System.Windows.Forms.Timer(this.components);
            this.CronometroTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lapListBox = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtVelGPSPromedio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVelGPS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtVelDisp = new System.Windows.Forms.TextBox();
            this.labelPotencia = new System.Windows.Forms.Label();
            this.labelVelDisp = new System.Windows.Forms.Label();
            this.lapBtn = new System.Windows.Forms.Button();
            this.playBtn = new System.Windows.Forms.Button();
            this.cronometroLabel = new System.Windows.Forms.Label();
            this.cronometroTextBox = new System.Windows.Forms.TextBox();
            this.labelZoom = new System.Windows.Forms.Label();
            this.trackZoom = new System.Windows.Forms.TrackBar();
            this.checkPinPos = new System.Windows.Forms.CheckBox();
            this.comboDisp = new System.Windows.Forms.ComboBox();
            this.labelLatitud = new System.Windows.Forms.Label();
            this.txtLatitud = new System.Windows.Forms.TextBox();
            this.labelLongitud = new System.Windows.Forms.Label();
            this.txtLongitud = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // gmapControl
            // 
            this.gmapControl.Bearing = 0F;
            this.gmapControl.CanDragMap = true;
            this.gmapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gmapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmapControl.GrayScaleMode = false;
            this.gmapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmapControl.LevelsKeepInMemmory = 5;
            this.gmapControl.Location = new System.Drawing.Point(0, 0);
            this.gmapControl.MarkersEnabled = true;
            this.gmapControl.MaxZoom = 2;
            this.gmapControl.MinZoom = 2;
            this.gmapControl.MouseWheelZoomEnabled = true;
            this.gmapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gmapControl.Name = "gmapControl";
            this.gmapControl.NegativeMode = false;
            this.gmapControl.PolygonsEnabled = true;
            this.gmapControl.RetryLoadTile = 0;
            this.gmapControl.RoutesEnabled = true;
            this.gmapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gmapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gmapControl.ShowTileGridLines = false;
            this.gmapControl.Size = new System.Drawing.Size(984, 561);
            this.gmapControl.TabIndex = 0;
            this.gmapControl.Zoom = 0D;
            // 
            // MapTimer
            // 
            this.MapTimer.Enabled = true;
            this.MapTimer.Interval = 2000;
            this.MapTimer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // CronometroTimer
            // 
            this.CronometroTimer.Tick += new System.EventHandler(this.Cronometro_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lapListBox);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(453, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 561);
            this.panel1.TabIndex = 17;
            // 
            // lapListBox
            // 
            this.lapListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lapListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lapListBox.FormattingEnabled = true;
            this.lapListBox.ItemHeight = 16;
            this.lapListBox.Location = new System.Drawing.Point(0, 327);
            this.lapListBox.Name = "lapListBox";
            this.lapListBox.Size = new System.Drawing.Size(531, 234);
            this.lapListBox.TabIndex = 32;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtVelGPSPromedio);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txtVelGPS);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.txtVelDisp);
            this.panel2.Controls.Add(this.labelPotencia);
            this.panel2.Controls.Add(this.labelVelDisp);
            this.panel2.Controls.Add(this.lapBtn);
            this.panel2.Controls.Add(this.playBtn);
            this.panel2.Controls.Add(this.cronometroLabel);
            this.panel2.Controls.Add(this.cronometroTextBox);
            this.panel2.Controls.Add(this.labelZoom);
            this.panel2.Controls.Add(this.trackZoom);
            this.panel2.Controls.Add(this.checkPinPos);
            this.panel2.Controls.Add(this.comboDisp);
            this.panel2.Controls.Add(this.labelLatitud);
            this.panel2.Controls.Add(this.txtLatitud);
            this.panel2.Controls.Add(this.labelLongitud);
            this.panel2.Controls.Add(this.txtLongitud);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(531, 327);
            this.panel2.TabIndex = 31;
            // 
            // txtVelGPSPromedio
            // 
            this.txtVelGPSPromedio.Location = new System.Drawing.Point(226, 55);
            this.txtVelGPSPromedio.Name = "txtVelGPSPromedio";
            this.txtVelGPSPromedio.ReadOnly = true;
            this.txtVelGPSPromedio.Size = new System.Drawing.Size(100, 20);
            this.txtVelGPSPromedio.TabIndex = 50;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(223, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Velocidad GPS Promedio";
            // 
            // txtVelGPS
            // 
            this.txtVelGPS.Location = new System.Drawing.Point(120, 55);
            this.txtVelGPS.Name = "txtVelGPS";
            this.txtVelGPS.ReadOnly = true;
            this.txtVelGPS.Size = new System.Drawing.Size(100, 20);
            this.txtVelGPS.TabIndex = 48;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Velocidad GPS";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(120, 102);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 46;
            // 
            // txtVelDisp
            // 
            this.txtVelDisp.Location = new System.Drawing.Point(358, 55);
            this.txtVelDisp.Name = "txtVelDisp";
            this.txtVelDisp.ReadOnly = true;
            this.txtVelDisp.Size = new System.Drawing.Size(100, 20);
            this.txtVelDisp.TabIndex = 45;
            // 
            // labelPotencia
            // 
            this.labelPotencia.AutoSize = true;
            this.labelPotencia.Location = new System.Drawing.Point(117, 86);
            this.labelPotencia.Name = "labelPotencia";
            this.labelPotencia.Size = new System.Drawing.Size(49, 13);
            this.labelPotencia.TabIndex = 44;
            this.labelPotencia.Text = "Potencia";
            // 
            // labelVelDisp
            // 
            this.labelVelDisp.AutoSize = true;
            this.labelVelDisp.Location = new System.Drawing.Point(355, 39);
            this.labelVelDisp.Name = "labelVelDisp";
            this.labelVelDisp.Size = new System.Drawing.Size(125, 13);
            this.labelVelDisp.TabIndex = 43;
            this.labelVelDisp.Text = "Velocidad del Dispositivo";
            // 
            // lapBtn
            // 
            this.lapBtn.Location = new System.Drawing.Point(327, 297);
            this.lapBtn.Name = "lapBtn";
            this.lapBtn.Size = new System.Drawing.Size(75, 23);
            this.lapBtn.TabIndex = 42;
            this.lapBtn.Text = "Lap";
            this.lapBtn.UseVisualStyleBackColor = true;
            this.lapBtn.Click += new System.EventHandler(this.lapBtn_Click);
            // 
            // playBtn
            // 
            this.playBtn.Location = new System.Drawing.Point(225, 297);
            this.playBtn.Name = "playBtn";
            this.playBtn.Size = new System.Drawing.Size(75, 23);
            this.playBtn.TabIndex = 41;
            this.playBtn.Text = "Play";
            this.playBtn.UseVisualStyleBackColor = true;
            this.playBtn.Click += new System.EventHandler(this.playBtn_Click);
            // 
            // cronometroLabel
            // 
            this.cronometroLabel.AutoSize = true;
            this.cronometroLabel.Location = new System.Drawing.Point(77, 274);
            this.cronometroLabel.Name = "cronometroLabel";
            this.cronometroLabel.Size = new System.Drawing.Size(61, 13);
            this.cronometroLabel.TabIndex = 40;
            this.cronometroLabel.Text = "Cronometro";
            // 
            // cronometroTextBox
            // 
            this.cronometroTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cronometroTextBox.Location = new System.Drawing.Point(16, 290);
            this.cronometroTextBox.Multiline = true;
            this.cronometroTextBox.Name = "cronometroTextBox";
            this.cronometroTextBox.ReadOnly = true;
            this.cronometroTextBox.Size = new System.Drawing.Size(203, 31);
            this.cronometroTextBox.TabIndex = 39;
            this.cronometroTextBox.Text = "00:00:00:0000";
            this.cronometroTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelZoom
            // 
            this.labelZoom.AutoSize = true;
            this.labelZoom.Location = new System.Drawing.Point(9, 159);
            this.labelZoom.Name = "labelZoom";
            this.labelZoom.Size = new System.Drawing.Size(37, 13);
            this.labelZoom.TabIndex = 37;
            this.labelZoom.Text = "Zoom:";
            // 
            // trackZoom
            // 
            this.trackZoom.Location = new System.Drawing.Point(52, 159);
            this.trackZoom.Maximum = 18;
            this.trackZoom.Minimum = 1;
            this.trackZoom.Name = "trackZoom";
            this.trackZoom.Size = new System.Drawing.Size(104, 45);
            this.trackZoom.TabIndex = 36;
            this.trackZoom.Value = 18;
            this.trackZoom.ValueChanged += new System.EventHandler(this.zoomTrack_Changed);
            // 
            // checkPinPos
            // 
            this.checkPinPos.AutoSize = true;
            this.checkPinPos.Checked = true;
            this.checkPinPos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkPinPos.Location = new System.Drawing.Point(12, 128);
            this.checkPinPos.Name = "checkPinPos";
            this.checkPinPos.Size = new System.Drawing.Size(81, 17);
            this.checkPinPos.TabIndex = 35;
            this.checkPinPos.Text = "Pin Position";
            this.checkPinPos.UseVisualStyleBackColor = true;
            this.checkPinPos.CheckedChanged += new System.EventHandler(this.checkPinPosition_Changed);
            // 
            // comboDisp
            // 
            this.comboDisp.DisplayMember = "1";
            this.comboDisp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDisp.FormattingEnabled = true;
            this.comboDisp.Location = new System.Drawing.Point(12, 7);
            this.comboDisp.Name = "comboDisp";
            this.comboDisp.Size = new System.Drawing.Size(121, 21);
            this.comboDisp.TabIndex = 34;
            this.comboDisp.ValueMember = "0";
            this.comboDisp.SelectedIndexChanged += new System.EventHandler(this.Combo_Dispositivo_Changed);
            // 
            // labelLatitud
            // 
            this.labelLatitud.AutoSize = true;
            this.labelLatitud.Location = new System.Drawing.Point(11, 39);
            this.labelLatitud.Name = "labelLatitud";
            this.labelLatitud.Size = new System.Drawing.Size(39, 13);
            this.labelLatitud.TabIndex = 33;
            this.labelLatitud.Text = "Latitud";
            // 
            // txtLatitud
            // 
            this.txtLatitud.Location = new System.Drawing.Point(11, 55);
            this.txtLatitud.Name = "txtLatitud";
            this.txtLatitud.ReadOnly = true;
            this.txtLatitud.Size = new System.Drawing.Size(100, 20);
            this.txtLatitud.TabIndex = 32;
            // 
            // labelLongitud
            // 
            this.labelLongitud.AutoSize = true;
            this.labelLongitud.Location = new System.Drawing.Point(12, 86);
            this.labelLongitud.Name = "labelLongitud";
            this.labelLongitud.Size = new System.Drawing.Size(48, 13);
            this.labelLongitud.TabIndex = 31;
            this.labelLongitud.Text = "Longitud";
            // 
            // txtLongitud
            // 
            this.txtLongitud.Location = new System.Drawing.Point(12, 102);
            this.txtLongitud.Name = "txtLongitud";
            this.txtLongitud.ReadOnly = true;
            this.txtLongitud.Size = new System.Drawing.Size(100, 20);
            this.txtLongitud.TabIndex = 30;
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gmapControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmapControl;
        private System.Windows.Forms.Timer MapTimer;
        private System.Windows.Forms.Timer CronometroTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button lapBtn;
        private System.Windows.Forms.Button playBtn;
        private System.Windows.Forms.Label cronometroLabel;
        private System.Windows.Forms.TextBox cronometroTextBox;
        private System.Windows.Forms.Label labelZoom;
        private System.Windows.Forms.TrackBar trackZoom;
        private System.Windows.Forms.CheckBox checkPinPos;
        private System.Windows.Forms.ComboBox comboDisp;
        private System.Windows.Forms.Label labelLatitud;
        private System.Windows.Forms.TextBox txtLatitud;
        private System.Windows.Forms.Label labelLongitud;
        private System.Windows.Forms.TextBox txtLongitud;
        private System.Windows.Forms.ListBox lapListBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtVelDisp;
        private System.Windows.Forms.Label labelPotencia;
        private System.Windows.Forms.Label labelVelDisp;
        private System.Windows.Forms.TextBox txtVelGPS;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtVelGPSPromedio;
        private System.Windows.Forms.Label label2;
    }
}

