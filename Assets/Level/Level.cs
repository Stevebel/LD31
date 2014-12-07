using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level {
	private List<ObjectDefinition> definitions;

	public Level(){
		definitions = new List<ObjectDefinition>();

		Add(new TextDefinition(0, "Adjust screen brightness until Viking is clearly visible").XPos(10).Color(1,1,1,1).Spaced(false));
	}
	public List<ObjectDefinition> getDefinitions(){
		return definitions;
	}
	private void Add(ObjectDefinition o){
		definitions.Add(o);
	}
}
