using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTest : MonoBehaviour {

   public GameObject person;
   CharacterController controller;
    bool running;
    public float velocity;
    // Use this for initialization
    void Start () {
        controller = this.GetComponent<CharacterController>();

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.LeftShift)) faster();
        else slower();
        if (running) velocity *= 2;
             Vector3 moveDirection = (this.transform.forward * Input.GetAxis("Vertical") + this.transform.right * Input.GetAxis("Horizontal")).normalized * velocity;
            controller.Move(moveDirection * Time.deltaTime);
            if (!moveDirection.Equals(Vector3.zero))
            {
                if (!person.GetComponent<Animator>().GetBool("walking"))
                    person.GetComponent<Animator>().SetBool("walking", true);
                person.transform.rotation = Quaternion.LookRotation(moveDirection);
            }
            else person.GetComponent<Animator>().SetBool("walking", false);
       
        if (!controller.isGrounded)
        {
            controller.Move(Vector3.down*10 * Time.deltaTime);
        }
        if (running) velocity /= 2;
    }

    private void faster()
    {
        running = true;
        person.GetComponent<Animator>().SetFloat("vel", 2f);
    }

    private void slower()
    {
        running = false;
        person.GetComponent<Animator>().SetFloat("vel", 1f);
    }
   
}
