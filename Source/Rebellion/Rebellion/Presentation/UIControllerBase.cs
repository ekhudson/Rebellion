using System;

using UnityEngine;
using UnityEngine.UI;

namespace Rebellion.Presentation
{
    public class UIControllerBase : MonoBehaviour
    {
        protected Canvas mCanvasReference;

        protected RebellionMain mRebellionMain = null;

        protected RectTransform mRectTransform = null;

        public RectTransform RectTransform
        {
            get
            {
                if (mRectTransform == null)
                {
                    mRectTransform = GetComponent<RectTransform>();
                }

                return mRectTransform;
            }
        }

        private void Start()
        {
            mCanvasReference = GetComponent<Canvas>();
        }

        public void Init(RebellionMain rebellionMain)
        {
            mRebellionMain = rebellionMain;
        }

        public T AddUIElement<T>(GameObject elementPrefab) where T : UnityEngine.Object
        {
            GameObject element = GameObject.Instantiate(elementPrefab);

            element.transform.SetParent(transform, false);

            return element.GetComponent<T>();
        }

        public GameObject AddUIElement(GameObject elementPrefab)
        {
            GameObject element = GameObject.Instantiate(elementPrefab);

            element.transform.SetParent(transform, false);

            return element as GameObject;
        }
    }
}
