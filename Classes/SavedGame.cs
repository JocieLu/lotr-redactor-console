using System;
using System.Collections.Generic;
using System.Text;

namespace lotr_redactor_console.Classes
{
    class SavedGame
    {
        public string PartyName { get; set; }
        
        public string Path { get; set; }
        public string Description { get; set; }

        public List<Hero> HeroInfo { get; set; }

        public SavedGame(string partyName, string path, List<Hero> heroes)
        {
            this.PartyName = partyName;
            this.Path = path;
            this.HeroInfo = heroes;
        }

        public void AddHero(Hero hero)
        {
            HeroInfo.Add(hero);
        }

        public void RemoveHero(Hero hero)
        {
            HeroInfo.Remove(hero);
        }
    }
}
