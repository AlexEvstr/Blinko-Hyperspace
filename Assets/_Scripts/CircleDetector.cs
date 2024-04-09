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
        StartCoroutine(ChangeSize());
    }

    private IEnumerator ChangeSize()
    {
        if (Manager.IsVibroOn) Vibration.VibrateIOS(ImpactFeedbackStyle.Rigid);
        transform.localScale += _scale;
        yield return new WaitForSeconds(0.05f);
        transform.localScale -= _scale;
    }
}
