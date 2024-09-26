using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCreate : MonoBehaviour
{
    [SerializeField] ObjectControll prefap;
    [SerializeField] Transform createPoisition;
    [SerializeField] int size;
    [SerializeField] int maxSize;

    private void Start()
    {
        StartCoroutine(CreateRoutine());
    }

    IEnumerator CreateRoutine()
    {
        WaitForSeconds delay = new WaitForSeconds(1f);

        while (size < maxSize)
        {
            Instantiate(prefap, createPoisition.position, Quaternion.identity);
            yield return null;
            size++;
            yield return delay;
        }
    }
}
