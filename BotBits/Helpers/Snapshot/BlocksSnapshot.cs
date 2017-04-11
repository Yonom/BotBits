using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
 using BotBits.Events;

namespace BotBits
{
    public class BlocksSnapshot : IWorld<ForegroundBlock, BackgroundBlock>, IWorldAreaEnumerable<ForegroundBlock, BackgroundBlock>
    {
        private readonly Blocks _parent;

        public BlocksSnapshot(Blocks parent)
        {
            this._parent = parent;
            this.Background = new SnapshotBlockLayer<BackgroundBlock>(
                parent.GetExpectedBackground,  parent.Background);
            this.Foreground = new SnapshotBlockLayer<ForegroundBlock>(
                parent.GetExpectedForeground, parent.Foreground);
        }

        public int Width => this._parent.Width;
        public int Height => this._parent.Height;

        public SnapshotBlockLayer<BackgroundBlock> Background { get; }
        public SnapshotBlockLayer<ForegroundBlock> Foreground { get; }

        IBlockLayer<BackgroundBlock> IWorld<ForegroundBlock, BackgroundBlock>.Background => this.Background;
        IBlockLayer<ForegroundBlock> IWorld<ForegroundBlock, BackgroundBlock>.Foreground => this.Foreground;
        IReadOnlyBlockLayer<BackgroundBlock> IReadOnlyWorld<ForegroundBlock, BackgroundBlock>.Background => this.Background;
        IReadOnlyBlockLayer<ForegroundBlock> IReadOnlyWorld<ForegroundBlock, BackgroundBlock>.Foreground => this.Foreground;

        public IEnumerator<WorldItem<ForegroundBlock, BackgroundBlock>> GetEnumerator()
        {
            return this.In(this.Area).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IWorld<ForegroundBlock, BackgroundBlock> World => this;
        public Rectangle Area => new Rectangle(0, 0, this.Width, this.Height);

        public void StageAll()
        {
            this.Foreground.StageAll();
            this.Background.StageAll();
        }

        public void DiscardAll()
        {
            this.Foreground.DiscardAll();
            this.Background.DiscardAll();
        }

        public void Save()
        {
            this.Foreground.PushHistory();
            this.Background.PushHistory();
        }

        public void Restore()
        {
            this.DiscardAll();

            var fgs = this.Foreground.PopHistory();
            for (var i = fgs.Count - 1; i >= 0; i--)
            {
                var fg = fgs[i];
                if (this.Foreground[fg.Location] == fg.NewBlock)
                    this.Foreground[fg.Location] = fg.OldBlock;
            }

            var bgs = this.Background.PopHistory();
            for (var i = bgs.Count - 1; i >= 0; i--)
            {
                var bg = bgs[i];
                if (this.Background[bg.Location] == bg.NewBlock)
                    this.Background[bg.Location] = bg.OldBlock;
            }

            this.StageAll();
        }

        public void Sync()
        {
            this.StageAll();

            foreach (var fg in this.Foreground.GetAndDeleteStagedChanges())
            {
                this._parent.Place(fg.Key.X, fg.Key.Y, fg.Value);
            }
            foreach (var bg in this.Background.GetAndDeleteStagedChanges())
            {
                this._parent.Place(bg.Key.X, bg.Key.Y, bg.Value);
            }
        }
    }
}