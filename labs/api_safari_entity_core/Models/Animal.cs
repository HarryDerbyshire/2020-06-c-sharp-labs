using System;
using System.Collections.Generic;

namespace api_safari_entity_core.Models
{
    public partial class Animal
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public int? TypeId { get; set; }

        public virtual AnimalType Type { get; set; }
    }
}
