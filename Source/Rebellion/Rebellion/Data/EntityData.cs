using System;

using UnityEngine;

using Rebellion.Data.Stats;

namespace Rebellion.Data
{
    public class EntityData
    {
        public CoverProvidedStat CoverProvided;
        public HealthStat Health;

        public virtual void Initialize()
        {
            CoverProvided.Initialize();
            Health.Initialize();
        }
    }
}
