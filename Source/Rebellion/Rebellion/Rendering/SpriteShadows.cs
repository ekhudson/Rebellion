using System;

using UnityEngine;
using UnityEngine.Rendering;

namespace Rebellion.Rendering
{
    [ExecuteInEditMode]
    public class SpriteShadows : MonoBehaviour
    {
        public ShadowCastingMode ShadowCastingMode = ShadowCastingMode.On;
        public bool ReceiveShadows = false;

        private void Start()
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();

            if (renderer != null)
            {
                renderer.shadowCastingMode = ShadowCastingMode;
                renderer.receiveShadows = ReceiveShadows;
            }
        }
    }
}
