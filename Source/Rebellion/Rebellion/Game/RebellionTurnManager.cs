using System;
using System.Collections.Generic;

using UnityEngine;

using Rebellion.Data;
using Rebellion.Presentation;
using Rebellion.Events;

namespace Rebellion.Game
{
    [System.Serializable]
    public class RebellionTurnManager
    {
        //public TestSpawnCharacter TestScript;
        private RebellionMain mRebellionMain;

        private List<CharacterView> mEntitiesInPlay = new List<CharacterView>();

        public void Initialize(RebellionMain rebellionMain)
        {
            mRebellionMain = rebellionMain;
            AddEventHandlers();
        }

        private void AddEventHandlers()
        {
            //TestScript.OnRoundStart.AddListener(OnRoundStartHandler);
            mRebellionMain.EntitySpawnFactory.EntitySpawnCallback.AddListener(OnEntitySpawnedHandler);
        }

        private void OnRoundStartHandler()
        {
            SortCharactersBySpeed(ref mEntitiesInPlay);
        }

        private void OnEntitySpawnedHandler(EntityView entityView, Vector3 position)
        {
            if (!(entityView is CharacterView))
            {
                return;
            }

            if (!mEntitiesInPlay.Contains(entityView as CharacterView))
            {
                mEntitiesInPlay.Add(entityView as CharacterView);
            }
        }

        private void SortCharactersBySpeed(ref List<CharacterView> characterList)
        {
            characterList.Sort(EntitySortMethods.SortCharactersBySpeedDescending);
        }
    }
}
