using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace bio_eko_fit_database.Entities
{
    class MenuEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
