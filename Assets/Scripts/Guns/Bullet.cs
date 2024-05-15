using UnityEngine;

public class Bullet : SteerinAgent
{
    public Transform target;

    

    void Update()
    {
        if (target == null)
        {
            
            Destroy(gameObject);
            return;
        }

        AddForce(Seek(target.position));
        Move();


        if (Vector3.Distance(target.position, transform.position) <= 0.2f)
        {
            target.GetComponent<IreColectable>().Colect(Statics.playerBaseDamage);
            
            Destroy(gameObject);

        }
    }


}
