using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 5f;
	public float mapWidth = 10f;
	public float jumpAmount = 10f;
	public bool isGrounded = false;
	public float powerUpTimer = 0;

	private Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		{
			if (Time.time > powerUpTimer + 5f)
			{
				rb.GetComponent<Renderer>().material.color = Color.white;
				jumpAmount = 10;
			}
			if (Input.GetKeyDown(KeyCode.Space))
			{
				if (isGrounded == true)
				{
					Jump();
				}
			}
			var movement = HandleMovement();
			Mathf.Clamp(movement.x, -mapWidth, mapWidth);
		}
	}

	private void Jump()
	{
		rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
	}

	Vector2 HandleMovement()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			return rb.velocity = new Vector2(-speed, rb.velocity.y);
		}
		else
		{
			if (Input.GetKey(KeyCode.RightArrow))
			{
				return rb.velocity = new Vector2(+speed, rb.velocity.y);
			}
			else
			{
				return rb.velocity = new Vector2(0, rb.velocity.y);
			}
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.tag.Equals("Building"))
		{
			isGrounded = true;
		}
		if (collision.gameObject.tag.Equals("Collectible"))
		{
			gameObject.GetComponent<Renderer>().material.color = Color.blue;
			powerUpTimer = Time.time;
			jumpAmount = 12;
		}
	}

	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.tag.Equals("Building"))
		{
			isGrounded = false;
		}
	}
}
