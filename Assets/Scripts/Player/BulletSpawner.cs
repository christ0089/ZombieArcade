using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bullet;

    public float coolDownTimer;


    // Use this for initialization
    void Start()
    {
        if (gameObject.tag == "Zombie")
        {
            coolDownTimer = Setups.Weapons[6].getFiringRate();
        }
        else {
            coolDownTimer = Setups.Weapons[Setups.currentWeaponIndx].getFiringRate();
        }
   }

    void Update() {
        coolDownTimer -= Time.deltaTime * 2.5f;
        if (coolDownTimer <= 0) {
            Fire();
        }
    }

    // Update is called once per frame


    void Fire() {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        WeaponChange();
        if (gameObject.tag == "Zombie")
        {
            coolDownTimer = Setups.Weapons[6].getFiringRate();
        }
        else {
            coolDownTimer = Setups.survivor.getSurvivorWeapon().getFiringRate();
        }
    }

    void WeaponChange() {
        if (gameObject.tag == "Zombie")
        {
            if (Setups.Weapons[6].getAmmo() - 1 <= -0)
            {
                Setups.Weapons[6].ActivateWeapon();
            }
        }
        else {
            if (Setups.survivor.getSurvivorWeapon().getAmmo() - 1 <= 0)
            {
                Setups.currentWeaponIndx = 0;
                Setups.survivor.getSurvivorWeapon().noAmmo();
                Setups.survivor.setSurvivorWeapon(Setups.Weapons[0]);
                Setups.survivor.getSurvivorWeapon().ActivateWeapon();
            }
            Setups.survivor.getSurvivorWeapon().firing();
        }
    }

}
