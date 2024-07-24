using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using API;
using Mapa;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DispositivoManager
{
    internal class Dispositivos
    {
        public static List<DispositivoModel> list = new List<DispositivoModel>();
        public static DispositivoModel current = new DispositivoModel();

        public static async Task<List<DispositivoModel>> Create_List()
        {
            string respuesta = await APIRequests.GetHttp("/disp", APIRequests.api_url);
            if(respuesta.Contains("ERROR"))
            {
                return null;
            }
            JObject json = JObject.Parse(respuesta);
            list = JsonConvert.DeserializeObject<List<DispositivoModel>>(json["data"].ToString());
            return list;
        }

        public static List<string> Get_Descripciones()
        {
            List<string> desc_list = new List<string>();
            if (list == null)
            {
                return desc_list;
            }
            foreach (var desc in list)
            {
                desc_list.Add(desc.Descripcion);
            }
            return desc_list;
        }

    }
    internal class DispositivoModel
    {
        [JsonProperty("disp_id")]
        public int Id { get; set; }

        [JsonProperty("disp_descripcion")]
        public string Descripcion { get; set; }

        [JsonProperty("disp_latitud_actual")]
        public double Latitud_Actual { get; set; }

        [JsonProperty("disp_longitud_actual")]
        public double Longitud_Actual { get; set; }

        [JsonProperty("disp_fecha_ingreso")]
        public DateTime Fecha_Ingreso { get; set; }

        [JsonProperty("disp_fecha_modificacion")]
        public DateTime? Fecha_Modificacion { get; set; }

        [JsonProperty("disp_habilitado")]
        public bool Habilitado { get; set; }

        public List<InformationModel> Information = new List<InformationModel>();

        public async Task<List<InformationModel>> Update_Information()
        {
            string respuesta = await APIRequests.GetHttp("/info/" + Id, APIRequests.api_url);
            if (respuesta.Contains("ERROR"))
            {
                return Information;
            }
            JObject json = JObject.Parse(respuesta);
            Information = JsonConvert.DeserializeObject<List<InformationModel>>(json["data"].ToString());
            if(Information == null)
            {
                return Information;
            }
            Latitud_Actual = Information[Information.Count-1].Latitud;
            Longitud_Actual = Information[Information.Count-1].Longitud;
            return Information;
        }

        public InformationModel Get_Last_Information()
        {
            if (Information.Count == 0 || Information == null) { return null; }
            return Information[Information.Count-1];
        }

        public LatLng Get_Current_Position()
        {
            return new LatLng(Latitud_Actual, Longitud_Actual);
        }

        public LatLng Get_Position_by_Id(int id)
        {
            return new LatLng(Information[id].Latitud, Information[id].Longitud);
        }

        public string Get_Position_Message()
        {
            return Descripcion + "\n Latitud:" + Latitud_Actual + "\n Longitud:" + Longitud_Actual;
        }
    }
    internal class InformationModel
    {
        [JsonProperty("info_id")]
        public int Id { get; set; }

        [JsonProperty("info_disp_id")]
        public string Disp_Id { get; set; }

        [JsonProperty("info_latitud")]
        public double Latitud { get; set; }

        [JsonProperty("info_longitud")]
        public double Longitud { get; set; }

        [JsonProperty("info_fecha_ingreso")]
        public DateTime Fecha_Ingreso { get; set; }

        [JsonProperty("info_corriente")]
        public double Corriente { get; set; }

        [JsonProperty("info_tension")]
        public double Tension { get; set; }

        [JsonProperty("info_energia")]
        public double Energia { get; set; }

        [JsonProperty("info_potencia")]
        public double Potencia { get; set; }

        [JsonProperty("info_velocidad")]
        public double Velocidad { get; set; }
    }
}
