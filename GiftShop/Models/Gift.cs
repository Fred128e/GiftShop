﻿using System;
using System.Collections.Generic;

namespace GiftShop.Models
{
    public partial class Gift
    {
        public int GiftId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int GenderId { get; set; }
        public byte[] Rowversion { get; set; }

        public Gender Gender { get; set; }
    }
}
