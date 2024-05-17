using UnityEngine;

public class Factory
{
    public T Create<T>() where T : MonoBehaviour
    {
        return Object.Instantiate(Resources.Load<T>(typeof(T).Name));
    }

}
