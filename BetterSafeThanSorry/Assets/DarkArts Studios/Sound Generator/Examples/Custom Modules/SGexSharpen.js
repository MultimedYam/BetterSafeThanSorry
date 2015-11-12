#pragma strict

class SGexSharpen extends DarkArtsStudios.SoundGenerator.Module.BaseModule
{
	static function MenuEntry() :String
	{ return "Examples/Filter/Sharpen (UnityScript)"; }
	
	function InitializeAttributes()
	{
		this.attributes.Add(new Attribute("Input", true));
		
		var distance:Attribute = new Attribute("Distance",0.1f);
		distance.type = Attribute.AttributeType.SLIDER;
		distance.clampMinimum = true;
		distance.clampMinimumValue = 0.01f;
		distance.clampMaximum = true;
		distance.clampMaximumValue = 0.999f;
		attributes.Add(distance);
	}

	function OnAmplitude(frequency:float, time:float, duration:float, depth:int) :float
	{
		var result:float = 0;
		if (attribute ("Input").generator)
		{
			var distance:float = attribute ("Distance").value;
			var local:float = attribute ("Input").generator.amplitude(frequency,time ,duration,depth+1)*2;
			var surround:float = attribute ("Input").generator.amplitude(frequency,time - distance,duration,depth+1);
			surround += attribute ("Input").generator.amplitude(frequency,time + distance,duration,depth+1);
			surround /= 4;
			result += local + ( local - surround );
		}
		return result;
	}
	
}