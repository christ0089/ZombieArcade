using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ButtonManager : MonoBehaviour {

    public Image currentSprite;
    public List<Sprite> upgrade_sprites = new List<Sprite>();
    public Text Upgrade;

    public int id;

    public void setID(int sendId) {
        id = sendId;
    }

	// Use this for initialization
	void Start () {
        
	}

    void Update() {
        Initialize();
    }

    public void Initialize() {
        Upgrade.text = "Upgrade: "+ SaveAndLoad.control.guns_bought[id].ToString();
        currentSprite.sprite = upgrade_sprites[SaveAndLoad.control.guns_bought[id]];
    }
}
