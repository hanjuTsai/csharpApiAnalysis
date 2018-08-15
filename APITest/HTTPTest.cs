using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Json;
using System.Diagnostics;

namespace APITest
{
    public static class HTTPTest
    {
		private const string ApiBaseUrl = "http://localhost:8080/api/patients";
		private static HttpClient SecureHttpClient(string token)
        {

            if (string.IsNullOrEmpty(token))
            {
                throw new ArgumentException("Token cannot be null");
            }
            var http = new HttpClient();
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return http;
        }
		public static async Task<long> Test()
        {
			//Secure the httpclient
			var http = SecureHttpClient(APITest.Program.token);
			var result = await http.GetAsync(ApiBaseUrl);

			//if the code isn't success throw the exception
            if (!result.IsSuccessStatusCode)
            {
				throw new Exception("Api error!!");
            }

            //Start to count the time
			var watch = Stopwatch.StartNew();

            //Serialization         
            var body = result.Content.ReadAsStringAsync();
			var jsonBody = await Json.ToObjectAsync<ObservableCollection<Patient>>(body.ToString());

            //For counting the time of serialization
            watch.Stop();
			var elapsedMs = watch.ElapsedMilliseconds;
			return elapsedMs;
        }
    }
}
