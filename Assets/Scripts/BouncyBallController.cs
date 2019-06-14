using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBallController : MonoBehaviour
{
    [SerializeField]
    private float bounceAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerFeet"))
        {
            Vector2 BounceVelocityToAdd = new Vector2(0f, bounceAmount);
            collision.transform.parent.GetComponent<Rigidbody2D>().velocity = BounceVelocityToAdd;
        }
    }
}
