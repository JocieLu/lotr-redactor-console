using System;
using System.Collections.Generic;
using System.Text;

namespace lotr_redactor_console.Classes
{
    class SavedGame
    {
        public string PartyName { get; set; }
        public string CurrentObjective { get; set; }
        public string RestTextOverride { get; set; }
        
        public string Path { get; set; }
        public string DescriptionHeroes { get; set; }
        public string Description { get; set; }

        public int Timestamp { get; set; }
        public int SaveIndex { get; set; }
        public int CampaignId { get; set; }
        public int CurrentAdventureId { get; set; }
        public int IsMidGameSave { get; set; }
        public int CurrentScene { get; set; }

        public int CampaignDifficulty { get; set; }
        public int LastStandsFailed { get; set; }
        public int overrideCutsceneId { get; set; }
        
        public bool IsHardcore { get; set; }

        public int[] ItemIds { get; set; }
        public int[] ProductIds { get; set; }
        public int[] CompletedAdventureIds { get; set; }
        public int[] AlternativeAdventureIds { get; set; }
        public int[] UsedEncounterIds { get; set; }
        public int[] UsedEncounterGroupIds { get; set; }
        public int[] UnlockedChainEncounterIds { get; set; }

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

        public void RemoveHero(Hero hero)
        {
            Heroes.Remove(hero);
        }
    }
}
