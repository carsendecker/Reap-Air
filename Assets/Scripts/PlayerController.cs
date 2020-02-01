using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float MoveSpeed;
	public bool CanMove = true;

	private Rigidbody2D rb;
	private Animator animator;
	private SpriteRenderer sr;
	
	private const float ScaleIncrease = 1.05f;
	
	private Vector3 newScale;
	private float cameraSize;
	private float growthValue;
	private bool isFacingLeft;
	
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		newScale = transform.localScale;
		cameraSize = Camera.main.orthographicSize;

		animator = GetComponent<Animator>();
		sr = GetComponent<SpriteRenderer>();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			GrowPlayer();
		}

		transform.localScale = Vector3.Lerp(transform.localScale, newScale, 0.1f);
		Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, cameraSize, 0.05f);

		if (isFacingLeft)
			sr.flipX = true;
		else
			sr.flipX = false;
	}

	void FixedUpdate()
    {
	    if(CanMove)
			Move();
    }
    
    public void Move()
    	{
    		Vector2 tempVel = rb.velocity;
    		
    		if (Input.GetKey(KeyCode.D))
    		{
    			tempVel.x = Mathf.Lerp(tempVel.x, MoveSpeed, 0.2f);
		    }
		    else if (Input.GetKey(KeyCode.A))
    		{
    			tempVel.x = Mathf.Lerp(tempVel.x, -MoveSpeed, 0.2f);
		    }
    		else
    		{
    			tempVel.x = Mathf.Lerp(tempVel.x, 0, 0.2f);
    		}
    		
		    if (Input.GetKey(KeyCode.W))
    		{
    			tempVel.y = Mathf.Lerp(tempVel.y, MoveSpeed, 0.2f);
    		}
		    else if (Input.GetKey(KeyCode.S))
    		{
    			tempVel.y = Mathf.Lerp(tempVel.y, -MoveSpeed, 0.2f);
    		}
    		else
    		{
    			tempVel.y = Mathf.Lerp(tempVel.y, 0, 0.2f);
    		}
    		
    		rb.velocity = tempVel;

		    if (rb.velocity.x > 0)
		    {
			    if (rb.velocity.y > 0) //Up right
			    {
				    animator.SetInteger("Direction", 2);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = false;
			    }
			    else if (rb.velocity.y < 0) //Down right
			    {
				    animator.SetInteger("Direction", 3);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = false;
			    }
			    else //Right
			    {
				    animator.SetInteger("Direction", 1);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = false;
			    }
		    }
		    else if (rb.velocity.x < 0)
		    {
			    if (rb.velocity.y > 0) //Up left
			    {
				    animator.SetInteger("Direction", 2);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = true;
			    }
			    else if (rb.velocity.y < 0) //Down left
			    {
				    animator.SetInteger("Direction", 3);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = true;
			    }
			    else //Left
			    {
				    animator.SetInteger("Direction", 1);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = true;
			    }
		    }
		    else
		    {
			    if (rb.velocity.y > 0) //Up
			    {
				    animator.SetInteger("Direction", 4);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = false;
			    }
			    else if (rb.velocity.y < 0) //Down
			    {
				    animator.SetInteger("Direction", 0);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = false;
			    }
			    else //Idle
			    {
				    animator.SetBool("isWalking", false);
			    }
		    }
    	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Grow"))
		{
			GrowPlayer();
			Destroy(other.gameObject);
		}
	}

	public void GrowPlayer()
	{
		newScale *= ScaleIncrease;
		cameraSize *= ScaleIncrease;
		MoveSpeed *= ScaleIncrease;
		growthValue += 1;
	}
	
}
