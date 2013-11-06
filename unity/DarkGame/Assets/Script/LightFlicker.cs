using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LightFlicker : MonoBehaviour 
{
	public float flickerSpeed;
	
	void Start () 
	{
		
	}
	
	void Update () 
	{
		this.light.intensity += flickerSpeed;
		
		if (light.intensity >= 6)
		{
			light.intensity = 6;
			flickerSpeed *= -1;
		}
		if (light.intensity <= 5)
		{
			light.intensity = 5;
			flickerSpeed *= -1;
		}
	}
}
