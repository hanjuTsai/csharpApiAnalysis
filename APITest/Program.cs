using System;
using System.Threading;
using System.Threading.Tasks;

namespace APITest
{

    class Program
	{
        public static int num = 0;
        public static string ApiBaseUrl { get; set; } = "http://localhost:8080/v1/generate/{0}";
        //public static string token = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJhZG1pbiIsImF1dGgiOiJST0xFX0FETUlOLFJPTEVfVVNFUiIsImV4cCI6MTUzNjcyMTcwN30.W-2GDUzxihpaIMpClSjjVCP_NwOfXTG6o1D2PELzyfOFS0MFHEgrJIce9849sFMShok2VPTZ6JfW6qMxSx-SCw";


		public static class AsyncHelper
        {
            private static readonly TaskFactory _taskFactory = new
                TaskFactory(CancellationToken.None,
                            TaskCreationOptions.None,
                            TaskContinuationOptions.None,
                            TaskScheduler.Default);

            public static TResult RunSync<TResult>(Func<Task<TResult>> func)
                => _taskFactory
                    .StartNew(func)
                    .Unwrap()
                    .GetAwaiter()
                    .GetResult();

            public static void RunSync(Func<Task> func)
                => _taskFactory
                    .StartNew(func)
                    .Unwrap()
                    .GetAwaiter()
                    .GetResult();
        }

		static void Main(string[] args)
        {

            int times = 1000;
            int[] bytearr = { 5, 10,  20, 100, 500, 1024, 2048, 4048 };


            for (int b = 0; b < bytearr.Length; b++){
                Console.WriteLine("--------------------{0}-bytes--------------------", bytearr[b]);
                num = bytearr[b];
                ApiBaseUrl = string.Format(ApiBaseUrl, num);

                for (int j = 0; j <= 2; j++)
                {
                    long t = 0;
                    switch (j)
                    {
                        case 0:
                            for (var i = 0; i < times; i++)
                            {
                                t += HTTPTest.Test();
                            }
                            //Console.WriteLine("Total time for http = {0} ms", t);
                            //Console.WriteLine("Average time for http = {0} ms", t * 1.0 / times);
                            Console.WriteLine(t * 1.0 / times);
                            break;
                        case 1:
                            for (var i = 0; i < times; i++)
                            {
                                t += RestTest.Test();
                            }
                            //Console.WriteLine("Totaltime for restsharp = {0} ms", t);
                            //Console.WriteLine("Average time for restsharp = {0} ms", t * 1.0 / times);
                            Console.WriteLine(t * 1.0 / times);
                            break;
                        case 2:
                            for (var i = 0; i < times; i++)
                            {
                                t += RefitTest.Test();
                            }
                            //Console.WriteLine("Totaltime for refit = {0} ms", t);
                            //Console.WriteLine("Average time for refit = {0} ms", t * 1.0 / times);
                            Console.WriteLine(t * 1.0 / times);
                            break;
                    }
                }

            }

        }
    }
}
