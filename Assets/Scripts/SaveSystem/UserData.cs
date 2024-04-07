using System;
using System.Collections.Generic;

namespace SaveSystem
{
    [Serializable]
    public class UserData
    {
        public int WinValue;
        public int LoseValue;
        public List<string> CompletedWords { get; private set; } = new List<string>();

        public void SetCompletedWords(string word)
        {
            WinValue++;
            if (!CompletedWords.Contains(word))
                CompletedWords.Add(word);
            
            SaveDataManager.SaveUserData(this);
        }

        public void SetLose() => LoseValue++;
    }
}