using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading.Tasks;

// Dependencias
using DispositivoManager;
using API;
using System.Threading;
using System.IO;

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
            Set_App_Config();
            await Task.Delay(500);
            SwitchFreezeUI();
            try
            {
                await Update_Dispositivos();
            }
            catch
            {
                MessageBox.Show("Cargado con exito. No se encontraron dispositivos.");
                SwitchFreezeUI();
                await Task.Run(() => Cronometro_Tick());
                return;
            }
            SwitchFreezeUI();
            MessageBox.Show("Cargado con exito.");
            await Task.Run(() => Cronometro_Tick());
        }

        private void Set_App_Config()
        {
            Create_Config_File();
            string[] lines = File.ReadAllLines(Path.Combine(Application.StartupPath, "Config", "config.txt"));
            Action[] settings = new Action[]
            {
                () => API.APIRequests.api_url = lines[0].Remove(0, lines[0].IndexOf(':')+1),
            };
            foreach (Action setting in settings)
            {
                setting();
            }
            txtAPIUrl.Text = APIRequests.api_url;
        }

        private void Create_Config_File()
        {
            string configDirectory = Path.Combine(Application.StartupPath, "Config");
            if (Directory.Exists(configDirectory))
            {
                return;
            }
            Directory.CreateDirectory(configDirectory);
            using (StreamWriter sw = new StreamWriter(Path.Combine(configDirectory, "config.txt")))
            {
                sw.WriteLine("API:" + API.APIRequests.api_url);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("Timer Tick");
            Task update_information = Task.Run(() => Update_Current_Information());
            Search_Selected_Dispositivo();
        }

        public async void Update_Current_Information()
        {
            Console.WriteLine("Actualizando Informacion Dispositivos...");
            await Dispositivos.current.Update_Information();
            Console.WriteLine("Informacion actualizada.");
        }

        public async Task Update_Dispositivos()
        {
           MapTimer.Stop();
           Console.WriteLine("Actualizando Dispositivos...");
           List<DispositivoModel> result = await Dispositivos.Create_List();
           await Task.Run(() =>
           {
               Parallel.ForEach(Dispositivos.list, async disp =>
               {
                   await disp.Update_Information();
               });
           });
           Fill_Dispositivo_Box();
           MapTimer.Start();
           Console.WriteLine("Dispositivos Actualizados.");
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

        private async Task Cronometro_Tick()
        {
            while (true)
            {
                await Task.Delay(100);
                if (!cronometro.IsRunning) { continue; }
                TimeSpan time = new TimeSpan(0, 0, 0, 0, (int)cronometro.ElapsedMilliseconds);
                cronometroText_Update(time.ToString(@"hh\:mm\:ss\:fff"));
            }
        }
        
        private void cronometroText_Update(string time)
        {
            if (cronometroTextBox.InvokeRequired)
            {
                cronometroTextBox.Invoke(new Action<string>(cronometroText_Update), time);
            }
            else
            {
                cronometroTextBox.Text = time;
            }
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
            SwitchFreezeUI();
            playBtn_Click(this, EventArgs.Empty);
            try
            {
                await Update_Dispositivos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se encontraron dispositivos: " + ex.Message);
                SwitchFreezeUI();
                return;
            }
            SwitchFreezeUI();
            MessageBox.Show("Se actualizo la lista de dispositivos.");
        }

        private void SwitchFreezeUI()
        {
            this.UseWaitCursor = !this.UseWaitCursor;
            panelMain.Enabled = !panelMain.Enabled;
            panelConfig.Enabled = !panelConfig.Enabled;
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
