using System;
using System.Collections.Generic;

namespace SaveSystem
{
    [Serializable]
    public class UserData
    {
        public int WinCount { get; private set; }
        public int LoseCount { get; private set; }

        public List<string> CompletedWords { get; private set; } = new List<string>();

        public void SetCompletedWords(string word)
        {
            if (!CompletedWords.Contains(word))
            {
                CompletedWords.Add(word);
                WinCount++;
                SaveDataManager.SaveUserData(this);
            }
        }

        public void SetLose() => LoseCount++;
    }
}