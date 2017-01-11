using Newtonsoft.Json;
using Sample.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Sample.Entities.Implementation
{
    public class WebApiDataProvider : IDataProvider
    {
        public string Uri { get; set; }

        public string Port { get; set; }

        public WebApiDataProvider()
        {
            Uri = "http://localhost";
            Port = "49568";
        }

        public WebApiDataProvider(string host, string port)
        {
            Uri = host;
            Port = port;
        }

        // Gets all rows from the table
        public IEnumerable<T> GetDataFromApi<T>(string table)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{Uri}:{Port}");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var url = $"api/{table}";

                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                }
            }

            return null;
        }

        // Gets all rows from the table
        public IEnumerable<T> GetDataFromApi<T>(string table, string action, string Id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{Uri}:{Port}");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                string url = "";
                if (string.IsNullOrEmpty(Id))
                {
                    url = $"api/{table}/{action}";
                }
                else
                {
                    url = $"api/{table}/{action}/{Id}";
                }

                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                }
            }

            return null;
        }

        // Gets a single instance from the table
        public T GetDataFromApi<T>(string table, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{Uri}:{Port}");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var url = $"api/{table}/{id}";

                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<T>().Result;
                }
            }

            return default(T);
        }

        // Gets all rows from the table where the action matches and (possibly) parameter matches
        public IEnumerable<T> GetDataFromApi<T>(string table, string action, int? id = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{Uri}:{Port}");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                string url = "";

                if (id != null)
                {
                    url = $"api/{table}/{action}/{id}";
                }
                else
                {
                    url = $"api/{table}/{action}";
                }

                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                }
            }

            return null;
        }

        // Gets all rows from the table where the action matches and (possibly) parameter matches
        public IEnumerable<T> GetDataFromApi<T>(string table, string action, string id, int? aType = null)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{Uri}:{Port}");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                string url = "";

                if (aType != null)
                    url = $"api/{table}/{action}/{id}/{aType}";
                else
                    url = $"api/{table}/{action}/{id}";

                var response = client.GetAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<IEnumerable<T>>().Result;
                }
            }

            return null;
        }

        public string UpdateDataToApi<T>(string table, int id, T value)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{Uri}:{Port}");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var url = $"api/{table}/{id}";

                var data = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");

                var response = client.PutAsync(url, data).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }

            return null;
        }

        // Empty all data from the table
        public string DeleteDataToApi(string table)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{Uri}:{Port}");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var url = $"api/{table}";

                var response = client.DeleteAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }

            return null;
        }

        public string DeleteDataToApi(string table, int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{Uri}:{Port}");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var url = $"api/{table}/{id}";

                var response = client.DeleteAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }

            return null;
        }

        public string DeleteDataToApi(string table, string action, string dateId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{Uri}:{Port}");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                //var url = $"api/{table}/{id}";
                var url = $"api/{table}/{action}/{dateId}";

                var response = client.DeleteAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }

            return null;
        }

        public string DeleteDataToApi(string table, string action, string dateId, int type)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{Uri}:{Port}");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                //var url = $"api/{table}/{id}{type}";
                var url = $"api/{table}/{action}/{dateId}/{type}";

                var response = client.DeleteAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }

            return null;
        }

        public string DeleteDataToApi(string table, string action, DateTime dateId)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{Uri}:{Port}");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                //var url = $"api/{table}/{id}";
                var url = $"api/{table}/{action}/{dateId}";

                var response = client.DeleteAsync(url).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsStringAsync().Result;
                }
            }

            return null;
        }

        public T AddDataToApi<T>(string table, T value)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri($"{Uri}:{Port}");
                // Add an Accept header for JSON format.
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var url = $"api/{table}";
                var data = new StringContent(JsonConvert.SerializeObject(value), Encoding.UTF8, "application/json");

                var response = client.PostAsync(url, data).Result;
                if (response.IsSuccessStatusCode)
                {
                    return response.Content.ReadAsAsync<T>().Result;
                }
            }

            return default(T);
        }
    }
}
