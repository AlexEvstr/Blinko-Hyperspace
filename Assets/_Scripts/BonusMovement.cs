using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusMovement : MonoBehaviour
{
    private float _speed = 3.0f;

    private void FixedUpdate()
    {


        transform.Translate(Vector2.right * Time.deltaTime * _speed);
        if (transform.position.x > 4 || transform.position.x < -4)
        {
            _speed = -_speed;    
        }
    }
}
