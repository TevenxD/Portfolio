using UnityEngine;
using System.Collections;

public class FallPlatform : MonoBehaviour 
{
	private bool fall = false;
	private Vector3 beginPos;
	private float speed = -0.01f;
	
	void Start () 
	{
		beginPos = transform.position;
	}
	
	void Update () 
	{
		if (fall)
		{
			speed -= .01f;
			transform.Translate(new Vector3(0, speed, 0));
			print(speed);
		}
		
		if (transform.position.y < -90)
		{
			transform.position = beginPos;
			fall = false;
			speed = -0.2f;
		}
	}
	
	public void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject == Locals.player && !fall)
		{
			fall = true;
		}
	}
}
