using System;
using UnityEngine;

namespace Rebellion.Data
{
    public class FloatValuePool : ValuePoolBase
    {
        [SerializeField]
        private float m_StartingValue = 0f;
        [SerializeField]
        private float m_MinimumValue = -float.MaxValue;
        [SerializeField]
        private float m_MaximumValue = float.MaxValue;

        public DescriptorComponent Descriptors;   
       
        private float mCurrentPoolValue;

        public float CurrentPoolValue
        {
            get
            {
                return mCurrentPoolValue;
            }
        }

        private void Start()
        {
            mCurrentPoolValue = m_StartingValue;
        }

        public void ModifyPoolValue(float amount)
        {
            float oldAmount = mCurrentPoolValue;

            mCurrentPoolValue = Mathf.Clamp(mCurrentPoolValue + amount, m_MinimumValue, m_MaximumValue);

            if (oldAmount != mCurrentPoolValue)
            {
                //Send out value changed event
            }
        }

        public void ResetValue()
        {
            mCurrentPoolValue = m_StartingValue;
            //Send out value changed event
        }

        public override string ValueAsString()
        {
            return mCurrentPoolValue.ToString();
        }
    }
}
