using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{
    public static void SaveScore(string levelName, int score)
    {
        string key = "HighScore_" + levelName; // Unique key for each level
        int highScore = PlayerPrefs.GetInt(key, 0);
        if (score > highScore)
        {
            PlayerPrefs.SetInt(key, score);
            PlayerPrefs.Save();
        }
    }

    public static int LoadHighScore(string levelName)
    {
        string key = "HighScore_" + levelName; // Use the same key format to load the score
        return PlayerPrefs.GetInt(key, 0);
    }
}