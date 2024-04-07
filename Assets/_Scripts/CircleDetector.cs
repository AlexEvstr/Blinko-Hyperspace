using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDetector : MonoBehaviour
{
    private Vector3 _scale;
    private void Start()
    {
        _scale = new Vector3 (0.1f, 0.1f, 0.1f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.localScale += _scale;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        transform.localScale -= _scale;
    }
}
