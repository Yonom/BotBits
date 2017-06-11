using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using BotBits.SendMessages;
using PlayerIOClient;

namespace BotBits
{
    public class StaffRoleData
    {
        public string Username { get; }
        public StaffRole Role { get; }

        public StaffRoleData(string username, StaffRole role)
        {
            this.Username = username;
            this.Role = role;
        }

        public static StaffRoleData[] GetStaffRoles(DatabaseObject obj)
        {
            return obj.Properties
                .Select(prop => new StaffRoleData(prop, (StaffRole)Enum.Parse(typeof(StaffRole), obj.GetString(prop))))
                .ToArray();
        }
    }
}