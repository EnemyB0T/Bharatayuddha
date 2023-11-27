using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 5f;
    float horizontalMove = 0f;
    private Rigidbody2D rb;
    public Animator animator;

    public float BORDER_X_LEFT = -19.5f;
    public float BORDER_X_RIGHT = 19.5f;
    public float BORDER_Y_TOP = 9f;
    public float BORDER_Y_BOTTOM = -9f;
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
        axisMovement.x = Input.GetAxisRaw("Horizontal");
        axisMovement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.magnitude));

        /*
        if(transform.position.y >= BORDER_Y_TOP)
        {
            transform.position = new Vector3(transform.position.x, BORDER_Y_TOP, 0);
        } 
        else if(transform.position.y <= BORDER_Y_BOTTOM)
        {
            transform.position = new Vector3(transform.position.x, BORDER_Y_BOTTOM, 0);
        } 
        else if(transform.position.x <= BORDER_X_LEFT)
        {
            transform.position = new Vector3(BORDER_X_LEFT, transform.position.y, 0);
        } 
        else if(transform.position.x >= BORDER_X_RIGHT)
        {
            transform.position = new Vector3(BORDER_X_RIGHT, transform.position.y, 0);
        } 
        */
        


        
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

