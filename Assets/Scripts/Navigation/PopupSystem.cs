using System.Collections.Generic;
using System.Linq;
using Settings;
using UI.Popups;
using UnityEngine;

namespace Navigation
{
    public class PopupSystem : MonoBehaviour
    {
        [SerializeField] private GameObject _background;
        
        private static PopupSystem _instance;
        private static List<BasePopup> _currentPopups = new List<BasePopup>();

        public void Start()
        {
            _instance = this;
        }

        public static void ShowPopup<T>(PopupSettings settings = null) where T : BasePopup
        {
            var prefabPopup = SettingsProvider.Get<PrefabSet>().GetPopup<T>();
            var popup = Instantiate(prefabPopup, _instance._background.transform);
            popup.Setup(settings);
            _currentPopups.Add(popup);
            ShowBackground();
        }

        public static void CloseAllPopups()
        {
            HideBackground();

            List<BasePopup> popupsForClose = new List<BasePopup>(_currentPopups);

            foreach (var basePopup in popupsForClose)
            {
                basePopup.Close();
            }
        }

        public static void CloseThisPopup(string popupId)
        {
            HideBackground();

            var currentPopup = _currentPopups.FirstOrDefault(x => x.PopupId == popupId);
            if (currentPopup == null)
            {
                _currentPopups.Clear();
            }
            else
            {
                _currentPopups.Remove(currentPopup);
            }
        }

        private static void HideBackground()
        {
            _instance._background.SetActive(false);
        }

        private static void ShowBackground()
        {
            _instance._background.SetActive(true);
            _instance._background.transform.SetAsLastSibling();
        }
    }
}