using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Refit;

namespace APITest
{
    public static class RefitTest
	{
		public interface PatientApi
        {
			[Get("")]
            Task<string> GetUser();

        }
		public static long Test()
		{
			//Start to count the time
            var watch = Stopwatch.StartNew();

            var Url = Program.ApiBaseUrl;
			var Api = RestService.For<PatientApi>(Url);
			var Result = Api.GetUser().Result.ToString();


			watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
			//Console.Write(elapsedMs + " ");
			//Console.WriteLine(Result);
            return elapsedMs;
            
		}
   
    }



}
