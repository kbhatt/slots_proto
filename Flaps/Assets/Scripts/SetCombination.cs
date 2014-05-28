using UnityEngine;
using System.Collections;

public class SetCombination : MonoBehaviour {

	public bool win;
	public bool topLine, middleLine, bottomLine, topZigZag, bottomZigZag;

	private Material targetImage;
	private Material [] reelImages;
	private GameObject target;


	// to do : set combinations for 3x3 gameplay mode

	public void mainFunction()
	{
		target = this.gameObject;
		probabilityFunction ();

		reelImages = target.GetComponent<GameAdministrator> ().reelImages;
		int reelSize = reelImages.Length;


		//setting configuratuions for different lines
		if (win) {
						int targetIndex = Random.Range (0, reelSize);
						targetImage = reelImages [targetIndex];
						reelImages [targetIndex] = reelImages [reelSize - 1];
						reelImages [reelSize - 1] = targetImage;


						//top line
						if (topLine) {
							for (int i = 0; i < 5; i++) 
								target.GetComponent<GameAdministrator> ().targetImages [i] = targetImage;
							
							for (int i = 5; i < 15; i++) 
								target.GetComponent<GameAdministrator> ().targetImages [i] = reelImages [Random.Range (0, reelSize - 1)];
						}


						//center line
						if (middleLine) {
								for (int i = 0; i < 5; i++) 
										target.GetComponent<GameAdministrator> ().targetImages [i] = reelImages [Random.Range (0, reelSize - 1)];

								for (int i = 5; i < 10; i++) 
										target.GetComponent<GameAdministrator> ().targetImages [i] = targetImage;
		
								for (int i = 10; i < 15; i++) 
										target.GetComponent<GameAdministrator> ().targetImages [i] = reelImages [Random.Range (0, reelSize - 1)];
						}

						


						//bottom line
						if (bottomLine) {
								for (int i = 0; i < 10; i++) 
										target.GetComponent<GameAdministrator> ().targetImages [i] = reelImages [Random.Range (0, reelSize - 1)];

								for (int i = 10; i < 15; i++) 
										target.GetComponent<GameAdministrator> ().targetImages [i] = targetImage;
						}

						//topZigZag
						if (topZigZag) {
								for (int i = 0; i < 10; i++) {
										if (i % 2 == 1)
												target.GetComponent<GameAdministrator> ().targetImages [i] = reelImages [Random.Range (0, reelSize - 1)];
										else
												target.GetComponent<GameAdministrator> ().targetImages [i] = targetImage;
								}
								for (int i = 10; i < 15; i++) 
										target.GetComponent<GameAdministrator> ().targetImages [i] = reelImages [Random.Range (0, reelSize - 1)];
						}

						//bottomZigZag
						if (bottomZigZag) {
								for (int i = 0; i < 5; i++) 
										target.GetComponent<GameAdministrator> ().targetImages [i] = reelImages [Random.Range (0, reelSize - 1)];
								for (int i = 5; i < 15; i++) {
										if (i % 2 == 1)
												target.GetComponent<GameAdministrator> ().targetImages [i] = reelImages [Random.Range (0, reelSize - 1)];
										else
												target.GetComponent<GameAdministrator> ().targetImages [i] = targetImage;
								}

						}
				} 
		//randomise configuration for losing
		else {
			for (int i = 0; i < 15; i++) 
				target.GetComponent<GameAdministrator> ().targetImages [i] = reelImages [Random.Range (0, reelSize)];
				}
		//starts of all computations from the GameAdministartor script
		target.GetComponent<GameAdministrator> ().mainFunction ();

		}

	void probabilityFunction()
	{
		int winOrLose = Random.Range (1, 3);
		//win probability
		if (winOrLose % 2 == 0) {
			win = true;
			int lineChoice = Random.Range(1,6);
			switch(lineChoice)
			{
			case 1: topLine = true;
				middleLine = false;
				bottomLine = false;
				topZigZag = false;
				bottomZigZag = false;
				break;
			case 2:  topLine = false;
				middleLine = true;
				bottomLine = false;
				topZigZag = false;
				bottomZigZag = false;
				break;
			case 3:  topLine = false;
				middleLine = false;
				bottomLine = true;
				topZigZag = false;
				bottomZigZag = false;
				break;
			case 4:  topLine = false;
				middleLine = false;
				bottomLine = false;
				topZigZag = true;
				bottomZigZag = false;
				break;
			case 5:  topLine = false;
				middleLine = false;
				bottomLine = false;
				topZigZag = false;
				bottomZigZag = true;
				break;
			}
				} 
		else
				win = false;

	}
}
