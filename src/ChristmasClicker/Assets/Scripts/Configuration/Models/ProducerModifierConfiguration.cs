using System;

// ReSharper disable InconsistentNaming

namespace Configuration.Models
{
    [Serializable]
    public class ProducerModifierConfiguration
    {
        public long FromLevel;
        public float ProductionMultiplier;
        public float ProductionTimeOffset;
    }
}