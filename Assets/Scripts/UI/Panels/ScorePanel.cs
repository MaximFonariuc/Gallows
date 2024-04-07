using System;
using SaveSystem;
using TMPro;
using UnityEngine;

namespace UI.Panels
{
    public class ScorePanel : BasePanel 
    {
        [SerializeField] private TMP_Text _winValue;
        [SerializeField] private TMP_Text _loseValue;
        
        public void SetupScore()
        {
            var userData = SaveDataManager.LoadUserData();
            _winValue.text = userData.WinValue.ToString();
            _loseValue.text = userData.LoseValue.ToString();
        }
    }
    
}