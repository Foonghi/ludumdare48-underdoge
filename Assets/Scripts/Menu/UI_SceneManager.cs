using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_SceneManager : MonoBehaviour
{
    [SerializeField] GameObject startButton;
    
    public void ShowCredits()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 8);
    }

    public void StartGame()
    {
        startButton.SetActive(false);
        FindObjectOfType<StartGameBlackScreenInAndOut>().GoFading();
        StartCoroutine(delayStartGame());
        StartCoroutine(delaySplashSound());
        FindObjectOfType<VolumeFader>().StartFadingVolume();

    }

    public void BackToMainFromCredits()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1);
    }

    IEnumerator delayStartGame()
    {
        yield return new WaitForSeconds(5f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    IEnumerator delaySplashSound()
    {
        yield return new WaitForSeconds(2.5f);
        GetComponent<AudioSource>().Play();
    }
}
