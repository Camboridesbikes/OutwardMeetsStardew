using RPGCharacterAnims.Lookups;
using UnityEngine;

namespace RPGCharacterAnims
{
    public class HighJumpTrampoline : MonoBehaviour
    {
        GameObject character;
        float oldJumpSpeed;

        void Update()
        {
            if (character != null) {
                _CharacterController controller = character.GetComponent<_CharacterController>();
                controller.SetJumpInput(Vector3.up);
                controller.TryStartAction(HandlerTypes.Jump);
            }
        }

        private void OnTriggerEnter(Collider collide)
        {
            _CharacterController controller = collide.gameObject.GetComponent<_CharacterController>();

            if (controller != null) {
                character = collide.gameObject;

                RPGCharacterMovementController movement = character.GetComponent<RPGCharacterMovementController>();
                oldJumpSpeed = movement.jumpSpeed;
                movement.jumpSpeed = oldJumpSpeed * 2f;
				Debug.Log("Trampoline!");
			}
        }

        private void OnTriggerExit(Collider collide)
        {
            if (collide.gameObject == character) {
                RPGCharacterMovementController movement = character.GetComponent<RPGCharacterMovementController>();
                movement.jumpSpeed = oldJumpSpeed;
                character = null;
            }
        }
    }
}