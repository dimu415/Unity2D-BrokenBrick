
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Script
     public LineCreate lineCreate;
    public ScoreManager scoreManager;
    public BrickManager brickManager;
    #endregion
    public GameObject StartBall;
   
    public GameObject LineBoard;
    public GameObject CreateBrick;
    public GameObject ball;
    
    public GameObject GameMainUI,GameOverUI,GameUI;
   
    private void Awake()
    {
        Application.targetFrameRate = 60;
        Input.multiTouchEnabled = false;
    }
  
    public void GameStart()
    {
        Time.timeScale = 1;
        GameOverUI.SetActive(false);
        GameMainUI.SetActive(false);
        GameUI.SetActive(true);
        LineBoard.SetActive(true);
        CreateBrick.SetActive(true);

        ball= Instantiate(StartBall);
        ball.transform.position = new Vector3(0, 0);
        brickManager.ResetBreick();
        brickManager.StartCreateBrick();

        Destroy(lineCreate.inst);
        scoreManager.ResetScore();
        lineCreate.Count = 1;
        lineCreate.MaxLineLength = 1;
    }

   
    public void Die()
    {
        Time.timeScale = 0;
        Destroy(ball.gameObject);
        brickManager.StopAllCoroutines();
        GameOverUI.SetActive(true);
        GameUI.SetActive(false);
        LineBoard.SetActive(false);
        scoreManager.GameOver();
    }
    public void DestroyBrick()
    {
        Die();
    }
    public void GameOver()
    {
        GameOverUI.SetActive(false);
        GameMainUI.SetActive(true);
        CreateBrick.SetActive(false);
    }

    
}
