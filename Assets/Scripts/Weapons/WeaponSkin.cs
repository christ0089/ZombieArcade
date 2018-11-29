using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponSkin : MonoBehaviour {


    public List<Sprite> Sprites = new List<Sprite>();
    // Use this for initialization

    public GameObject WeaponCrate;


    public float chanceSkin;
    float weaponIndx;
   
    // Use this for initialization
    void Start()
    {
        chanceSkin = Random.Range(0.0f, 1.0f);


        if (chanceSkin >= .8)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[0];
        }
        else if (chanceSkin >= .6)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[1];
        }
        else if (chanceSkin >= .4)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[2];
        }
        else if (chanceSkin >= .2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[3];
        }
        else if (chanceSkin >= 0.0)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = Sprites[4];
        }
    }


    void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "Survivor") {

            if (chanceSkin >= .8)
            {
                WeaponChange(1);
             //  selectWeap.SelectWeapon(1);
            }
            else if (chanceSkin >= .60)
            {
                WeaponChange(2);
         //       selectWeap.SelectWeapon(2);
            }
            else if (chanceSkin >= .40)
            {
                WeaponChange(3);
         //       selectWeap.SelectWeapon(3);
            }
            else if (chanceSkin >= 0.20)
            {
                WeaponChange(4);
        //        selectWeap.SelectWeapon(4);
            }
            else if (chanceSkin >= 0.0)
            {
                WeaponChange(5);
         //       selectWeap.SelectWeapon(5);
            }
            WeaponCrate.SetActive(false);
        }
    }
    // Update is called once per frame

    public void WeaponChange(int indx) {
        Setups.survivor.getSurvivorWeapon().noAmmo();
        Setups.currentWeaponIndx = indx;
        Setups.survivor.setSurvivorWeapon(Setups.Weapons[indx]);      
        Setups.survivor.getSurvivorWeapon().ActivateWeapon();
    }
}
