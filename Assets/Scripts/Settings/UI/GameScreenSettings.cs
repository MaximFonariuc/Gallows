using UnityEngine;

namespace Settings.UI
{
    [CreateAssetMenu(fileName = "GameScreenSettings", menuName = "ScreenSettings/GameScreenSettings", order = 0)]
    public class GameScreenSettings : ScriptableObject
    {
        public GameObject LetterPrefab;
        public GameObject KeyboardLetterPrefab;
        public int ActiveButtonsCount;
    }
    
}