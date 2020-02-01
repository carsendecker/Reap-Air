using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float MoveSpeed;
	public bool CanMove = true;

	private Rigidbody2D rb;
	private const float ScaleIncrease = 1.05f;
	private Vector3 newScale;
	private float cameraSize;

	
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		newScale = transform.localScale;
		cameraSize = Camera.main.orthographicSize;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.G))
		{
			GrowPlayer();
		}

		transform.localScale = Vector3.Lerp(transform.localScale, newScale, 0.1f);
		Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, cameraSize, 0.05f);
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
	}
	
}
