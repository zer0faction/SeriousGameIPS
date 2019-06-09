using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrotBulletController : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject objectCollided = collider.gameObject;
        if (objectCollided.CompareTag("Enemy"))
        {
            objectCollided.GetComponent<HealthController>().RemoveHealth();
        }
        Destroy(gameObject);
    }
}
