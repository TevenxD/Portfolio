using UnityEngine;
using System.Collections;

public class BridgeActivate : MonoBehaviour 
{
	private GameObject button;
	private GameObject bridge;
	private bool active;
	
	void Start () 
	{
		button = GameObject.Find("Switch");
		bridge = GameObject.Find("Bridge");
		active = false;
	}
	
	void Update () 
	{
		Click();
		
		if (active)
		{		
			if (bridge.transform.localScale.z < 220)
			{
				bridge.transform.localScale += new Vector3(0, 0, .4f);
				bridge.transform.Translate(new Vector3(0,0,-.2f));
			}
		}
	}
	
	void Click()
	{
		RaycastHit hit = new RaycastHit();
	    Ray ray = new Ray();        
	    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	 
	    if (Input.GetMouseButtonDown (0))  //Returns true during the frame the user touches the object
	    {
	        if (Physics.Raycast (ray, out hit)) 
	        {
	            if (hit.collider.gameObject == button && Vector3.Distance(Locals.player.transform.position, button.transform.position) < 80) {
					active = true;
					print("activate");
				}
	        }
	    }
	}
}
