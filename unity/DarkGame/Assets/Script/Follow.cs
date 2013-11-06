using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Follow : MonoBehaviour 
{
	private GameObject target;
	public float maxDistance;
	public float rotationSpeed;
	public float speed;
	
	public List<Light> lights;
	
	public float appearTimer;
	public float appearDistance;
	private float timer;
	
	void Start () 
	{
		target = Locals.player;
		timer = 0.05f;
		
		Locals.lights = lights;
	}
	
	void Update () 
	{
		foreach(Light light in lights)
			if (Vector3.Distance(target.transform.position, light.transform.position) < light.range)
			{
				renderer.enabled = false;
				timer = 0;
			}
		
		if (!renderer.enabled)
			timer += (float)(Time.deltaTime);
		
		if (timer >= appearTimer)
		{
			timer = 0;
			renderer.enabled = true;
			
			transform.position = target.transform.position;
			transform.rotation = target.transform.rotation;
			transform.position += transform.forward * appearDistance;
		}
		
		if (renderer.enabled && Vector3.Distance(target.transform.position, transform.position) < maxDistance)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.transform.position - transform.position), rotationSpeed * Time.deltaTime);
			transform.position += transform.forward * speed * Time.deltaTime;
			//transform.position = new Vector3(transform.position.x, target.transform.position.y, transform.position.z);
		}
	}
}
