using System.Collections.Generic;
using GameCore;
using Settings;
using UnityEngine;

namespace UI.Screens
{
    public class GameScreen : DefaultScreen
    {
        [SerializeField] private Transform _lettterList;
        [SerializeField] private Transform _gameStateKeyboard;
        [SerializeField] private Hangman _hangmanParts;

        public override void Setup(ScreenSettings settings)
        {
            if (settings is not GameScreenSettings gameScreenSettings)
                return;

            var letterSettings = SettingsProvider.Get<GameSettings>();
            for (int i = 0; i < gameScreenSettings.Letters.Count; i++)
            {
                var letter = Instantiate(letterSettings.LetterPrefab, _lettterList);
                letter.Setup(gameScreenSettings.Letters[i], () => { });
            }

            for (char letter = gameScreenSettings.StartChar; letter <= gameScreenSettings.EndChar; letter++)
            {
                var keyboardItem = Instantiate(letterSettings.KeyboardLetterPrefab, _gameStateKeyboard);
                keyboardItem.Setup(letter.ToString(), () => { });
            }
        }
    }

    public class GameScreenSettings : ScreenSettings
    {
        public List<char> Letters;
        public char StartChar;
        public char EndChar;
    }
}