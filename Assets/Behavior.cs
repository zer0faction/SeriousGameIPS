using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Behavior : MonoBehaviour
{
    public GameObject FireballWithGravity;

    Rigidbody2D bulletRb;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireFireball", 0f, 2f);
    }

    private void FireFireball()
    {
        GameObject bullet = Instantiate(FireballWithGravity, new Vector2(transform.position.x, transform.position.y), Quaternion.Euler(0, 0, 270)) as GameObject;
        bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.velocity = new Vector2(0, 40);
    }
}
