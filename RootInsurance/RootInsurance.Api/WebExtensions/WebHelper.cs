using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RootInsurance.Api.WebExtensions
{
    /// <summary>
    /// This is a helper class to call the root web api and resolve the responses
    /// </summary>
    public class WebHelper
    {

        #region Properties
        public Configuration.Config Config { get; private set; }
        #endregion

        #region ctor
        public WebHelper(Configuration.Config config)
        {
            this.Config = config;
        }
        #endregion

        #region Methods
        public async Task<T> CallWebApi<T>(string callUrl, HttpMethod method, object parameters = null)
        {
            try
            {
                var url = this.FixUrl(callUrl);
                HttpClient httpClient = new HttpClient();
                httpClient.BaseAddress = new Uri(url);
                // Set up the authentication
                var authToken = Encoding.ASCII.GetBytes($"{Config.RootApiKey}:");
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));
                HttpContent content = null;
                if (parameters != null)
                {
                    string jsonValue = Newtonsoft.Json.JsonConvert.SerializeObject(parameters);
                    content = new StringContent(jsonValue, Encoding.UTF8, "application/json");
                }
                // Declare the response message
                HttpResponseMessage responseMessage = null;
                if (method == HttpMethod.Post)
                    responseMessage = await httpClient.PostAsync(url, content);
                else if (method == HttpMethod.Get)
                    responseMessage = await httpClient.GetAsync(url);
                else if (method == HttpMethod.Put)
                    responseMessage = await httpClient.PutAsync(url, content);
                else if (method == HttpMethod.Delete)
                    responseMessage = await httpClient.DeleteAsync(url);
                else
                {
                    var request = new HttpRequestMessage(method, url)
                    {
                        Content = content
                    };
                    responseMessage = await httpClient.SendAsync(request);
                }
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseContent = await responseMessage.Content.ReadAsStringAsync();
                    var result = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseContent);
                    return result;
                }
                else
                {
                    throw new WebException(responseMessage.ReasonPhrase + Environment.NewLine + responseMessage.Content.ReadAsStringAsync().Result, WebExceptionStatus.UnknownError);
                }
            }
            catch (WebException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion

        #region Helper Methods
        private string FixUrl(string subUrl)
        {
            if (string.IsNullOrEmpty(subUrl))
                throw new ArgumentNullException("Sub Url cannot be blank");
            // Get the base url
            var baseUrl = Config.RootApiBaseUrl;
            // First check if the base url ends with a '/' and the sub url does not start with a '/'
            if (baseUrl.EndsWith("/") && !subUrl.StartsWith("/"))
                return baseUrl + subUrl;
            else if (!baseUrl.EndsWith("/") && subUrl.StartsWith("/")) // Next check if the base url does not end with a '/' and the sub url starts with a '/'
                return baseUrl + subUrl;
            else
            {
                // At this point we know that both urls either contains the '/' character or not at all
                if (subUrl.StartsWith("/") && baseUrl.EndsWith("/"))
                    return baseUrl + subUrl.Substring(1);
                else
                    return baseUrl + "/" + subUrl;
            }
        }
        #endregion


    }
}
