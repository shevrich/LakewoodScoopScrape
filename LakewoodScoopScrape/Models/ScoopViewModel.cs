using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LakewoodScoop.Api;

namespace LakewoodScoopScrape.Models
{
    public class ScoopViewModel
    {
        public IEnumerable<LkwdScoopItem> Items { get; set; }
    }
}