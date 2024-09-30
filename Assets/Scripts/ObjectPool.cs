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

        //prefaps�� ����
        for (int y = 0; y < prefaps.Length; y++)
        {
            //������ų prefaps�� ����
            for (int x = 0; x < size; x++)
            {
                ObjectControll instance = Instantiate(prefaps[y], transform.position, Quaternion.identity);
                instance.transform.parent = transform;
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

            ObjectControll instance = objPools[randNum];
            instance.transform.position = position;
            instance.transform.parent = null;
            instance.gameObject.SetActive(true);

            objPools.RemoveAt(randNum);
            
            //��� �� ���ڸ�
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

        //�ߺ����� �ʴ� ���� ���
        if (choice[randNum] == false)
        {
            choice[randNum] = true;
            return randNum;
        }
        else
            return RandomNum();
    }
}
