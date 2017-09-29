using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace ChocolatesGallery.Models
{
    [Serializable]
    public class AzureSearchService
    {
        private static readonly string QueryString = $"https://{WebConfigurationManager.AppSettings["SearchName"]}.search.windows.net/indexes/{WebConfigurationManager.AppSettings["IndexName"]}/docs?api-key={WebConfigurationManager.AppSettings["SearchKey"]}&api-version=2015-02-28&";

        public async Task<SearchResult> SearchByChocolateName(string name)
        {
            using (var httpClient = new HttpClient())
            {
                string nameQuey = $"{QueryString}search={name}";
                try
                {
                    string response = await httpClient.GetStringAsync(nameQuey);
                    return JsonConvert.DeserializeObject<SearchResult>(response);
                }
                catch (Exception ex)
                {

                    string e = ex.Message;
                }

                return (new SearchResult());
            
            }
        }


    }
}