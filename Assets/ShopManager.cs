using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour {
    
    public static ShopManager shop;

    public Text Coins;

    public GameObject weapon_Shop, character_Shop, mainShop, referenceShopClose;
    public GameObject shopConfirm;
    public GameObject noMoney;
    public GameObject Yes, No;
    public GameObject LoadingScene;
    public Slider loadBar;

    public List<Text> gunShopPrice;
    public List<Text> characterShopPrice;

    GameObject currentScene;
    public CharacterSpecs characterSpecs;

    private AsyncOperation async;
    private int[] gunShopPrice_int;
    private int[] characterShopPrice_int;
    private float startPosition;
    private bool closeShop = false;

    public ScrollRectSnap[] rectSnaps;


    void Start() {
        Coins.text = SaveAndLoad.control.coin.ToString();
        currentScene = mainShop;

        initialize();
    }

    void initialize() {

        gunShopPrice_int = new int[5] { 200, 300, 500, 550, 660 };
        characterShopPrice_int = new int[5] { 200, 300, 500, 550, 660 };

        this.characterSpecs.UpdateSpecs();

        for (int i = 0; i < gunShopPrice_int.Length; i++)
        {
            if (SaveAndLoad.control.guns_bought[i] == 0)
            {
                gunShopPrice[i].text = gunShopPrice_int[i].ToString();
            }
            else {

                if (SaveAndLoad.control.guns_bought[i] < gunShopPrice.Count - 1)
                {
                    SaveAndLoad.control.guns_bought[i] += 1;
                    gunShopPrice[i].text = (gunShopPrice_int[i] + (SaveAndLoad.control.guns_bought[i] * 100)).ToString();
                }
                else
                {
                    gunShopPrice[i].text = "Max Stats";
                }
            }
        }

        for (int i = 0; i < characterShopPrice_int.Length; i++)
        {
            if (SaveAndLoad.control.character_bought[i] == false)
            {
                characterShopPrice[i].text = characterShopPrice_int[i].ToString();
            }else if ((SaveAndLoad.control.selectedCharacter - 1) == i)
            {
                characterShopPrice[i].text = "Selected";
            }
            else {
                characterShopPrice[i].text = "Select";
               
            }
        }
    }

    void Update() {
        if (currentScene.GetComponent<RectTransform>().position.y >= 600 && closeShop == true)
        {
            currentScene.SetActive(false);
            currentScene.transform.position = new Vector3(currentScene.transform.position.x, 600);
            currentScene = mainShop;
            closeShop = false;
        }
    }

    public void WeaponsShop() {
        weapon_Shop.SetActive(true);
        currentScene = weapon_Shop;
        startPosition = weapon_Shop.transform.position.x;
        currentScene.GetComponent<Rigidbody2D>().gravityScale = 24;
    }

    public void CharacterShop() {
        character_Shop.SetActive(true);
        currentScene = character_Shop;
        currentScene.GetComponent<Rigidbody2D>().gravityScale = 24;
        startPosition = weapon_Shop.transform.position.x;
    }

    public void CloseShop() {
        currentScene.GetComponent<Rigidbody2D>().gravityScale = -24;
        closeShop = true;
        SaveAndLoad.control.Save();
    }


    public void Main_Menu()
    {
        try
        {
            SaveAndLoad.control.Save();
            LoadingScene.SetActive(true);
            StartCoroutine(loadAsync(0));
        }
        catch (Exception ex)
        {
        }
    }

    IEnumerator loadAsync(int level)
    {
        async = SceneManager.LoadSceneAsync(level);
        while (!async.isDone)
        {
            loadBar.value = async.progress;
            yield return null;
        }

    }
    public void selctionConfirm()
    {
        if (character_Shop.activeSelf == true)
        {
            if (SaveAndLoad.control.character_bought[ScrollRectSnap.currentBttn] == false)
            {
                shopConfirm.SetActive(true);
            }
            else
            {
                if (character_Shop.activeSelf == true)
                {
                    characterShopPrice[SaveAndLoad.control.selectedCharacter - 1].text = "Select";
                    SaveAndLoad.control.selectedCharacter = ScrollRectSnap.currentBttn + 1;
                    characterShopPrice[SaveAndLoad.control.selectedCharacter - 1].text = "Selected";
                    this.characterSpecs.UpdateSpecs();
                }
            }
        }else {
            int i = GetComponent<ScrollRectSnap1>().getCurrentBttn();
            if (SaveAndLoad.control.guns_bought[i] < 4)
            {
                shopConfirm.SetActive(true);
            }
        }
    }

    public void yesConfirm()
    {
        shopConfirm.SetActive(false);
        if (weapon_Shop.activeSelf == true) {
            int i = GetComponent<ScrollRectSnap1>().getCurrentBttn();
            Debug.Log("Current Button" + i);
            if (SaveAndLoad.control.coin >= gunShopPrice_int[i])
            {
                SaveAndLoad.control.coin = (SaveAndLoad.control.coin - gunShopPrice_int[i]);
                if (SaveAndLoad.control.guns_bought[i] < gunShopPrice.Count - 1)
                {
                    SaveAndLoad.control.guns_bought[i] += 1;
                    gunShopPrice[i].text = (gunShopPrice_int[i] + (SaveAndLoad.control.guns_bought[i] * 100)).ToString();
                }else {
                    gunShopPrice[i].text = "Max Stats";
                }
            }
            else {
                noMoney.SetActive(true);
            }
        }

        else if (character_Shop.activeSelf == true) {
            int i = rectSnaps[1].getCurrentBttn();
        
            if (SaveAndLoad.control.coin >= characterShopPrice_int[i])
            {
                SaveAndLoad.control.coin = (SaveAndLoad.control.coin - characterShopPrice_int[i]);
                SaveAndLoad.control.character_bought[i] = true;

                characterShopPrice[i].text = "Select";
            }
            else
            {
                noMoney.SetActive(true);
            }
        }
        Coins.text = (SaveAndLoad.control.coin).ToString();
        SaveAndLoad.control.Save();
    }

    public void noConfirm() {
        shopConfirm.SetActive(false);
        noMoney.SetActive(false);
    }


}
