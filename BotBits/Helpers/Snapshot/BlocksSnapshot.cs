using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
 using BotBits.Events;

namespace BotBits
{
    public class BlocksSnapshot : IWorld<ForegroundBlock, BackgroundBlock>, 
        IWorldAreaEnumerable<ForegroundBlock, BackgroundBlock>
    {
        private Blocks Blocks { get; }

        public BlocksSnapshot(Blocks blocks)
        {
            this.Blocks = blocks;
            this.Background = new SnapshotBlockLayer<BackgroundBlock>(
                blocks.GetExpectedBackground,  blocks.Background);
            this.Foreground = new SnapshotBlockLayer<ForegroundBlock>(
                blocks.GetExpectedForeground, blocks.Foreground);
        }

        public int Width => this.Blocks.Width;
        public int Height => this.Blocks.Height;

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

            this.Foreground.RestoreHistory();
            this.Background.RestoreHistory();
        }

        public void Sync()
        {
            this.StageAll();

            this.Foreground.DeleteStagedChanges(fgs =>
            {
                foreach (var fg in fgs)
                {
                    this.Blocks.Place(fg.Key.X, fg.Key.Y, fg.Value);
                }
            });

            this.Background.DeleteStagedChanges(bgs =>
            {
                foreach (var bg in bgs)
                {
                    this.Blocks.Place(bg.Key.X, bg.Key.Y, bg.Value);
                }
            });
        }
    }
}