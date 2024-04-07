using System;
using TMPro;
using UI.Buttons;
using UnityEngine;

namespace UI.Items
{
    public class LetterItem : BaseButton
    {
        [SerializeField] private TMP_Text _title;
        public char Letter { get; private set; }
        public bool IsActive => _title.alpha != 0 && gameObject.activeSelf;

        public void Activity()
        {
            if(gameObject.activeSelf)
                gameObject.SetActive(false);
            else
                gameObject.SetActive(true);
        }

        public void Setup(char title)
        {
            _title.text = title.ToString();
            Letter = title;
            _title.alpha = 0;
        }

        public void SetLetter() => _title.alpha = 1;
        
    }
}