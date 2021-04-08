using UnityEngine;
using UnityEngine.Events;

public class CharacterInputs : MonoBehaviour
{
    public float horizontalMove = 0;
    public CharacterController2D controller;
    bool jump = false;
    bool crouch = false;
    private Animator characterAnimator;
    public UnityEvent OnStart;

    private KeyCode[] keyIdentity = { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R,
    KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P, KeyCode.A, KeyCode.S,
    KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Z,
    KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M, KeyCode.Space};

    //public Sprite[] _keyboardSprites;

    bool[] checkArray;
    public KeyCode rightKey;
    public KeyCode leftKey;
    public KeyCode crouchKey;
    public KeyCode jumpKey;

    public bool canMove = false;
    public float startDelay;

    private void OnEnable()
    {
        checkArray = new bool[keyIdentity.Length];
        characterAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        rightKey = KeyCode.D;

        leftKey = KeyCode.A;

        crouchKey = KeyCode.S;

        jumpKey = KeyCode.Space;

        if (OnStart != null)
        {
            OnStart.Invoke();
        }

        Invoke("LevelStart", startDelay);

    }

    void LevelStart()
    {
        canMove = true;
        startDelay = 0.0f;
    }

    int RNG()
    {
        int x = 0;
        do// do is a loop where the copde is executed when you know it must be exdecuted astleast once
        {
            x = Random.Range(0, keyIdentity.Length);//get a randoim index

        } while (checkArray[x] == true);
        checkArray[x] = true;//we have used this index
        return x;//return index
        /*while(conditional)
         {
         code may not need ot be executed once
         }
         foreach(container variable in collection)
         {
         when you know you must do the exact same operation for each element in the collection
         }
         */
    }

    void Update()
    {
        characterAnimator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        if (canMove == true)
        {
            if (Input.GetKey(rightKey))
            {
                horizontalMove = 1;
            }

            else if (Input.GetKeyUp(rightKey))
            {
                horizontalMove = 0;
            }

            if (Input.GetKey(leftKey))
            {
                horizontalMove = -1;
            }

            else if (Input.GetKeyUp(leftKey))
            {
                horizontalMove = 0;
            }


            if (Input.GetKeyDown(jumpKey) && !crouch)
            {
                jump = true;
                characterAnimator.SetBool("Jump", true);
            }

            if (Input.GetKeyDown(crouchKey))
            {
                crouch = true;
                //animator.SetBool("Jump", false);
            }
            else if (Input.GetKeyUp(crouchKey))
            {
                crouch = false;
            }
        }

    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove, crouch, jump);
        jump = false;
    }

    public void RandomiseAll()
    {
        horizontalMove = 0;

        rightKey = keyIdentity[RNG()];

        leftKey = keyIdentity[RNG()];

        crouchKey = keyIdentity[RNG()];

        jumpKey = keyIdentity[RNG()];
    }

    public void RandomiseMovement()
    {
        horizontalMove = 0;

        checkArray[11] = true;
        checkArray[26] = true;

        rightKey = keyIdentity[RNG()];

        leftKey = keyIdentity[RNG()];
    }

    public void RandomiseJump()
    {
        checkArray[11] = true;
        checkArray[10] = true;
        checkArray[12] = true;

        jumpKey = keyIdentity[RNG()];
    }

    public void RandomiseCrouch()
    {
        checkArray[26] = true;
        checkArray[10] = true;
        checkArray[12] = true;

        crouchKey = keyIdentity[RNG()];
    }

    public void OnLanding()
    {
        characterAnimator.SetBool("Jump", false);
    }

    public void OnCrouch (bool isCrouching)
    {
        characterAnimator.SetBool("isCrouching", isCrouching);

    }

}
