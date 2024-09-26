using System.Timers;
using UnityEngine;
using UnityEngine.Jobs;

public class ObjectControll : MonoBehaviour
{
    [SerializeField] ObjectData objData;

    [SerializeField] bool trust;
    public bool Trust { get { return trust; } }

    [SerializeField] int index;
    public int Index { set { index = value; } }

    [SerializeField] float speed;

    [SerializeField] bool first;
    public bool First { set { first = value; } }


    private void Start()
    {
        objData = GameObject.FindGameObjectWithTag("test").GetComponent<ObjectData>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A) && first)
        {
            transform.position = Vector3.Lerp(transform.position, objData.LeftPoint.position, speed * Time.deltaTime);
        }

        if(Input.GetKeyDown(KeyCode.D) && first)
        {
            transform.position = Vector3.Lerp(transform.position, objData.RighttPoint.position, speed * Time.deltaTime);
        }
    }
}
