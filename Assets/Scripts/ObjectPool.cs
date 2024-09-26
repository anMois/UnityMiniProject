using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] List<ObjectControll> objPools = new List<ObjectControll>();
    [SerializeField] ObjectControll prefap;
    [SerializeField] int size;

    [SerializeField] float[] zPoints;

    private void Awake()
    {
        Vector3[] vector3s = new Vector3[zPoints.Length];
        for (int i = 0; i < zPoints.Length; i++)
        {
            vector3s[i] = new Vector3(prefap.transform.position.x, prefap.transform.position.y, zPoints[i]);
        }
        for(int i = 0; i < size; i++)
        {
            ObjectControll instance = Instantiate(prefap, vector3s[i], Quaternion.identity);
            instance.gameObject.SetActive(false);
            instance.transform.parent = transform;
            objPools.Add(instance);
        }
    }
}
