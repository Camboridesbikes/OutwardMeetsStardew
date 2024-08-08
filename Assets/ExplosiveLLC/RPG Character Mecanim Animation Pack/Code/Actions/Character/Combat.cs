using RPGCharacterAnims.Extensions;
using RPGCharacterAnims.Lookups;
using UnityEngine;

namespace RPGCharacterAnims.Actions
{
    public class Combat : BaseActionHandler<AttackContext>
    {
        public override bool CanStartAction(_CharacterController controller)
        { return !controller.isRelaxed && !controller.isCasting && controller.canAction; }

        public override bool CanEndAction(_CharacterController controller)
        { return active; }

        protected override void _StartAction(_CharacterController controller, AttackContext context)
        {



            var attackNumber = context.number;
            var attackWeight = context.AttackWeight;
            var weaponNumber = controller.rightWeapon;
            var duration = 0f;



            if (attackNumber == -1)
            {
                switch (context.type)
                {
                    case "Combat":
                        attackNumber = AnimationData.AttackNumber(attackWeight, weaponNumber);
                        break;
                    case "Special":
                        attackNumber = 1;
                        break;
                }
            }

            duration = AnimationData.AttackDuration(attackWeight, weaponNumber, attackNumber);


            if (context.type == "Combat")
            {
                controller.Attack(
                    attackNumber,
                    attackWeight,
                    duration
                );
                EndAction(controller);
            }
            else if (context.type == "Block")
            {
               // controller.Block();
            }
            else if (context.type == "Parry")
            {
                //controller.Parry();
            }
        }

        protected override void _EndAction(_CharacterController controller)
        {
            if (controller.isSpecial)
            {
                controller.isSpecial = false;
                controller.EndSpecial();
            }
        }
    }
}