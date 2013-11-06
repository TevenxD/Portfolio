using UnityEngine;
using System.Collections;

public class Looking : MonoBehaviour {
	
	public GameObject gameObject;
	
	void Start () 
	{
		
	}
	
	
	void Update () 
	{
		transform.rotation = gameObject.transform.rotation;
	}
}
