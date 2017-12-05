using MY.Northwind.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MY.Northwind.Entity.Concrete
{
    public class Product:IEntity
    {
        [Required]
        public int ProductID { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public decimal UnitPrice { get; set; }

        [Required]
        public short UnitsInStock { get; set; }
    }
}