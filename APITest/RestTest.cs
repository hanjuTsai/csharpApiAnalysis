using System;
using RestSharp;
using System.Threading.Tasks;
using System.Diagnostics;

namespace APITest
{
    public static class RestTest
	{
		public static long Test()
        {
            var watch = Stopwatch.StartNew();

            // Set up client and request
            var client = new RestClient();
            client.BaseUrl = new Uri(Program.ApiBaseUrl);
            RestRequest request = new RestRequest(Method.GET);

            ////Authorization
            //request.AddHeader();
            //RestSharp.Deserializers.JsonDeserializer deserial = new RestSharp.Deserializers.JsonDeserializer();
            //IRestResponse getResponse = client.Execute(request);
            //request.JsonSerializer = new RestSharp.Serializers.JsonSerializer();


            IRestResponse response = client.Execute(request);
            var result = response.Content;
            //var jsonBody = Json.ToObjectAsync<Patient[]>(response.Content).Result;

            watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
            //Console.Write(elapsedMs + " ");
            //Console.Write(result);

            return elapsedMs;
        }
    }
}
