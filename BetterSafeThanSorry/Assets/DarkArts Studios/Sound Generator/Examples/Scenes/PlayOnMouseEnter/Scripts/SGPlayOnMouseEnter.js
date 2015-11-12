#pragma strict

private var audioClip:AudioClip = null;

function Start()
{
	var audioClips = GetComponent(typeof(DarkArtsStudios.SoundGenerator.Composition)).audioClips;
	
	/* Wait for the audio to be generated */
	while (audioClips.Count < 1 )
	{
		yield;
	}
	
	audioClip = audioClips["Output"];
}

function OnMouseEnter()
{
	GetComponent(typeof(AudioSource)).PlayOneShot( audioClip );
}

function OnGUI()
{
	if (audioClip == null)
	{
		GUI.Label(new Rect(10,10,Screen.width -20, 20), "Generating Sounds..." );
	}
}