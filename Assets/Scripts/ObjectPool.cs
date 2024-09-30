using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] List<ObjectControll> objPools = new List<ObjectControll>();
    [SerializeField] ObjectControll[] prefaps;
    [SerializeField] ObjectData data;
    [SerializeField] int size;

    private bool[] choice;

    private void Awake()
    {
        data = GetComponent<ObjectData>();

        //prefaps의 종류
        for (int y = 0; y < prefaps.Length; y++)
        {
            //생성시킬 prefaps의 갯수
            for (int x = 0; x < size; x++)
            {
                ObjectControll instance = Instantiate(prefaps[y], transform.position, Quaternion.identity);
                instance.transform.parent = transform;
                instance.objPool = this;
                instance.gameObject.SetActive(false);
                objPools.Add(instance);
            }
        }

        choice = new bool[objPools.Count];
    }

    public ObjectControll GetObject(Vector3 position)
    {
        if (objPools.Count > 0)
        {
            int randNum = RandomNum();
            Debug.Log(randNum);
            ObjectControll instance = objPools[randNum];
            instance.transform.position = position;
            instance.transform.parent = null;
            instance.gameObject.SetActive(true);
            instance.objPool = this;

            objPools.RemoveAt(randNum);
            choice[randNum] = false;

            return instance;
        }
        else
            return null;
    }

    public void RetrunObject(ObjectControll instance)
    {
        instance.gameObject.SetActive(false);
        instance.transform.parent = transform;
        objPools.Add(instance);
    }

    private int RandomNum()
    {
        int randNum = Random.Range(0, objPools.Count);
        if (choice[randNum] == false)
        {
            choice[randNum] = true;
            return randNum;
        }
        else
            return RandomNum();
    }
}
