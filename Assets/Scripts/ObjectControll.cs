using System;
using UnityEngine;

public class ObjectControll : MonoBehaviour
{
    [SerializeField] ObjectData objData;
    public ObjectPool objPool;

    [Header("State")]
    [SerializeField] float speed;
    [SerializeField] int index;
    [SerializeField] bool trust;
    [SerializeField] bool first;
    [SerializeField] bool choice;

    [Header("Next Move Vector3")]
    [SerializeField] Vector3 offset;

    public int Index { set { index = value; } }
    public bool Trust { get { return trust; } }
    public bool First { set { first = value; } }
    public bool Choice { set { choice = value; } }

    private void Awake()
    {
        objData = GameObject.FindGameObjectWithTag("test").GetComponent<ObjectData>();
        objPool = GameObject.FindGameObjectWithTag("test").GetComponent<ObjectPool>();
    }

    private void Update()
    {
        //입력을 받고 현재 위치가 첫번째인 경우
        if (choice && first)
        {
            transform.position = Vector3.Lerp(transform.position, objData.GetPosition(trust), speed * Time.deltaTime);
        }

        //현재 위치가 첫번째가 아닌경우
        if (Physics.Raycast(transform.position, Vector3.back, out RaycastHit hit, 0.5f) == false)
        {
            if (first || choice || index == 0 )
                return;

            transform.position = Vector3.MoveTowards(transform.position, GetOffset(), 1);
        }
    }

    private Vector3 GetOffset()
    {
        offset = new Vector3(transform.position.x, transform.position.y, objData.zPoints[--index]);

        return offset;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Tray"))
        {
            first = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.CompareTag("Tray"))
        {
            if (trust)
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            else
                transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Tray"))
        {
            objData.Size--;
            choice = false;
            objPool.RetrunObject(this);
        }
    }
}
