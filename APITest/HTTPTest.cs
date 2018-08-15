using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Diagnostics;

namespace APITest
{
    public static class HTTPTest
    {
        public static long Test()
        {
            //Start to count the time
            var watch = Stopwatch.StartNew();

            var http = new HttpClient();
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Program.token);
            var result = http.GetAsync(Program.ApiBaseUrl).Result;

            // Serialization         
            var body = result.Content.ReadAsStringAsync();
            var jsonBody = Json.ToObjectAsync<Patient[]>(body.Result).Result;

            // For counting the time of serialization
            watch.Stop();
			var elapsedMs = watch.ElapsedMilliseconds;
            Console.Write(elapsedMs + " ");
			return elapsedMs;
        }
    }
}
