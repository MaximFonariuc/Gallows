using Navigation;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class MainScreen : DefaultScreen
    {
        [SerializeField] private Button _startButton;

        private void Awake()
        {
            _startButton.onClick.AddListener(() => { SelectTab(MainTabType.Start); });
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