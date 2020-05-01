using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using sm_coding_challenge.Models;
using smcodingchallenge.Models;

namespace sm_coding_challenge.Services.DataProvider
{
    public class DataProviderImpl : IDataProvider
    {
        public static TimeSpan Timeout = TimeSpan.FromSeconds(30);

        // Created one method to response to all different read requests with switching to main different actions as all the requests depends on one sigle point
        public async Task<ResponseModel> GetPlayers(IList<string> id, int flag)
        {
            var responseModels = new ResponseModel();
            var handler = new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };
            using (var client = new HttpClient(handler))
            {
                client.Timeout = Timeout;
                var response = await client.GetAsync("https://gist.githubusercontent.com/RichardD012/a81e0d1730555bc0d8856d1be980c803/raw/3fe73fafadf7e5b699f056e55396282ff45a124b/basic.json");
                var stringData = await response.Content.ReadAsStringAsync();

                var dataResponse = JsonConvert.DeserializeObject<DataResponseModel>(stringData, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.Auto });

                switch (flag)
                {
                    // Used LINQ to return multi or single player with no replication
                    case (int)PlayersFlagType.players:
                        responseModels.Passing.AddRange(dataResponse.Passing.Where(a => id.Contains(a.Id)).ToList());
                        responseModels.Rushing.AddRange(dataResponse.Rushing.Where(a => id.Contains(a.Id)).ToList());
                        responseModels.Receiving.AddRange(dataResponse.Receiving.Where(a => id.Contains(a.Id)).ToList());
                        responseModels.Kicking.AddRange(dataResponse.Kicking.Where(a => id.Contains(a.Id)).ToList());
                        break;
                    // The request and business was not clear if latest player is first on apperance or last, so assumed last and returned it
                    case (int)PlayersFlagType.latestPlayers:
                        responseModels.Passing.Add(dataResponse.Passing.LastOrDefault());
                        responseModels.Receiving.Add(dataResponse.Receiving.LastOrDefault());
                        responseModels.Kicking.Add(dataResponse.Kicking.LastOrDefault());
                        responseModels.Rushing.Add(dataResponse.Rushing.LastOrDefault());
                        break;
                    // The business was not clear why to request exactly 1000 player, so assumed that it needs all players and thus combined them
                    case (int)PlayersFlagType.allPlayers:
                        responseModels.Passing.AddRange(dataResponse.Passing.ToList());
                        responseModels.Receiving.AddRange(dataResponse.Receiving.ToList());
                        responseModels.Kicking.AddRange(dataResponse.Kicking.ToList());
                        responseModels.Rushing.AddRange(dataResponse.Rushing.ToList());
                        break;

                }

                return responseModels;

            }

        }

    }
}
