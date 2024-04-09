using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public static bool IsVibroOn;
    [SerializeField] private GameObject _ball;
    [SerializeField] private Sprite[] _balls;

    private void OnEnable()
    {
        LoadBall();
    }

    private void Start()
    {
        Vibration.Init();
        int vibro = PlayerPrefs.GetInt("vibro", 1);
        if (vibro == 1) IsVibroOn = true;
        else IsVibroOn = false;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene("MenuScene");
    }

    private void LoadBall()
    {
        string ballName = PlayerPrefs.GetString("Ball", "");

        for (int i = 0; i < _balls.Length; i++)
        {
            if (_balls[i].name == ballName)
            {
                _ball.GetComponent<SpriteRenderer>().sprite = _balls[i];
            }
        }
    }

}
