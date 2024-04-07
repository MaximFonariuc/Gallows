using System;
using TMPro;
using UI.Buttons;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Items
{
    public class KeyboardItem : BaseButton
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Button _button;

        private bool _activity = true;
        public char Letter { get; private set; }
        public void SetActive() => _activity = true;
        public void Setup(char title, Action onClick, Action<char> setLetterInContainer)
        {
            _title.text = title.ToString();
            Letter = title;
            _button.onClick.AddListener(() =>
            {
                if (_activity)
                {
                    onClick?.Invoke();
                    setLetterInContainer?.Invoke(_title.text[0]);
                    _activity = false;
                }
            });           
        }

        public void UnactiveKeyboardItem() => _activity = false;
    }
}