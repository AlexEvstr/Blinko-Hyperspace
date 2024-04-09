using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinsManager : MonoBehaviour
{
    [SerializeField] private GameObject _metka;
    [SerializeField] private int _price;

    [SerializeField] private GameObject _earn_score;
    [SerializeField] private GameObject _unlocked;

    private void Start()
    {
        string ballName = PlayerPrefs.GetString("Ball", "");
        if (gameObject.name == ballName)
        {
            _metka.transform.SetParent(gameObject.transform);
        }
    }

    public void BuySkin()
    {
        if (!_unlocked.activeInHierarchy)
        {
            if (MenuController.IsVibroOn) Vibration.VibrateIOS(NotificationFeedbackStyle.Success);
            MenuController.TotalScore -= _price;
            SaveStatus();
        }
        if (MenuController.IsVibroOn) Vibration.VibratePeek();

        PlayerPrefs.SetString("Ball", gameObject.name);

        _metka.transform.SetParent(gameObject.transform);

        MakeOwned();
    }

    private void SaveStatus()
    {
        if (gameObject.name.Contains("0"))
        {
            PlayerPrefs.SetString("ball_0", "unlocked");
        }
        else if (gameObject.name.Contains("1"))
        {
            PlayerPrefs.SetString("ball_1", "unlocked");
        }
        else if (gameObject.name.Contains("2"))
        {
            PlayerPrefs.SetString("ball_2", "unlocked");
        }
        else if (gameObject.name.Contains("3"))
        {
            PlayerPrefs.SetString("ball_3", "unlocked");
        }
    }

    private void Update()
    {
        CheckBall();
        CheckPrice();
        CheckStatus();
    }

    private void CheckBall()
    {
        if (gameObject.transform.childCount == 4)
        {
            gameObject.GetComponent<Image>().color = Color.red;
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(1, 1, 1);
        }
    }

    private void CheckPrice()
    {
        if (_price > Score.TotalScore && !_unlocked.activeInHierarchy)
        {
            gameObject.GetComponent<Button>().interactable = false;
        }
        else
        {
            gameObject.GetComponent<Button>().interactable = true;
        }
    }

    private void CheckStatus()
    {
        if (gameObject.name.Contains("0"))
        {
            if (PlayerPrefs.GetString("ball_0", "") != "")
            {
                MakeOwned();
            }
        }
        else if (gameObject.name.Contains("1"))
        {
            if (PlayerPrefs.GetString("ball_1", "") != "")
            {
                MakeOwned();
            }
        }
        else if (gameObject.name.Contains("2"))
        {
            if (PlayerPrefs.GetString("ball_2", "") != "")
            {
                MakeOwned();
            }
        }
        else if (gameObject.name.Contains("3"))
        {
            if (PlayerPrefs.GetString("ball_3", "") != "")
            {
                MakeOwned();
            }
        }
    }

    private void MakeOwned()
    {
        _earn_score.SetActive(false);
        _unlocked.SetActive(true);
    }
}
