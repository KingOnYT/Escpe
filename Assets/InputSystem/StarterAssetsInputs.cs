using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Gun gun;
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;

		[Header("Movement Settings")]
		public bool analogMovement;
		public GameObject crosshair2;
		public GameObject crosshair;
		public Animator animator;

#if !UNITY_IOS || !UNITY_ANDROID
		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;
#endif

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}
		public void OnADS(InputValue value)
        {
			ADS(value.isPressed);
        }

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}
		public void OnShooting(InputValue value)
        {
			ShootingInput(value.isPressed);
        } 
#else
	// old input sys if we do decide to have it (most likely wont)...
#endif
		public void ADS(bool value)
        {
			if(value == true)
            {
				crosshair2.SetActive(true);
				animator.SetBool("isShooting", true);
				
				crosshair.SetActive(false);
            }else if(value != true)
            {
				crosshair2.SetActive(false);
				animator.SetBool("isShooting", false);
				crosshair.SetActive(true);
				
            }
        }
		public void ShootingInput(bool isShooting)
        {
			if(isShooting)
            {
				gun.Shoot();
            }
        }
		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

#if !UNITY_IOS || !UNITY_ANDROID

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

#endif

	}
	
}