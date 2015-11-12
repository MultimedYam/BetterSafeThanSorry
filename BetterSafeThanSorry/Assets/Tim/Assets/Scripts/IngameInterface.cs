using UnityEngine;
using System.Collections;

public class IngameInterface : MonoBehaviour {

	GameObject pausedPanel;
	// Use this for initialization
	void Start () 
	{
		pausedPanel = this.transform.FindChild("PausedPanel").gameObject;
	}

	void Update()
	{

	

		if (Input.GetKeyDown (KeyCode.G)) 
		{
			GameObject gameOverPanel = this.transform.FindChild("GameOverPanel").gameObject;
			gameOverPanel.SetActive(!gameOverPanel.activeSelf);
		}
	}

	public void NavigateToMainMenu()
	{
		Application.LoadLevel (0);
	}

	public void NavigateToIngame()
	{
		Application.LoadLevel (1);
		Time.timeScale = 1f;
	}

	public void PauseCurrent()
	{
		pausedPanel.SetActive(true);
		Time.timeScale = 0f;
	}

	public void Resume()
	{
		pausedPanel.SetActive(false);
		Time.timeScale = 1f;
	}
	

}
