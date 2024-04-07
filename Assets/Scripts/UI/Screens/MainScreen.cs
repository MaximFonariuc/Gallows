using System.Collections.Generic;
using DG.Tweening;
using GameCore;
using Navigation;
using Settings;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class MainScreen : DefaultScreen
    {
        [SerializeField] private Button _startButton;

        private void Awake()
        {
            _startButton.onClick.AddListener(() =>
            {
                _startButton.transform.DOScale(Vector3.one * 1.15f, 0.25f).SetEase(Ease.OutQuad).OnComplete(() =>
                {
                    _startButton.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutQuad).OnComplete(() => { SelectTab(MainTabType.Start); });
                });
            });
        }

        public override void Setup(ScreenSettings settings)
        {
            if (settings is not MainScreenSettings mainScreenSettings)
                return;

            SelectTab(mainScreenSettings.TabType);
        }

        public void SelectTab(MainTabType tabType)
        {
            switch (tabType)
            {
                case MainTabType.Start:
                    NavigationController.Instance.ScreenTransition<GameScreen>();
                    CoreSystem.Instance.Setup();
                    break;
                case MainTabType.Settings:

                    break;
            }
        }

        public enum MainTabType
        {
            Start = 0,
            Settings = 1,
        }
    }

    public class MainScreenSettings : ScreenSettings
    {
        public MainScreen.MainTabType TabType;
    }
}