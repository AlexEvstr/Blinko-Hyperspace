using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonBorder : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _firstPlatfrom;

    private void Start()
    {
        SpawnBall();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(collision.gameObject);
        SpawnBall();
    }

    private void SpawnBall()
    {
        GameObject ball = Instantiate(_ball);
        ball.transform.position = new Vector2(_firstPlatfrom.transform.position.x, _firstPlatfrom.transform.position.y + 0.3f);
    }
}
