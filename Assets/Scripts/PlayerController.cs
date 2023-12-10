using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    float horizontalMove = 0f;
    private Rigidbody2D rb;
    public Animator animator;

    public bool isPlayer1 = true;
    private Vector2 axisMovement;

    private int speedBoostDuration = 1; //default boost duration
    private float speedBoost = 1f; //default boost
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        /* // SinglePlayer support
        axisMovement.x = Input.GetAxisRaw("Horizontal");
        axisMovement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.magnitude));
        */

        //Split Screen Support

        if (isPlayer1)
        {
            // For Player 1's horizontal movement (A and D keys)
            if (Input.GetKey(KeyCode.A))
            {
                axisMovement.x = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                axisMovement.x = 1;
            }
            else
            {
                axisMovement.x = 0;
            }

            // For Player 1's vertical movement (W and S keys)
            if (Input.GetKey(KeyCode.W))
            {
                axisMovement.y = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                axisMovement.y = -1;
            }
            else
            {
                axisMovement.y = 0;
            }
        }
        else
        {
            // For Player 2's horizontal movement (Left and Right arrow keys)
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                axisMovement.x = -1;
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                axisMovement.x = 1;
            }
            else
            {
                axisMovement.x = 0;
            }

            // For Player 2's vertical movement (Up and Down arrow keys)
            if (Input.GetKey(KeyCode.UpArrow))
            {
                axisMovement.y = 1;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                axisMovement.y = -1;
            }
            else
            {
                axisMovement.y = 0;
            }
        }


    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.velocity = axisMovement.normalized * moveSpeed;
        CheckForFlipping();

    }

    private void CheckForFlipping()
    {
        bool movingLeft = axisMovement.x < 0;
        bool movingRight = axisMovement.x > 0;

        if(movingLeft && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-1f*transform.localScale.x, transform.localScale.y);
        }
        if(movingRight && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-1f*transform.localScale.x, transform.localScale.y);
        } 
    }

    public void SpeedBuff(float speedBoost, int speedBoostDuration)
    {
        this.speedBoost = speedBoost;
        moveSpeed += speedBoost;
        this.speedBoostDuration = speedBoostDuration;
        StartCoroutine(SpeedBuffCoroutine());
    }
    IEnumerator SpeedBuffCoroutine()
    {
        yield return new WaitForSeconds(speedBoostDuration);

        moveSpeed -= speedBoost;
    }

}

