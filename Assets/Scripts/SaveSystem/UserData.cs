using System;
using System.Collections.Generic;

namespace SaveSystem
{
    [Serializable]
    public class UserData
    {
        private int _winCount;
        private int _loseCount;

        public List<string> CompletedWords { get; private set; }
        public void SetCompletedWords(string word)
        {
            if (CompletedWords.Contains(word))
            {
                CompletedWords.Add(word);
                _winCount++;
                SaveDataManager.SaveUserData(this);
            }
        }

        public void SetLose() => _loseCount++;
    }
}