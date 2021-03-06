using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsOffered { get; set; }
        public bool IsSold { get; set; }
        public bool CanOffer { get; set; }
        public string ImagePath { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }
}
