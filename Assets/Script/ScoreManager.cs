
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    public int CurrentScore, HighScore;
    public DataController data;
    public Text HighScoreText;
    public void ScoreSet()=>HighScoreText.text = data.gameData.HighScore.ToString();
    
    public void ScoreCurrent()
    {
        CurrentScore++;
        ScoreText.text = CurrentScore.ToString();
        if (Time.timeScale < 2)
            Time.timeScale += 0.01f;
    }

    public void ResetScore()
    {

        CurrentScore = 0;
        ScoreText.text = CurrentScore.ToString();
    }

    public void GameOver()
    {
        if (CurrentScore > HighScore)
        {
            data.gameData.HighScore = CurrentScore;

            data.SaveGameData();
            ScoreSet();
        }
      
    }
}
