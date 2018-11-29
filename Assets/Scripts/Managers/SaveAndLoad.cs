using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveAndLoad : MonoBehaviour {
    public static SaveAndLoad control;

    public int coin;
    public int TopHighScore;
    public Boolean debug;
    public WeaponClass[] weapons = new WeaponClass[6];

    public int[] guns_bought = new int[5]  ;
    public bool[] character_bought = new bool[5] ;

    public int selectedCharacter;

    public int survivorSpeed = 100;

    void Awake() {
        if (control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if (control != this){
            Destroy(gameObject);
        }
    }

    void OnEnable() {
        Load();
    }

    public void Save() {
        BinaryFormatter binary = new BinaryFormatter();

        FileStream fStream = File.Create(Application.persistentDataPath + "/save_1_File.dat");
        SaveManager saver = new SaveManager();
        saver.coins = coin;

        if (saver.TopHighScore < ScoreManager.zombieCount)
        {
            saver.TopHighScore = ScoreManager.zombieCount;
        }
        if (saver.roundNumber < ScoreManager.roundCount)
        {
            saver.roundNumber = ScoreManager.roundCount;
        }

        saver.gunBought = new int[5];
        saver.characterBought = new bool[5];

        for (int i = 0; i < guns_bought.Length; i++) {
            saver.gunBought[i] = guns_bought[i];
        }
        for (int i = 0; i < character_bought.Length; i++)
        {
            saver.characterBought[i] = character_bought[i];
            Debug.Log(saver.characterBought[i]);
        }

        saver.selctedSurvivor = selectedCharacter;
        binary.Serialize(fStream, saver);
        fStream.Close();

    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/save_1_File.dat"))
        {
            BinaryFormatter binary = new BinaryFormatter();
            FileStream fStream = File.Open(Application.persistentDataPath + "/save_1_File.dat", FileMode.Open);
            SaveManager saver = (SaveManager)binary.Deserialize(fStream);
            fStream.Close();
            coin = debug == true ? 1000 : saver.coins;


            TopHighScore = saver.TopHighScore;
                for (int i = 0; i < guns_bought.Length; i++)
                {
                    guns_bought[i] = saver.gunBought[i];
                }

                for (int i = 0; i < character_bought.Length; i++)
                {
                    character_bought[i] = saver.characterBought[i];
                }
            selectedCharacter = saver.selctedSurvivor;

        }
        else {
            coin = 0000;
            TopHighScore = 0;
            Save();
        }
    }
}
[Serializable]
class SaveManager
{
    public int coins;
    public int TopHighScore;
    public int roundNumber;
    public WeaponClass[] weapons;
    public int selctedSurvivor;
    public int[] gunUpgrade;
    public bool[] characterBought;
    public int[] gunBought;
}