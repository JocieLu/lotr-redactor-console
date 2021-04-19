using System;
using System.Collections.Generic;
using System.Text;

namespace lotr_redactor_console.Classes
{
    class AvailableXP
    {
        public int RoleId { get; set; }
        public int XP { get; set; }

        public AvailableXP(int roleId, int xp)
        {
            this.RoleId = roleId;
            this.XP = xp;
        }
    }
}
