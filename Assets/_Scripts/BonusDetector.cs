using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDetector : MonoBehaviour
{
    [SerializeField] private BottonBorder bottonBorder;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            StartCoroutine(ChangeScale());
            StartCoroutine(bottonBorder.SpawnBall());
        }
    }

    private IEnumerator ChangeScale()
    {
        transform.localScale = new Vector3(1.3f, 1.3f, 1.3f);
        yield return new WaitForSeconds(0.1f);
        transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    }
}
