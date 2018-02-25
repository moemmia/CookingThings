using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour {

   public GameObject person;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
                Vector3 moveDirection = (this.transform.forward * Input.GetAxis("Vertical") * 0.1f + this.transform.right * Input.GetAxis("Horizontal") * 0.1f);
                this.GetComponent<CharacterController>().Move(moveDirection);
        if (!moveDirection.Equals(Vector3.zero))
        {
            if (!person.GetComponent<Animator>().GetBool("walking"))
                 person.GetComponent<Animator>().SetBool("walking", true);
            person.transform.rotation = Quaternion.LookRotation(moveDirection);
        }
        else person.GetComponent<Animator>().SetBool("walking", false);
                
    }
}
