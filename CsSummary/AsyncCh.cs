using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CsSummary
{
    public class AsyncCh
    {
        /// <summary>
        /// Threadを使った非同期処理
        /// </summary>
        public void ThreadMethod()
        {
            Console.WriteLine("すごく重い処理(´・ω・｀)はじまり");
            Thread.Sleep(3000);
            Console.WriteLine("すごく重い処理(´・ω・｀)おわり");
        }

        /// <summary>
        /// Taskを使った非同期処理
        /// </summary>
        public void TaskMethod()
        {
            Task<string> task = Task.Run(() => {
                Console.WriteLine("すごく重い処理(´・ω・｀)はじまり");
                Thread.Sleep(5000);
                Console.WriteLine("すごく重い処理(´・ω・｀)おわり");

                return "hoge";
            });

            string result = task.Result;
            Console.WriteLine(result);
        }

        /// <summary>
        /// await, asyncをつかった場合
        /// </summary>
        /// <returns></returns>
        public async Task<string> AsyncMethod()
        {
            Console.WriteLine("すごく重い処理(´・ω・｀)はじまり");
            await Task.Delay(5000);  //非同期にしたい処理にawaitをつける
            Console.WriteLine("すごく重い処理(´・ω・｀)おわり");
            return "hoge";
        }

    }
}