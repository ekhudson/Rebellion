using System;

using UnityEngine;
using UnityEngine.Events;

using Rebellion.Data;

namespace Rebellion.Presentation
{
    public class EntityView : MonoBehaviour
    {
        public SpriteRenderer SpriteReference;
        public bool FaceCamera = true;
        public Vector3 CameraRotation = Vector3.zero;
        
        public virtual void InitializeWithDependencies(RebellionMain rebellionMain, EntityAsset entityAsset)
        {

        }

        protected virtual void Update()
        {
            if (FaceCamera)
            {
                CameraRotation = Camera.main.transform.localRotation.eulerAngles;
                Vector3 entRot = transform.rotation.eulerAngles;
                entRot.y = CameraRotation.y;
                transform.rotation = Quaternion.Euler(entRot);
            }
        }
    }
}
