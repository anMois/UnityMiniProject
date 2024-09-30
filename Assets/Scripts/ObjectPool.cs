using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] Queue<ObjectControll> objPools = new Queue<ObjectControll>();
    [SerializeField] ObjectControll prefap;
    [SerializeField] ObjectData data;
    [SerializeField] int size;

    private void Awake()
    {
        data = GetComponent<ObjectData>();

        Vector3[] offset = new Vector3[data.zPoints.Length];
        for (int i = 0; i < data.zPoints.Length; i++)
        {
            offset[i] = new Vector3(0, prefap.transform.position.y, data.zPoints[i]);
        }
        for(int i = 0; i < size; i++)
        {
            ObjectControll instance = Instantiate(prefap, offset[i], Quaternion.identity);
            instance.transform.parent = transform;
            instance.Index = i;
            objPools.Enqueue(instance);
        }
    }
}
