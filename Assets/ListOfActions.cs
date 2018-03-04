using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfActions : MonoBehaviour {

    [Serializable]
    public struct Acciones
    {
        public string name;
        public Component script;
    }
    public Acciones[] actions;

	// Update is called once per frame
	void Update () {
		
	}

    internal void show()
    {
        
        Action_Interface ai= actions[0].script as Action_Interface;
        StartCoroutine(ai.Do());
    }
}
