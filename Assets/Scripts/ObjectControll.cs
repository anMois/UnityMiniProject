using UnityEngine;

public class ObjectControll : MonoBehaviour
{

    [SerializeField] Transform leftPoint;
    [SerializeField] Transform righttPoint;
    [SerializeField] bool left;
    public bool Left { set { left = value; } }
    [SerializeField] bool right;
    public bool Right { set { right = value; } }

    [SerializeField] bool trust;
    public bool Trust { get { return trust; } }

    [SerializeField] float speed;
    Vector3 firstPoint;

    private void Start()
    {
        firstPoint = transform.position;
    }

    private void Update()
    {
        if (left)
        {
            transform.position = Vector3.Slerp(transform.position, leftPoint.position, speed * Time.deltaTime);
        }
        else if (right)
        {
            transform.position = Vector3.Slerp(transform.position, righttPoint.position, speed * Time.deltaTime);
        }
    }
}
