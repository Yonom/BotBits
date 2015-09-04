using System.Collections;
using System.Collections.Generic;

namespace BotBits
{
    public class WorldAreaEnumerable<TForeground, TBackground> : IWorldAreaEnumerable<TForeground, TBackground>
        where TForeground : struct
        where TBackground : struct
    {
        public World<TForeground, TBackground> World { get; private set; }
        public Rectangle Area { get; private set; }

        public WorldAreaEnumerable(World<TForeground, TBackground> world, Rectangle area)
        {
            this.World = world;
            this.Area = area;
        }

        public IEnumerator<WorldItem<TForeground, TBackground>> GetEnumerator()
        {
            for (int y = this.Area.Top; y <= this.Area.Bottom; y++)
                for (int x = this.Area.Left; x <= this.Area.Right; x++)
                    yield return new WorldItem<TForeground, TBackground>(
                        this.World, x, y);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}