using System;

using UnityEngine;

using Rebellion.Data.Stats;

namespace Rebellion.Data
{
    [System.Serializable]
    public class CharacterData
    {
        public Sprite CharacterSprite;
        public string CharacterName = string.Empty;
        [Space]

        public HealthStat Health;
        public CoverProvidedStat CoverProvided;
        public SpeedStat Speed;

        public void Initialize()
        {
            CoverProvided.Initialize();
            Health.Initialize();
            Speed.Initialize();
        }
    }
}
