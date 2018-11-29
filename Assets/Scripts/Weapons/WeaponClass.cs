using UnityEngine;
using System.Collections;

public class WeaponClass {
    private string w_name;
    private float w_power;
    private float w_firingRate;
    private float w_speed;
    private float w_ammo;
    private float temp_ammo;

    GameObject NormalWeapon;
    // Use this for initialization


    // Update is called once per frame
    public WeaponClass(string name, GameObject normWeap, float power, float firingRate, float speed, float ammo) {
        w_name = name;
        NormalWeapon = normWeap;
        w_power = power;
        w_firingRate = firingRate;
        w_speed = speed;
        w_ammo = ammo;
        temp_ammo = w_ammo;
    }

    public void setName(string name) { w_name = name;}
    public void setPower(float power) { w_power = power; }
    public void setSpeed(float speed) { w_speed = speed; }
    public void firingRate(float firingRate) { w_firingRate = firingRate; }
    public void setAmmo(float ammo) { w_ammo = ammo; temp_ammo = ammo; }


    public string getName() {return w_name;}
    public float getPower() { return w_power;}
    public float getFiringRate() { return w_firingRate; }
    public float getSpeed() { return w_speed; }
    public float getAmmo() { return w_ammo; }

    public float getAmmoPercentage() { return w_ammo / temp_ammo; }

    public void firing() {
        w_ammo -= 1;
        if (w_ammo <= 0) {
            noAmmo();
        }
    }


    public void noAmmo() {
        NormalWeapon.SetActive(false);
        w_ammo = temp_ammo;
    }

    public void ActivateWeapon() {
        if (w_ammo < temp_ammo) {
            w_ammo = temp_ammo;
        }
        NormalWeapon.SetActive(true);
    }

    public void upgradeWeapon(int upgrade) {
        if (upgrade == 0) {
            return;
        }
        w_ammo = w_ammo + (w_ammo * 0.10f) * upgrade;
        w_power = w_power + (w_power * 0.10f) * upgrade;
    } 
}   
