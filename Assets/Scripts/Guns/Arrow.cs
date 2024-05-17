using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target == null)
        {
            gameObject.SetActive(false);
            return;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, 0.1f);
            transform.forward = target.position - transform.position;
            if (Vector3.Distance(target.position, transform.position) <= 0.2f)
            {
                target.GetComponent<IreColectable>().Colect(Statics.playerBaseDamage);
                target = null;
            }
        }
    }
}
