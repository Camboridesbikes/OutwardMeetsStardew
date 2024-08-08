using UnityEngine;
using UnityEngine.InputSystem;

namespace RPGCharacterAnims
{
	/// <summary>
	/// Basic Camera Controller with Follow, Rotate, and Zoom functionality.
	/// Can be used with either Legacy Input or Input System inputs.
	/// </summary>
	public class CameraController:MonoBehaviour
	{
		public GameObject cameraTarget;
		public float cameraTargetOffsetY;
		private Vector3 cameraTargetOffset;
		public float rotateSpeed = 2.0f;
		private float rotate;
		public float height = 6.0f;
		public float maxheight = 6.0f;
		public float minheight = 2.0f;
		public float distance = 5.0f;
		public float zoomAmount = 0.1f;
		public float smoothing = 2.0f;
		private Vector3 offset;
		private bool following = true;
		private Vector3 lastPosition;

		// Inputs.
		private bool inputFollow;
		private bool inputRotateR;
		private float inputRotate;
		private bool inputMouseScrollUp;
		private bool inputMouseScrollDown;
		private Vector2 CameraMovementInput => _CameraMovementInput;
		private Vector2 _CameraMovementInput;

		// Input System.
		private @RPGInputs rpgInputs;

        private void Start()
		{
			// Try to find Player if not set in Inspector.
			if (cameraTarget == null) { cameraTarget = GameObject.FindWithTag("Player"); }

			if (!cameraTarget) { Debug.LogError("No target selected for Camera."); }
			else { SetStartPosition(); }

        }

        private void Awake()
        {
            rpgInputs = new @RPGInputs();
        }

        private void OnEnable()
		{
			rpgInputs.Enable(); 
		}


		/// <summary>
		/// Sets the initial starting position for the camera.
		/// </summary>
		private void SetStartPosition()
		{
			offset = new Vector3(cameraTarget.transform.position.x,
				cameraTarget.transform.position.y + height,
				cameraTarget.transform.position.z - distance);

			lastPosition = new Vector3(cameraTarget.transform.position.x,
				cameraTarget.transform.position.y + height,
				cameraTarget.transform.position.z - distance);

			distance = 1;
			height = 1;
		}

		/// <summary>
		/// Sets the inputs depending on whether the Input System is used or the Legacy Inputs.
		/// </summary>
		private void Inputs()
		{
			try
			{
                inputFollow = Keyboard.current.fKey.isPressed;
                inputRotate = rpgInputs.Camera.Movement.ReadValue<Vector2>().x;
                //inputRotateR = Keyboard.current.eKey.isPressed;
                inputMouseScrollUp = rpgInputs.Camera.Movement.ReadValue<Vector2>().y < 0f;
                inputMouseScrollDown = rpgInputs.Camera.Movement.ReadValue<Vector2>().y > 0f;

				Debug.Log( "inputRotate: " +inputRotate);
                Debug.Log("input Camera Movement: " + rpgInputs.Camera.Movement.ReadValue<Vector2>());

            }
			catch (System.Exception) { Debug.LogError("Inputs not found!  Character must have Player Input component."); }
				
    
		
		}

		private void Update()
		{
			if (!cameraTarget) { return; }

			Inputs();

			// Follow cam.
			if (inputFollow) {
				if (following) { following = false; }
				else { following = true; }
			}
			if (following) { CameraFollow(); }
			else { transform.position = lastPosition; }

			// Rotate cam.

			rotate = inputRotate;

			// Mouse zoom.
			if (inputMouseScrollUp && height <= maxheight) { distance += zoomAmount; height += zoomAmount; }
			else if (inputMouseScrollDown && height >= minheight) { distance -= zoomAmount; height -= zoomAmount; }

			// Set cameraTargetOffset as cameraTarget + cameraTargetOffsetY.
			cameraTargetOffset = cameraTarget.transform.position + new Vector3(0, cameraTargetOffsetY, 0);

			// Smoothly look at cameraTargetOffset.
			transform.rotation = Quaternion.Slerp(transform.rotation,
				Quaternion.LookRotation(cameraTargetOffset - transform.position),
				Time.deltaTime * smoothing);
		}

		private void CameraFollow()
		{
			offset = Quaternion.AngleAxis(rotate * rotateSpeed, Vector3.up) * offset;

			transform.position = new Vector3(Mathf.Lerp(lastPosition.x, cameraTarget.transform.position.x + offset.x, smoothing * Time.deltaTime),
				Mathf.Lerp(lastPosition.y, cameraTarget.transform.position.y + offset.y * height, smoothing * Time.deltaTime),
				Mathf.Lerp(lastPosition.z, cameraTarget.transform.position.z + offset.z * distance, smoothing * Time.deltaTime));
		}

		private void LateUpdate()
		{ lastPosition = transform.position; }
	}
}