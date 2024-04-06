using System;
using TMPro;
using UI.Buttons;
using UnityEngine;

namespace UI.Items
{
    public class LetterItem : BaseButton
    {
        [SerializeField] private TMP_Text _title;
        private Action SetActive;

        public bool IsActive => _title.alpha != 0;

        public void Setup(char title, Action action)
        {
            _title.text = title.ToString();
            _title.alpha = 0;
            SetActive = action;
        }

        public void SetLetter() => _title.alpha = 1;
        
    }
}