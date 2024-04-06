using System;
using System.Collections.Generic;
using UnityEngine;

namespace Settings
{
    [CreateAssetMenu(fileName = "CommonSettings", menuName = "Gallows/CommonSettings", order = 0)]
    public class CommonSettings : ScriptableObject
    {
        [field: SerializeField] public string AppId { private set; get; }
        [field: SerializeField] public Localization Localizations { private set; get; }
    }

    [Serializable]
    public class Localization
    {
        public LocalizationType LocalizationType;
        public char StartChar;
        public char EndChar;
    }

    public enum LocalizationType
    {
        None = 0,
        Ru = 1,
        En = 2
    }
}