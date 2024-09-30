using System;
using UnityEngine;

public class ObjectControll : MonoBehaviour
{
    [SerializeField] ObjectData objData;

    [SerializeField] float speed;

    [SerializeField, Range(0f, 1f)] float downSpeed;

    [SerializeField] int index;
    [SerializeField] bool trust;
    [SerializeField] bool first;
    [SerializeField] bool choice;

    [SerializeField] Vector3 offset;

    public int Index { set { index = value; } }
    public bool Trust { get { return trust; } }
    public bool First { get { return first; } set { first = value; } }
    public bool Choice { set { choice = value; } }

    private void Start()
    {
        objData = GameObject.FindGameObjectWithTag("test").GetComponent<ObjectData>();

    }

    private void Update()
    {
        if (choice && first)
        {
            transform.position = Vector3.Lerp(transform.position, objData.GetPosition(trust), speed * Time.deltaTime);
        }

        if (Physics.Raycast(transform.position, Vector3.back, out RaycastHit hit, 0.5f) == false)
        {
            if (first || choice || index == 0 )
                return;

            Debug.Log("1");
            transform.position = Vector3.MoveTowards(transform.position, GetOffset(), downSpeed);
            //MoveTrail();
        }
    }

    private Vector3 GetOffset()
    {
        offset = new Vector3(transform.position.x, transform.position.y, objData.zPoints[--index]);

        return offset;
    }

    private void MoveTrail()
    {
        Vector3 offset = new Vector3(transform.position.x, transform.position.y, objData.zPoints[index--]);

        transform.position = Vector3.MoveTowards(transform.position, offset, 1);
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
            gameObject.SetActive(false);
        }
    }
}
