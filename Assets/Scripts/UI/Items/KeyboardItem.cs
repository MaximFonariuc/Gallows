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

        private Action _onClick;
        private Action<char> _setLetterInContainer;

        public char Letter { get; private set; }
        public void Setup(char title, Action onClick, Action<char> setLetterInContainer)
        {
            _onClick = onClick;
            _title.text = title.ToString();
            Letter = title;
            _button.onClick.AddListener(() =>
            {
                if (_onClick != null)
                {
                    _onClick?.Invoke();
                    _setLetterInContainer?.Invoke(_title.text[0]);
                }
            });            _setLetterInContainer = setLetterInContainer;
        }

        public void UnactiveKeyboardItem() => _onClick = null;
    }
}