using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    //private Touch _touch;
    //private float _movementSpeed = 0.005f;

    //private void Update()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        _touch = Input.GetTouch(0);

    //        if (_touch.phase == TouchPhase.Moved)
    //            transform.position = new Vector2(transform.position.x + _touch.deltaPosition.x * _movementSpeed, transform.position.y);
    //    }
    //}

    private bool _grounded = false;

    private float _speed = 30.0f;
    private void FixedUpdate()
    {
        if (_grounded)
        {
            GetComponent<Rigidbody2D>().AddForce(GetSmoothedAcceleration() * _speed, ForceMode2D.Force);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Vibration.VibrateIOS(ImpactFeedbackStyle.Light);
            _grounded = true;
            GetComponent<Rigidbody2D>().freezeRotation = false;
        }
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        _grounded = false;
        GetComponent<Rigidbody2D>().freezeRotation = true;
    }

    bool first = true;
    Vector2 previousAccel = Vector3.zero;

    Vector2 GetSmoothedAcceleration()
    {
        if (first)
        {
            previousAccel = Input.acceleration;
            first = false;
        }

        Vector2 smoothedAccel = Vector2.Lerp(Input.acceleration, previousAccel, 0.0001f) ;
        previousAccel = smoothedAccel;
        return smoothedAccel;
    }
}
