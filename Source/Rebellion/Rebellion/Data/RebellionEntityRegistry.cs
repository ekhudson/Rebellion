using System;
using System.Collections.Generic;

using UnityEngine;

namespace Rebellion.Data
{
    [System.Serializable]
    public class RebellionEntityRegistry : ScriptableObject
    {
        [System.Serializable]
        public class FactionEntry
        {
            public RebellionFaction FactionSettings;
            public CharacterAsset[] FactionCharacters;
        }

        public FactionEntry[] Factions;

        private Dictionary<string, CharacterAsset> mEntityDictionary = new Dictionary<string, CharacterAsset>();

        public void Initialize()
        {
            foreach (FactionEntry faction in Factions)
            {
                foreach (CharacterAsset asset in faction.FactionCharacters)
                {
                    TryAddCharacterToDictionary(asset);
                }
            }
        }

        private void TryAddCharacterToDictionary(CharacterAsset asset)
        {
            if (!mEntityDictionary.ContainsKey(asset.name))
            {
                mEntityDictionary.Add(asset.name, asset);
            }
            else
            {
                Debug.Log(string.Format("Tried to add entity {0}, but it already exists in the dictionary", asset.name));
            }
        }

        public EntityAsset TryGetEntityAsset(string entityName)
        {
            if (mEntityDictionary.ContainsKey(entityName))
            {
                return mEntityDictionary[entityName];
            }
            else
            {
                Debug.Log(string.Format("Tried to find entity {0}, but it wasn't present in the registry.", entityName));
                return null;
            }
        }
    }
}
