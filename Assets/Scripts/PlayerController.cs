using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float MoveSpeed;
	public bool CanMove = true;

	private Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

    void Update()
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
		    if (Input.GetKey(KeyCode.A))
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
		    if (Input.GetKey(KeyCode.S))
    		{
    			tempVel.y = Mathf.Lerp(tempVel.y, -MoveSpeed, 0.2f);
    		}
    		else
    		{
    			tempVel.y = Mathf.Lerp(tempVel.y, 0, 0.2f);
    		}
    		
    		rb.velocity = tempVel;
    	}
}
