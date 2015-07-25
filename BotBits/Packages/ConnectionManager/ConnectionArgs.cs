using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BotBits
{
    public class ConnectionArgs
    {
        public ShopData ShopData { get; set; }
        public PlayerObject PlayerObject { get; set; }

        public ConnectionArgs(ShopData shopData, PlayerObject playerObject)
        {
            this.ShopData = shopData;
            this.PlayerObject = playerObject;
        }

        public ConnectionArgs()
        {

        }
    }
}
