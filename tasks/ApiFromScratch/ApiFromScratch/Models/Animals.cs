using System;
using System.Collections.Generic;

namespace ApiFromScratch.Models
{
    public partial class Animals
    {
        public int AnimalId { get; set; }
        public string AnimalName { get; set; }
        public int? AnimalTypeId { get; set; }

        public virtual AnimalTypes AnimalType { get; set; }
    }
}
