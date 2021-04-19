using System;
using System.Collections.Generic;
using System.Text;

namespace lotr_redactor_console.Classes
{
    class Hero
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public int Status { get; set; }
        public int LastStandDifficulty { get; set; }
        public int RoleId { get; set; }
        public int Corruption { get; set; }

        List<int> HeroItemIds { get; set; }
        List<int> UnlockedTitleIds { get; set; }
        List<int> EquippedSkillIds { get; set; }

        List<AvailableXP> AvailableXP { get; set; }
    }
}
