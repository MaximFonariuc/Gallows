using System;
using System.Collections.Generic;

namespace SaveSystem
{
    [Serializable]
    public class UserData
    {
        public int WinCount;
        public int LoseCount;
        public List<string> CompletedWords { get; private set; } = new List<string>();

        public void SetCompletedWords(string word)
        {
            WinCount++;
            if (!CompletedWords.Contains(word))
                CompletedWords.Add(word);
            
            SaveDataManager.SaveUserData(this);
        }

        public void SetLose() => LoseCount++;
    }
}