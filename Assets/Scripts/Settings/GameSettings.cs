using System.Collections.Generic;
using UI.Items;
using UnityEngine;
using Utils;

namespace Settings
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Gallows/GameSettings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        public LetterItem LetterPrefab;
        public KeyboardItem KeyboardLetterPrefab;
        public List<string> DefaultSecretWords;
        public string GetRandomSecretWord(List<string> allCompletedWords)
        {
            List<string> availableWords = new List<string>();

            foreach (string word in DefaultSecretWords)
            {
                if (!allCompletedWords.IsNullOrEmpty() && !allCompletedWords.Contains(word))
                {
                    availableWords.Add(word);
                }
            }

            if (availableWords.Count == 0)
            {
                return DefaultSecretWords.GetRandomElement();
            }
            
            return availableWords.GetRandomElement();
        }
    }
}