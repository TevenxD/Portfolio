using UnityEngine;
using System.Collections;

public class RotatingObject : MonoBehaviour 
{
	public float rotateSpeedX = 0;
	public float rotateSpeedY = 0;
	public float rotateSpeedZ = 0;
	
	void Start () 
	{
		
	}
	
	void Update () 
	{
		transform.Rotate(new Vector3(rotateSpeedX, rotateSpeedY, rotateSpeedZ));
	}
}
