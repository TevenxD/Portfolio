using UnityEngine;
using System.Collections;

public class LightEffect : MonoBehaviour 
{
	public float minIntensity;
	public float maxIntensity;
	public float flickerSpeed;
	
	void Start () 
	{
		
	}
	
	void Update () 
	{
		light.intensity += flickerSpeed * Time.deltaTime;
		
		if (light.intensity <= minIntensity || light.intensity >= maxIntensity)
			flickerSpeed *= -1;
	}
}
