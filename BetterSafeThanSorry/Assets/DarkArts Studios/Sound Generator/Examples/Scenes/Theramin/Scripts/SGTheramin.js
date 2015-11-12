#pragma strict

private var finishedGenerating:boolean = false;

private var audioSource:AudioSource = null;

function Start()
{
	audioSource = GetComponent(typeof(AudioSource));

	var audioClips = GetComponent(typeof(DarkArtsStudios.SoundGenerator.Composition)).audioClips;
	
	while (audioClips.Count < 1 )
	{
		yield;
	}

	audioSource.clip = audioClips["Output"];
	audioSource.loop = true;
	audioSource.volume = 0;
	audioSource.Play();
}


function Update () {
	var xThreshold:float = Mathf.Clamp( Input.mousePosition.x / Screen.width, 0, 1 );
	var yThreshold:float = Mathf.Clamp( Input.mousePosition.y / Screen.height, 0, 1 );
	var x:float = xThreshold-0.5;
	var y:float = yThreshold-0.5;
	transform.position = new Vector3( x*10, y*10, 0 );
	
	audioSource.volume = 1-xThreshold;
	audioSource.pitch = 0.5 + yThreshold*2;
}