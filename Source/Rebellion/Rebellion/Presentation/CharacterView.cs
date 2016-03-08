using System;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

using Rebellion.Data;
using Rebellion.Data.Stats;
using Rebellion.Events;

namespace Rebellion.Presentation
{
    public class CharacterView : EntityView
    {
        public CharacterInteractionEvent OnCharacterClicked;

        private Slider mHealthBar = null;
        private Text mHealthReadout = null;

        private CharacterData mCharacterData = null;
        private CharacterViewSettings mViewSettings = null;

        private RebellionMain mRebellionMain;

        public CharacterData CharacterData
        {
            get
            {
                return mCharacterData;
            }
        }

        public override void InitializeWithDependencies(RebellionMain rebellionMain, EntityAsset characterAsset)
        {
            mCharacterData = (characterAsset.DataObject as CharacterDataObject).CharacterData;
            mCharacterData.Initialize();

            mViewSettings = characterAsset.ViewSettings as CharacterViewSettings;
            mRebellionMain = rebellionMain;

            name = mCharacterData.CharacterName;

            InitializeEventHandlers();
            InitializeUI(mRebellionMain.UIInGameController3D);
            InitializeSprite(mCharacterData.CharacterSprite);
        }

        private void InitializeEventHandlers()
        {
            OnCharacterClicked.AddListener(mRebellionMain.Selection.OnCharacterInteraction);
        }

        private void InitializeUI(InGameUIController3D inGameUIController)
        {
            mHealthBar = inGameUIController.AddUIElement<Slider>(mViewSettings.HealthBarPrefab);
            mHealthBar.transform.position = transform.position + mViewSettings.HealthBarOffset;

            mHealthReadout = inGameUIController.AddUIElement<Text>(mViewSettings.HealthReadoutPrefab);
            mHealthReadout.transform.position = mHealthBar.transform.position;

            UpdateUI();
        }

        private void InitializeSprite(Sprite sprite)
        {
            SpriteReference.sprite = sprite;
        }

        protected override void Update()
        {
            UpdateUI();

            base.Update();
        }

        private void UpdateUI()
        {
            if (mHealthBar != null)
            {
                mHealthBar.value = ((float)mCharacterData.Health.CurrentValue / (float)mCharacterData.Health.MaxValue);
                mHealthBar.transform.position = transform.position + mViewSettings.HealthBarOffset;
            }

            if (mHealthReadout != null)
            {
                mHealthReadout.text = string.Format("{0} / {1}", mCharacterData.Health.CurrentValue, mCharacterData.Health.MaxValue);
                mHealthReadout.transform.position = mHealthBar.transform.position + (Vector3.up * mHealthBar.fillRect.rect.height);
            }
        }

        public void ModifyHealth(int amount)
        {
            mCharacterData.Health.ModifyValue(amount);
        }

        public void OnMouseUpAsButton()
        {
            OnCharacterClicked.Invoke(this, CharacterInteractionEvent.CharacterInteractionEventTypes.CLICKED);
        }

        public void OnMouseEnter()
        {
            OnCharacterClicked.Invoke(this, CharacterInteractionEvent.CharacterInteractionEventTypes.HOVER_ENTER);
        }

        public void OnMouseExit()
        {
            OnCharacterClicked.Invoke(this, CharacterInteractionEvent.CharacterInteractionEventTypes.HOVER_EXIT);
        }
    }
}
