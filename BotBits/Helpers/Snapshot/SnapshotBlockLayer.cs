using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BotBits
{
    public class SnapshotBlockLayer<T> : IBlockLayer<T> where T : struct, IEquatable<T>
    {
        private readonly Func<Point, T> _expectedBlocks;
        private readonly IReadOnlyBlockLayer<BlockData<T>> _innerLayer;
        private readonly Stack<List<SnapshotHistoryItem<T>>> _history = new Stack<List<SnapshotHistoryItem<T>>>();
        private readonly Dictionary<Point, T> _stagedChanges = new Dictionary<Point, T>();
        public Dictionary<Point, T> UnstagedChanges { get; } = new Dictionary<Point, T>();

        public SnapshotBlockLayer(Func<Point, T> expectedBlocks, IReadOnlyBlockLayer<BlockData<T>> innerLayer)
        {
            this._expectedBlocks = expectedBlocks;
            this._innerLayer = innerLayer;
        }

        public int Height => this._innerLayer.Height;
        public int Width => this._innerLayer.Width;

        public T this[int x, int y]
        {
            get { return this[new Point(x, y)]; }
            set { this[new Point(x, y)] = value; }
        }

        public T this[Point p]
        {
            get
            {
                T res;
                if (!this.UnstagedChanges.TryGetValue(p, out res))
                    if (!this._stagedChanges.TryGetValue(p, out res))
                        res = this._expectedBlocks(p);
                return res;
            }
            set { this.UnstagedChanges[p] = value; }
        }
        
        public IEnumerator<LayerItem<T>> GetEnumerator()
        {
            for (var y = 0; y < this.Height; y++)
                for (var x = 0; x < this.Width; x++)
                {
                    T res;
                    if (!this.UnstagedChanges.TryGetValue(new Point(x, y), out res))
                        if (!this._stagedChanges.TryGetValue(new Point(x, y), out res))
                            res = this._expectedBlocks(new Point(x, y));
                    yield return new LayerItem<T>(res, x, y);
                }
        }

        internal void PushHistory()
        {
            if (this.UnstagedChanges.Count > 0)
                throw new InvalidOperationException("You have unstaged changes, please stage all changes before using Save()");
            
            this._history.Push(new List<SnapshotHistoryItem<T>>());
        }

        private List<SnapshotHistoryItem<T>> PopHistory()
        {
            if (this._history.Count <= 0) return new List<SnapshotHistoryItem<T>>();
            return this._history.Pop();
        }

        internal void RestoreHistory()
        {
            var bgs = this.PopHistory();
            for (var i = bgs.Count - 1; i >= 0; i--)
            {
                var bg = bgs[i];
                if (this[bg.Location].Equals(bg.NewBlock))
                    this[bg.Location] = bg.OldBlock;
            }
        }

        public KeyValuePair<Point, T>[] GetAndDeleteStagedChanges()
        {
            var changes = this._stagedChanges.ToArray();
            this._stagedChanges.Clear();
            return changes;
        }

        public void Stage(Point p)
        {
            T change;
            if (this.UnstagedChanges.TryGetValue(p, out change))
            {
                this.UnstagedChanges.Remove(p);
                var old = this[p];
                this._stagedChanges[p] = change;

                if (this._history.Count > 0)
                    this._history.Peek().Add(new SnapshotHistoryItem<T>(p, old, change));
            }
        }

        public void StageAll()
        {
            while (this.UnstagedChanges.Count > 0)
            {
                this.Stage(this.UnstagedChanges.Keys.First());
            }
        }

        public void Discard(Point p)
        {
            this.UnstagedChanges.Remove(p);
        }

        public void DiscardAll()
        {
            this.UnstagedChanges.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}