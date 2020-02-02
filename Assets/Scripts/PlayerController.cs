using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float MoveSpeed;
	public bool CanMove = true;
	public float GrowCircleRadius;

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
//    			tempVel.x = Mathf.Lerp(tempVel.x, MoveSpeed, 0.8f);
			    tempVel.x = MoveSpeed;
		    }
		    else if (Input.GetKey(KeyCode.A))
    		{
//    			tempVel.x = Mathf.Lerp(tempVel.x, -MoveSpeed, 0.8f);
			    tempVel.x = -MoveSpeed;
		    }
    		else
    		{
//    			tempVel.x = Mathf.Lerp(tempVel.x, 0, 0.8f);
			    tempVel.x = 0f;

    		}
    		
		    if (Input.GetKey(KeyCode.W))
    		{
//    			tempVel.y = Mathf.Lerp(tempVel.y, MoveSpeed, 0.8f);
			    tempVel.y = MoveSpeed;
		    }
		    else if (Input.GetKey(KeyCode.S))
    		{
//    			tempVel.y = Mathf.Lerp(tempVel.y, -MoveSpeed, 0.8f);
			    tempVel.y = -MoveSpeed;
    		}
    		else
    		{
//    			tempVel.y = Mathf.Lerp(tempVel.y, 0, 0.8f);
			    tempVel.y = 0;
    		}
    		
    		rb.velocity = tempVel;

			if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S)) {
				animator.SetInteger("Direction", -1);
				animator.SetBool("isWalking", false);
				
			}

		    if (rb.velocity.x > 0.1f)
		    {
			    if (rb.velocity.y > 0.1f) //Up right
			    {
				    animator.SetInteger("Direction", 2);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = false;
					Debug.Log("Up Right");
			    }
			    else if (rb.velocity.y < -0.1f) //Down right
			    {
				    animator.SetInteger("Direction", 3);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = false;
					Debug.Log("Down Right");
			    }
			    else //Right
			    {
				    animator.SetInteger("Direction", 1);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = false;
					Debug.Log("Right");
			    }
		    }
		    else if (rb.velocity.x < -0.1f)
		    {
			    if (rb.velocity.y > 0.1f) //Up left
			    {
				    animator.SetInteger("Direction", 2);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = true;
					Debug.Log("Up Left");
			    }
			    else if (rb.velocity.y < -0.1f) //Down left
			    {
				    animator.SetInteger("Direction", 3);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = true;
					Debug.Log("Down Left");
			    }
			    else //Left
			    {
				    animator.SetInteger("Direction", 1);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = true;
					Debug.Log("Left");
			    }
		    }
		    else
		    {
			    if (rb.velocity.y > 0.1f) //Up
			    {
				    animator.SetInteger("Direction", 4);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = false;
					Debug.Log("Up");
			    }
			    else if (rb.velocity.y < -0.1f) //Down
			    {
				    animator.SetInteger("Direction", 0);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = false;
					Debug.Log("Down");
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

		Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(transform.position, GrowCircleRadius);

		GetComponentInChildren<ParticleSystem>().Play();
		
		foreach (Collider2D collider in nearbyObjects)
		{
			Debug.Log(collider.gameObject.name);
			DecorManager.DM.GrowObject(collider.gameObject);
		}
	}
	
}
