using System;
using DG.Tweening;
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
            if (popupSettings is not NotificationCreateCharacterPopupSettings notificationPopupSettings)
                return;

            _content.text = notificationPopupSettings.Content;
            _titleButton.text = notificationPopupSettings.TitleButton;
            _button.onClick.AddListener(() =>
            {
                _button.transform.DOScale(Vector3.one * 1.15f, 0.25f).SetEase(Ease.OutQuad).OnComplete(() =>
                {
                    _button.transform.DOScale(Vector3.one, 0.25f).SetEase(Ease.OutQuad).OnComplete(() =>
                    {
                        notificationPopupSettings.Action.Invoke();
                    });
                });
            });
        }
    }

    public class NotificationCreateCharacterPopupSettings : PopupSettings
    {
        public string Content;
        public string TitleButton;
        public Action Action;
    }
}