using UnityEngine;

using Rebellion.Data;
using Rebellion.Events;
using Rebellion.Game;
using Rebellion.Presentation;

namespace Rebellion
{
    public class TestSpawnCharacter : MonoBehaviour
    {
        [System.Serializable]
        public class Spawner
        {
            public Transform SpawnPosition;
            public CharacterAsset CharacterToSpawn;
        }

        public RebellionMain RebellionMainReference;
        public Spawner[] PlayerCharacters;
        public Spawner[] EnemyCharacters;

        public RoundStartEvent OnRoundStart = new RoundStartEvent();

        private void Awake()
        {
            RebellionMainReference.OnMainInitializedEvent.AddListener(ExecuteScript);
        }

        private void ExecuteScript()
        {
            if (PlayerCharacters.Length > 0)
            {
                foreach (Spawner spawner in PlayerCharacters)
                {
                    SpawnCharacterAtPosition(spawner.CharacterToSpawn, spawner.SpawnPosition.position, false);
                }
            }

            if (EnemyCharacters.Length > 0)
            {
                foreach (Spawner spawner in EnemyCharacters)
                {
                    SpawnCharacterAtPosition(spawner.CharacterToSpawn, spawner.SpawnPosition.position, true);
                }
            }

            OnRoundStart.Invoke();
        }

        private void SpawnCharacterAtPosition(CharacterAsset character, Vector3 position, bool faceLeft)
        {
            RebellionMainReference.EntitySpawnFactory.SpawnEntity<CharacterAsset>(character.name, position, faceLeft);
        }
    }
}
