using UnityEngine;
using System.Collections;

public class TurnTheLock : MonoBehaviour {
	public float graden;
	public float y;
	public float x;
	public float z;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		turnThatShit();
	}

	private void turnThatShit()
	{
		x = Input.acceleration.x;
		if(x > 1f) { x = 1f; }
		if(x < -1f) { x = -1f;}

		y = Input.acceleration.y;
		if(y > 1f) { y = 1f;}
		if(y < -1f) { y = -1f;} 


		if(Mathf.Asin(x * -1f) < 0)
		{
			graden = Mathf.Acos(y);
			graden = graden * -1f;
			graden = graden * (180f/Mathf.PI);
		}
		else
		{
			graden = Mathf.Acos(y);
			graden = graden * (180f/Mathf.PI);
		}
		graden *= -1f;
		this.gameObject.transform.rotation = Quaternion.Euler(0,0,graden);
	}
}
