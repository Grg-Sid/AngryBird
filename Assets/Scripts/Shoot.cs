using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float power = 5f;
    Rigidbody2D rb;
    //LineRenderer lr;

    public Vector2 minPower;
    public Vector2 maxPower;

    private Camera cam;
    private bool isNotShot = true;
    private float dragDistanceThreshold = 0.1f;

    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //lr = GetComponent<LineRenderer>();
        cam = Camera.main;
    }
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
            startPoint.z = 15;
        }
        if(Input.GetMouseButtonUp(0) && isNotShot) 
        { 
            endPoint = cam.ScreenToWorldPoint(Input.mousePosition); 
            endPoint.z = 15;

            if(Mathf.Abs(startPoint.x - endPoint.x) > dragDistanceThreshold || Mathf.Abs(startPoint.y - endPoint.y) >  dragDistanceThreshold)
            { 
                rb.constraints = RigidbodyConstraints2D.None;
                Debug.Log(Mathf.Abs(startPoint.x - endPoint.x));
                isNotShot = false;
            }

            force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
        }
    }


}
