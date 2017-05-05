using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PlayerIOClient;

namespace BotBits
{
    public static class DatabaseUtils
    {        /// <summary>
        /// Loads DatabaseObjects in an index, batches requests for large indexes
        /// </summary
        public static Task<List<DatabaseObject>> RecursiveLoadRangeAsync(Client client, string table, string index, object[] indexPath, object start, object stop, int limit, Func<DatabaseObject, object> indexPicker)
        {
            var results = new List<DatabaseObject>();
            return BatchLoadRangeAsync(client, table, index, indexPath, start, stop, limit, indexPicker, objs => results.AddRange(objs))
                .Then(t => results)
                .ToSafeTask();
        }

        public static Task BatchLoadRangeAsync(Client client, string table, string index, object[] indexPath, object start, object stop, int limit, Func<DatabaseObject, object> indexPicker, Action<List<DatabaseObject>> batchHandler)
        {
            const int loadLimit = 1000;

            return BatchLoadRangeAsyncInternal(0)
                .ToSafeTask();

            Task BatchLoadRangeAsyncInternal(int i)
            {
                var objectsToLoad = Math.Min(limit - i, loadLimit);
                return client.BigDB.LoadRangeAsync(table, index, indexPath, start, stop, objectsToLoad)
                    .Then(t =>
                    {
                        var results = t.Result.ToList();
                        var oldStart = start;

                        // Getting fewer items marks the end of our index
                        if (objectsToLoad > results.Count)
                            limit = i + results.Count;

                        // If we need another batch
                        if (limit - i > loadLimit)
                        {
                            // Set the last item as the start value for the next batch and remove it from our batch
                            start = indexPicker(results[results.Count - 1]);
                            results.RemoveAt(results.Count - 1);
                        }

                        batchHandler(results);

                        // If start didn't change, we cannot query any more worlds
                        if (limit - i <= loadLimit || oldStart == start)
                            return TaskHelper.FromResult(true);

                        return BatchLoadRangeAsyncInternal(i + loadLimit - 1);
                    });
            }
        }
    }
}
