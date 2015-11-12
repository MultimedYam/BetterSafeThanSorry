#pragma strict

class SGexSine extends DarkArtsStudios.SoundGenerator.Module.BaseModule
{
	static function MenuEntry() :String
	{ return "Examples/Oscillator/Sine (UnityScript)"; }

	function OnAmplitude(frequency:float, time:float, duration:float, depth:int) :float
	{
		return Mathf.Sin(Mathf.Deg2Rad * time * frequency * 360f);
	}
	
}