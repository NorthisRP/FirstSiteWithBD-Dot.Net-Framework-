using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace StoreKeys.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int KeyId { get; set; }
        public int UserId { get; set; }
        public DateTime date { get; set; }
    }
}