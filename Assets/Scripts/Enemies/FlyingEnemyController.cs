using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyController : MonoBehaviour
{
    [SerializeField] private float timeTillMoveAround;
    [SerializeField] private float FlySpeed;
    [SerializeField] private bool isGoingUp;

    private Vector3 velocity;
    private GameObject parent;

    // Start is called before the first frame update
    private void Start()
    {
        velocity = new Vector3(0, FlySpeed / 20, 0);
        InvokeRepeating("SwitchPosition", timeTillMoveAround, timeTillMoveAround);
    }

    private void FixedUpdate()
    {
        if (isGoingUp)
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
        if (isGoingUp)
        {
            isGoingUp = false;
        }
        else
        {
            isGoingUp = true;
        }
    }
}
