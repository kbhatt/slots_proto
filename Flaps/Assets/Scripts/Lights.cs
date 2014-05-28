using UnityEngine;
using System.Collections;

public class Lights : MonoBehaviour {

	//common light mode switch and timeout
	public static float timeout;
	public static bool flash;

	//maximum duration of light flash
	public float stopTime;

	private GameObject target;
	private Light topLight, middleLight, bottomLight;
	private int count;
	private float flashTimer,staticTimer;
	private bool calculateMaxTime;

	// Use this for initialization
	void Start () {
		target = this.gameObject;
		topLight = target.transform.FindChild ("Top").gameObject.GetComponent<Light>();
		middleLight = target.transform.FindChild ("Middle").gameObject.GetComponent<Light>();
		bottomLight = target.transform.FindChild ("Bottom").gameObject.GetComponent<Light>();
		timeout = 0.125f;
		calculateMaxTime = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (flash) {
						//ensures maximum flash time is calculated only once
						if(calculateMaxTime)
						{
							stopTime = SpinScript.maxSpinTime;
							calculateMaxTime=false;
						}
						
						//update timers
						flashTimer -= Time.deltaTime;
						stopTime -= Time.deltaTime;
						if (flashTimer <= 0 && stopTime > 0)
								flashLight ();
						if( stopTime <=0 )
							{
								flash = false;
							}
				} 
		else {
						//update timer
						staticTimer -= Time.deltaTime;
						if(staticTimer <= 0)
							staticLight();
				}
	}

	void flashLight()
	{

		switch (count % 3) {
		case 0: topLight.enabled = true;
			middleLight.enabled=false;
			bottomLight.enabled=false;
			break;
		case 1: topLight.enabled = false;
			middleLight.enabled=true;
			bottomLight.enabled=false;
			break;
		case 2: topLight.enabled = false;
			middleLight.enabled=false;
			bottomLight.enabled=true;
			break;

				}

		count += 1;
		flashTimer = timeout;
		}

	void staticLight()
	{
		topLight.enabled = !topLight.enabled;
		middleLight.enabled = !middleLight.enabled;
		bottomLight.enabled = !bottomLight.enabled;
		staticTimer = timeout;

	}
}
