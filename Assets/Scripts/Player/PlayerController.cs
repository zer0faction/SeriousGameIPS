﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{

    // Config
    [SerializeField] float runSpeed = 5f;
    [SerializeField] float jumpSpeed = 5f;

    Rigidbody2D rb2d;
    Animator myAnimator;
    BoxCollider2D myFeet;
    private Vector2 playerVelocity;  

    public GameObject carrotBullet;
    public GameObject bulletSpawnPoint;
    Rigidbody2D bulletRb;

    private GameObject pickupList;
    private GameObject carrotGun;

    private CarrotAmmoController carrotAmmoController;

    private bool isDead;

    private PlayerHealthController playerHealth;
    private PlayerStaminaScript playerStamina;

    private float tempTimeForStaminaRegen;
    private float tempTimeForStaminaLoss;

    private bool running;
    private bool cooldownTime;

    private bool StaminaHasBeenAdded;

    // Use this for initialization
    private void Start()
    {
        StaminaHasBeenAdded = false;
        isDead = false;
        rb2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myFeet = this.gameObject.transform.GetChild(2).gameObject.GetComponent<BoxCollider2D>();
        Debug.Log("haha" + myFeet);

        pickupList = this.gameObject.transform.GetChild(1).gameObject;
        carrotGun = this.gameObject.transform.GetChild(0).gameObject;

        playerHealth = gameObject.GetComponent<PlayerHealthController>();
        playerStamina = gameObject.GetComponent<PlayerStaminaScript>();

        carrotAmmoController = carrotGun.GetComponent<CarrotAmmoController>();
        //PickupRecipeScript = pickupList.GetComponent<PickupRecipeScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Run();
            Jump();
            FireCarrot();
            FLipSprite();
           
        }

        tempTimeForStaminaLoss += Time.deltaTime;
        tempTimeForStaminaRegen += Time.deltaTime;
        if (tempTimeForStaminaRegen > 0.05 && cooldownTime == false)
        {
            tempTimeForStaminaRegen = 0;
            playerStamina.AddStamina();
        }

        if (cooldownTime)
        {
            StartCoroutine(ExecuteAfterTime(2));
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("name: " + other.gameObject.name);
        if (other.gameObject.CompareTag("RecipePickup"))
        {
            pickupList.GetComponent<RecipePickupListController>().recipeIsPickedUp(other.gameObject);
        }
        else if (other.gameObject.CompareTag("ApplePickup"))
        {
            playerHealth.AddHealth();
            pickupList.GetComponent<RecipePickupListController>().AppleIsPickedUp(other.gameObject);
        }
        //Een hazard killed je altijd
        else if (other.gameObject.CompareTag("Hazard"))
        {
            playerHealth.RemoveAllHealth();
            Die();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            playerHealth.RemoveHealth();
        }
        else if (other.gameObject.CompareTag("CarrotPickup"))
        {
            carrotAmmoController.AddCarrot();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("FitnessSchool"))
        {
            if (!StaminaHasBeenAdded)
            {
                StaminaHasBeenAdded = true;
                playerStamina.HigherMaxStamina();
            }
        }
    }

    public void Die()
    {
        isDead = true;

        myAnimator.SetBool("Walking", false);
        myAnimator.SetBool("Dead", true);
       
        rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;

        Debug.Log("Player died");

        gameObject.transform.GetChild(0).gameObject.SetActive(false);

        Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);
    }

    private void Run()
    {
        float controlThrow = CrossPlatformInputManager.GetAxis("Horizontal");
      
            if (Input.GetKey(KeyCode.LeftShift) && playerStamina.AllowedToSprint())
            {
                running = true;
                cooldownTime = true;

                playerVelocity = new Vector2(controlThrow * runSpeed * 3 / 2, rb2d.velocity.y);
                
                if (tempTimeForStaminaLoss > 0.02)
                {
                    tempTimeForStaminaLoss = 0;
                    playerStamina.RemoveStamina();
                }
            }
            else
            {
                running = false;
                playerVelocity = new Vector2(controlThrow * runSpeed, rb2d.velocity.y);
            }
        
        rb2d.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(rb2d.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("Walking", playerHasHorizontalSpeed);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        cooldownTime = false;
        // Code to execute after the delay
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
            transform.localScale = new Vector2(Mathf.Sign(rb2d.velocity.x) * 1, 1f);
        }
    }

    private void FireCarrot()
    {
        if (CrossPlatformInputManager.GetButtonDown("Fire1"))
        {
            if(carrotGun.GetComponent<CarrotAmmoController>().carrotAmount > 0)
            {
                float rightIfHigherThanZero = bulletSpawnPoint.transform.position.x - gameObject.transform.position.x;

                if (rightIfHigherThanZero > 0)
                {
                    GameObject bullet = Instantiate(carrotBullet, new Vector2(bulletSpawnPoint.transform.position.x, bulletSpawnPoint.transform.position.y), Quaternion.Euler(0, 0, -90)) as GameObject;
                    bulletRb = bullet.GetComponent<Rigidbody2D>();
                    bulletRb.velocity = new Vector2(18, 0);
                    carrotAmmoController.RemoveCarrot();
                }
                else
                {
                    GameObject bullet = Instantiate(carrotBullet, new Vector2(bulletSpawnPoint.transform.position.x, bulletSpawnPoint.transform.position.y), Quaternion.Euler(0, 0, 90)) as GameObject;
                    bulletRb = bullet.GetComponent<Rigidbody2D>();
                    bulletRb.velocity = new Vector2(-18, 0);
                    carrotAmmoController.RemoveCarrot();
                }
            }
        }
    }
}
