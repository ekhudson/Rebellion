using System;

using UnityEngine;
using UnityEngine.Events;

using Rebellion.Presentation;

namespace Rebellion.Events
{
    public class EntitySpawnEvent : UnityEvent<EntityView, Vector3>
    {

    }
}
