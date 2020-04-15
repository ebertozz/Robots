using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
// allows us to embed a class with sub properties in the inspector


public class Dialog  //does NOT extend monodevelop
{
	public string name;  // these will show up in the inspector when attached to a monodevelop script
	[TextArea(3, 10)]       // sets the size of text area in inspector
	public string[] sentences;  // can add as many sentences as desired

}
