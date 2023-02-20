using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission7_ejake370.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieId { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string year { get; set; }
        [Required]
        public string director { get; set; }

        [Required]
        public string rating { get; set; }
        public bool edited { get; set; }
        public string lentTo { get; set; }
        [StringLength(25)]
        public string notes { get; set; }


        //Build a foreign key relationship
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
