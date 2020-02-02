using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Facing
{
	Up = 0,
	Down = 1,
	Left = 2,
	Right = 3,
	UpRight = 4,
	UpLeft = 5,
	DownRight = 6,
	DownLeft = 7
}

public class PlayerController : MonoBehaviour
{
	
	public float MoveSpeed;
	public bool CanMove = true;
	public float GrowCircleRadius;
	public float DashCooldown;
	public float GrowthValue;
	public float DashForce;
	
	public Facing FaceDir;
	[HideInInspector] public bool isFacingLeft;

	[Space(10)] 
	public ParticleSystem PuffParticles;
	public ParticleSystem DashParticles;

	private Rigidbody2D rb;
	private Animator animator;
	private SpriteRenderer sr;
	
	private const float ScaleIncrease = 1.05f;
	
	private Vector3 newScale;
	private float cameraSize;
	private bool dashing;
	
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
		transform.localScale = Vector3.Lerp(transform.localScale, newScale, 0.1f);
		Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, cameraSize, 0.05f);

		if (isFacingLeft)
			sr.flipX = true;
		else
			sr.flipX = false;

		if (Input.GetKeyDown(KeyCode.LeftShift) && !dashing)
		{
			StartCoroutine(Dash());
		}
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
				FaceDir = Facing.Down;

			}

		    if (rb.velocity.x > 0.1f)
		    {
			    if (rb.velocity.y > 0.1f) //Up right
			    {
				    animator.SetInteger("Direction", 2);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = false;
				    FaceDir = Facing.UpRight;

			    }
			    else if (rb.velocity.y < -0.1f) //Down right
			    {
				    animator.SetInteger("Direction", 3);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = false;
				    FaceDir = Facing.DownRight;

			    }
			    else //Right
			    {
				    animator.SetInteger("Direction", 1);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = false;
				    FaceDir = Facing.Right;
			    }
		    }
		    else if (rb.velocity.x < -0.1f)
		    {
			    if (rb.velocity.y > 0.1f) //Up left
			    {
				    animator.SetInteger("Direction", 2);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = true;
				    FaceDir = Facing.UpLeft;

			    }
			    else if (rb.velocity.y < -0.1f) //Down left
			    {
				    animator.SetInteger("Direction", 3);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = true;
				    FaceDir = Facing.DownLeft;

			    }
			    else //Left
			    {
				    animator.SetInteger("Direction", 1);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = true;
				    FaceDir = Facing.Left;

			    }
		    }
		    else
		    {
			    if (rb.velocity.y > 0.1f) //Up
			    {
				    animator.SetInteger("Direction", 4);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = false;
				    FaceDir = Facing.Up;

			    }
			    else if (rb.velocity.y < -0.1f) //Down
			    {
				    animator.SetInteger("Direction", 0);
				    animator.SetBool("isWalking", true);
				    isFacingLeft = false;
				    FaceDir = Facing.Down;
			    }
			    else //Idle
			    {
				    animator.SetBool("isWalking", false);
				    FaceDir = Facing.Down;
			    }
		    }
    	}

	private IEnumerator Dash()
	{
		CanMove = false;
		dashing = true; 
		
		switch (FaceDir)
		{
			case Facing.Up:
				rb.AddForce(new Vector2(0, DashForce), ForceMode2D.Impulse);
				break;
			case Facing.Down:
				rb.AddForce(new Vector2(0, -DashForce), ForceMode2D.Impulse);
				break;
			case Facing.Left:
				rb.AddForce(new Vector2(-DashForce, 0), ForceMode2D.Impulse);
				break;
			case Facing.Right:
				rb.AddForce(new Vector2(DashForce, 0), ForceMode2D.Impulse);
				break;
			case Facing.UpRight:
				rb.AddForce(new Vector2(DashForce / 1.5f, DashForce / 1.5f), ForceMode2D.Impulse);
				break;
			case Facing.UpLeft:
				rb.AddForce(new Vector2(-DashForce / 1.5f, DashForce / 1.5f), ForceMode2D.Impulse);
				break;
			case Facing.DownLeft:
				rb.AddForce(new Vector2(-DashForce / 1.5f, -DashForce / 1.5f), ForceMode2D.Impulse);
				break;
			case Facing.DownRight:
				rb.AddForce(new Vector2(DashForce / 1.5f, -DashForce / 1.5f), ForceMode2D.Impulse);
				break;
		}
		
		DashParticles.Play();
		
		yield return new WaitForSeconds(0.2f);
		
		CanMove = true;
		
		yield return new WaitForSeconds(DashCooldown);
		
		dashing = false;
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
		PuffParticles.transform.localScale *= ScaleIncrease;
		DashParticles.transform.localScale *= ScaleIncrease;
		GrowthValue += 1;

		Collider2D[] nearbyObjects = Physics2D.OverlapCircleAll(transform.position, GrowCircleRadius);

		PuffParticles.Play();
		
		foreach (Collider2D collider in nearbyObjects)
		{
			Debug.Log(collider.gameObject.name);
			DecorManager.DM.GrowObject(collider.gameObject);
		}
	}
	
}
