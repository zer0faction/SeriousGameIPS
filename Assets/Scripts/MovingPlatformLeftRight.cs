using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformLeftRight : MonoBehaviour
{

    [SerializeField] private float timeTillMoveAround;
    [SerializeField] private float platformSpeed;
    [SerializeField] private bool isGoingRight;

    private Vector3 velocity;
    private GameObject parent;

    // Start is called before the first frame update
    private void Start()
    {
        velocity = new Vector3(platformSpeed / 20,0,0);
        InvokeRepeating("SwitchPosition", timeTillMoveAround, timeTillMoveAround);
    }

    private void FixedUpdate()
    {
        if (isGoingRight)
        {
            transform.position += velocity;
        }
        else
        {
            transform.position -= velocity;
        }
    }

    // Update is called once per frame
    private void SwitchPosition()
    {
        if (isGoingRight)
        {
            isGoingRight = false;
        } else
        {
            isGoingRight = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            parent = collision.gameObject.transform.gameObject;
            parent.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            parent = collision.gameObject.transform.gameObject;
            parent.transform.SetParent(null);
        }
    }
}
