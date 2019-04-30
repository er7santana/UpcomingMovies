using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace UpcomingMoviesApp.Services.Base
{
    public class BaseService
    {
        protected HttpClient client;

        public BaseService()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }

        protected async Task<T> GetFromWebApi<T>(string actionRoute) where T : class
        {
            try
            {
                return await DeserializeJson<T>(await GetFromWebApi(actionRoute));
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected async Task<T> DeleteAsync<T>(string actionRoute) where T : class
        {
            try
            {
                return await DeserializeJson<T>(await DeleteAsync(actionRoute));
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected async Task<HttpResponseMessage> GetFromWebApi(string actionRoute)
        {
            return await client.GetAsync(actionRoute).ConfigureAwait(false);
        }

        protected async Task<HttpResponseMessage> DeleteAsync(string actionRoute)
        {
            return await client.DeleteAsync(actionRoute).ConfigureAwait(false);
        }

        protected async Task<TResult> PostToWebApi<TResult>(string actionRoute, object itemToPost) where TResult : class
        {
            try
            {
                return await DeserializeJson<TResult>(await PostToWebApi(actionRoute, itemToPost));
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected async Task<HttpResponseMessage> PostToWebApi(string actionRoute, object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            return await client.PostAsync(actionRoute, content);
        }

        protected async Task<T> DeserializeJson<T>(HttpResponseMessage message) where T : class
        {
            if (message.IsSuccessStatusCode)
            {
                using (var responseStream = await message.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<T>(await new StreamReader(responseStream).ReadToEndAsync().ConfigureAwait(false));
                }
            }
            return null;
        }
    }
}
