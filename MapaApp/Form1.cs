using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;

// Dependencias
using DispositivoManager;
using API;
using System.Threading;

namespace Mapa
{
    public partial class Form1 : Form
    {
        //API o Dependencia que se usa
        GoogleMapControl map;

        Stopwatch cronometro = new Stopwatch();
        List<LapInfo> lapList = new List<LapInfo>();
        public Form1()
        {
            InitializeComponent();
            Start_Program();
        }

        private async void Start_Program()
        {
            map = new GoogleMapControl(gmapControl);
            map.Set_Map_Zoom(trackZoom.Value);
            txtAPIUrl.Text = APIRequests.api_url;
            await Task.Delay(500);
            this.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            await Update_Dispositivos();
            this.Enabled = true;
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Cargado con exito.");
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Timer Tick");
            Task update_information = Task.Run(() => Update_Current_Information());
            try
            {
                Search_Selected_Dispositivo();
            } catch (Exception ex)
            {
                Console.WriteLine("ERROR AL BUSCAR EL DISPOSITIVO! " + ex.Message);
            }
        }

        public async void Update_Current_Information()
        {
            Console.WriteLine("Actualizando Informacion Dispositivos...");
            await Dispositivos.current.Update_Information();
            if (Dispositivos.current.Information == null || Dispositivos.current.Information.Count == 0)
            {
                Console.WriteLine("La información del dispositivo " + Dispositivos.current.Descripcion + " es nula!");
                return;
            }
            Console.WriteLine("Informacion actualizada.");
        }

        public async Task<bool> Update_Dispositivos()
        {
           MapTimer.Stop();
           Console.WriteLine("Actualizando Dispositivos...");
           var result = await Dispositivos.Create_List();
           await Task.Run(() =>
           {
               if(result == null) { return; }
               Parallel.ForEach(Dispositivos.list, async disp =>
               {
                    await disp.Update_Information();
               });
           });
           if (result != null){
                Fill_Dispositivo_Box();
                MapTimer.Start();
           }
           Console.WriteLine("Dispositivos Actualizados.");
           return result == null ? false : true;
        }

        public void Fill_Dispositivo_Box()
        {
            if(comboDisp.Items.Count > 0) // Por alguna razon hay que checkear si tiene items si no se rompe.
            {
                comboDisp.Items.Clear();
            }
            foreach (string dispositivo_desc in Dispositivos.Get_Descripciones())
            {
                comboDisp.Items.Add(dispositivo_desc);
            }
            comboDisp.SelectedIndex = 0;
        }

        private void Search_Selected_Dispositivo()
        {
            map.Overlays_Tick();
            InformationModel info = Dispositivos.current.Get_Last_Information();
            if (info == null) { return; }
            // Texts
            txtLatitud.Text = info.Latitud.ToString();
            txtLongitud.Text = info.Longitud.ToString();
            txtVelGPS.Text = map.Calculate_Velocity_of_Dispositivo(Dispositivos.current) + " km/h";
            txtVelGPSPromedio.Text = map.Calculate_Velocity_of_Dispositivo(Dispositivos.current, 5) + " km/h";
            txtVelDisp.Text = info.Velocidad.ToString() + " km/h";
            txtCorriente.Text = info.Corriente.ToString() + " A";
            txtTension.Text = info.Tension.ToString() + " V";
            txtEnergia.Text = info.Energia.ToString() + " kWh";
            txtPotencia.Text = info.Potencia.ToString() + " W";
            // Pins
            if (!checkPinPos.Checked) { return; }
            map.Set_Map_Position(new LatLng(info.Latitud, info.Longitud));
        }

        private void Combo_Dispositivo_Changed(object sender, EventArgs e)
        {
            Dispositivos.current = Dispositivos.list[comboDisp.SelectedIndex];
            Search_Selected_Dispositivo();
        }

        private void checkPinPosition_Changed(object sender, EventArgs e)
        {
            map.Toggle_Movement();
            if (checkPinPos.Checked)
            {
                map.Set_Map_Position(Dispositivos.current.Get_Current_Position());
                map.Set_Map_Zoom(trackZoom.Value);
            }
        }

        private void zoomTrack_Changed(object sender, EventArgs e)
        {
            gmapControl.Zoom = trackZoom.Value;
        }

        private void playBtn_Click(object sender, EventArgs e)
        {
            if (!cronometro.IsRunning)
            {
                cronometro.Start();
                playBtn.Text = "Stop";
                CronometroTimer.Enabled = true;
                
                return;
            }
            playBtn.Text = "Play";
            cronometro.Stop();
        }

        private void lapBtn_Click(object sender, EventArgs e)
        {
            if (cronometro.ElapsedMilliseconds == 0)
            {
                return;
            }
            lapList.Insert(0, (new LapInfo(lapListBox.Items.Count, TimeSpan.Zero)));
            lapList[0].Total_Time = new TimeSpan(0, 0, 0, 0, (int)cronometro.ElapsedMilliseconds);
            lapList[0].Elapsed_Time = lapList[0].Total_Time;
            lapList[0].Elapsed_Time = lapList.Count == 1 ? lapList[0].Elapsed_Time : lapList[0].Elapsed_Time - lapList[1].Elapsed_Time;
            lapListBox.Items.Insert(0, lapList[0].ToString());
        }

        private void Cronometro_Tick(object sender, EventArgs e)
        {
            TimeSpan time = new TimeSpan(0, 0, 0, 0, (int)cronometro.ElapsedMilliseconds);
            cronometroTextBox.Text = time.ToString(@"hh\:mm\:ss\:fff");
        }

        private void config_Click(object sender, EventArgs e)
        {
            panelConfig.Visible = !panelConfig.Visible;
            panelConfig.Height = 0;
            configTransition.Start();
        }

        private void configTransition_Tick(object sender, EventArgs e)
        {
            panelConfig.Height += 8;
            if(panelConfig.Height > 45)
            {
                configTransition.Stop();
            }
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            Cursor.Current = Cursors.WaitCursor;
            bool existen_dispositivos = await Update_Dispositivos();
            Cursor.Current = Cursors.Default;
            this.Enabled = true;
            if (!existen_dispositivos)
            {
                MessageBox.Show("No se encontraron dispositivos.");
                return;
            }
            MessageBox.Show("Se actualizo la lista de dispositivos.");
        }

        private async void btnAPIAccept_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.Enabled = false;
            string result = await APIRequests.GetHttp("/", txtAPIUrl.Text);
            this.Enabled = true;
            Cursor.Current = Cursors.Default;
            if (result.StartsWith("ERROR"))
            {
                MessageBox.Show("La dirección de la API no es válida o no está accesible.");
                return;
            }
            MessageBox.Show("La dirección de la API Cambio!");
            APIRequests.api_url = txtAPIUrl.Text;
        }

        private void txtAPIUrl_TextChanged(object sender, EventArgs e)
        {
            btnAPIAccept.Enabled = txtAPIUrl.Text != APIRequests.api_url;
        }
    }
}

internal class LapInfo
{
    public int Id { get; set; }
    public TimeSpan Elapsed_Time { get; set; }
    public TimeSpan Total_Time = TimeSpan.Zero;
    public LapInfo(int a_Id, TimeSpan a_Elapsed_Time)
    {
        Id = a_Id;
        Elapsed_Time = a_Elapsed_Time;
    }
    public override string ToString()
    {
        return $"Lap {Id+1}: + {Elapsed_Time.ToString(@"hh\:mm\:ss\:fff")} / {Total_Time.ToString(@"hh\:mm\:ss\:fff")}";
    }
}
