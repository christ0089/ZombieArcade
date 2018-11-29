using UnityEngine;
using CnControls;
namespace UnityStandardAssests.Copy._2D
{

    public class CharacterMovement : MonoBehaviour
    {

   
        private Rigidbody2D _characterController;
        private Transform _transform;


        private void Awake()
        {
            _characterController = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        private void FixedUpdate()
        {
            
            var inputVector = new Vector2(CnInputManager.GetAxis("Horizontal"), CnInputManager.GetAxis("Vertical"));
            _characterController.MovePosition(_characterController.position + inputVector * Time.deltaTime * Setups.survivor.getSurvivorVelocity());

            
            var angle = Mathf.Atan2(inputVector.x, -inputVector.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

            _characterController.velocity = Vector3.zero;
            _characterController.angularVelocity = 0;
        }


    }
}