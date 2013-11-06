using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	public List<Light> lights;
	
	void Start () 
	{
		Locals.lights = lights;
	}
	
	void Update () 
	{
	
	}
}
