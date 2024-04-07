using System;
using System.Collections.Generic;
using GameCore;
using Settings;
using TMPro;
using UI.Items;
using UnityEngine;

namespace UI.Screens
{
    public class GameScreen : DefaultScreen
    {
        [SerializeField] private Transform _lettterParent;
        [SerializeField] private Transform _gameStateKeyboard;
        [SerializeField] private Hangman _hangmanParts;

        [SerializeField] private TMP_Text _winStatus;
        [SerializeField] private TMP_Text _loseStatus;

        private List<LetterItem> _letterContainer = new List<LetterItem>();
        private List<KeyboardItem> _keyboardContainer = new List<KeyboardItem>();

        private int _loseTurnCount;
        private int _currentLetterCount;
        public override void Setup(ScreenSettings settings)
        {
            if (settings is not GameScreenSettings gameScreenSettings)
                return;

            _loseTurnCount = 0;
            _hangmanParts.ResetHangman();
            _gameStateKeyboard.gameObject.SetActive(true);
            _currentLetterCount = gameScreenSettings.Letters.Count;
            _winStatus.text = gameScreenSettings.WinCount;
            _loseStatus.text = gameScreenSettings.LoseCount;

            var letterSettings = SettingsProvider.Get<GameSettings>();

            for (int i = 0; i < _currentLetterCount; i++)
            {
                if (_letterContainer.Count < _currentLetterCount)
                    _letterContainer.Add(Instantiate(letterSettings.LetterPrefab, _lettterParent));
                else if (_letterContainer.Count - 1 - i >= _currentLetterCount )
                    _letterContainer[_letterContainer.Count - 1 - i].SetActive(false);
                
                _letterContainer[i].Setup(gameScreenSettings.Letters[i]);
            }

            for (char letter = gameScreenSettings.StartChar; letter <= gameScreenSettings.EndChar; letter++)
            {
                var copyLetter = letter;

                KeyboardItem existingKeyboardItem = null;
                foreach (var item in _keyboardContainer)
                {
                    if (item.Letter == letter)
                    {
                        existingKeyboardItem = item;
                        break;
                    }
                }

                if (existingKeyboardItem == null)
                {
                    existingKeyboardItem = Instantiate(letterSettings.KeyboardLetterPrefab, _gameStateKeyboard);
                    existingKeyboardItem.Setup(letter, () =>
                    {
                        if (CoreSystem.Instance.CheckAndAddLetter(copyLetter))
                            existingKeyboardItem.UnactiveKeyboardItem();
                        else
                        {
                            if(_hangmanParts.ShowNextPart(_loseTurnCount)) 
                                _gameStateKeyboard.gameObject.SetActive(false);
                            _loseTurnCount++;
                        }
                    }, SetLetterInContainer);
                    _keyboardContainer.Add(existingKeyboardItem);
                }
                else
                    existingKeyboardItem.SetActive();
                
            }
        }

        public void SetLetterInContainer(char letter)
        {
            bool allLettersOpened = true;

            for (int i = 0; i < _currentLetterCount; i++)
            {
                if (_letterContainer[i].Letter == letter)
                {
                    _letterContainer[i].SetLetter();
                }

                if (!_letterContainer[i].IsActive)
                {
                    allLettersOpened = false;
                }
            }

            if (allLettersOpened)
            {
                _gameStateKeyboard.gameObject.SetActive(false);
                CoreSystem.Instance.EndLevel(LevelStateType.Win);
            }
        }
    }

    public class GameScreenSettings : ScreenSettings
    {
        public List<char> Letters;
        public char StartChar;
        public char EndChar;
        public string WinCount;
        public string LoseCount;
    }
}