using System;
// ReSharper disable InconsistentNaming

namespace Configuration.Models
{
    [Serializable]
    public class GameConfiguration
    {
        public ResourceConfiguration[] Resources;
        public ProducerConfiguration[] Producers;
        public ManagerConfiguration[] Managers;
    }
}