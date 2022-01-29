using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DeleteAfterDelay());
    }
    private IEnumerator DeleteAfterDelay()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Cubo"))
        {
            collision.gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }
}
