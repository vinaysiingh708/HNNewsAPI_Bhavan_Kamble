using HNNewsAPI.Data;
using HNNewsAPI.Services.Helpers;
using HNNewsAPI.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HNNewsAPI.Services.Implementations
{
    public class StoryService : IStoryService
    {
        ConfigurationSettingHelper _ConfigurationSettingHelper;
        public StoryService()
        {
            _ConfigurationSettingHelper = new ConfigurationSettingHelper();
        }
        public async Task<List<StoryModel>> GetStories()
        {
            var stories = new List<StoryModel>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_ConfigurationSettingHelper.NewsAPIBaseEndpoint);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //GET Method
                HttpResponseMessage response = await client.GetAsync("topstories.json?print=pretty");
                if (response.IsSuccessStatusCode)
                {
                    string stories1 = await response.Content.ReadAsStringAsync();

                    var json = JsonConvert.DeserializeObject(stories1);
                    var newjson = json.ToString().Replace(System.Environment.NewLine + "  ", string.Empty);

                       List<int> list = new List<int>(Convert.ToInt32(newjson));



                }
                else
                {
                    Console.WriteLine("Internal server Error");
                }
            }
            return stories;

        }
    }
}
