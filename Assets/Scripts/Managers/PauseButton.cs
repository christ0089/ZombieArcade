using UnityEngine;
using System;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour {
    bool pause, offMusic = true;
    public static bool offSFX = true;
    public Canvas joysticCanvas;
    public GameObject pauseButton, pauseMenu, MainMenu, Weapons, Normal, SettingsMenu, LoadingScene;
    public List<Sprite> ButtonSprite = new List<Sprite>();
    public List<GameObject> settingsButtons = new List<GameObject>();
    public Slider loadBar;
    private bool gamestarted = false;

    private AsyncOperation async;

    // Use this for initialization
    void Awake() {
        pause = false;
        LoadingScene.SetActive(false);
        if (Respawn.tryAgain == false) //Main Menu Screen
        {
            joysticCanvas.GetComponent<Canvas>().enabled = false;
            Time.timeScale = 0;
            Weapons.SetActive(false);
            ScoreManager.gamestarted = false;
        }
        else { //Try Again without Going to the Main Menu Screen
            GameStart();
        }
    }

    public void GameStart() {
        MainMenu.SetActive(false);
        joysticCanvas.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 1;
        pauseButton.SetActive(true);
        Weapons.SetActive(true);
        Normal.SetActive(false);
        ScoreManager.coinCoint = 0;
        ScoreManager.zombieCount = 0;
        ScoreManager.gamestarted = true;
    }


    // Update is called once per frame
    void Paused() {
        if (Setups.survivor.getSurvivorHealth() <= 0) {
            return;
        }
        if (pause)
        {
            Time.timeScale = 0;
            joysticCanvas.GetComponent<Canvas>().enabled = false;
            pauseButton.SetActive(false);
            pauseMenu.SetActive(true);
        }
        else if (!pause) {
            Time.timeScale = 1;
            joysticCanvas.GetComponent<Canvas>().enabled = true;
            pauseButton.SetActive(true);
            pauseMenu.SetActive(false);
        }
    }
    public void SetPause(bool pause_tmp) {
        if (pause_tmp == true)
        {
            pause = true;
        }
        else if (pause_tmp == false){
            pause = false;
        }
        Paused();
    }

    public void Music_Levels (bool temp) {
        if (temp == true && offMusic == true)
        {
            GetComponent<AudioSource>().volume = 0;
            settingsButtons[3].GetComponent<Image>().sprite = ButtonSprite[0];
            offMusic = false;
        }
        else if (offMusic == false){
            GetComponent<AudioSource>().volume = 1;
            settingsButtons[3].GetComponent<Image>().sprite = ButtonSprite[1];
            offMusic = true;
        }
    }

    public void SoundEffects_Levels(bool temp)
    {
        if (temp == true && offSFX == true)
        {
            offSFX = false;
            settingsButtons[2].GetComponent<Image>().sprite = ButtonSprite[0];
        }
        else if (offSFX == false){
            offSFX = true;
            settingsButtons[2].GetComponent<Image>().sprite = ButtonSprite[1];
        }
    }

    public void Settings_Menu(bool temp) 
    {
        if (temp == false)
        {
             SettingsMenu.SetActive(false);
        }
        else if (temp == true){
             SettingsMenu.SetActive(true);
        }
    }
    public void Shopping_Menu() {
        try {
            LoadingScene.SetActive(true);
            StartCoroutine(loadAsync(1));
        }
        catch (Exception ex) {
        }    
    }
    public void Credits() {

    }
    IEnumerator loadAsync(int level) {
        async = SceneManager.LoadSceneAsync(level);
        Time.timeScale = 1;
        while (!async.isDone) {
            loadBar.value = async.progress;
            yield return null;
        }
    }
}
