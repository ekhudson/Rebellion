using System;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

using Rebellion.Game;
using Rebellion.Data;
using Rebellion.Events;

namespace Rebellion.Presentation
{
    public class RebellionMain : MonoBehaviour
    {
        [Header("UI")]
        public FrontEndUIController UIFrontEndController;
        public InGameUIController2D UIInGameController2D;
        public InGameUIController3D UIInGameController3D;
        public EventSystem EventSystem;
        public Camera MainCamera;
        public RebellionSelection Selection;
        public RebellionTurnManager TurnManager;

        [Header("Game")]
        public RebellionEntityRegistry EntityRegistry;
        public EntitySpawnFactory EntitySpawnFactory;
        public RebellionGridManager GridManager;

        [Header("Events")]
        public MainInitializedEvent OnMainInitializedEvent = new MainInitializedEvent();

        private void Start()
        {
            InitializeDependencies();
        }

        private void InitializeDependencies()
        {
            UIFrontEndController.Init(this);
            UIInGameController2D.Init(this);
            UIInGameController3D.Init(this);

            Selection.Initialize(UIInGameController2D);
            
            EntityRegistry.Initialize();
            EntitySpawnFactory.Initialize(this);

            TurnManager.Initialize(this);

            OnMainInitializedEvent.Invoke();
        }        
    }
}
