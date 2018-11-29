using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {

   public static bool tryAgain = false;

   public void ReloadScene()// your listener calls this function
    {
        Debug.Log(SceneManager.GetActiveScene());
        SaveAndLoad.control.coin += ScoreManager.coinCoint;
        SaveAndLoad.control.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        tryAgain = true;
    }
    public void MainScene()// your listener calls this function
    {
        Debug.Log(SceneManager.GetActiveScene());
        SaveAndLoad.control.coin += ScoreManager.coinCoint;
        SaveAndLoad.control.Save();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        tryAgain = false;
    }
}