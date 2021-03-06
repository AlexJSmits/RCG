using UnityEngine;
using UnityEngine.Events;

public class CharacterController2D : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;							// Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;			// Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;							// Whether or not a player can steer while jumping;
	public LayerMask m_WhatIsGround;							// A mask determining what is ground to the character
	public Transform m_GroundCheck;							// A position marking where to check if the player is grounded.
	public Transform m_CeilingCheck;							// A position marking where to check for ceilings
	public Collider2D m_CrouchDisableCollider;              // A collider that will be disabled when crouching

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	public bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	private bool m_inCyote = false;
	private float timer;
	private bool jumpSaveOn;
	private Animator characterAnimator;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;


	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		characterAnimator = GetComponent<Animator>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

	private void Update()
	{
		if (!m_inCyote)
		{
			bool wasGrounded = m_Grounded;

			// The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
			// This can be done using layers instead but Sample Assets will not overwrite your project settings.
			Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
			for (int i = 0; i < colliders.Length; i++)
			{
				if (colliders[i].gameObject != gameObject)
				{
					m_inCyote = true;
					Invoke("CoyoteTime", 0.175f);
					m_Grounded = true;
					if (!wasGrounded)
						OnLandEvent.Invoke();
				}
			}
		}

		if (timer > 0)
			{
				timer -= Time.deltaTime;
			} 
	}

	private void CoyoteTime()
	{		
		m_Grounded = false;
		m_inCyote = false;
	}

	public void Move(float move, bool crouch, bool jump)
	{
		// If crouching, check to see if the character can stand up
		if (!crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{

			// If crouching
			if (crouch)
			{
				if (!m_wasCrouching)
				{
					m_wasCrouching = true;
					OnCrouchEvent.Invoke(true);
				}

				// Reduce the speed by the crouchSpeed multiplier
				move *= m_CrouchSpeed;

				// Disable one of the colliders when crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = false;
			} else
			{
				// Enable the collider when not crouching
				if (m_CrouchDisableCollider != null)
					m_CrouchDisableCollider.enabled = true;

				if (m_wasCrouching)
				{
					m_wasCrouching = false;
					OnCrouchEvent.Invoke(false);
				}
			}

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (m_Grounded && jump)
		{
			// Add a vertical force to the player.
			m_Rigidbody2D.velocity = new Vector2 (0, 0);
			m_inCyote = false;
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
		}

		//check to see if the player attempts a jump while still in the air
		if (!m_Grounded && jump)
		{
			jumpSaveOn = true;
			timer = 0.1f;
		}

		//if the player has attempted a jump in the air, check to see if the player lands 0.1 seconds after their input. If true then allow them to jump immediately.
		if (jumpSaveOn && m_Grounded)
		{
			if (timer > 0)
			{
				m_Rigidbody2D.velocity = new Vector2(0, 0);
				m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
				characterAnimator.SetBool("Jump", true);
				jumpSaveOn = false;
			}

			else if (timer <= 0)
			{
				jumpSaveOn = false;
			}
		}
	}

	private void Flip()
	{
		m_FacingRight = !m_FacingRight;
		if (!m_FacingRight)
		{
			GetComponent<SpriteRenderer>().flipX = true;
			this.transform.GetChild(5).gameObject.transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
		}
		else if (m_FacingRight)
		{
			GetComponent<SpriteRenderer>().flipX = false;
			this.transform.GetChild(5).gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}
}
