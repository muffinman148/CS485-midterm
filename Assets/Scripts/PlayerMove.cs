using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

	public int playerSpeed = 10;
	private bool facingRight = false;
	public int playerJumpPower = 1250;
	private float moveX;
	public bool isGrounded;

	
	// Update is called once per frame
	void Update () {
		Player_Move ();
		PlayerRaycast ();
	}

	// Player Movement
	void Player_Move() {
		// Controls
		moveX = Input.GetAxis("Horizontal");

		if (Input.GetButtonDown ("Jump") && isGrounded == true) {
			Jump ();
		}

		// TODO Animation
		// Player Direction
		if (moveX < 0.0f && facingRight == false) {
			FlipPlayer();
		} else if (moveX > 0.0f && facingRight == true) {
			FlipPlayer();
		}
		// Physics
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}


	void Jump() {
		// Jumping Code
		GetComponent<Rigidbody2D>().AddForce (Vector2.up * playerJumpPower);
		isGrounded = false;
	}

	// Flips Player Direction
	void FlipPlayer() {
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	// Ground Collision


	// Reference of Player to Object
	void PlayerRaycast() {
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down);
		if(hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag == "enemy") {
			hit.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (Vector2.up * 500);
			hit.collider.gameObject.GetComponent<Rigidbody2D> ().gravityScale = 5;
			hit.collider.gameObject.GetComponent<Rigidbody2D> ().freezeRotation = false;
			hit.collider.gameObject.GetComponent<BoxCollider2D> ().enabled = false;
			hit.collider.gameObject.GetComponent<EnemyMove> ().enabled = false;
			//Destroy (hit.collider.gameObject);
		}
		if(hit != null && hit.collider != null && hit.distance < 0.9f && hit.collider.tag != "enemy") {
			isGrounded = true;
		}
	}
}
