using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    // The force added when a player jumps
	public Vector2 jumpForce = new Vector2(0,300);

    private Rigidbody2D movement;
    private Vector2 screenPosition;

    // Use this for initialization
    void Start () {
        movement = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

        // Jump input
	    if (Input.GetKeyUp("space"))
        {
            movement.velocity = Vector2.zero;
            movement.MoveRotation(45);
            movement.AddForce(jumpForce);
        }

        // If we are moving downward, "gradually" rotate player downwards
        if (movement.velocity.y < 0)
        {
            float rotation = 45 * movement.velocity.y > -45 ? 45 * movement.velocity.y : -45;
            movement.MoveRotation(rotation);
        }

        // Die when move off screen
        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        if (screenPosition.y > Screen.height || screenPosition.y < 0)
        {
            Die();
        }
	}

    // Die by collision
    void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }

    // Restart level
    void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
