using System.Collections;
using UnityEngine;

public class GarbageDestoryer : MonoBehaviour
{
    [SerializeField] GameObject portal;

    private void Start()
    {
        StartCoroutine(deletePortal());
    }

    IEnumerator deletePortal() 
    {
        yield return new WaitForSeconds(2f);

        Destroy(portal);
    }
}
