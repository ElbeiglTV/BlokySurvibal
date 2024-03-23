using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public LayerMask terrainMask;
    public Vector3 offset;
    public Vector3 rotation;
    public float radius;
    int _iterations = 0;
   




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
        _iterations++;

        if (_iterations >= 10)
        {


            if (Physics.Linecast(transform.position+rayOffSet, target.position, out RaycastHit hitInfo, terrainMask))
            {

                Container c = hitInfo.collider.GetComponent<Container>();
                Debug.Log("Container" + c.ContainerPosition);

                List<Voxel> TransparencyData = new List<Voxel>();
                foreach (Voxel v in c.solidData)
                {
                    if (Vector3.Magnitude(v.WorldPos - hitInfo.point) < radius)
                    {
                        Debug.Log("transparent" + v);


                        Voxel vox = v;
                        vox.isTransparent = true;
                        TransparencyData.Add(vox);

                    }
                    else
                    {
                        Voxel vox = v;
                        vox.isTransparent = false;
                        TransparencyData.Add(vox);

                    }
                }
                c.solidData = TransparencyData;

                c.ReloadCoolDown = 2.1f;
                _iterations = 0;
            }


        }
    }


}
