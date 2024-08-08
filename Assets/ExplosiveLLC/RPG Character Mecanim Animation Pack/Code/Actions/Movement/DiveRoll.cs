using RPGCharacterAnims.Lookups;

namespace RPGCharacterAnims.Actions
{
    public class DiveRoll : MovementActionHandler<DiveRollType>
    {
        public DiveRoll(RPGCharacterMovementController movement) : base(movement)
        {
        }

        public override bool CanStartAction(_CharacterController controller)
        { return controller.canAction && !controller.isRelaxed; }

        protected override void _StartAction(_CharacterController controller, DiveRollType rollType)
        {
            controller.DiveRoll(rollType);
            movement.currentState = CharacterState.DiveRoll;
		}

        public override bool IsActive()
        { return movement.currentState != null && (CharacterState)movement.currentState == CharacterState.DiveRoll; }
    }
}