
using UnityEngine;

public class DeadLine : MonoBehaviour
{
    GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Ball"))
          gm.Die();
        
        if (collision.CompareTag("Brick"))
          gm.DestroyBrick();
        
    }
}
