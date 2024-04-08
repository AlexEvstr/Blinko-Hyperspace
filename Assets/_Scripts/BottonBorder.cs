using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottonBorder : MonoBehaviour
{
    [SerializeField] private GameObject _ball;
    [SerializeField] private GameObject _firstPlatfrom;
    [SerializeField] private GameObject _camera;

    private void Start()
    {
        _ball.transform.position = new Vector2(_firstPlatfrom.transform.position.x, _firstPlatfrom.transform.position.y + 0.5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(SpawnBall());
    }

    private IEnumerator SpawnBall()
    {
        _ball.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        _ball.SetActive(true);
        _ball.transform.position = new Vector2(_firstPlatfrom.transform.position.x, _firstPlatfrom.transform.position.y + 0.5f);
        _camera.transform.position = new Vector3(0, 10, -10);
    }
}
