using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingStore.Models
{
    
    public class Item
    {
        [ScaffoldColumn(false)]
       public int ItemId { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }

        [DisplayName("Producer")]
        public int ProducerId { get; set; }

        [Required(ErrorMessage ="An Item title is required")]
        [StringLength(160)]
        public string Title { get; set; }

        [Required(ErrorMessage ="Price is Required")]
        [Range(0.1,10000,ErrorMessage ="Price must be between 0.1 and 10000")]
        public decimal Price { get; set; }
        public string Description { get; set; }

        [DisplayName("Item Art Url")]
        [StringLength(1024)]
        public string ItemArtUrl { get; set; }
        public virtual Category Category { get; set; }
        public virtual Producer Producer { get; set; }
        public virtual List<OrderDetail>  OrderDetails { get; set; }
    }
}