using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour 
{
	private enum LightState
	{
		Normal,
		Charging,
		Dying
	}
	private LightState lightState = LightState.Normal;
	
	public GameObject camera;
	public float durability;
	public int battetylife;
	public float chargeSpeed;
	
	public float flickerSpeed;
	private bool powerOn = true;
	private float timer;
	
	void Start () 
	{
		
	}
	
	void Update ()
	{
		this.transform.rotation = camera.transform.rotation;
		
		// Normal
		/*timer += Time.deltaTime;
		if (timer > durability)
		{
			timer = 0;
			battetylife --;
			if (battetylife <= 0)
				lightState = LightState.Dying;
		}*/
		
		// Charging
		foreach(Light L in Locals.lights) {
			if (Vector3.Distance(transform.position, L.transform.position) < L.range)
			{
				timer += Time.deltaTime;
				if (timer > chargeSpeed)
				{
					timer = 0;
					if (battetylife < 100)
						battetylife ++;
				}
			}
		}
		
		// Dying
		/*timer += Time.deltaTime;
		if (timer > flickerSpeed)
		{
			powerOn = !powerOn;
			timer = 0;
		}
		
		if (powerOn)
			this.light.intensity = 8;
		else
			this.light.intensity = 0;*/
	}
}
