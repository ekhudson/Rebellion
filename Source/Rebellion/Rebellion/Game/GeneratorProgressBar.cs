using UnityEngine;
using UnityEngine.UI;

using Rebellion.Data;

namespace Rebellion.Game
{
    public class GeneratorProgressBar : MonoBehaviour
    {
        public Generator GeneratorReference;
        public Image ProgressBar;

        public void Update()
        {
            ProgressBar.fillAmount = GeneratorReference.GetNormalizedCycleTime();
        }
    }
}
