using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Popups
{
    public class NotificationGameStatePopup : BasePopup
    {
        [SerializeField] private TMP_Text _content;
        [SerializeField] private TMP_Text _titleButton;
        [SerializeField] private Button _button;
    
        public override void Setup(PopupSettings popupSettings)
        {
            if(popupSettings is not NotificationCreateCharacterPopupSettings notificationPopupSettings)
                return;

            _content.text = notificationPopupSettings.Content;
            _titleButton.text = notificationPopupSettings.TitleButton;
            _button.onClick.AddListener(notificationPopupSettings.Action.Invoke);
        }
    }

    public class NotificationCreateCharacterPopupSettings : PopupSettings
    {
        public string Content;
        public string TitleButton;
        public Action Action;
    }
}