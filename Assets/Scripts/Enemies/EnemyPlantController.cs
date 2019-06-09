using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlantController : MonoBehaviour
{
    public GameObject Fireball;
    public GameObject fireBallSpawnpoint;

    Rigidbody2D bulletRb;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("FireFireball", 0f, 1f);
    }

    private void FireFireball()
    {
        float rightIfHigherThanZero = fireBallSpawnpoint.transform.position.x - gameObject.transform.position.x;
        if(rightIfHigherThanZero > 0)
        {
            GameObject bullet = Instantiate(Fireball, new Vector2(fireBallSpawnpoint.transform.position.x, fireBallSpawnpoint.transform.position.y), Quaternion.Euler(0, 0, 180)) as GameObject;
            bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = new Vector2(18, 0);
        } else
        {
            GameObject bullet = Instantiate(Fireball, new Vector2(fireBallSpawnpoint.transform.position.x, fireBallSpawnpoint.transform.position.y), Quaternion.Euler(0, 0, 0)) as GameObject;
            bulletRb = bullet.GetComponent<Rigidbody2D>();
            bulletRb.velocity = new Vector2(-18, 0);
        }
    }         
}
