using System;

using UnityEngine;
using UnityEngine.Events;

using Rebellion.Presentation;

namespace Rebellion.Events
{
    [System.Serializable]
    public class CharacterInteractionEvent : UnityEvent<CharacterView, CharacterInteractionEvent.CharacterInteractionEventTypes>
    {
        public enum CharacterInteractionEventTypes
        {
            HOVER_ENTER,
            HOVER_EXIT,
            CLICKED,
        }
    }
}
