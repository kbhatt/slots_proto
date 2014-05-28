using UnityEngine;
using System.Collections;

public class SetFinal : MonoBehaviour {

	public Material finalMaterial;
	private GameObject target;

	public void mainFunction()
	{
		target = this.gameObject;

		//sets the rear surface to the final target
		if(RotateArm.spinCount % 2 == 1) 
			target.transform.FindChild ("RearFace").renderer.material = finalMaterial;

		if(RotateArm.spinCount % 2 == 0) 
			target.transform.FindChild ("FrontFace").renderer.material =finalMaterial;

		//starts spin
		target.GetComponent<SpinScript> ().mainFunction ();
	}

}
