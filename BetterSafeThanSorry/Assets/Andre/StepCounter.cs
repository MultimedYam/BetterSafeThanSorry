using UnityEngine;
using System.Collections;

public class StepCounter : MonoBehaviour {

	private bool allowedToStep;

	private float loLim = 0.005F;
	private float hiLim = 0.3F;
	public int steps = 0;
	private bool stateH = false;
	private float fHigh = 8.0F;
	private float curAcc= 0F;
	private float fLow = 0.2F;
	private float avgAcc;

	public int requestedSteps;

	private bool safeEmpty;

	public int stepDetector(){
		curAcc = Mathf.Lerp (curAcc, Input.acceleration.magnitude, Time.deltaTime * fHigh);
		avgAcc = Mathf.Lerp (avgAcc, Input.acceleration.magnitude, Time.deltaTime * fLow);
		float delta = curAcc - avgAcc;
		if (!stateH) { 
			if (delta > hiLim) {
				stateH = true;
				steps++;
			} else if (delta < loLim) {
				stateH = false;
			}
			stateH = false;
		}
		avgAcc = curAcc;
		
		return steps;
	}

	// Use this for initialization
	void Start () {
		safeEmpty = false;
		allowedToStep = false;
	}

	public bool safeStatus
	{
		get {return safeEmpty;}
	}
	// Update is called once per frame
	void Update () {
		if(allowedToStep)
		{
			steps = stepDetector();
			checkSteps();
		}
	}

	private void checkSteps()
	{
		if(steps >= requestedSteps)
		{
			safeEmpty = true;
			allowedToStep = false;
		}
	}

	public void setSteps(int amount)
	{
		steps = 0;
		requestedSteps = amount;
		allowedToStep = true;
	}
}
