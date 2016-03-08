using System;

using UnityEngine;
using UnityEngine.UI;

namespace Rebellion.Presentation
{
    public class CanvasUtility
    {
        public static Vector2 WorldToCanvasPosition(RectTransform canvasRect, Vector3 position)
        {
            Vector2 screenPos = RectTransformUtility.WorldToScreenPoint(Camera.main, position);
            Vector2 canvasPos = Vector2.zero;

            if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPos, null, out canvasPos))
            {
                Vector2 offset = canvasRect.sizeDelta;
                offset.x *= canvasRect.pivot.x;
                offset.y *= canvasRect.pivot.y;
                canvasPos += offset;
            }

            return canvasPos;
        }
    }
}
