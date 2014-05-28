using UnityEngine;
using System.Collections;

public class RotateArm : MonoBehaviour {

	//counts number of spins
	public static int spinCount;

	private bool spinning;
	private float timer;
	// Update is called once per frame

	void Start()
	{
		spinCount = 0;
		spinning = false;
		timer = 0;
		}
	void Update () {
		if (Input.GetMouseButtonDown(0) && !spinning)
		{

			RaycastHit hitInfo = new RaycastHit();
			if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo) && GameObject.FindWithTag("Handle"))
			{
				spinCount += 1;
				spinning = true;
				//Spin the handle
				iTween.PunchRotation(GameObject.Find("Arm"),new Vector3(0,270,0),5);

				//Call target line setting function of GameBoard
				GameObject.FindGameObjectWithTag("GameBoard").GetComponent<SetCombination>().mainFunction();

				//Start rotating light flash
				Lights.flash = true;
			}
			
		}

		//no additional spins during a spin;
		timer += Time.deltaTime;
		if (timer >= (SpinScript.maxSpinTime + 0.5f)) {
			spinning = false;
			timer = 0;
		
			}
	}
}
