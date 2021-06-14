using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void HowToPlay()
    {
        AudioManager.instance.Play(SoundList.ButtonPress);
        SceneManager.LoadScene(2);
    }
    public void LoadGame()
    {
        AudioManager.instance.Play(SoundList.ButtonPress);
        SceneManager.LoadScene(1);
    }
    public void Back()
    {
        AudioManager.instance.Play(SoundList.ButtonPress);
        SceneManager.LoadScene(0);
    }
}
