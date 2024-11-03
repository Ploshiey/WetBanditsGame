using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    #region Player Components
    public Rigidbody rb;
    public Animator anim;
    public Animator flip;
    public SpriteRenderer sr;
    public GameObject footsteps;
    public GameObject running;
    #endregion

    #region Movement Stats
    [Header("Movement Stats")]
    [SerializeField] private float walkSpeed = 4;
    [SerializeField] private float sprintSpeed = 8;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool movingBackwards;
    

    [Header("Stamina Main")]
    [SerializeField] private float maxStamina = 100.0f;
    //[SerializeField] private float jumpCost = 20;
    public float playerStamina = 100.0f;
    public bool hasRegenerated = true;
    public bool isSprinting = false;

    [Header("Stamina Regen")]
    [Range(0, 50)][SerializeField] private float staminaDrain = 0.5f;
    [Range(0, 50)][SerializeField] private float staminaRegen = 0.5f;

    [Header("Stamina UI Elements")]
    [SerializeField] private Image staminaProgessUI = null;
    [SerializeField] private CanvasGroup sliderCanvasGroup = null;
    #endregion

    private Vector2 moveInput;


    void Update()
    {
        SprintingController();
        if (Input.GetKey(KeyCode.LeftShift) && playerStamina > 0)
        {
            moveSpeed = sprintSpeed;
            isSprinting = true;
            hasRegenerated = false;
            Sprinting();
        }
        else
        {
            moveSpeed = walkSpeed;
            isSprinting = false;
            hasRegenerated = true;
        }

     

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (moveSpeed > walkSpeed)
            {
                footsteps.SetActive(false);
                running.SetActive(true);
            }
            else
            {
                footsteps.SetActive(true);
                running.SetActive(false);
            }
        }
        else
        {
            footsteps.SetActive(false);
            running.SetActive(false);
        }

        staminaProgessUI.fillAmount = playerStamina / maxStamina;

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        moveInput.Normalize();

        rb.velocity = new Vector3(moveInput.x * moveSpeed, rb.velocity.y, moveInput.y * moveSpeed);

        anim.SetFloat("moveSpeed", rb.velocity.magnitude);
        anim.SetFloat("x", moveInput.x);
        anim.SetFloat("y", moveInput.y);
       
    }

    void FixedUpdate()
    {
        if(!sr.flipX && moveInput.x < 0)
        {
            sr.flipX = true;
        }
        else if(sr.flipX && moveInput.x > 0)
        {
            sr.flipX = false;
        }

        if (moveInput.x == 1 || moveInput.x == -1)
        {
            anim.SetBool("sideWalk", true);
        }
        else
        {
            anim.SetBool("sideWalk", false);
        }

        if (!movingBackwards && moveInput.y > 0)
        {
            movingBackwards = true;
        }
        else if (movingBackwards && moveInput.y < 0)
        {
            movingBackwards = false;
        }

        anim.SetBool("moveBackwards", movingBackwards);
    }

    #region Sprint Controller
    private void SprintingController()
    {
        if (isSprinting == false && playerStamina < maxStamina - 0.01)
        {
            playerStamina += staminaRegen * Time.deltaTime;




        }
        else if (isSprinting == false && playerStamina >= maxStamina - 0.01)
        {
            //set to normal speed
            //reset our slider value slider
            sliderCanvasGroup.alpha = 0;
            hasRegenerated = true;
            playerStamina = 100f;
            UpdateStamina(0);
        }

    }

    //public void StaminaJump()
    //{
    //    if(playerStamina >= (maxStamina * jumpCost / maxStamina))
    //    {
    //        playerStamina -= jumpCost;
    //        UpdateStamina(1);
    //    }
    //}

    public void Sprinting()
    {
        if (hasRegenerated == false)
        {
            isSprinting = true;
            playerStamina -= staminaDrain * Time.deltaTime;
            UpdateStamina(1);

            if (playerStamina <= 0)
            {
                hasRegenerated = false;
                //slow the player
            }
        }
    }

    void UpdateStamina(int value)
    {

        if (value == 0)
        {
            sliderCanvasGroup.alpha = 0;
        }
        else
        {
            sliderCanvasGroup.alpha = 1;

        }
        //Stamina Slider
        #endregion
    }
    public void onMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
}
