using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// esta clase va a ser la encargada de controlar si el player esta cerca de un recurso y en caso de estarlo ponerse a recolectarlo de forma automatica
// el daño a los recursos se realizara mediante animation event y coliders 
// este script se encargara de prender las animaciones que sean nesesarias
// y rotar al player hacia el obj nesesario
// el objeto del player rotara desde la animacion con riguin



public class FarmingTriguerControl : MonoBehaviour
{
    public Transform rotateTarget;// se movera hacia el obj que estemos rompiendo;

    private void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Tree")) // si el colider tiene la tag arbol tonces activo anim talar
        {
            // animator.play treee
            rotateTarget.position =other.transform.position;
        }
    }
}
