using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    // Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    Rigidbody2D rb2d;
    Animator myAnimator;
    BoxCollider2D myBody;
    CapsuleCollider2D myFeet;
    private Vector2 playerVelocity;  

    public GameObject carrotBullet;
    public GameObject bulletSpawnPoint;
    Rigidbody2D bulletRb;

    private GameObject pickupList;

    // Use this for initialization
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBody = GetComponent<BoxCollider2D>();
        myFeet = GetComponent<CapsuleCollider2D>();
        pickupList = this.gameObject.transform.GetChild(1).gameObject;
        //PickupRecipeScript = pickupList.GetComponent<PickupRecipeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
        Jump();
        FLipSprite();
        FireCarrot();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RecipePickup"))
        {
            pickupList.GetComponent<RecipePickupListController>().recipeIsPickedUp(other.gameObject);
        }
        else if (other.gameObject.CompareTag("ApplePickup"))
        {
            AppleCollected(1);
        }
    }

    private void AppleCollected(float amount)
    {
        pickupList.GetComponent<RecipePickupListController>().AppleIsPickedUp(amount);
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        bool playerHasHorizontalSpeed = Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon;  

        playerVelocity = new Vector2(controlThrow * runSpeed, rb2d.velocity.y);
        rb2d.velocity = playerVelocity;
        myAnimator.SetBool("Walking", playerHasHorizontalSpeed);
    }

    private void Jump()
    {
        if (!myFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if (CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            Vector2 JumpVelocityToAdd = new Vector2(0f, jumpSpeed);
            rb2d.velocity += JumpVelocityToAdd;
        }
    }

    private void FLipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon;
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb2d.velocity.x) * 2, 2f);
        }
    }

    private void FireCarrot()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            float rightIfHigherThanZero = bulletSpawnPoint.transform.position.x - gameObject.transform.position.x;           

            if (rightIfHigherThanZero > 0)
            {
                GameObject bullet = Instantiate(carrotBullet, new Vector2(bulletSpawnPoint.transform.position.x, bulletSpawnPoint.transform.position.y), Quaternion.Euler(0, 0, -90)) as GameObject;
                bulletRb = bullet.GetComponent<Rigidbody2D>();
                bulletRb.velocity = new Vector2(18, 0);
            } else
            {
                GameObject bullet = Instantiate(carrotBullet, new Vector2(bulletSpawnPoint.transform.position.x, bulletSpawnPoint.transform.position.y), Quaternion.Euler(0, 0, 90)) as GameObject;
                bulletRb = bullet.GetComponent<Rigidbody2D>();
                bulletRb.velocity = new Vector2(-18, 0);
            }         
        }
    }

    private void HitByEnemy()
    {
        if (myBody.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            print("youve been hit");
        }
    }
}
