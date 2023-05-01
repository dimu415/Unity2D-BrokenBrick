
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Vector3 MovePos; // ¿Ãµø∫§≈Õ
    public float _speed = 4f;

    public void Start()
    {
        MovePos = new Vector2(1f, 1f).normalized;
    }

    void Update()
    {
        transform.position += MovePos * _speed * Time.deltaTime;
    }

    public void SpeedUp()
    {
        if (_speed < 5)
        {
            _speed += 0.01f;
        }
    }
    public void SpeedDown()
    {
        if (_speed > 2.5)
        {
            _speed -= 0.01f;
        }
    }
}
