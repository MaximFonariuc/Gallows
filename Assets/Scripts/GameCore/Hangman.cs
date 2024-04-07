using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameCore
{
    [Serializable]
    public class Hangman
    {
        [SerializeField] private List<Image> _hangmanParts;
        
        public void ResetHangman()
        {
            for (int i = 0; i < _hangmanParts.Count; i++)
            {
                if (_hangmanParts[i].gameObject.activeSelf)
                    _hangmanParts[i].gameObject.SetActive(false);
            }
        }
            
        public bool ShowNextPart(int wrongAttempts)
        {
            if (wrongAttempts < _hangmanParts.Count - 1)
                _hangmanParts[wrongAttempts].gameObject.SetActive(true);
            else
            {
                _hangmanParts[wrongAttempts].gameObject.SetActive(true);
                CoreSystem.Instance.EndLevel(LevelStateType.Lose);
                return true;
            }

            return false;
        }
    }
}
