using UnityEngine;
using UnityEngine.UI;

using Rebellion.Data;
using SimpleScript;

namespace Rebellion.Game
{
    public class GetPoolValueForUI : MonoBehaviour
    {
        [SerializeField]
        private ValuePoolBase m_ValuePoolReference;
        [SerializeField]
        private Text m_TextField;
        [SerializeField]
        private bool m_UpdateContinuously;

        private void Start()
        {
            UpdateUI();
        }

        private void Update()
        {
            if (m_UpdateContinuously)
            {
                UpdateUI();
            }
        }

        public void UpdateUI()
        {
            if (m_TextField != null)
            {
                m_TextField.text = m_ValuePoolReference.ValueAsString();
            }
        }
    }
}
