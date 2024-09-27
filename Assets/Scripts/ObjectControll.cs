using System;
using UnityEngine;

public class ObjectControll : MonoBehaviour
{
    [SerializeField] ObjectData objData;

    [SerializeField] float speed;

    [SerializeField] int index;
    [SerializeField] bool trust;
    [SerializeField] bool first;
    [SerializeField] bool choice;

    [SerializeField] Vector3 offset;

    public int Index { set { index = value; } }
    public bool Trust { get { return trust; } }
    public bool First { set { first = value; } }
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
            if (first)
                return;

            index--;
            transform.position = Vector3.MoveTowards(transform.position, GetOffset(), speed * Time.deltaTime);
        }
    }

    private Vector3 GetOffset()
    {
        offset = new Vector3(transform.position.x, transform.position.y, objData.zPoints[index]);

        return offset;
    }

    private bool ConfirmInput()
    {
        if (choice && trust)
            return true;

        return false;
    }

    private void MoveTrail()
    {
        Vector3 offset = new Vector3(transform.position.x, transform.position.y, objData.zPoints[index--]);

        transform.position = Vector3.MoveTowards(transform.position, offset, speed * Time.deltaTime);
    }
}
