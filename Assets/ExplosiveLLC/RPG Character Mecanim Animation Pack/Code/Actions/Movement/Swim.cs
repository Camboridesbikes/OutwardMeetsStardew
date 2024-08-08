using RPGCharacterAnims.Lookups;

namespace RPGCharacterAnims.Actions
{
    public class Swim : MovementActionHandler<EmptyContext>
    {
        public Swim(RPGCharacterMovementController movement) : base(movement)
        {
        }

        public override bool CanStartAction(_CharacterController controller)
        { return !IsActive(); }

        protected override void _StartAction(_CharacterController controller, EmptyContext context)
        {
            movement.currentState = CharacterState.Swim;
			controller.SetIKOff();
		}

        public override bool IsActive()
        { return movement.currentState != null && (CharacterState)movement.currentState == CharacterState.Swim; }
    }
}