using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
            this.GetComponent<CharacterController>().Move(this.transform.forward*Input.GetAxis("Vertical")*0.1f);
            this.GetComponent<CharacterController>().Move(this.transform.right * Input.GetAxis("Horizontal") * 0.1f);
    }
}
