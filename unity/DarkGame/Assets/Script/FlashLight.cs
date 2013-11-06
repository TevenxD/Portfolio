using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour 
{
	public GameObject player;
	public float batteryLife;
	
	void Start () 
	{
		light.intensity = 8;
		batteryLife /= 10;
	}
	
	void Update () 
	{
		transform.rotation = player.transform.rotation;
		light.intensity -= batteryLife;
		
		foreach(Light _light in Locals.lights)
		{
			if (Vector3.Distance(transform.position, _light.transform.position) < _light.range)
			{
				light.intensity = 8;
			}
		}
	}
}
