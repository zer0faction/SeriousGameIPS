using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurgerBossController : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField] private bool isGoingRight;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;

    private Vector3 velocity;
    private bool onGround;
    private bool doingAttack;

    private GameObject shadowFromAttackGO;
    private GameObject shadowFromAttack;

    // Start is called before the first frame update
    void Start()
    {
        shadowFromAttackGO = transform.GetChild(0).gameObject;
        shadowFromAttack = shadowFromAttackGO.transform.GetChild(0).gameObject;

        onGround = true;
        rb2d = GetComponent<Rigidbody2D>();
        velocity = new Vector3(speed, rb2d.velocity.y, 0);
        if (isGoingRight)
        {
            velocity = new Vector3(speed, rb2d.velocity.y, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            velocity = new Vector3(-speed, rb2d.velocity.y, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        //InvokeRepeating("HighjumpAttack", 3f, 3f);
        InvokeRepeating("Jump", 0f, 1f);
        
    }

    // Update is called once per frame
    private void update()
    {
        if (onGround)
        {
            if (rb2d.IsTouchingLayers(LayerMask.GetMask("Ground")))
            {
                rb2d.velocity = new Vector2(0, 0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            SwitchPosition();
        }
    }

    private void SwitchPosition()
    {
        if (isGoingRight)
        {
            velocity = new Vector3(-speed, rb2d.velocity.y, 0);
            transform.localScale = new Vector3(-1, 1, 1);
            isGoingRight = false;
        }
        else
        {
            velocity = new Vector3(speed, rb2d.velocity.y, 0);
            transform.localScale = new Vector3(1, 1, 1);
            isGoingRight = true;
        }
    }

    private void Jump()
    {
        onGround = true;
        rb2d.velocity = new Vector2(0f, 0f);
        if (isGoingRight)
        {
            Vector2 JumpVelocityToAdd = new Vector2(8f, jumpSpeed);
            rb2d.velocity += JumpVelocityToAdd;
            Debug.Log("Jump " + JumpVelocityToAdd);
        }
        else
        {
            Vector2 JumpVelocityToAdd = new Vector2(-8f, jumpSpeed);
            rb2d.velocity += JumpVelocityToAdd;
            Debug.Log("Jump " + JumpVelocityToAdd);
        }
        StartCoroutine(ExecuteAfterTime(1));
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        onGround = false;
    }

    private void HighjumpAttack()
    {
        Debug.Log("highattack");
        Vector2 JumpVelocityToAdd = new Vector2(0f, 1000);
        rb2d.velocity += JumpVelocityToAdd;
    }
}
