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
			[Get("/patients")]
			Task<Patient[]> GetUser([Header("Authorization")] string bearerToken);

        }
		public static long Test()
		{
			//Start to count the time
            var watch = Stopwatch.StartNew();

			var Url = "http://localhost:8080/api";
			var Api = RestService.For<PatientApi>(Url);
			var Result = Api.GetUser("Bearer " + APITest.Program.token).Result.ToString();


			watch.Stop();
            var elapsedMs = watch.ElapsedMilliseconds;
			//Console.WriteLine(elapsedMs + " ");
			Console.WriteLine(Result);
            return elapsedMs;
            
		}
   
    }



}
