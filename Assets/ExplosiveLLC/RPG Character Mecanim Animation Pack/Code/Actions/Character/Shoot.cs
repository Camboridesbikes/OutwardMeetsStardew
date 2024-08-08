using RPGCharacterAnims.Lookups;

namespace RPGCharacterAnims.Actions
{
    public class Shoot : InstantActionHandler<EmptyContext>
    {
        public override bool CanStartAction(_CharacterController controller)
        { return controller.canAction; }

        protected override void _StartAction(_CharacterController controller, EmptyContext context)
        {
            var attackNumber = 1;
            if (controller.rightWeapon == Weapon.Rifle && controller.isHipShooting) { attackNumber = 2; }
            controller.Shoot(attackNumber);
        }
    }
}