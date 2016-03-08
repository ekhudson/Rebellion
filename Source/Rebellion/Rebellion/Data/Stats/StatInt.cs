using System;

namespace Rebellion.Data.Stats
{
    [System.Serializable]
    public class StatInt
    {
        public int Value;
        public int MinValue;
        public int MaxValue;

        private int mCurrentValue;

        public void Initialize()
        {
            mCurrentValue = Value;
        }

        public int CurrentValue
        {
            get
            {
                return mCurrentValue;
            }
        }

        public int ModifyValue(int delta)
        {
            int value = mCurrentValue;

            value += delta;

            if (value < MinValue)
            {
                value = MinValue;
            }

            if (value > MaxValue)
            {
                value = MaxValue;
            }

            mCurrentValue = value;

            return mCurrentValue;
        }
    }
}
