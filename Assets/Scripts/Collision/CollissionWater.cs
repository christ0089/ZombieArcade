using UnityEngine;
using CnControls;
namespace UnityStandardAssests.Copy._2D
{

    public class CollissionWater : MonoBehaviour
    {
        private ZombieMechanism zombieMechanismScript;

        public GameObject waterParticle;

        void OnTriggerStay2D(Collider2D col)
        {
            if (col.gameObject.tag == "Survivor")
            {
                Setups.survivor.setSurvivorVelocity(2.0f);
            }
        }
        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Survivor")
            {
                
                Instantiate(waterParticle, col.gameObject.transform.position, col.gameObject.transform.rotation);
            }
            else if (col.gameObject.tag == "Zombie")
            {
                Instantiate(waterParticle, col.gameObject.transform.position, col.gameObject.transform.rotation);
                
            }
        }
        void OnTriggerExit2D(Collider2D col)
        {
            if (col.gameObject.tag == "Survivor")
            {
                Setups.survivor.setSurvivorVelocity(10.0f);
            }
        }
    }
}