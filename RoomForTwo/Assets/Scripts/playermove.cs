using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class playermove : MonoBehaviour {
	
	public Rigidbody2D cRigidbody2D
	{
		get
		{
			if(!_cRigidbody2D)
				_cRigidbody2D = GetComponent<Rigidbody2D>();
			return _cRigidbody2D;
		}
	}
	Rigidbody2D _cRigidbody2D;
	
	public Transform cTransform
	{
		get
		{
			if(!_cTransform)
				_cTransform = transform;
			return _cTransform;
		}
	}

	Transform _cTransform;
	
	public float moveSpeed = 3;
	public float jumpForce = 250;
	
	bool isGrounded;
	
	void FixedUpdate()
	{
		Move();
		Jump();
	}
	
	void Move()
	{
		if((cTransform.localScale.x > 0 && Input.GetAxisRaw("Horizontal") < 0)
		   || (cTransform.localScale.x < 0 && Input.GetAxisRaw("Horizontal") > 0))
		{
			Vector2 temp = cTransform.localScale;
			temp.x *= -1;
			cTransform.localScale = temp;
		}
		cRigidbody2D.velocity = new Vector2(moveSpeed * Input.GetAxisRaw("Horizontal"),
		                                    cRigidbody2D.velocity.y);
	}
	
	void Jump()
	{
		if (isGrounded && Input.GetButtonDown ("Jump")) {
			isGrounded = false;
			cRigidbody2D.AddForce (Vector2.up * jumpForce);
		}
	}
	
	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.tag == "Ground")
			isGrounded = true;
	}
}