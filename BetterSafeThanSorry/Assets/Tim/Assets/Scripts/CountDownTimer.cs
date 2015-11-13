using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountDownTimer : MonoBehaviour {

	public float timeLeft = 300.0f;
	public Text text;

	// Use this for initialization
	void Start () {
	
	}
	

	void Update(){
		
		timeLeft -= Time.deltaTime;

		
		float minutes = Mathf.Floor(timeLeft / 60);
		float seconds = Mathf.Round (timeLeft % 60);
		if(seconds > 59) seconds = 59;

		if (seconds < 10) 
		{
			text.text =   "0" + minutes + ":0" + seconds;

		} else
		{
			text.text =   "0" + minutes + ":" + seconds;
		}




		if (timeLeft < 0) 
		{
			text.text = "Game Over!";

			//DO GAMEOVER STUFF.

		}
}
}
