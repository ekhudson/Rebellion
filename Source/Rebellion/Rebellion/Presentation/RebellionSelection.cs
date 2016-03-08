using System;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using Rebellion.Presentation;
using Rebellion.Events;

namespace Rebellion.Presentation
{
    [System.Serializable]
    public class RebellionSelection : IEventSystemHandler
    {
        public float SelectionMarkerVerticalOffset = 20f;
        public GameObject SelectionMarkerPrefab;
        public GameObject HoverMarkerPrefab;

        private InGameUIController2D mInGameUIController2D;
        private RectTransform mSelectionMarker;
        private RectTransform mHoverMarker;
        
        private EntityView mCurrentSelectedEntity = null;

        public EntityView CurrentSelectedEntity
        {
            get
            {
                return mCurrentSelectedEntity;
            }
        }

        public void Initialize(InGameUIController2D inGameUIController2D)
        {
            mInGameUIController2D = inGameUIController2D;

            mSelectionMarker = inGameUIController2D.AddUIElement(SelectionMarkerPrefab).GetComponent<RectTransform>();
            mSelectionMarker.GetComponent<Image>().enabled = false;
            
            mHoverMarker = inGameUIController2D.AddUIElement(HoverMarkerPrefab).GetComponent<RectTransform>();
            mHoverMarker.GetComponent<Image>().enabled = false;
        }

        public void OnCharacterInteraction(CharacterView character, CharacterInteractionEvent.CharacterInteractionEventTypes eventType)
        {
            switch (eventType)
            {
                case CharacterInteractionEvent.CharacterInteractionEventTypes.CLICKED:

                    if (mCurrentSelectedEntity == character)
                    {
                        return;
                    }

                    mCurrentSelectedEntity = character;

                    Vector3 selectionPosition = character.SpriteReference.bounds.center;
                    selectionPosition += Vector3.up * (character.SpriteReference.bounds.extents.y + SelectionMarkerVerticalOffset);

                    mSelectionMarker.anchoredPosition = CanvasUtility.WorldToCanvasPosition(mInGameUIController2D.RectTransform, selectionPosition);

                    mSelectionMarker.GetComponent<Image>().enabled = true;

                    break;

                case CharacterInteractionEvent.CharacterInteractionEventTypes.HOVER_ENTER:

                    Vector2 delta = Vector2.zero;                    

                    delta.x = character.SpriteReference.bounds.size.x * mInGameUIController2D.RectTransform.lossyScale.x;
                    delta.y = character.SpriteReference.bounds.size.y * mInGameUIController2D.RectTransform.lossyScale.y;

                    mHoverMarker.sizeDelta = delta;

                    mHoverMarker.anchoredPosition =  CanvasUtility.WorldToCanvasPosition(mInGameUIController2D.RectTransform, character.SpriteReference.bounds.center);
                    mHoverMarker.GetComponent<Image>().enabled = true;

                    break;

                case CharacterInteractionEvent.CharacterInteractionEventTypes.HOVER_EXIT:

                    mHoverMarker.GetComponent<Image>().enabled = false;

                    break;
            }            
        }        
    }
}
