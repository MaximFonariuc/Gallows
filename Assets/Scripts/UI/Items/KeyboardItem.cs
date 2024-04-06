using System;
using TMPro;
using UI.Buttons;
using UnityEngine;

namespace UI.Items
{
    public class KeyboardItem : BaseButton
    {
        [SerializeField] private TMP_Text _title;
        private Action _onClick;
        
        public void Setup(string title, Action onClick)
        {
            _title.text = title;
            _onClick = onClick;
        }

        public void UnActiveKeboardItem() => _onClick = null;
    }
}