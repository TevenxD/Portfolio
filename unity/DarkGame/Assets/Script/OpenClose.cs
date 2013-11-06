using UnityEngine;
using System.Collections;

public class OpenClose : MonoBehaviour 
{
	private Vector3 beginPos;
	private float speed = .2f;
	
	void Start () 
	{
		beginPos = transform.position;
	}
	
	void Update () 
	{
		transform.Translate(new Vector3(0,0,speed));
		
		if (transform.position.z < beginPos.z - transform.localScale.z)
		{
			speed *= -1;
		}
		if (transform.position.z > beginPos.z)
		{
			speed *= -1;	
		}
	}
}
