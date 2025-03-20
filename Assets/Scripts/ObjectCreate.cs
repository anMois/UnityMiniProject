using System.Collections;
using UnityEngine;

public class ObjectCreate : MonoBehaviour
{
    [Header("GetComponent")]
    [SerializeField] ObjectData data;
    [SerializeField] ObjectPool pool;

    [SerializeField, Space] int maxSize;

    private bool wait;

    private void Start()
    {
        data = GetComponent<ObjectData>();
        pool = GetComponent<ObjectPool>();
        maxSize = data.zPoints.Length;
        StartCreateObject();
    }

    private void Update()
    {
        if (data.Size < maxSize && wait)
        {
            CreateObject();
        }
    }

    // 게임 시작시 레일 위에 오브젝트 생성
    void StartCreateObject()
    {
        Vector3[] dir = new Vector3[data.zPoints.Length];
        for (int i = 0; i < data.zPoints.Length; i++)
        {
            dir[i] = new Vector3(0, transform.position.y, data.zPoints[i]);
        }

        for (int i = 0; i < data.zPoints.Length; i++)
        {
            data.Size++;
            ObjectControll objControll = pool.GetObject(dir[i]);
            objControll.Index = i;
        }
        wait = true;
    }

    private void CreateObject()
    {
        Vector3 dir = new Vector3(transform.position.x, transform.position.y, data.zPoints[maxSize - 1]);
        ObjectControll objControll = pool.GetObject(dir);
        objControll.Index = maxSize - 1;
        data.Size++;
    }
}
