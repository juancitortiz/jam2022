using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sea : MonoBehaviour
{
    public delegate void CatFall(Gato gato);
    public event CatFall OnCatFall;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Cat"))
        {
            OnCatFall?.Invoke(collision.gameObject.GetComponent<Gato>());

        }
    }
}
