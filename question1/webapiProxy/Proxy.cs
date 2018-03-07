using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using webapiProxy.DataContracts;

namespace webapiProxy
{
    public class Proxy
    {
        private HttpClient _client;
        public Proxy(string webapiUrl)
        {
            _client = new HttpClient(new HttpClientHandler() { UseProxy = false });
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            _client.BaseAddress = new Uri($"{webapiUrl}api/entities/");
        }
        public async Task<Entity> GetAsync(int id)
        {

            var response =  _client.GetAsync($"{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return await Task.Run(() => JsonConvert.DeserializeObject<Entity>(result));
            }
            else
            {
                throw new ApplicationException($"failed to connect web api, error code {response.StatusCode}");
            }
        }

        public async Task<List<Entity>> GetAllAsync()
        {
            var response =  _client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                return await Task.Run(() => JsonConvert.DeserializeObject<List<Entity>>(result));
            }
            else
            {
                throw new ApplicationException($"failed to connect web api, error code {response.StatusCode}");
            }
        }


        public async Task<Uri> PostAsync(Entity entity)
        {
            var param = JsonConvert.SerializeObject(entity);
            HttpContent contentPost = new StringContent(param, Encoding.UTF8, "application/json");
            var response =  _client.PostAsync("", contentPost).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Headers.Location;
            }
            else
            {
                throw new ApplicationException($"failed to connect web api, error code {response.StatusCode}");
            }
        }
    }
    
}
