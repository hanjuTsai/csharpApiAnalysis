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
            var len = args.Length;
            if (len == 0) {
                // TODO: no args
            } else if (len == 1) {
                long t = 0;
                int times = 1000;
                Console.WriteLine("please enter the number of byte");
                num = Int32.Parse(Console.ReadLine());
                ApiBaseUrl = string.Format(ApiBaseUrl, num);
                switch (args[0])
                {
                    case "http":
                        for (var i = 0; i < times; i++) {
                            t += HTTPTest.Test();
                        }
                        Console.WriteLine("Total time for http = {0} ms", t);
                        Console.WriteLine("Average time for http = {0} ms", t * 1.0 / times);
                        break;
                    case "restsharp":
                        for (var i = 0; i < times; i++)
                        {
                            t += RestTest.Test();
                        }
                        Console.WriteLine("Totaltime for restsharp = {0} ms", t);
                        Console.WriteLine("Average time for restsharp = {0} ms", t * 1.0 / times);
                        break;
                    case "refit":
						for (var i = 0; i < times; i++)
                        {
                            t += RefitTest.Test();
                        }
						Console.WriteLine("Totaltime for refit = {0} ms", t);
                        Console.WriteLine("Average time for refit = {0} ms", t * 1.0 / times);
                        break;
                }
            } else {
                Console.WriteLine("Error: only accept one argument!");
            }
        }
    }
}
