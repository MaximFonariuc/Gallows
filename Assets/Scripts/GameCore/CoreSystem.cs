using System;
using System.Collections.Generic;
using Navigation;
using SaveSystem;
using Settings;
using UI.Popups;
using UI.Screens;
using Utils;

namespace GameCore
{
    public class CoreSystem : MonoSingleton<CoreSystem>
    {
        private List<char> _openedLetters = new List<char>();
        private UserData _userData;

        private string _currentWord;

        public void Setup()
        {
            _userData = SaveDataManager.LoadUserData();
            _currentWord = SettingsProvider.Get<GameSettings>().GetRandomSecretWord(_userData.CompletedWords, _currentWord);
            var commonSettings = SettingsProvider.Get<CommonSettings>().Localizations;

            SetupLevel(new GameScreenSettings()
            {
                Letters = new List<char>(_currentWord.ToCharArray()),
                StartChar = commonSettings.StartChar,
                EndChar = commonSettings.EndChar,
                WinCount = _userData.WinCount.ToString(),
                LoseCount = _userData.LoseCount.ToString()
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
                    _userData.SetCompletedWords(_currentWord);
                    PopupSystem.ShowPopup<NotificationGameStatePopup>(new NotificationCreateCharacterPopupSettings()
                    {
                        Content = "ПОБЕДА!!!",
                        TitleButton = "ИГРАТЬ ЕЩЕ РАЗ",
                        Action = () =>
                        {
                            PopupSystem.CloseAllPopups();
                            Setup();
                        }
                    });
                    break;
                case LevelStateType.Lose:
                    _userData.SetLose();
                    SaveDataManager.SaveUserData(_userData);
                    PopupSystem.ShowPopup<NotificationGameStatePopup>(new NotificationCreateCharacterPopupSettings()
                    {
                        Content = "Они повесили Кучерявого Бобби",
                        TitleButton = "ИГРАТЬ ЕЩЕ РАЗ",
                        Action = () =>
                        {
                            PopupSystem.CloseAllPopups();
                            Setup();
                        }
                    });
                    break;
            }

            _openedLetters = new List<char>();
        }

        public bool CheckAndAddLetter(char letter)
        {
            if (_currentWord.Contains(letter))
            {
                if (!_openedLetters.Contains(letter))
                {
                    _openedLetters.Add(letter);
                    return true;
                }

                return true;
            }

            return false;
        }
    }
}