using System;

using UnityEngine;

using Rebellion.Data;
using Rebellion.Presentation;
using Rebellion.Events;

namespace Rebellion.Game
{
    [System.Serializable]
    public class EntitySpawnFactory
    {
        public LayerMask RaycastLayerMask;

        public EntitySpawnEvent EntitySpawnCallback = new EntitySpawnEvent();

        private RebellionMain mRebellionMain;

        private const float kSpawnRaycastDistance = 1000f;

        public void Initialize(RebellionMain rebellionMain)
        {
            mRebellionMain = rebellionMain;
        }
        
        public EntityView SpawnEntity<T>(string entityName, Vector3 position, bool isFlipped) where T : EntityAsset
        {
            RaycastHit hit;

            if (Physics.Raycast(position, Vector3.down, out hit, kSpawnRaycastDistance, RaycastLayerMask))
            {
                T entity = mRebellionMain.EntityRegistry.TryGetEntityAsset(entityName) as T;

                if (entity == null)
                {
                    Debug.Log(string.Format("Tried to spawn entity {0} at position {1}, but asset was null", entityName, position));
                    return null;
                }

                EntityView entView = (GameObject.Instantiate(entity.ViewSettings.ViewPrefab, hit.point, Quaternion.identity) as GameObject).GetComponent<EntityView>();

                entView.InitializeWithDependencies(mRebellionMain, entity);

                entView.SpriteReference.flipX = isFlipped;

                EntitySpawnCallback.Invoke(entView, hit.point);

                return entView;
            }
            else
            {
                Debug.Log(string.Format("Tried to spawn entity {0} at position {1}, but no ground was found", entityName, position));
                return null;
            }
        }
    }
}
