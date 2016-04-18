using System.Collections.Generic;

namespace BotBits
{
    internal static class VarintHelper
    {
        public static int[] ToInt32Array(byte[] bytes)
        {
            var shift = 0;
            var result = 0;

            var results = new List<int>();

            foreach (var byteValue in bytes)
            {
                var tmp = byteValue & 0x7f;
                result |= tmp << shift;

                if ((byteValue & 0x80) != 0x80)
                {
                    results.Add(result);
                    result = 0;
                    shift = 0;
                    continue;
                }

                shift += 7;
            }

            return results.ToArray();
        }
    }
}
