using UnityEngine;

namespace RPGCharacterAnims.Actions
{
    public class Navigation : BaseActionHandler<Vector3>
    {
        RPGCharacterNavigationController navigation;

        public Navigation(RPGCharacterNavigationController navigation)
        { this.navigation = navigation; }

        public override bool CanStartAction(_CharacterController controller)
        { return navigation != null && controller.canMove; }

        public override bool CanEndAction(_CharacterController controller)
        { return navigation != null && navigation.isNavigating; }

        protected override void _StartAction(_CharacterController controller, Vector3 context)
        { navigation.MeshNavToPoint(context); }

        public override bool IsActive()
        { return navigation.isNavigating; }

        protected override void _EndAction(_CharacterController controller)
        { navigation.StopNavigating(); }
    }
}