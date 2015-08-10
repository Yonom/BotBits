using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlayerIOClient;

namespace BotBits
{
    public class PlayerObject
    {
        private readonly DatabaseObject _databaseObject;

        public PlayerObject(DatabaseObject databaseObject)
        {
            this._databaseObject = databaseObject;
        }

        public bool ClubMember
        {
            get
            {
                return this._databaseObject.Contains("club_expire") &&
                       this._databaseObject.GetDateTime("club_expire") > DateTime.Now;
            }
        }

        public bool IsAdministrator
        {
            get { return this._databaseObject.GetBool("isAdministrator", false); }
        }
    }
}
