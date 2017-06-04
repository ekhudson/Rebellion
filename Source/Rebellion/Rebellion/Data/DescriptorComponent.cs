using UnityEngine;

namespace Rebellion.Data
{
    public class DescriptorComponent : MonoBehaviour
    {
        [Header("Descriptors")]
        [SerializeField]
        private string m_Title = "New Title";
        [SerializeField]
        private string m_LongDescription = "New Long Description";
        [SerializeField]
        private string m_ShortDescription = "New Short Description";

        public string Title { get { return m_Title; } }
        public string LongDescription { get { return m_LongDescription; } }
        public string ShortDescription { get { return m_ShortDescription; } }
    }
}
