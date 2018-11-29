using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Setups : MonoBehaviour {

    public static SurvivorClass survivor;
    public static WeaponClass[] Weapons = new WeaponClass[7];

    [SerializeField]
    public float movementSpeed = 5;
    public static int currentWeaponIndx = 0;

    private float health = 100;

    public GameObject survivorGameObject;
    public List<GameObject> weapons = new List<GameObject>(7);

    public  int StartZombieNumber = 30;

	// Use this for initialization
	void Awake () {
        initializeObject();
	}

    void initializeObject()
    {
        Weapons[0] = new WeaponClass("Magnum", weapons[0], 25, .75f, 8, 5);
        Weapons[1] = new WeaponClass("c_Riffle", weapons[1], 30, .75f, 6, 125);
        Weapons[2] = new WeaponClass("S_machinegun", weapons[2], 20, .5f, 12, 100);
        Weapons[3] = new WeaponClass("Shotgun", weapons[3], 40, 1.5f, 6, 20);
        Weapons[4] = new WeaponClass("Bazooka", weapons[4], 30, 2, 10, 10);
        Weapons[5] = new WeaponClass("GranadeLauncher", weapons[5], 50, 2, 5, 30);
        Weapons[6] = new WeaponClass("AcidBullet", weapons[6], 30, 1.5f, 5, 100);

        survivor = new SurvivorClass("Mike", Weapons[0], survivorGameObject, health, movementSpeed);
    }
    public void Start()
    {
        if (SaveAndLoad.control != null)
        {
            for (int i = 0; i < SaveAndLoad.control.guns_bought.Length; i++)
            {
                Weapons[i + 1].upgradeWeapon(SaveAndLoad.control.guns_bought[i]);
            }
            if (SaveAndLoad.control.selectedCharacter != 3) {
                health += (5 * SaveAndLoad.control.selectedCharacter);
                movementSpeed += (.5f * SaveAndLoad.control.selectedCharacter);
            }
            survivor.setSurvivorMaxHealth(health);
            survivor.setSurvivorHealth(health);
            survivor.setSurvivorVelocity(movementSpeed);
            survivor.getSurvivorWeapon().ActivateWeapon();
        }
    }

    public SurvivorClass getSurivivorClass() { return survivor; }

}
