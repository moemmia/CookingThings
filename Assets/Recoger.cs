using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    class Recoger: MonoBehaviour, Action_Interface
    {
        PlayerController player;

        public void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        }

        public IEnumerator Do() {
            player.MoveTo(this.transform.position);
            yield return new WaitForEndOfFrame();
            player.onArrive = Accion;
        }

        public void Accion()
        {
            player.carrying = true;
            player.attached = this.gameObject;
        }
    }

}
