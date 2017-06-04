using System;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Rebellion.Presentation
{
    public class GridTileView : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public Image FrameImage;
        public Image FillImage;

        public Color IdleColor = Color.clear;
        public Color HoverColor = Color.yellow;
        public Color AttackRangeColor = Color.red;
        public Color MoveRangeColor = Color.green;

        public void Start()
        {
            FillImage.color = IdleColor;
        }

        public void OnPointerEnter(PointerEventData pointerEventData)
        {
            FillImage.color = HoverColor;
        }

        public void OnPointerExit(PointerEventData pointerEventData)
        {
            FillImage.color = IdleColor;
        }
        
    }
}
