using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform ball;

    private Vector3 _offset;
    private float _ballPosY;

    private void Start()
    {
        _ballPosY = ball.transform.position.y;
        _offset = transform.position - ball.position;
    }

    private void LateUpdate()
    {
        if (ball.transform.position.y < _ballPosY && ball.gameObject.activeInHierarchy && transform.position.y > 0)
        {
            Vector3 newPos = Vector3.Lerp(transform.position, ball.position + _offset, 1f);
            transform.position = new Vector3(0, newPos.y, newPos.z);

        }
    }
}
