using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;

namespace Rebellion.Presentation
{
    public class DayCounter : MonoBehaviour
    {
        public DateTime CurrentDateTime = new DateTime(2023, 1, 1);
        public float ClockTimeScale = 10f;
        
        private Text mText;

        private void Start()
        {
            mText = GetComponent<Text>();
        }

        private void Update()
        {
            CurrentDateTime = CurrentDateTime.AddSeconds(Time.unscaledDeltaTime * ClockTimeScale);
            mText.text = CurrentDateTime.ToLongDateString() + "\n" + CurrentDateTime.ToLongTimeString();
        }
    }
}
