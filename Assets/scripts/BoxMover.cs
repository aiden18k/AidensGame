using UnityEngine;
public class BoxMover : MonoBehaviour

{
    public float scrollSpeed = 9f;
    public Transform endPoint;
    void Start()
    {
        endPoint = GameObject.Find("EndPoint").transform;
    }
    void Update()
    {
        transform.Translate(scrollSpeed * Time.deltaTime * Vector3.right);
         if (transform.position.x >= endPoint.position.x)
        {
            Destroy(gameObject);
        }
    }
}