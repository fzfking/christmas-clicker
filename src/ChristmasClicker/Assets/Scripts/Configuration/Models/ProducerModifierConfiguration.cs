using System;

// ReSharper disable InconsistentNaming

namespace Configuration.Models
{
    [Serializable]
    public class ProducerModifierConfiguration
    {
        public float ProductionMultiplier;
        public float ProductionTimeOffset;
    }
}