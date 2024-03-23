using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public LayerMask terrainMask;
    public Vector3 offset;
    public Vector3 rotation;
    public float radius;



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
        if(Physics.Linecast(transform.position,target.position,out RaycastHit hitInfo,terrainMask))
        {
            
           Container c = hitInfo.collider.GetComponent<Container>();
                
                
                    Debug.Log("Container" + c.ContainerPosition);
                    foreach (Vector3 v in c.data.Keys)
                    {
                        if (Vector3.Magnitude(v - hitInfo.point) < radius)
                        {
                            Debug.Log("transparent" + v);

                            Voxel Vox = c.data.Get(v);
                            Vox.isTransparent = true;
                            c.data.Set(v, Vox);
                            c.ReloadChunck();
                        }
                        else
                        {
                            Voxel Vox = c.data.Get(v);
                            Vox.isTransparent = false;
                            c.data.Set(v, Vox);
                            c.ReloadChunck();
                        }
                    }

                
            
        }
    }
   
}
