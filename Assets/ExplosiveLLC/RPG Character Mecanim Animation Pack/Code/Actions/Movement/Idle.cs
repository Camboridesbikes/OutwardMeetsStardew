using System.Collections;
using RPGCharacterAnims.Lookups;
using UnityEngine;

namespace RPGCharacterAnims.Actions
{
    public class Idle : MovementActionHandler<EmptyContext>
    {
        IEnumerator randomIdleCoroutine;

        public Idle(RPGCharacterMovementController movement) : base(movement)
        {
        }

        public override bool CanStartAction(_CharacterController controller)
        {
            if (controller.isMoving) { return controller.moveInput.magnitude < 0.2f; }
            return controller.acquiringGround;
        }

        protected override void _StartAction(_CharacterController controller, EmptyContext context)
        {
            movement.currentState = CharacterState.Idle;
            if (randomIdleCoroutine != null) { controller.StopCoroutine(randomIdleCoroutine); }
            StartRandomIdleCountdown(controller);
        }

        public override bool IsActive()
        { return movement.currentState != null && (CharacterState)movement.currentState == CharacterState.Idle; }

        private void StartRandomIdleCountdown(_CharacterController controller)
        {
            randomIdleCoroutine = RandomIdle(controller);
            controller.StartCoroutine(randomIdleCoroutine);
        }

        private IEnumerator RandomIdle(_CharacterController controller)
        {
            float waitTime = Random.Range(15f, 25f);
            yield return new WaitForSeconds(waitTime);

            // If we're not still idling, stop here.
            if (!IsActive()) {
                randomIdleCoroutine = null;
                yield break;
            }

            if (controller.canMove) { controller.RandomIdle(); }

            StartRandomIdleCountdown(controller);
        }
    }
}