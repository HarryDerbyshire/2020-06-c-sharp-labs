using System;
using System.Collections.Generic;

namespace ApiFromScratch.Models
{
    public partial class AnimalTypes
    {
        public AnimalTypes()
        {
            Animals = new HashSet<Animals>();
        }

        public int AnimalTypeId { get; set; }
        public string TypeName { get; set; }

        public virtual ICollection<Animals> Animals { get; set; }
    }
}
