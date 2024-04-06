using System.Collections.Generic;
using UI.Items;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Gallows/GameSettings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        public LetterItem LetterPrefab;
        public KeyboardItem KeyboardLetterPrefab;
        public List<string> DefaultSecretWords;
    }
    
}