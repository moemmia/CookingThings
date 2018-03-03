using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets
{
    class Recoger: MonoBehaviour, Action_Interface
    {

        public void Do() {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Mouse_Move>().MoveTo(this.transform.position);
            //Y AHORA? REFORMULAR TODO ESTO, NO ESTOY SEGURO :(
        }


    }

}
