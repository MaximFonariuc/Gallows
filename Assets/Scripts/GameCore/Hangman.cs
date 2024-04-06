using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore
{
    [Serializable]
    public class Hangman
    {
        [SerializeField] private List<Image> _hagmanParts;
    }
}
