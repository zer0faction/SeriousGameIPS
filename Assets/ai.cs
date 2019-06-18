using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai : MonoBehaviour
{
    public Transform burger;
    public Camera cam;
    float shake = 0;
    Rigidbody burgerbody;
    float shakeAmount = 1;
    float decreaseFactor  = 1;
    public Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    private Vector3 posA = Vector3.zero; //Vector3.zero is for initialization
    private Vector3 posB = Vector3.zero;
    Path path;
    int currentWayPoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        burgerbody = burger.GetComponent<Rigidbody>();
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);
        Invoke("ChangeObject", 8);

    }

    void ChangeObject()
    {
        cam.transform.localPosition = Random.insideUnitSphere * shakeAmount;
        shake -= Time.deltaTime * decreaseFactor;
        posA = transform.position;
        posB = burger.transform.position;
        transform.position = posB;
        burger.transform.position = new Vector3(posA.x,3);
        Invoke("move", 2);
    }
    void move()
    {
        burger.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        burger.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }

        void UpdatePath()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(rb.position, target.position, OnPatchComplete);
        }
    }
    void OnPatchComplete(Path p)
    {
        if(!p.error)
        {
            path = p;
            currentWayPoint = 0;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if(path == null)
        {
            return;
        }
        if (currentWayPoint >=path.vectorPath.Count)
        {
            reachedEndOfPath = true;
            return;
        }
        else
        {
            reachedEndOfPath = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWayPoint]- rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWayPoint]);

        if (distance < nextWaypointDistance)
        {
            currentWayPoint++;
        }

    }
}
