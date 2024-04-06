using System.Collections.Generic;
using GameCore;
using Settings;
using UnityEngine;

namespace UI.Screens
{
    public class GameScreen : DefaultScreen
    {
        [SerializeField] private Transform _lettterParent;
        [SerializeField] private Transform _gameStateKeyboard;
        [SerializeField] private Hangman _hangmanParts;

        private LetterContainer _letterContainer;
        public override void Setup(ScreenSettings settings)
        {
            if (settings is not GameScreenSettings gameScreenSettings)
                return;

            var letterSettings = SettingsProvider.Get<GameSettings>();
            for (int i = 0; i < gameScreenSettings.Letters.Count; i++)
            {
                _letterContainer.LetterItems.Add(Instantiate(letterSettings.LetterPrefab, _lettterParent));
                _letterContainer.LetterItems[i].Setup(gameScreenSettings.Letters[i], () =>
                {
                    
                });
            }

            for (char letter = gameScreenSettings.StartChar; letter <= gameScreenSettings.EndChar; letter++)
            {
                var keyboardItem = Instantiate(letterSettings.KeyboardLetterPrefab, _gameStateKeyboard);
                keyboardItem.Setup(letter.ToString(), () =>
                {
                    if(CoreSystem.Instance.CheckAndAddLetter(letter))
                        keyboardItem.UnActiveKeboardItem();
                });
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