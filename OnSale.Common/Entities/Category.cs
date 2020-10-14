using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnSale.Common.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} should be contain less of {1} characters")]
        [Required]
        public string Name { get; set; }

        

        //TODO: Pending to put the correct paths
        
        [Display(Name = "Imagen")]
        public string ImagePath { get; set; }

        //[Display(Name = "Image")]
        //public string ImageFullPath => ImageId == Guid.Empty
        //    ? $"https://localhost:44390/images/noimage.png"
        //    : $"https://onsale.blob.core.windows.net/products/{ImageId}";


    }
}
