using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject _vibro_on;
    [SerializeField] private GameObject _vibro_off;

    [SerializeField] private GameObject _soundOn;
    [SerializeField] private GameObject _soundOff;
    public static bool IsVibroOn;

    public static int TotalScore;

    [SerializeField] private TMP_Text _scoreText;

    [SerializeField] private GameObject _skinsPanel;
    [SerializeField] private GameObject _tutorialPanel;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        Vibration.Init();
        TotalScore = PlayerPrefs.GetInt("TotalScore", 0);
        int vibro = PlayerPrefs.GetInt("vibro", 1);
        if (vibro == 1) VibroOn();
        else VibroOff();

        float audio = PlayerPrefs.GetFloat("audio", 1);
        if (audio == 1) SoundON();
        else SoundOff();
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

    public void SoundOff()
    {
        if (IsVibroOn) Vibration.VibratePeek();
        _soundOff.SetActive(true);
        _soundOn.SetActive(false);
        AudioListener.volume = 0;
        PlayerPrefs.SetFloat("audio", AudioListener.volume);
    }

    public void SoundON()
    {
        if (IsVibroOn) Vibration.VibratePeek();
        _soundOn.SetActive(true);
        _soundOff.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetFloat("audio", AudioListener.volume);
    }

    public void OpenTutorial()
    {
        if (IsVibroOn) Vibration.VibratePeek();
        _tutorialPanel.SetActive(true);
    }

    public void CloseTutorial()
    {
        if (IsVibroOn) Vibration.VibratePeek();
        _tutorialPanel.SetActive(false);
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
