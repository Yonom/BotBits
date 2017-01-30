using System.Collections;
using System.Collections.Generic;

namespace BotBits
{
    public class ReadOnlyWorldAreaEnumerable<TForeground, TBackground> : IReadOnlyWorldAreaEnumerable<TForeground, TBackground>
        where TForeground : struct
        where TBackground : struct
    {
        public ReadOnlyWorldAreaEnumerable(IReadOnlyWorld<TForeground, TBackground> world, Rectangle area)
        {
            this.World = world;
            this.Area = area;
        }

        public IReadOnlyWorld<TForeground, TBackground> World { get; }
        public Rectangle Area { get; }

        public IEnumerator<ReadOnlyWorldItem<TForeground, TBackground>> GetEnumerator()
        {
            for (var y = this.Area.Top; y <= this.Area.Bottom; y++)
                for (var x = this.Area.Left; x <= this.Area.Right; x++)
                    yield return new ReadOnlyWorldItem<TForeground, TBackground>(
                        this.World, x, y);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}