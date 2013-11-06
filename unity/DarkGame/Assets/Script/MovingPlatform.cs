using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	
	float speed = 0.2f;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.Translate(new Vector3(0f, 0f, speed));
		
		if(transform.position.y > 30 || transform.position.y < 1)
			speed = -speed;
	}
}
