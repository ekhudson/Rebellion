using System;

using UnityEngine;
using UnityEngine.UI;

namespace Rebellion.Data
{
    public enum ActionTargetModes
    {
        SELF,
        GROUND,
        SINGLE_TARGET,
        MULTI_TARGET,
    }

    public enum ActionTargetTypes
    {
        SELF,
        ALLY,
        ENEMY,
    }

    public class CharacterAction
    {
        public string ActionName = string.Empty;
        public Sprite ActionIcon = null;
        public ActionTargetModes TargetMode = ActionTargetModes.GROUND;
        public ActionTargetTypes TargetTypes = ActionTargetTypes.ENEMY;
    }
}
