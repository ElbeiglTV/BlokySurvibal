using UnityEngine;
// esta clase va a ser la encargada de controlar si el player esta cerca de un recurso y en caso de estarlo ponerse a recolectarlo de forma automatica
// este script se encargara de prender las animaciones que sean nesesarias
// y rotar al player hacia el obj nesesario




public class FarmingTriguerControl : MonoBehaviour
{
    public PlayerController controller;
    public Transform rotateTarget;// se movera hacia el obj que estemos rompiendo;
    public Animator myAnimator;

    IreColectable colectable;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Tree")) // si el colider tiene la tag arbol tonces activo anim talar
        {
            if (controller.GetInput().magnitude == 0)
            {
                colectable = other.GetComponent<IreColectable>();
                myAnimator.SetBool("Talando",true);
                rotateTarget.position = new Vector3(other.transform.position.x, rotateTarget.position.y, other.transform.position.z);
            }
        }
    }

    public void Colect()
    {
        colectable?.Colect(1);
    }
}
