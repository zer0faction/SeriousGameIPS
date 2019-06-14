using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    private void OnTriggerEnter2D()
    {
        Destroy(gameObject);
    }
}
