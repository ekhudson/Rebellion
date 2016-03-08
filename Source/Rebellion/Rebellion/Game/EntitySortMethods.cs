using System;

using UnityEngine;

using Rebellion.Data;
using Rebellion.Presentation;

namespace Rebellion.Game
{
    public static class EntitySortMethods
    {
        public static int SortCharactersBySpeedAscending(CharacterView view1, CharacterView view2)
        {
            return SortCharactersBySpeed(view1.CharacterData, view2.CharacterData, true);
        }

        public static int SortCharactersBySpeedAscending(CharacterData data1, CharacterData data2)
        {
            return SortCharactersBySpeed(data1, data2, true);
        }

        public static int SortCharactersBySpeedDescending(CharacterView view1, CharacterView view2)
        {
            return SortCharactersBySpeed(view1.CharacterData, view2.CharacterData, false);
        }

        public static int SortCharactersBySpeedDescending(CharacterData data1, CharacterData data2)
        {
            return SortCharactersBySpeed(data1, data2, false);
        }

        private static int SortCharactersBySpeed(CharacterData data1, CharacterData data2, bool isAsending)
        {
            if (data1 == null)
            {
                if (data2 == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return isAsending ? - 1 : 1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (data2 == null)
                // ...and y is null, x is greater.
                {
                    return isAsending ? 1 : -1;
                }
                else
                {
                    if (data1.Speed.CurrentValue > data2.Speed.CurrentValue)
                    {
                        return isAsending ? 1 : -1;
                    }
                    else if (data1.Speed.CurrentValue < data2.Speed.CurrentValue)
                    {
                        return isAsending ? - 1 : 1;
                    }
                    else if (data1.Speed.CurrentValue == data2.Speed.CurrentValue)
                    {
                        return 0;
                    }

                    return 0;
                }
            }
        }
    }
}
