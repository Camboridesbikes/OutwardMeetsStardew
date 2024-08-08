using UnityEngine;

namespace RPGCharacterAnims.Actions
{
    public class SlowTime : BaseActionHandler<float>
    {
        public override bool CanStartAction(_CharacterController controller)
        { return !active; }

        public override bool CanEndAction(_CharacterController controller)
        { return active; }

        protected override void _StartAction(_CharacterController controller, float context)
        { Time.timeScale = context; }

        protected override void _EndAction(_CharacterController controller)
        { Time.timeScale = 1f; }
    }
}