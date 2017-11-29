using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clanmanager.ViewModels
{
    public class MemberViewModel
    {
        ////interface Items
        ////{
        ////    tag: string;
        ////    name: string;
        ////    role: string;
        ////    expLevel: number;
        ////}
        
        public string Tag { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public int ExpLevel { get; set; }
        public int TroopLevel { get; set; }
    }
}
