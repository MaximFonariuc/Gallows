using UnityEngine;
using UnityEngine.UI;

namespace UI.Screens
{
    public class GameScreen : DefaultScreen
    {
        [SerializeField] private Button _startButton;
        [SerializeField] private Transform _lettterList;

        public override void Setup(ScreenSettings settings)
        {
            if (settings is not GameScreenSettings mainScreenSettings)
                return;

        }
        
    }

    public class GameScreenSettings : ScreenSettings
    {
        public int LetterCount;
    }
}