using System;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using RestSharp.Serializers;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.Generic;

namespace APITest
{
	public static class RestTest
	{
		public static string ApiBaseUrl {get;set;} = "http://localhost:8080/api/patients";
		public static async Task<long> Test()
        {
            var watch = Stopwatch.StartNew();

            //Set up client and request
            var client = new RestClient();
            client.BaseUrl = new Uri(ApiBaseUrl);
            RestRequest request = new RestRequest(Method.GET);

            //Authorization
            request.AddHeader("authorization", "Bearer " + APITest.Program.token);

       
            RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            IRestResponse getResponse = client.Execute(request);
            request.JsonSerializer = new RestSharp.Serializers.JsonSerializer();


            IRestResponse response = client.Execute(request);
            var jsonBody = await Json.ToObjectAsync<ObservableCollection<Patient>>(response.Content);
         

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;

            return elapsedMs;
        }
    }
}
