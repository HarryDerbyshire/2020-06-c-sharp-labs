using System;
using System.Collections.Generic;

namespace api_safari_entity_core.Models
{
    public partial class AnimalType
    {
        public AnimalType()
        {
            Animals = new HashSet<Animal>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public int? NumberOfLegs { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}
