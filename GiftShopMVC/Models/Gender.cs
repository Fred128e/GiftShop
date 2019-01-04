using System;
using System.Collections.Generic;

namespace GiftShop.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Gift = new HashSet<Gift>();
        }

        public int GenderId { get; set; }
        public string Gender1 { get; set; }

        public ICollection<Gift> Gift { get; set; }
    }
}
