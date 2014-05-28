using UnityEngine;
using System.Collections;

public class SpinScript : MonoBehaviour {

	//individual flap spin behaviou
	public float time;
	public float rotations;
	public string easetype;

	//common variable to calculate highest spin time
	public static float maxSpinTime;

	private GameObject target;

	//spinning the planes
	public void mainFunction()
	{
		maxSpinTime = Mathf.Max (maxSpinTime, time);
		target = this.gameObject;
		iTween.RotateBy(target,iTween.Hash("x",rotations,"time",time,"easetype",easetype));
	}
}
