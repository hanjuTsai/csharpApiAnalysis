using System;
using System.Threading;
using System.Threading.Tasks;

namespace APITest
{

    class Program
	{

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
		public static string token = "eyJhbGciOiJIUzUxMiJ9.eyJzdWIiOiJhZG1pbiIsImF1dGgiOiJST0xFX0FETUlOLFJPTEVfVVNFUiIsImV4cCI6MTUzNjcyMTcwN30.W-2GDUzxihpaIMpClSjjVCP_NwOfXTG6o1D2PELzyfOFS0MFHEgrJIce9849sFMShok2VPTZ6JfW6qMxSx-SCw";
		static void Main(string[] args)
        {
			//For Small Image
			int i = 0;
			while(true){
				i++;
				if (i%2==1)
                {
                    Console.WriteLine("Totaltime for http = {0} ms", AsyncHelper.RunSync<long>(HTTPTest.Test));
                }
                else
                {
                    Console.WriteLine("Totaltime for restsharp = {0} ms", AsyncHelper.RunSync<long>(RestTest.Test));
                };
				if(i==10){
					break;
				}
			}
			//Console.WriteLine("Totaltime = {0} ms",AsyncHelper.RunSync<long>(HTTPTest.Test));
			//Task.Delay(100000);
			//Console.WriteLine("Totaltime = {0} ms", AsyncHelper.RunSync<long>(RestTest.Test))
			//RestTest.Test();
			//Console.WriteLine("Totaltime = {0} ms", RestTest.Test());
			//Task.Delay(100000);
			///HTTPTest.Test();
			//Console.WriteLine("Totaltime = {0} ms", AsyncHelper.RunSync<long>(HTTPTest.Test));
        }      

    }
}
