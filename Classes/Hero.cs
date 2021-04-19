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

        public int[] HeroItemIds { get; set; }
        public int[] UnlockedTitleIds { get; set; }
        public int[] EquippedSkillIds { get; set; }

        public AvailableXP[] AvailableXP { get; set; }

        public Hero(Hero hero)
        {
            this.TitleId = hero.TitleId;
            this.Status = hero.Status;
            this.LastStandDifficulty = hero.LastStandDifficulty;
            this.Corruption = hero.Corruption;
        }
    }
}
