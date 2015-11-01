using System.Collections;
using System.Collections.Generic;

namespace BotBits
{
    public class WorldAreaEnumerable<TForeground, TBackground> : IWorldAreaEnumerable<TForeground, TBackground>
        where TForeground : struct
        where TBackground : struct
    {
        public WorldAreaEnumerable(World<TForeground, TBackground> world, Rectangle area)
        {
            this.World = world;
            this.Area = area;
        }

        public World<TForeground, TBackground> World { get; }
        public Rectangle Area { get; }

        public IEnumerator<WorldItem<TForeground, TBackground>> GetEnumerator()
        {
            for (var y = this.Area.Top; y <= this.Area.Bottom; y++)
                for (var x = this.Area.Left; x <= this.Area.Right; x++)
                    yield return new WorldItem<TForeground, TBackground>(
                        this.World, x, y);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}