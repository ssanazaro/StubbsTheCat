using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public float speed = 5f;
	public float mapWidth = 10f;
	public float jumpAmount = 10f;

	private Rigidbody2D rb;

	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	void Update()
	{
		//float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;
		//float y = Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed;
		//Vector2 newPosition = (rb.position + Vector2.right * x);

		//newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				Jump();
			}
			var movement = HandleMovement();
			Mathf.Clamp(movement.x, -mapWidth, mapWidth);
		}
	}

	void Jump()
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
		if (collision.gameObject.tag.Equals("Enemy"))
		{
			if (gameObject.GetComponent<Renderer>().material.color == Color.blue)
			{
				Destroy(collision.gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
		}
		if (collision.gameObject.tag.Equals("Collectible"))
		{
			gameObject.GetComponent<Renderer>().material.color = Color.blue;
		}
	}


}
