using UnityEngine;
using UnityEngine.Events;

public class CharControl : MonoBehaviour
{
    private float horizontalMove = 0;
    public CharacterController2D controller;
    bool jump = false;
    bool crouch = false;
    public Animator animator;
    public UnityEvent OnStart;

    private KeyCode[] keyIdentity = { KeyCode.Q, KeyCode.W, KeyCode.E, KeyCode.R,
    KeyCode.T, KeyCode.Y, KeyCode.U, KeyCode.I, KeyCode.O, KeyCode.P, KeyCode.A, KeyCode.S,
    KeyCode.D, KeyCode.F, KeyCode.G, KeyCode.H, KeyCode.J, KeyCode.K, KeyCode.L, KeyCode.Z,
    KeyCode.X, KeyCode.C, KeyCode.V, KeyCode.B, KeyCode.N, KeyCode.M, KeyCode.Space};
    bool[] checkArray;
    private KeyCode rightKey;
    private KeyCode leftKey;
    private KeyCode crouchKey;
    private KeyCode jumpKey;
    private KeyCode killKey;

    private void OnEnable()
    {
        checkArray = new bool[keyIdentity.Length];
    }
    void Start()
    {
        rightKey = KeyCode.D;

        leftKey = KeyCode.A;

        crouchKey = KeyCode.C;

        jumpKey = KeyCode.Space;

        killKey = KeyCode.K;

        if (OnStart != null)
        {
            OnStart.Invoke();
        }

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
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown(rightKey))
        {
            horizontalMove = 1;
        }

        else if (Input.GetKeyUp(rightKey))
        {
            horizontalMove = 0;
        }

        if (Input.GetKeyDown(leftKey))
        {
            horizontalMove = -1;
        }

        else if (Input.GetKeyUp(leftKey))
        {
            horizontalMove = 0;
        }


        if (Input.GetKeyDown(jumpKey))
        {
            jump = true;
            animator.SetBool("Jump", true);
            animator.SetBool("isCrouching", false);
        }

        if (Input.GetKeyDown(crouchKey))
        {
            crouch = true;
            animator.SetBool("isCrouching", true);
            animator.SetBool("Jump", false);
        }
        else if (Input.GetKeyUp(crouchKey))
        {
            crouch = false;
            animator.SetBool("isCrouching", false);
        }

        if (Input.GetKey(killKey))
        {
            KillPlayer();
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

        killKey = keyIdentity[RNG()];
    }

    public void RandomiseMovement()
    {
        horizontalMove = 0;

        rightKey = keyIdentity[RNG()];

        leftKey = keyIdentity[RNG()];
    }

    public void RandomiseJump()
    {
        jumpKey = keyIdentity[RNG()];
    }

    public void RandomiseCrouch()
    {
        crouchKey = keyIdentity[RNG()];
    }

    public void OnLanding()
    {
        animator.SetBool("Jump", false);
    }

    void KillPlayer()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
