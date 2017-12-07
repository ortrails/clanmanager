using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clanmanager.Models
{
    public class MaxLevels
    {
        public MaxLevels() 
        {
            Troops = new Dictionary<string, Dictionary<int, int>>
            {
                {
                    "TOTAL", new Dictionary<int, int>()
                    {
                        {3, 6},
                        {4, 12},
                        {5, 17},
                        {6, 21},
                        {7, 36},
                        {8, 56},
                        {9, 76},
                        {10, 98},
                        {11, 115}
                    }
                }
            };

            Spells = new Dictionary<string, Dictionary<int, int>>
            {
                {
                    "TOTAL", new Dictionary<int, int>()
                    {
                        {3, 2},
                        {4, 5},
                        {5, 8},
                        {6, 10},
                        {7, 14},
                        {8, 21},
                        {9, 29},
                        {10, 45},
                        {11, 50}
                    }
                }
            };

            Heroes = new Dictionary<string, Dictionary<int, int>>
            {
                {
                    "TOTAL", new Dictionary<int, int>()
                    {
                        {3, 0},
                        {4, 0},
                        {5, 0},
                        {6, 0},
                        {7, 5},
                        {8, 10},
                        {9, 60},
                        {10, 80},
                        {11, 110}
                    }
                }
            };
        }
        
        public Dictionary<string, Dictionary<int, int>> Troops { get; }
        
        public Dictionary<string, Dictionary<int, int>> Spells { get; }

        public Dictionary<string, Dictionary<int, int>> Heroes { get; }

    }
}
