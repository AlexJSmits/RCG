using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class BoxPhysics : MonoBehaviour
{

    private Rigidbody2D boxRB;
    
    public float power;

    private CharacterController2D script;

    private float direction;

    private float timesKicked;

    private void Start()
    {
        boxRB = this.gameObject.GetComponent<Rigidbody2D>();
        script = GameObject.FindWithTag("Player").GetComponent<CharacterController2D>();
    }

    private void Update()
    {
        if (script.m_FacingRight)
        {
            direction = 0.5f;
        }
        else
        {
            direction = -0.5f;
        }

        if (timesKicked > 0)
            timesKicked -= 1 * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Foot" && timesKicked < 1)
        {
            timesKicked += 1;
            boxRB.AddForce(new Vector2(direction, 1) * (power * 10), ForceMode2D.Impulse);
        }
    }
}
