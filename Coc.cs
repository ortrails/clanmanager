using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clanmanager
{
    public class IconUrls
    {
        public string small { get; set; }
        public string tiny { get; set; }
        public string medium { get; set; }
    }

    public class League
    {
        public int id { get; set; }
        public string name { get; set; }
        public IconUrls iconUrls { get; set; }
    }

    public class Item
    {
        public string tag { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public int expLevel { get; set; }
        public League league { get; set; }
        public int trophies { get; set; }
        public int versusTrophies { get; set; }
        public int clanRank { get; set; }
        public int previousClanRank { get; set; }
        public int donations { get; set; }
        public int donationsReceived { get; set; }
    }

    public class Cursors
    {
    }

    public class Paging
    {
        public Cursors cursors { get; set; }
    }

    public class Member
    {
        public List<Item> items { get; set; }
        public Paging paging { get; set; }
    }

    public class BadgeUrls
    {
        public string small { get; set; }
        public string large { get; set; }
        public string medium { get; set; }
    }

    public class Clan
    {
        public string tag { get; set; }
        public string name { get; set; }
        public int clanLevel { get; set; }
        public BadgeUrls badgeUrls { get; set; }
    }

    public class Achievement
    {
        public string name { get; set; }
        public int stars { get; set; }
        public int value { get; set; }
        public int target { get; set; }
        public string info { get; set; }
        public string completionInfo { get; set; }
        public string village { get; set; }
    }

    public class Troop
    {
        public string name { get; set; }
        public int level { get; set; }
        public int maxLevel { get; set; }
        public string village { get; set; }
    }

    public class Hero
    {
        public string name { get; set; }
        public int level { get; set; }
        public int maxLevel { get; set; }
        public string village { get; set; }
    }

    public class Spell
    {
        public string name { get; set; }
        public int level { get; set; }
        public int maxLevel { get; set; }
        public string village { get; set; }
    }

    public class Player
    {
        public string tag { get; set; }
        public string name { get; set; }
        public int townHallLevel { get; set; }
        public int expLevel { get; set; }
        public int trophies { get; set; }
        public int bestTrophies { get; set; }
        public int warStars { get; set; }
        public int attackWins { get; set; }
        public int defenseWins { get; set; }
        public int builderHallLevel { get; set; }
        public int versusTrophies { get; set; }
        public int bestVersusTrophies { get; set; }
        public int versusBattleWins { get; set; }
        public string role { get; set; }
        public int donations { get; set; }
        public int donationsReceived { get; set; }
        public Clan clan { get; set; }
        public League league { get; set; }
        public List<Achievement> achievements { get; set; }
        public int versusBattleWinCount { get; set; }
        public List<Troop> troops { get; set; }
        public List<Hero> heroes { get; set; }
        public List<Spell> spells { get; set; }
    }
}
