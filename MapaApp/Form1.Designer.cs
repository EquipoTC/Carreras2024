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
            this.gmapControl = new GMap.NET.WindowsForms.GMapControl();
            this.txtLongitud = new System.Windows.Forms.TextBox();
            this.labelLongitud = new System.Windows.Forms.Label();
            this.labelLatitud = new System.Windows.Forms.Label();
            this.txtLatitud = new System.Windows.Forms.TextBox();
            this.comboDisp = new System.Windows.Forms.ComboBox();
            this.checkPinPos = new System.Windows.Forms.CheckBox();
            this.checkPinZoom = new System.Windows.Forms.CheckBox();
            this.trackZoom = new System.Windows.Forms.TrackBar();
            this.labelZoom = new System.Windows.Forms.Label();
            this.labelVelGPS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).BeginInit();
            this.SuspendLayout();
            // 
            // gmapControl
            // 
            this.gmapControl.Bearing = 0F;
            this.gmapControl.CanDragMap = true;
            this.gmapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gmapControl.GrayScaleMode = false;
            this.gmapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gmapControl.LevelsKeepInMemmory = 5;
            this.gmapControl.Location = new System.Drawing.Point(12, 12);
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
            this.gmapControl.Size = new System.Drawing.Size(400, 400);
            this.gmapControl.TabIndex = 0;
            this.gmapControl.Zoom = 0D;
            // 
            // txtLongitud
            // 
            this.txtLongitud.Location = new System.Drawing.Point(420, 173);
            this.txtLongitud.Name = "txtLongitud";
            this.txtLongitud.Size = new System.Drawing.Size(100, 20);
            this.txtLongitud.TabIndex = 1;
            // 
            // labelLongitud
            // 
            this.labelLongitud.AutoSize = true;
            this.labelLongitud.Location = new System.Drawing.Point(420, 157);
            this.labelLongitud.Name = "labelLongitud";
            this.labelLongitud.Size = new System.Drawing.Size(48, 13);
            this.labelLongitud.TabIndex = 2;
            this.labelLongitud.Text = "Longitud";
            // 
            // labelLatitud
            // 
            this.labelLatitud.AutoSize = true;
            this.labelLatitud.Location = new System.Drawing.Point(420, 118);
            this.labelLatitud.Name = "labelLatitud";
            this.labelLatitud.Size = new System.Drawing.Size(39, 13);
            this.labelLatitud.TabIndex = 4;
            this.labelLatitud.Text = "Latitud";
            // 
            // txtLatitud
            // 
            this.txtLatitud.Location = new System.Drawing.Point(420, 134);
            this.txtLatitud.Name = "txtLatitud";
            this.txtLatitud.Size = new System.Drawing.Size(100, 20);
            this.txtLatitud.TabIndex = 3;
            // 
            // comboDisp
            // 
            this.comboDisp.DisplayMember = "1";
            this.comboDisp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDisp.FormattingEnabled = true;
            this.comboDisp.Location = new System.Drawing.Point(421, 94);
            this.comboDisp.Name = "comboDisp";
            this.comboDisp.Size = new System.Drawing.Size(121, 21);
            this.comboDisp.TabIndex = 6;
            this.comboDisp.ValueMember = "0";
            this.comboDisp.SelectedIndexChanged += new System.EventHandler(this.Combo_Dispositivo_Changed);
            // 
            // checkPinPos
            // 
            this.checkPinPos.AutoSize = true;
            this.checkPinPos.Location = new System.Drawing.Point(419, 200);
            this.checkPinPos.Name = "checkPinPos";
            this.checkPinPos.Size = new System.Drawing.Size(81, 17);
            this.checkPinPos.TabIndex = 7;
            this.checkPinPos.Text = "Pin Position";
            this.checkPinPos.UseVisualStyleBackColor = true;
            this.checkPinPos.CheckedChanged += new System.EventHandler(this.checkPinPosition_Changed);
            // 
            // checkPinZoom
            // 
            this.checkPinZoom.AutoSize = true;
            this.checkPinZoom.Location = new System.Drawing.Point(418, 223);
            this.checkPinZoom.Name = "checkPinZoom";
            this.checkPinZoom.Size = new System.Drawing.Size(71, 17);
            this.checkPinZoom.TabIndex = 8;
            this.checkPinZoom.Text = "Pin Zoom";
            this.checkPinZoom.UseVisualStyleBackColor = true;
            // 
            // trackZoom
            // 
            this.trackZoom.Location = new System.Drawing.Point(459, 246);
            this.trackZoom.Maximum = 18;
            this.trackZoom.Minimum = 1;
            this.trackZoom.Name = "trackZoom";
            this.trackZoom.Size = new System.Drawing.Size(104, 45);
            this.trackZoom.TabIndex = 9;
            this.trackZoom.Value = 10;
            this.trackZoom.ValueChanged += new System.EventHandler(this.TrackZoom_Value_Changed);
            // 
            // labelZoom
            // 
            this.labelZoom.AutoSize = true;
            this.labelZoom.Location = new System.Drawing.Point(418, 247);
            this.labelZoom.Name = "labelZoom";
            this.labelZoom.Size = new System.Drawing.Size(37, 13);
            this.labelZoom.TabIndex = 10;
            this.labelZoom.Text = "Zoom:";
            // 
            // labelVelGPS
            // 
            this.labelVelGPS.AutoSize = true;
            this.labelVelGPS.Location = new System.Drawing.Point(417, 278);
            this.labelVelGPS.Name = "labelVelGPS";
            this.labelVelGPS.Size = new System.Drawing.Size(82, 13);
            this.labelVelGPS.TabIndex = 11;
            this.labelVelGPS.Text = "Velocidad GPS:";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(601, 424);
            this.Controls.Add(this.labelVelGPS);
            this.Controls.Add(this.labelZoom);
            this.Controls.Add(this.trackZoom);
            this.Controls.Add(this.checkPinZoom);
            this.Controls.Add(this.checkPinPos);
            this.Controls.Add(this.comboDisp);
            this.Controls.Add(this.labelLatitud);
            this.Controls.Add(this.txtLatitud);
            this.Controls.Add(this.labelLongitud);
            this.Controls.Add(this.txtLongitud);
            this.Controls.Add(this.gmapControl);
            this.Name = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.trackZoom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gmapControl;
        private System.Windows.Forms.TextBox txtLongitud;
        private System.Windows.Forms.Label labelLongitud;
        private System.Windows.Forms.Label labelLatitud;
        private System.Windows.Forms.TextBox txtLatitud;
        private System.Windows.Forms.ComboBox comboDisp;
        private System.Windows.Forms.CheckBox checkPinPos;
        private System.Windows.Forms.CheckBox checkPinZoom;
        private System.Windows.Forms.TrackBar trackZoom;
        private System.Windows.Forms.Label labelZoom;
        private System.Windows.Forms.Label labelVelGPS;
    }
}

