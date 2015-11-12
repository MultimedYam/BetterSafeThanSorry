using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class GameManager : MonoBehaviour {

	public GameObject gameplayObject;
	public GameObject eventPanel;
	bool canMove = false; 

	Vector3 startPos = Vector3.zero;
	Vector3 endPos; 
	public float speed = 15F;

	// Use this for initialization
	void Start () {
		endPos = new Vector3 (15, 0, 0);

	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			canMove = true;
		}
		if (canMove) 
		{
			StartCoroutine(moveInEventPanel());
		}
	}

	IEnumerator moveInEventPanel()
	{

		float step = Time.deltaTime * speed;
		gameplayObject.transform.position = Vector3.Lerp(gameplayObject.transform.position, endPos, step);		
		yield return new WaitForSeconds (1f);
		StartCoroutine (fadeEventPanel ());
	}

	IEnumerator fadeEventPanel()
	{
		float targetScale = 1f;
		float growSpeed = 2f;
		eventPanel.transform.localScale = Vector3.Lerp(eventPanel.transform.localScale, new Vector3(targetScale, targetScale, targetScale), Time.deltaTime*growSpeed);
	
		float progress = 0.0f;
		CanvasGroup canvasGroup = eventPanel.GetComponent<CanvasGroup> ();
		float rate = 1.0f / growSpeed;
		
		while (progress < 1.0) 
		{
			canvasGroup.alpha = Mathf.Lerp (0.0f, 1.0f, progress);
			progress += rate * Time.deltaTime;

		}


		yield return null;
	}


 	
}
