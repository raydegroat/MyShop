using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class BasketItem : BaseEntity
    {
        public string BaskerId { get; set; }
        public string ProdcutId { get; set; }
        public int Quantity { get; set; }
    }
}
