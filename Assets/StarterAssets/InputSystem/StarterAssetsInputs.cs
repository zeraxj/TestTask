using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		private Animator m_Animator;
		private ThirdPersonController m_ThirdPersonController;
		private float backSpeed;
        private float backSprintSpeed;
		
        [Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
        public bool use;

        [Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;
		private void Start()
		{
			m_ThirdPersonController = GetComponent<ThirdPersonController>();
			backSpeed = m_ThirdPersonController.MoveSpeed;
			backSprintSpeed = m_ThirdPersonController.SprintSpeed;
			m_Animator = GetComponent<Animator>();
		}
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

		public void OnJump(InputValue value)
		{
			//JumpInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnPunch()
		{

			m_ThirdPersonController.MoveSpeed = 0f;
			m_ThirdPersonController.SprintSpeed = 0f;

            m_Animator.SetBool("Punch", true);
			Invoke("OffPunch", 1f);
            
        }

		public void OnUse(InputValue value)
		{
			UseInput(value.isPressed);
			//Invoke("OffUse", Time.deltaTime);
		}
#endif
        public void UseInput(bool newUseState)
        {
            use = newUseState;
        }
        public void OffPunch()
		{
			m_ThirdPersonController.MoveSpeed = backSpeed;
			m_ThirdPersonController.SprintSpeed = backSprintSpeed;
            
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

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}
	
}