using UnityEngine;
// esta clase va a ser la encargada de controlar si el player esta cerca de un recurso y en caso de estarlo ponerse a recolectarlo de forma automatica
// este script se encargara de prender las animaciones que sean nesesarias
// y rotar al player hacia el obj nesesario




public class FarmingTriguerControl : MonoBehaviour
{
    public UserModel model;
    public Transform rotateTarget;// se movera hacia el obj que estemos rompiendo;
    public Animator myAnimator;
    public Transform bow;
    public bool Tree;
    public bool Enemy;
    public bool Rock;

    IreColectable _colectable;

    private void Update()
    {
        if (_colectable != null)
        {
            if (!_colectable.ActiveSelf())
            {
                myAnimator.SetBool("Talando", false);
                myAnimator.SetBool("Shoot", false);
                _colectable.TogleSelect(false);
                _colectable = null;
            }
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Tree")&& Tree) // si el colider tiene la tag arbol tonces activo anim talar
        {
            if (model.GetInput().magnitude == 0)
            {
                _colectable = other.GetComponent<IreColectable>();
                myAnimator.SetBool("Talando", true);
                _colectable.TogleSelect(true);
                rotateTarget.position = new Vector3(other.transform.position.x, rotateTarget.position.y, other.transform.position.z);
            }
            else
            {
                myAnimator.SetBool("Talando", false);
            }
        }

        if (other.CompareTag("Enemy")&& Enemy) // si el colider tiene la tag Enemy tonces activo anim shoot
        {
            if (model.GetInput().magnitude == 0)
            {
                _colectable = other.GetComponent<IreColectable>();
                myAnimator.SetBool("Shoot", true);
                _colectable.TogleSelect(true);
                rotateTarget.position = new Vector3(other.transform.position.x, rotateTarget.position.y, other.transform.position.z);
            }
            else
            {
                myAnimator.SetBool("Shoot", false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tree")&& Tree) // si el colider tiene la tag Tree tonces activo anim talar
        {
            if (other.GetComponent<IreColectable>() == _colectable)
            {
                _colectable.TogleSelect(false);
                _colectable = null;
            }
            myAnimator.SetBool("Talando", false);
        }

        if (other.CompareTag("Enemy")&&Enemy) // si el colider tiene la tag Enemy tonces activo anim shoot
        {
            if (other.GetComponent<IreColectable>() == _colectable)
            {
                _colectable.TogleSelect(false);
                _colectable = null;
            }
            myAnimator.SetBool("Shoot", false);
        }
    }


    public void Colect()
    {
        _colectable?.Colect(1);
    }

    public void Shoot()
    {
        if (_colectable != null)
        {
            Arrow arrow = ArrowPool.Instance.Get();
            arrow.target = _colectable.GetObject().transform;
            arrow.transform.position = bow.position;
            arrow.gameObject.SetActive(true);
        }

    }
}
