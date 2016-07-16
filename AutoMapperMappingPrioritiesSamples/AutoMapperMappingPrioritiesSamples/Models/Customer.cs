using System;

namespace AutoMapperMappingPrioritiesSamples.Models
{
    public abstract class Customer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}