using UnityEngine;
using System.Collections;

public class ZombieClass  {
    private GameObject z_gameObject;
    private Transform z_transfrom;
    private float z_attackPoint;
    private float z_speed;
    private float z_health;
    private float z_health_temp;

    public ZombieClass(GameObject zombieGameObject, float zombieAttackPoint, float zombieHealth, float zombieSpeed) {
        z_gameObject = zombieGameObject;
        z_transfrom = zombieGameObject.transform;
        z_attackPoint = zombieAttackPoint;
        z_speed = zombieSpeed;
        z_health = zombieHealth;
        z_health_temp = z_health;
    }
    // Use this for initialization
    public float getZombieSpeed() { return z_speed; }
    public float getZombieHealth() { return z_health;}
    public float getZombieAttackPoints() { return z_attackPoint;}

    public void setzombieHealth(float zHealth) { z_health = zHealth; }
    public void setZombeAttackPoints(float zAttackPoints) { z_attackPoint = zAttackPoints; }
    public void setZombieSpeed(float zSpeed) { z_speed = zSpeed; }

    public void moveAndLookAtSurvivor(Transform survivorTransform) {
        Vector3 v2ZombiePos = new Vector3(z_transfrom.position.x, z_transfrom.position.y);

        Vector3 v2SurivorPos = new Vector3(survivorTransform.position.x, survivorTransform.position.y);

        Vector3 lookAtDirection = v2SurivorPos - v2ZombiePos;

        z_transfrom.up = -lookAtDirection;

        float deltaSpace = Time.deltaTime * z_speed;

        z_transfrom.position = Vector3.Lerp(z_transfrom.position, survivorTransform.position, deltaSpace);
    }

      

public void subtractHealth(float damage)
    {
        z_health -= damage;
        if (z_health <= 0)
        {
            getDestroyed();

        }
    }
    public void getDestroyed() {
        z_gameObject.SetActive(false);
        ScoreManager.zombieCount += 1;
        resetConfig();
    }

    public void resetConfig() {
        z_health = z_health_temp + (ScoreManager.roundCount * 1.25f);
    }
}

