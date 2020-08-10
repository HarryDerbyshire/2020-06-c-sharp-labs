using System;
using System.Collections.Generic;

namespace api_safari_entity_core.Models
{
    public partial class Animal
    {
        public long AnimalId { get; set; }
        public string AnimalName { get; set; }
        public long? TypeId { get; set; }

        public virtual AnimalType Type { get; set; }
    }
}
