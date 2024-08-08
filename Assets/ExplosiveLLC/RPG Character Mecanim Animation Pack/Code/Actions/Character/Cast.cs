namespace RPGCharacterAnims.Actions
{
    public class Cast : BaseActionHandler<CastContext>
    {
        public override bool CanStartAction(_CharacterController controller)
        { return !controller.isRelaxed && !active && controller.maintainingGround
				&& controller.canAction && controller.hasCastableWeapon; }

        public override bool CanEndAction(_CharacterController controller)
        { return controller.isCasting && active; }

        protected override void _StartAction(_CharacterController controller, CastContext context)
        {  controller.StartCast(context.Type, context.Side); }

        protected override void _EndAction(_CharacterController controller)
        { controller.EndCast(); }
    }
}