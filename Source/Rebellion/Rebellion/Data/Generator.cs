using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Rebellion.Data
{
    public class Generator : MonoBehaviour
    {
        [System.Serializable]
        public class CycleCompleteEvent : UnityEvent<float> { }

        public AnimationCurve OutputValueCurve;
        public AnimationCurve CycleTimeCurve;
        public AnimationCurve UpgradeCostCurve;
        public CycleCompleteEvent OnCycleCompleteEvent;
        public Button UpgradeButton;
        public Text CostLabel;
        public Text ValueLabel;
        public FloatValuePool ValuePool;
                
        private float mCurrentCycleTime = 0f;

        private const float kShortestCycleTime = 0.2f;
        private int mCurrentCount = 0;

        public float CurrentCycleTimeSecond
        {
            get
            {
                return CycleTimeCurve.Evaluate(mCurrentCount);
            }
        }

        public float CurrentOutputValue
        {
            get
            {
                return OutputValueCurve.Evaluate(mCurrentCount);
            }
        }

        public float CurrentUpgradeCost
        {
            get
            {
                return UpgradeCostCurve.Evaluate(mCurrentCount);
            }
        }

        public float GetNormalizedCycleTime()
        {
            return CurrentCycleTimeSecond < kShortestCycleTime ? 1f : mCurrentCycleTime / CurrentCycleTimeSecond;
        }

        private void Update()
        {
            CheckCost();

            ValueLabel.text = CurrentOutputValue.ToString();

            mCurrentCycleTime += Time.deltaTime;

            if (mCurrentCycleTime >= CurrentCycleTimeSecond)
            {
                float remainder = mCurrentCycleTime - CurrentCycleTimeSecond;
                mCurrentCycleTime = remainder;
                OnCycleComplete();
            }
        }

        private void CheckCost()
        {
            UpgradeButton.interactable = (ValuePool.CurrentPoolValue >= CurrentUpgradeCost);
            CostLabel.text = CurrentUpgradeCost.ToString();
        }

        private void OnCycleComplete()
        {
            ValuePool.ModifyPoolValue(CurrentOutputValue);
            OnCycleCompleteEvent.Invoke(CurrentOutputValue);
        }

        public void TryBuyUpgrade()
        {
            if (ValuePool.CurrentPoolValue < CurrentUpgradeCost)
            {
                return;
            }

            ValuePool.ModifyPoolValue(-CurrentUpgradeCost);
            mCurrentCount++;
        }
    }
}
