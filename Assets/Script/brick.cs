
using UnityEngine;

public class brick : MonoBehaviour
{
    ScoreManager scoreManager;
    BrickManager brickManager;
    public int id;
 
    private void Start()
    {
        scoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
        brickManager = GameObject.Find("BrickManager").GetComponent<BrickManager>();
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Brick"))
        {
            if (collision.GetComponent<brick>().id != id)
            {
                Destroy(this.gameObject);
            }
            else brickManager.move(id);
        }
    }
    public void BallCol()
    {
        scoreManager.ScoreCurrent();
        
        Destroy(this.gameObject);

    }

}
