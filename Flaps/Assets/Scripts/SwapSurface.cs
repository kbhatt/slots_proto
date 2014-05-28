using UnityEngine;
using System.Collections;

public class SwapSurface : MonoBehaviour {

	//flap's image reel
	public Material[] images;

	private GameObject target;

	void Start () {
		target = this.gameObject;
	}
	
	void Update () {

		//swap out images when plane is perpendicular to user 
		if (target.transform.eulerAngles.x == 90 || target.transform.eulerAngles.x == 270 ) 
		{
			if(RotateArm.spinCount % 2 == 0) 
				target.transform.FindChild ("RearFace").renderer.material = images [Random.Range(0,images.Length)];
			
			if(RotateArm.spinCount % 2 == 1) 
				target.transform.FindChild ("FrontFace").renderer.material = images [Random.Range(0,images.Length)];
		}
	}
}
