using UnityEngine;
using System.Collections.Generic;

public class Generate : MonoBehaviour {

    public GameObject pipe;

    private int score = 0;
    private Queue<GameObject> pipes = new Queue<GameObject>();

	// Use this for initialization
	void Start () {
        InvokeRepeating("CreateObstacle", 1f, 1.5f);
        InvokeRepeating("DestroyObstacle", 6f, 1.5f);
    }

    // Keep score
    void OnGUI()
    {
        GUI.color = Color.black;
        GUILayout.Label(" Score: " + score.ToString());
    }
	
    // Creates pipes
    void CreateObstacle()
    {
        GameObject obj = Instantiate(pipe);
        pipes.Enqueue(obj);
        score++;
    }

    // Used to clean up old pipes
    void DestroyObstacle()
    {
        if (pipes.Count > 1) {
            Destroy(pipes.Dequeue());
        }
    }

	// Update is called once per frame
	void Update () {
	
	}
}
