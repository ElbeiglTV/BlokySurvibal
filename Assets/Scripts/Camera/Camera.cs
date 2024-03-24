using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public LayerMask terrainMask;
    public Vector3 offset;
    public Vector3 rotation;
    public Material[] mat;
    public float maxRadius;
    //int _iterations = 0;





    // Start is called before the first frame update
    void Start()
    {
        UpdateManager.OnUpdate += ManagedUpdate;
        UpdateManager.OnFixedUpdate += ManagedFixedUpdate;
    }

    void ManagedUpdate()
    {
        transform.position = target.position + offset;
        transform.rotation = Quaternion.Euler(rotation);



    }

    void ManagedFixedUpdate()
    {
        TransparencyControl(Vector3.zero);


    }

    void TransparencyControl(Vector3 rayOffSet)
    {


        float Radius;
        if (Physics.Linecast(transform.position + rayOffSet, target.position, out RaycastHit hitInfo, terrainMask))
        {
            Radius = maxRadius / hitInfo.distance;
            if (Radius < 1.5f)
            {
                Radius = 1.5f;
            }

            foreach (Material mat in mat)
            {
                mat.SetVector("_Position", hitInfo.point);
                mat.SetFloat("_Radius", Radius);
                mat.SetFloat("_Intencity", 4);

            }


        }
        else
        {
            foreach (Material mat in mat)
                mat.SetFloat("_Intencity", 1);
        }



    }


}
