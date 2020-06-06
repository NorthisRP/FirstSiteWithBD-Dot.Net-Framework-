using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreKeys.Models
{
    public class Key
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Tag {get; set; }
        public string Img { get; set; }

    }
}