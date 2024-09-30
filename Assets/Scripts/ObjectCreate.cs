using System.Collections;
using UnityEngine;

public class ObjectCreate : MonoBehaviour
{
    [SerializeField] ObjectData data;
    [SerializeField] ObjectControll prefap;
    [SerializeField] int maxSize;

    bool wait;

    private void Start()
    {
        data = GetComponent<ObjectData>();
        maxSize = data.zPoints.Length;
        StartCoroutine(StartCreateRoutine());
    }

    private void Update()
    {
        if (data.Size < maxSize && wait)
        {
            CreateObject();
        }
    }

    IEnumerator StartCreateRoutine()
    {
        Vector3[] dir = new Vector3[data.zPoints.Length];
        for (int i = 0; i < data.zPoints.Length; i++)
        {
            dir[i] = new Vector3(0, prefap.transform.position.y, data.zPoints[i]);
        }

        for (int i = 0; i < data.zPoints.Length; i++)
        {
            prefap.Index = i;
            data.Size++;
            Instantiate(prefap, dir[i], Quaternion.identity);
            yield return null;
        }
        wait = true;
        yield break;
    }

    private void CreateObject()
    {
        Vector3 dir = new Vector3(transform.position.x, transform.position.y, data.zPoints[maxSize - 1]);
        prefap.Index = maxSize - 1;
        Instantiate(prefap, dir, Quaternion.identity);
        data.Size++;
    }
}
