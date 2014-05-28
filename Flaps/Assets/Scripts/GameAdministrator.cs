using UnityEngine;
using System.Collections;

public class GameAdministrator : MonoBehaviour {

	//switches for gameboard size and randomising flap behaviour
	public bool threeByThree;
	public bool randomTime, randomRotation, randomEaseType;
	public float min, max;
	public Material [] reelImages;
	public Material [] targetImages;


	private GameObject target;


	// Use this for initialization
	public void mainFunction () {

		target = this.gameObject;
		int i, j, initial, final, counter=0; 

		//setting the gameboard size
		if (threeByThree) {
				target.transform.GetChild (0).gameObject.SetActive (false);
				target.transform.GetChild (4).gameObject.SetActive (false);
			}

		//setting the image reel
		for (i = 0; i < 5; i ++) 
			for(j = 0; j < 3; j++)
				target.transform.GetChild(i).GetChild(j).GetComponent<SwapSurface>().images = reelImages;

		//switching randomised times
		if (!randomTime) {
			for (i = 0; i < 5; i ++) 
				for(j = 0; j < 3; j++)
					target.transform.GetChild(i).GetChild(j).GetComponent<RandomiseSpin>().timeSwitch = false;
				}

		//switching randomised spins
		if (!randomRotation) {
			for (i = 0; i < 5; i ++) 
				for(j = 0; j < 3; j++)
					target.transform.GetChild(i).GetChild(j).GetComponent<RandomiseSpin>().rotationSwitch = false;
		}

		//switching randomised ease types
		if (!randomEaseType) {
			for (i = 0; i < 5; i ++) 
				for(j = 0; j < 3; j++)
					target.transform.GetChild(i).GetChild(j).GetComponent<RandomiseSpin>().easetypeSwitch = false;
		}

		//setting randomiser limits
		for (i = 0; i < 5; i ++) {
				for (j = 0; j < 3; j++) {
						target.transform.GetChild (i).GetChild (j).GetComponent<RandomiseSpin> ().min = min;
						target.transform.GetChild (i).GetChild (j).GetComponent<RandomiseSpin> ().max = max;
				}
		}

		//setting target materials
		if (threeByThree) {
						initial = 1;
						final = 4;
				} 
		else {
						initial = 0;
						final = 5;
				}

		for (i = 0; i < 3; i ++) {
			for (j = initial; j < final; j++) {
				target.transform.GetChild(j).GetChild(i).GetComponent<SetFinal>().finalMaterial = targetImages [counter];
				counter ++;
			}
		}

		//setting up individual flap behaviour
		for (i = 0; i < 5; i ++) {
			for (j = 0; j < 3; j++) {
				target.transform.GetChild (i).GetChild (j).GetComponent<RandomiseSpin> ().mainFunction();
			}
		}
	}

}
