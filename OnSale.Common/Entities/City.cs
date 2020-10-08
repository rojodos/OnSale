using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OnSale.Common.Entities
{
    public class City
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0} should be contain less of {1} characters")]
        [Required]
        public string Name { get; set; }

        [JsonIgnore]
        [NotMapped]
        public int IdDepartment { get; set; }
        //other form to relate two tables, but this form have problems when i create the aoi services
        //public  Department Department { get; set; } for this i coment this line the relation in both direcctions have a cicle reference
        //[JsonIgnore]
        //public Department Department { get; set; }
    }

}
