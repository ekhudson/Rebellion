using System;

using UnityEngine;
using UnityEditor;

using Rebellion.Data;

namespace Rebellion.EditorStuff
{
    public class ScriptableObjectMenuEntries
    {
        [MenuItem("Assets/Create/Entity/Character/CharacterDataObject")]
        public static void CreateCharacterDataObject()
        {
            ScriptableObjectUtility.CreateAsset<CharacterDataObject>();
        }

        [MenuItem("Assets/Create/Entity/Character/CharacterAsset")]
        public static void CreateCharacterAsset()
        {
            ScriptableObjectUtility.CreateAsset<CharacterAsset>();
        }

        [MenuItem("Assets/Create/Entity/Character/CharacterViewSettings")]
        public static void CreateCharacterViewSettings()
        {
            ScriptableObjectUtility.CreateAsset<CharacterViewSettings>();
        }

        [MenuItem("Assets/Create/Entity/EntityRegistry")]
        public static void CreateEntityRegistry()
        {
            ScriptableObjectUtility.CreateAsset<RebellionEntityRegistry>();
        }
    }
}
