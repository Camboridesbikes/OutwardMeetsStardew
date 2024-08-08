using UnityEngine;
using UnityEngine.AI;
using RPGCharacterAnims.Lookups;

namespace RPGCharacterAnims
{
    [RequireComponent(typeof(_CharacterController))]
    public class NPC : MonoBehaviour
    {
        [HideInInspector] public NavMeshAgent navMeshAgent;
        private _CharacterController rpgCharacterController;
        private RPGCharacterNavigationController rpgNavigationController;
        private Vector3 targetPosition;

		void Awake()
		{
            rpgCharacterController = GetComponent<_CharacterController>();
            rpgNavigationController = GetComponent<RPGCharacterNavigationController>();
		}

		private void Update()
		{
			if (targetPosition != null) {
				targetPosition = rpgCharacterController.target.transform.position;
				if (IsOutOfRange(transform.position, targetPosition))
				{ rpgCharacterController.StartAction(HandlerTypes.Navigation, RandomOffset(targetPosition)); }
			}
		}

		private Vector3 RandomOffset(Vector3 position)
		{ return new Vector3(position.x - Random.Range(1, 2), position.y, position.z - Random.Range(1, 2)); }

		private bool IsOutOfRange(Vector3 npc, Vector3 player)
		{
			if (Vector3.Distance(npc, player) > 3f) { return true; }
			else { return false; }
		}
	}
}