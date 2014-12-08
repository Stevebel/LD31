using UnityEngine;
using System.Collections;

public class Switches {
	public enum SWITCH{
		LEVER_ACTIVATED = 0,

		SWITCH_COUNT
	}

	public static bool[] switches = new bool[(int)SWITCH.SWITCH_COUNT];

	public static void SwitchOn(SWITCH s){
		switches[(int)s] = true;
	}
	public static void SwitchOff(SWITCH s){
		switches[(int)s] = false;
	}
	public static bool IsOn(SWITCH s){
		return switches [(int)s];
	}
}
