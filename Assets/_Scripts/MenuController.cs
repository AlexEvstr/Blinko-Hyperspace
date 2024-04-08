using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    private void Start()
    {
        Vibration.Init();
    }

    public void PlayGameButton()
    {
        SceneManager.LoadScene("GameScene");
        VibrateClick();
    }

    private void VibrateClick()
    {
        Vibration.VibratePeek();
    }
}
