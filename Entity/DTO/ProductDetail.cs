using Core.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
    class ProductDetail : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsOffered { get; set; }
        public bool IsSold { get; set; }
        public bool CanOffer { get; set; }
        public string ImagePath { get; set; }
        public string ColorName { get; set; }
        public string BrandName { get; set; }
        public string CategoryName { get; set; }
    }
}
