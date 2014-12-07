using UnityEngine;
using System.Collections;

public class ObjectDefinition{
	public float height;

	public ObjectDefinition(float height){
		this.height = height;
	}
}

public class PrefabDefinition:ObjectDefinition{
	public float xPos = 0;
	public GameObject prefab;
	
	public PrefabDefinition(float height, GameObject prefab):base(height){
		this.prefab = prefab;
	}
	public PrefabDefinition XPos(float xPos){
		this.xPos = xPos;
		return this;
	}
}

public class TextDefinition:ObjectDefinition{
	public float xPos = 0;
	public string text;

	public Color color = new Color(1,1,1,1);
	public float brightness = 0;
	public float size = 1;
	
	public TextDefinition(float height, string text):base(height){
		this.text = text;
	}
	public TextDefinition XPos(float xPos){
		this.xPos = xPos;
		return this;
	}
	public TextDefinition Color(Color color){
		this.color = color;
		return this;
	}
	public TextDefinition Color(float r, float g, float b, float a){
		this.color = new Color(r,g,b,a);
		return this;
	}
	public TextDefinition Brightness(float brightness){
		this.brightness = brightness;
		return this;
	}
	public TextDefinition Size(float size){
		this.size = size;
		return this;
	}
}