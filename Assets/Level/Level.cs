﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level {
	private List<ObjectDefinition> definitions;

	public Level(){
		definitions = new List<ObjectDefinition>();

		Add(new TextDefinition(10, "Adjust screen brightness").XPos(-23).Spaced(false));
		Add(new TextDefinition(14, "until Viking is clearly visible").XPos(-25).Spaced(false));
	}
	public List<ObjectDefinition> getDefinitions(){
		return definitions;
	}
	private void Add(ObjectDefinition o){
		definitions.Add(o);
	}
}
