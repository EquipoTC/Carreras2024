﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    internal class APIRequests
    {
        
        public static string apiUrl = "https://carreras2024.onrender.com/";
		public static double timeoutResponseSeconds = 30;
        //Verbs
        public static async Task<string> GetHttp(string url, string api)
        {
			TimeSpan timeout = TimeSpan.FromSeconds(timeoutResponseSeconds);
			using (HttpClient client = new HttpClient())
			{
				client.Timeout = timeout;
				try
				{
					HttpResponseMessage response = await client.GetAsync(api + url);
					response.EnsureSuccessStatusCode();
					string responseJson = await response.Content.ReadAsStringAsync();
					return responseJson;
				}
				catch (TaskCanceledException ex)
				{
					Console.WriteLine("La solicitud ha excedido el tiempo límite.");
					throw new TimeoutException("La solicitud HTTP ha excedido el tiempo límite.", ex);
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error en la solicitud HTTP: " + ex.Message);
					throw new Exception("Error en la solicitud HTTP.", ex);
				}
			}
		}
		public static async Task<string> PostHttp(string url, string api, string jsonContent)
		{
			TimeSpan timeout = TimeSpan.FromSeconds(timeoutResponseSeconds);

			using (HttpClient client = new HttpClient())
			{
				client.Timeout = timeout;
				try
				{
					HttpContent content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
					HttpResponseMessage response = await client.PostAsync(api + url, content);
					response.EnsureSuccessStatusCode();
					string responseJson = await response.Content.ReadAsStringAsync();
					return responseJson;
				}
				catch (TaskCanceledException ex)
				{
					if (!ex.CancellationToken.IsCancellationRequested)
					{
						Console.WriteLine("La solicitud ha excedido el tiempo límite.");
						throw new TimeoutException("La solicitud HTTP ha excedido el tiempo límite.", ex);
					}
					else
					{
						Console.WriteLine("La solicitud fue cancelada.");
						throw new Exception("La solicitud fue cancelada.", ex);
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error en la solicitud HTTP: " + ex.Message);
					throw new Exception("Error en la solicitud HTTP.", ex);
				}
			}
		}
	}
}
