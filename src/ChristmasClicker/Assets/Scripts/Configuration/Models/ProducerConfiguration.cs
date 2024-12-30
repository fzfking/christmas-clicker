using System;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace Configuration.Models
{
    [Serializable]
    public class ProducerConfiguration
    {
        public string Id;
        public List<ProducerModifierConfiguration> Modifiers;
        public long BasePrice;
        public long BaseProduction;
        public float BaseProductionTime;
        public int SortOrder;
    }
}