﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace OnSale.Common.Entities
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} should be contain less of {1} characters")]
        [Required]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal Price { get; set; }

        [DisplayName("Is Active")]
        public bool IsActive { get; set; }

        [DisplayName("Is Starred")]
        public bool IsStarred { get; set; }

        public Category Category { get; set; }

        public ICollection<ProductImage> ProductImages { get; set; }

        [DisplayName("Product Images Number")]
        public int ProductImagesNumber => ProductImages == null ? 0 : ProductImages.Count;

        //TODO: Pending to put the correct paths
        [Display(Name = "Imagen")]
        public string ImagePath { get; set; }

    }

}
