using UnityEngine;
using System.Collections;

public class RandomiseSpin : MonoBehaviour {
	//variables for flap behaviour
	public bool timeSwitch;
	public bool rotationSwitch;
	public float min,max;
	public bool easetypeSwitch;

	private GameObject target;
	private string [] easetype;

	// Use this for initialization
	public void mainFunction () {
		target = this.gameObject;
		easetype= new string[] {"easeInOutQuart","easeInOutBack","easeInOutBounce","easeInOutCirc","easeInOutCubic","easeInOutElastic"};
		float temp = Random.Range (min, max);

		//randomising the time, rotations and easetype
		if(timeSwitch)
			target.GetComponent<SpinScript>().time = temp;
		if(rotationSwitch)
			target.GetComponent<SpinScript> ().rotations = Mathf.Floor(temp)+ 0.5f;
		if(easetypeSwitch)
			target.GetComponent<SpinScript> ().easetype = easetype [Random.Range (0, easetype.Length)];

		//sets final surface
		target.GetComponent<SetFinal> ().mainFunction ();
	}

}
