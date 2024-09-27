using System.Collections;
using UnityEngine;

public class ObjectCreate : MonoBehaviour
{
    [SerializeField] ObjectData data;
    [SerializeField] ObjectControll prefap;
    [SerializeField] int size;
    [SerializeField] int maxSize;

    private void Start()
    {
        data = GetComponent<ObjectData>();
        maxSize = data.zPoints.Length;
        StartCoroutine(CreateRoutine());
    }

    IEnumerator CreateRoutine()
    {
        Vector3[] dir = new Vector3[data.zPoints.Length];
        for (int i = 0; i < data.zPoints.Length; i++)
        {
            dir[i] = new Vector3(0, prefap.transform.position.y, data.zPoints[i]);
        }

        for (int i = 0; i < data.zPoints.Length; i++)
        {
            prefap.Index = i;
            size++;
            Instantiate(prefap, dir[i], Quaternion.identity);
            yield return null;
        }
    }
}
