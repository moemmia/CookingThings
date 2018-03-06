using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soltar : MonoBehaviour, Action_Interface
{

    PlayerController player;
    RaycastHit hit;
    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    public IEnumerator Do()
    {

        hit = new RaycastHit();
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100);
        player.MoveTo(hit.point);
        yield return new WaitForEndOfFrame();
        player.onArrive = Accion;
    }

    public void Accion()
    {
        player.transform.LookAt(hit.transform.position);
        player.carrying = false;
    }
}
