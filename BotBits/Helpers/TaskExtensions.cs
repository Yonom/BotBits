using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotBits
{
    internal static class TaskExtensions
    {
        public static void WaitEx(this Task task)
        {
            try
            {
                task.Wait();
            }
            catch (AggregateException ex)
            {
                throw ex.Flatten().InnerExceptions.FirstOrDefault() ?? ex;
            }
        }

        public static T GetResultEx<T>(this Task<T> task)
        {
            try
            {
                return task.Result;
            }
            catch (AggregateException ex)
            {
                throw ex.Flatten().InnerExceptions.FirstOrDefault() ?? ex;
            }
        }
    }
}
