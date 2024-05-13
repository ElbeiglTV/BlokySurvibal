using UnityEngine;

public class Bullet : SteerinAgent
{
    public Transform target;

    void Start()
    {
        UpdateManager.OnUpdate += ManagedUpdate;
    }


    void ManagedUpdate()
    {
        if (target == null)
        {
            UpdateManager.OnUpdate -= ManagedUpdate;
            Destroy(gameObject);
            return;
        }

        AddForce(Seek(target.position));
        Move();


        if (Vector3.Distance(target.position, transform.position) <= 0.2f)
        {
            target.GetComponent<IreColectable>().Colect(1);
            UpdateManager.OnUpdate -= ManagedUpdate;
            Destroy(gameObject);

        }
    }


}
