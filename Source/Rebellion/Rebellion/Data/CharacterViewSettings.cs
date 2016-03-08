using System;

using UnityEngine;

namespace Rebellion.Data
{
    public class CharacterViewSettings : EntityViewSettings
    {
        public GameObject HealthBarPrefab;
        public GameObject HealthReadoutPrefab;

        public Vector3 HealthBarOffset = Vector3.zero;
    }
}
