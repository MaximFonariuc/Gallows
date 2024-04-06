using System;
using System.Collections.Generic;
using Navigation;
using SaveSystem;
using Settings;
using UI.Screens;
using Utils;

namespace GameCore
{
    public class CoreSystem : MonoSingleton<CoreSystem>
    {
        private string _currentWord;
        private List<char> _openedLetters;

        public void Setup() 
        {
            var userData = SaveDataManager.LoadUserData();
            _currentWord = SettingsProvider.Get<GameSettings>().GetRandomSecretWord(userData.CompletedWords);
            var commonSettings = SettingsProvider.Get<CommonSettings>().Localizations;
            SetupLevel(new GameScreenSettings()
            {
                Letters = new List<char>(_currentWord.ToCharArray()),
                StartChar = commonSettings.StartChar,
                EndChar = commonSettings.EndChar
            });
        }

        public void SetupLevel(GameScreenSettings gameScreenSettings = null)
        {
            if (gameScreenSettings != null)
                NavigationController.Instance.CurrentScreen.Setup(gameScreenSettings);
        }

        public void EndLevel(LevelStateType levelState)
        {
            switch (levelState)
            {
                case LevelStateType.Win:
                    break;
                case LevelStateType.Lose:
                    break;
            }
        }
        
        public bool CheckAndAddLetter(char letter)
        {
            if (_currentWord.Contains(letter))
            {
                if (!_openedLetters.Contains(letter))
                {
                    _openedLetters.Add(letter);
                }
                return true;
            }
            return false;
        }
        
    }
}
