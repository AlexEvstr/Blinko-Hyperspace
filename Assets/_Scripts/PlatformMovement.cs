using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private void FixedUpdate()
    {


        transform.Translate(Vector2.right * Time.deltaTime * _speed);
        if (transform.position.x > 1 || transform.position.x < -1)
        {
            _speed = -_speed;

        }
    }
}
