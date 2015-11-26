using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

    public Vector2 velocity = new Vector2(-4, 0);
    public float range = 4; // higher number => greater variations in obstacles

    private Rigidbody2D movement;

	// Use this for initialization
	void Start () {
        // Set velocity
        GetComponent<Rigidbody2D>().velocity = velocity;

        // Randomize position on Y-Axis
        transform.position = new Vector3(transform.position.x, transform.position.y - (range * Random.Range(-1f,1f)), transform.position.z);
	}
	
}
