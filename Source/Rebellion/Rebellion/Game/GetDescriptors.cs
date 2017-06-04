using UnityEngine;
using UnityEngine.UI;

using Rebellion.Data;

namespace Rebellion.Game
{
    public class GetDescriptors : MonoBehaviour
    {
        [SerializeField]
        private DescriptorComponent m_DescriptorReference;

        [SerializeField]
        private Text m_TitleText = null;
        [SerializeField]
        private Text m_LongDescText = null;
        [SerializeField]
        private Text m_ShortDescText = null;

        private void Start()
        {
            UpdateText();
        }

        public void ApplyNewDescriptorReference(DescriptorComponent descriptorComponent)
        {
            m_DescriptorReference = descriptorComponent;
            UpdateText();
        }

        public void UpdateText()
        {
            if (m_TitleText != null)
            {
                m_TitleText.text = m_DescriptorReference.Title;
            }

            if (m_LongDescText != null)
            {
                m_LongDescText.text = m_DescriptorReference.LongDescription;
            }

            if (m_ShortDescText != null)
            {
                m_ShortDescText.text = m_DescriptorReference.ShortDescription;
            }
        }
    }
}
