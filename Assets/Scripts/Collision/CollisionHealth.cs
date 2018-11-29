using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHealth : MonoBehaviour
{
    public int medKit = 15;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Survivor")
        {
            Destroy(gameObject);
            if (Setups.survivor.getSurvivorHealth() <= Setups.survivor.getMaxHealth())
            {
                if (Setups.survivor.getSurvivorHealth() + medKit > Setups.survivor.getMaxHealth())
                {
                    Setups.survivor.setSurvivorHealth(Setups.survivor.getMaxHealth());
                }else {
                    Setups.survivor.setSurvivorHealth(Setups.survivor.getSurvivorHealth() + medKit);
                }

            }

        }
    }
}
