using UnityEngine;
using UnityEngine.UI;

namespace Rebellion.Game
{
    public class SetUIAlpha : MonoBehaviour
    {
        [SerializeField]
        private MaskableGraphic m_UIElement;

        private Color mElementColor = Color.white;

        public void SetAlpha(float alpha)
        {
            mElementColor = m_UIElement.color;
            mElementColor.a = alpha;
            m_UIElement.color = mElementColor;
        }
    }
}
