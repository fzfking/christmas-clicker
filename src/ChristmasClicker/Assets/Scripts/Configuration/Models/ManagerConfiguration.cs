﻿using System;

// ReSharper disable InconsistentNaming

namespace Configuration.Models
{
    [Serializable]
    public class ManagerConfiguration
    {
        public string Id;
        public string AutomationProducerId;
        public string PriceResourceId;
        public long Price;
    }
}