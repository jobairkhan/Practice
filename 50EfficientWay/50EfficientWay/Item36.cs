using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _50EfficientWay
{
    public static class Item36
    {
        public static void Execute()
        {
            Console.WriteLine();
            IEnumerable<string> urls = new List<string>()
                { 
                    "http://msdn.microsoft.com",
                    "http://msdn.microsoft.com/library/windows/apps/br211380.aspx",
                    "http://msdn.microsoft.com/en-us/library/hh290136.aspx",
                    "http://msdn.microsoft.com/en-us/library/dd470362.aspx",
                    "http://msdn.microsoft.com/en-us/library/fguyfuutyrtytryrtyrtyrtyrtyrt.aspx",
                };

            Console.WriteLine("Start Item 36");
            try
            {
                urls.RunAsync(url =>
                    startDownload(url),
                    task => finishDownload(task.AsyncState.ToString(), task.Result));
            }
            catch (AggregateException problems)
            {
                ReportAggregateError(problems);
            }
            
        }

        private static void RunAsync<T, TResult>(this IEnumerable<T> taskParms, Func<T, Task<TResult>> taskStarter, Action<Task<TResult>> taskFinisher)
        {
            taskParms.Select(parm => taskStarter(parm)).AsParallel().ForAll(t => t.ContinueWith(t2 => taskFinisher(t2)));
        }

        private static void ReportAggregateError(AggregateException aggregate)
        {
            foreach (var exception in aggregate.InnerExceptions)
                if (exception is AggregateException)
                    ReportAggregateError(
                    exception as AggregateException);
                else
                    Console.WriteLine("-- Item 36 --" + exception.Message);
        }

        private static Task<byte[]> startDownload(string url)
        {
            var tcs = new TaskCompletionSource<byte[]>(url);
            var wc = new WebClient();
            wc.DownloadDataCompleted += (sender, e) =>
            {
                if (e.UserState == tcs)
                {
                    if (e.Cancelled)
                        tcs.TrySetCanceled();
                    else if (e.Error != null)
                        tcs.TrySetException(e.Error);
                    else
                        tcs.TrySetResult(e.Result);
                }
            };
            wc.DownloadDataAsync(new Uri(url), tcs);
            return tcs.Task;
        }

        private static void finishDownload(string url, byte[] bytes)
        {
            Console.WriteLine("-- Item 36 -- Read {0} bytes from {1}", bytes.Length, url);
        }
    }
}
