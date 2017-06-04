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
            public int SpawnRow;
            public int SpawnColumn;
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
                    Vector3 pos = RebellionMainReference.GridManager.GetWorldPositionOfTile(spawner.SpawnRow, spawner.SpawnColumn);
                    SpawnCharacterAtPosition(spawner.CharacterToSpawn, pos, false);
                }
            }

            if (EnemyCharacters.Length > 0)
            {
                foreach (Spawner spawner in EnemyCharacters)
                {
                    Vector3 enemyPos = RebellionMainReference.GridManager.GetWorldPositionOfTile(spawner.SpawnRow, spawner.SpawnColumn);
                    SpawnCharacterAtPosition(spawner.CharacterToSpawn, enemyPos, true);
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
