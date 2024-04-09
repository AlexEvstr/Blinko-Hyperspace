using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _vibro_on;
    [SerializeField] private GameObject _vibro_off;
    public static bool IsVibroOn;

    public static int TotalScore;

    [SerializeField] private TMP_Text _scoreText;

    [SerializeField] private GameObject _skinsPanel;

    private void Start()
    {
        Vibration.Init();
        TotalScore = PlayerPrefs.GetInt("TotalScore", 0);
        int vibro = PlayerPrefs.GetInt("vibro", 1);
        if (vibro == 1) VibroOn();
        else VibroOff();
    }

    public void PlayGameButton()
    {
        SceneManager.LoadScene("GameScene");
        VibrateClick();
    }

    private void VibrateClick()
    {
        if (IsVibroOn) Vibration.VibratePeek();
    }

    public void VibroOff()
    {
        _vibro_on.SetActive(false);
        _vibro_off.SetActive(true);
        IsVibroOn = false;
        PlayerPrefs.SetInt("vibro", 0);
        if (IsVibroOn) Vibration.VibratePeek();
    }

    public void VibroOn()
    {
        _vibro_off.SetActive(false);
        _vibro_on.SetActive(true);
        IsVibroOn = true;
        PlayerPrefs.SetInt("vibro", 1);
        if (IsVibroOn) Vibration.VibratePeek();
    }

    public void OpenSkinsPanel()
    {
        if (IsVibroOn) Vibration.VibratePeek();
        _skinsPanel.SetActive(true);
    }

    public void CloseSkinsPanel()
    {
        if (IsVibroOn) Vibration.VibratePeek();
        _skinsPanel.SetActive(false);
    }

    private void Update()
    {
        _scoreText.text = TotalScore.ToString();
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("TotalScore", TotalScore);
    }
}
