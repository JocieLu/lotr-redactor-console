using System;
using System.Collections.Generic;
using System.Text;

namespace lotr_redactor_console.Classes
{
    class SavedGame
    {
        public string Path { get; set; }
        public string PartyName{ get; set; }

        public List<Hero> Heroes { get; set; }

        public SavedGame(string partyName, string path, List<Hero> heroes)
        {
            this.PartyName = partyName;
            this.Path = path;
            this.Heroes = heroes;
        }

        public void AddHero(Hero hero)
        {
            Heroes.Add(hero);
        }
    }
}
