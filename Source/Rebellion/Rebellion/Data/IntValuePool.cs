using System;
using UnityEngine;

namespace Rebellion.Data
{
    public class IntValuePool : ValuePoolBase
    {
        [SerializeField]
        private int m_StartingValue = 0;
        [SerializeField]
        private int m_MinimumValue = -int.MaxValue;
        [SerializeField]
        private int m_MaximumValue = int.MaxValue;

        private int mCurrentPoolValue;

        private void Start()
        {
            mCurrentPoolValue = m_StartingValue;
        }

        public void ModifyPoolValue(int amount)
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

