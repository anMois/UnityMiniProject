using System.Collections;
using UnityEngine;

public class ObjectCreate : MonoBehaviour
{
    [SerializeField] ObjectData data;
    [SerializeField] ObjectControll prefap;
    [SerializeField] Transform createPoisition;
    [SerializeField] int size;
    [SerializeField] int maxSize;

    private void Start()
    {
        data = GetComponent<ObjectData>();
        StartCoroutine(CreateRoutine());
    }

    IEnumerator CreateRoutine()
    {
        Vector3[] dir = new Vector3[data.zPoints.Length];
        for (int i = 0; i < data.zPoints.Length; i++)
        {
            dir[i] = new Vector3(0, transform.position.y, data.zPoints[i]);
        }

        for (int i = 0; i < data.zPoints.Length; i++)
        {
            Instantiate(prefap, dir[i], Quaternion.identity);
            prefap.Index = i;
            size++;
            yield return null;
        }
    }
}
