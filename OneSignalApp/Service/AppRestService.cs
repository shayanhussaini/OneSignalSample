using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace OneSignalApp.Models
{
    public class AppRestService : IAppRestService
    {
        readonly string baseUri = ConfigurationManager.AppSettings["API_URL"].ToString();
        public AppRestService()
        {

        }
        public List<AppModel> Get()
        {
            string uri = baseUri;
            JObject objResult = new JObject();
            List<AppModel> apps = new List<AppModel>();
            using (HttpClient httpClient = new HttpClient())
            {                
                httpClient.BaseAddress = new Uri(uri);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                var authKey = ConfigurationManager.AppSettings["API_KEY"].ToString();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authKey);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                Task<String> response = httpClient.GetStringAsync(uri);
                apps = JsonConvert.DeserializeObjectAsync<List<AppModel>>(response.Result).Result;
            }
            //UpdateAppById(apps[0].id, apps[0]);
            return apps;
        }
        public AppModel GetById(string id)
        {
            string uri = baseUri + "/" + id;
            JObject objResult = new JObject();
            AppModel apps = new AppModel();
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(uri);
                httpClient.DefaultRequestHeaders.Accept.Clear();
                var authKey = ConfigurationManager.AppSettings["API_KEY"].ToString();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authKey);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                
                Task<String> response = httpClient.GetStringAsync(uri);
                apps = JsonConvert.DeserializeObjectAsync<AppModel>(response.Result).Result;
            }
            //UpdateAppById(apps[0].id, apps[0]);
            return apps;
        }

        public AppModel Update(AppModel app)
        {
            string uri = baseUri + "/" + app.id;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                var authKey = ConfigurationManager.AppSettings["API_KEY"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //HTTP POST
                var putTask = client.PutAsJsonAsync<AppModel>(uri, app);
                putTask.Wait();
                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return app;
                }
            }
            return app;
        }

        public AppModel Create(AppModel app)
        {
            string uri = baseUri + "/" + app.id;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(uri);
                client.DefaultRequestHeaders.Accept.Clear();
                var authKey = ConfigurationManager.AppSettings["API_KEY"].ToString();
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authKey);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //HTTP POST
                var putTask = client.PostAsJsonAsync<AppModel>(uri, app);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return app;
                }
            }
            return app;
        }
    }
}