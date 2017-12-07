using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using Clanmanager.ViewModels;
using Newtonsoft.Json;
using Clanmanager.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clanmanager.Controllers
{
    [Route("api/[controller]")]
    public class ClashOfClansController : Controller
    {
        private readonly HttpClient _client;
        
        //public const int Lab1 = 2 + 2 + 2 + 2;
        //public const int Lab2 = Lab1 + 2 + 2 + 2 + 3 + 2;
        //public const int Lab3 = Lab2 + 1 + 1 + 1 +


        public ClashOfClansController()
        {
            _client = new HttpClient();
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            //client.BaseAddress = new Uri("https://api.clashofclans.com/v1/clans/#cug2ppju/members");
            _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(
                "Bearer",
                "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImExNDYxZDBhLTRmNWUtNGRmZS1iNmEzLWYzODRmMDZkMzk3MSIsImlhdCI6MTUwNTgzMDQ4OSwic3ViIjoiZGV2ZWxvcGVyLzFlY2I3M2JkLTdkMjEtYzg2OC1jMTMwLTgwM2RjZDQzN2JlMSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjIwNi4xNjkuMTAwLjE2MiJdLCJ0eXBlIjoiY2xpZW50In1dfQ.UauB-MfJTO5iosANN9mKou_7GGr69x9EdHrASPadF86E2TrQP_f_z1n90-XM4vE0x5gO4cYyqnrZqHZCNWsTxA");

        }

        


        [HttpGet("members")]
        public List<MemberViewModel> Members()
        {
            string response = null;
            try
            {
                response = _client.GetStringAsync("https://api.clashofclans.com/v1/clans/%23cug2ppju/members").Result;
                
            }
            catch
            {
            }

            ////var client = new RestClient("https://api.clashofclans.com/v1/clans/");
            ////var request = new RestRequest("#cug2ppju/members");
            ////request.AddHeader("Authorization", "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiIsImtpZCI6IjI4YTMxOGY3LTAwMDAtYTFlYi03ZmExLTJjNzQzM2M2Y2NhNSJ9.eyJpc3MiOiJzdXBlcmNlbGwiLCJhdWQiOiJzdXBlcmNlbGw6Z2FtZWFwaSIsImp0aSI6ImExNDYxZDBhLTRmNWUtNGRmZS1iNmEzLWYzODRmMDZkMzk3MSIsImlhdCI6MTUwNTgzMDQ4OSwic3ViIjoiZGV2ZWxvcGVyLzFlY2I3M2JkLTdkMjEtYzg2OC1jMTMwLTgwM2RjZDQzN2JlMSIsInNjb3BlcyI6WyJjbGFzaCJdLCJsaW1pdHMiOlt7InRpZXIiOiJkZXZlbG9wZXIvc2lsdmVyIiwidHlwZSI6InRocm90dGxpbmcifSx7ImNpZHJzIjpbIjIwNi4xNjkuMTAwLjE2MiJdLCJ0eXBlIjoiY2xpZW50In1dfQ.UauB-MfJTO5iosANN9mKou_7GGr69x9EdHrASPadF86E2TrQP_f_z1n90-XM4vE0x5gO4cYyqnrZqHZCNWsTxA");
            ////IRestResponse response = client.Execute(request);
            ////var content = response.Content;

            Member member = JsonConvert.DeserializeObject<Member>(response);
            List<MemberViewModel> vmList = new List<MemberViewModel>();
            var maxLevels = new MaxLevels();

            foreach (var item in member.items)
            {
                var player = GetPlayer(item.tag);

                var homeTroops = player.Troops.Where(x => x.village == "home").ToList();
                var homeSpells = player.Spells.Where(x => x.village == "home").ToList();
                var heroes = player.Heroes.ToList();

                ////var king = player.Heroes.SingleOrDefault(x => x.name == "Barbarian King");
                ////var queen = player.Heroes.SingleOrDefault(x => x.name == "Archer Queen");

                vmList.Add(new MemberViewModel()
                {
                    Tag = item.tag,
                    ExpLevel = item.expLevel,
                    Name = item.name,
                    Role = item.role,
                    TroopLevel = homeTroops.Sum(troop => troop.level),
                    TroopMaxLevel = maxLevels.Troops["TOTAL"][player.TownHallLevel],
                    SpellLevel = homeSpells.Sum(spell => spell.level),
                    SpellMaxLevel = maxLevels.Spells["TOTAL"][player.TownHallLevel],
                    HeroesLevel = heroes.Sum(hero => hero.level),
                    HeroesMaxLevel = maxLevels.Heroes["TOTAL"][player.TownHallLevel]
                });
            }

            return vmList;
        }

        private PlayerViewModel GetPlayer(string tag)
        {
            var total = 0;
            tag = tag.TrimStart('#');
            var myUri = $"https://api.clashofclans.com/v1/players/%23{tag}";
            try
            {
                var response = _client.GetStringAsync(myUri).Result;
                var player = JsonConvert.DeserializeObject<PlayerViewModel>(response);
                return player;
            }
            catch
            {
                return null;
            }
        }

        ////private int GetTroopLevel(string tag)
        ////{
        ////    var total = 0;
        ////    tag = tag.TrimStart('#');
        ////    var myUri = $"https://api.clashofclans.com/v1/players/%23{tag}";
        ////    try
        ////    {
        ////        var response = _client.GetStringAsync(myUri).Result;
        ////        var player = JsonConvert.DeserializeObject<Player>(response);
        ////        return player.troops.Sum(troop => troop.level);
        ////    }
        ////    catch
        ////    {
        ////        return total;
        ////    }
        ////}

        [HttpGet("players/{tag}")]
        public Player Players([FromRoute] string tag)
        {
            var myUri = $"https://api.clashofclans.com/v1/players/%23{tag.TrimStart('#')}";
            string response = null;
            try
            {
                response = _client.GetStringAsync(myUri).Result;
            }
            catch
            {
            }

            Player player = JsonConvert.DeserializeObject<Player>(response);
            return player;
        }
    }

}
