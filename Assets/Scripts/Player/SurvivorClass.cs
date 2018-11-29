using UnityEngine;
using System.Collections;

public class SurvivorClass
{
    private string s_name;
    private GameObject s_gameObject;
    private WeaponClass s_weapon;
    private Transform s_transform;
    private float s_health;
    private float max_health;
    private float s_velocity;


    public SurvivorClass(string name, WeaponClass weapon, GameObject gameObject, float health, float velocity) {
        s_name = name;
        s_gameObject = gameObject;
        s_transform = gameObject.transform;
        s_health = health;
        max_health = health;
        s_velocity = velocity;
        s_weapon = weapon;
    }

    public void setSurvivorHealth(float health) { s_health = health; }
    public void setSurvivorVelocity(float velocity) { s_velocity = velocity; }
    public void setSurvivorWeapon(WeaponClass weapon) { s_weapon = weapon; }
    public void setSurvivorMaxHealth(float maxHealth) { max_health = maxHealth; }

    public string getSurvivorName() { return s_name; }
    public float getSurvivorHealth() { return s_health; }
    public float getSurvivorVelocity() { return s_velocity; }
    public WeaponClass getSurvivorWeapon() { return s_weapon; }
    public float getMaxHealth() { return max_health; }


    public void setSurvivorAngle(Vector3 v3TouchPos) {
        Vector3 v3SurvivorPos = Camera.main.WorldToScreenPoint(s_transform.position);
        Vector3 v3DiffVec = v3TouchPos - v3SurvivorPos;
        float angle = Mathf.Atan2(v3DiffVec.x, v3DiffVec.y) * Mathf.Rad2Deg;

        s_transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void Damage(int damage) {
        s_health -= damage;
        if (s_health <= 0)
        {
            youAreDead();
        }
    }

    public void onZombieCollisionPushback(ZombieClass zombieThatCollided) {
        s_health -= zombieThatCollided.getZombieAttackPoints();
       // Debug.Log("A Zombie Touched You. Health = " + s_health);
        if (s_health <= 0) {
            youAreDead();
        }  
    }

    public void youAreDead() {
        s_gameObject.SetActive(false);
    }

    // Use this for initialization
}
