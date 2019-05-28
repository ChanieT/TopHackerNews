using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Data
{
    public class NewsApi
    {
        public IEnumerable<News> GetNews()
        {
            List<News> news = new List<News>();
            foreach (int id in GetTopTwenty().Take(20))
            {
                var client = new HttpClient();
                string url = $"https://hacker-news.firebaseio.com/v0/item/{id}.json?print=pretty";
                string json = client.GetStringAsync(url).Result;
                news.Add(JsonConvert.DeserializeObject<News>(json));
            }
            return news;

        }

        public IEnumerable<int> GetTopTwenty()
        {
            var client = new HttpClient();
            string url = "https://hacker-news.firebaseio.com/v0/topstories.json?print=pretty";
            string json = client.GetStringAsync(url).Result;
            var result = JsonConvert.DeserializeObject<IEnumerable<int>>(json);
            return result;
        }
    }

    public class News
    {
        public string Title { get; set; }
        public string Url { get; set; }
    }
}
