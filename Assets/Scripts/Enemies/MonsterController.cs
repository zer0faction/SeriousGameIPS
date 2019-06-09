using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField] private bool isGoingRight;
    [SerializeField] private float speed;

    private Vector3 velocity;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        velocity = new Vector3(speed, rb2d.velocity.y, 0);
        if (isGoingRight)
        {
            velocity = new Vector3(speed, rb2d.velocity.y, 0);
            transform.localScale = new Vector3(-1, 1, 1);
        } else
        {
            velocity = new Vector3(-speed, rb2d.velocity.y, 0);
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        if (isGoingRight)
        {
            rb2d.velocity = velocity;
        }
        else
        {
            rb2d.velocity = velocity;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground")){
            SwitchPosition();
        }
    }

    private void SwitchPosition()
    {
        if (isGoingRight)
        {
            velocity = new Vector3(-speed, rb2d.velocity.y, 0);
            transform.localScale = new Vector3(1, 1, 1);
            isGoingRight = false;
        }
        else
        {
            velocity = new Vector3(speed, rb2d.velocity.y, 0);
            transform.localScale = new Vector3(-1, 1, 1);
            isGoingRight = true;
        }
    }
}
