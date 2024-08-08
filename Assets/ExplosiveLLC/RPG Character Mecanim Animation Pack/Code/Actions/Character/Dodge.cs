using RPGCharacterAnims.Lookups;

namespace RPGCharacterAnims.Actions
{
    public class Dodge : InstantActionHandler<DodgeType>
    {
        public override bool CanStartAction(_CharacterController controller)
        { return controller.canAction && !controller.IsActive("Relax"); }

        protected override void _StartAction(_CharacterController controller, DodgeType dodgeType)
        {
            controller.GetAngry();
            controller.Dodge(dodgeType);
        }
    }
}