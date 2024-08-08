namespace RPGCharacterAnims.Actions
{
    public class Null : InstantActionHandler<EmptyContext>
    {
        public override bool CanStartAction(_CharacterController controller)
        { return false; }

        protected override void _StartAction(_CharacterController controller, EmptyContext context)
        {
        }
    }
}