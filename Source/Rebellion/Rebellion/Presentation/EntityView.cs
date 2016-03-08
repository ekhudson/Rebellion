using System;

using UnityEngine;
using UnityEngine.Events;

using Rebellion.Data;

namespace Rebellion.Presentation
{
    public class EntityView : MonoBehaviour
    {
        public SpriteRenderer SpriteReference;
        
        public virtual void InitializeWithDependencies(RebellionMain rebellionMain, EntityAsset entityAsset)
        {

        }
    }
}
