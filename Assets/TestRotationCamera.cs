using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRotationCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Rotate(this.transform.up,0.1f);
	}
}
