using System.Collections;
using UnityEngine;

public class ObjectCreate : MonoBehaviour
{
    [SerializeField] ObjectData data;
    [SerializeField] ObjectControll[] prefaps;
    [SerializeField] int maxSize;

    private bool wait;

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
            dir[i] = new Vector3(0, transform.position.y, data.zPoints[i]);
        }

        for (int i = 0; i < data.zPoints.Length; i++)
        {
            int num = RandomNum();
            data.Size++;
            ObjectControll objControll = Instantiate(prefaps[num], dir[i], Quaternion.identity);
            objControll.Index = i;
            yield return null;
        }
        wait = true;
        yield break;
    }

    private void CreateObject()
    {
        Vector3 dir = new Vector3(transform.position.x, transform.position.y, data.zPoints[maxSize - 1]);
        ObjectControll objControll = Instantiate(prefaps[RandomNum()], dir, Quaternion.identity);
        objControll.Index = maxSize - 1;
        data.Size++;
    }

    private int RandomNum()
    {
        int randNum = Random.Range(0, 2);

        return randNum;
    }
}
