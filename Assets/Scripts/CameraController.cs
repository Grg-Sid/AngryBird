using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float offsetX;
    public float offsetY;
    public float offsetSmoothing;
    public float minY = 5f;
    public float maxY = 5f;

    private Transform target;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }

    private void LateUpdate()
{
    if (target != null)
    {
        Vector3 targetPosition = target.position;
        targetPosition.z = transform.position.z;

        if (target.localScale.x > 0f)
        {
            targetPosition.x += offsetX;
        }
        else
        {
            targetPosition.x -= offsetX;
        }

        targetPosition.y += offsetY;
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

        transform.position = Vector3.Lerp(transform.position, targetPosition, offsetSmoothing * Time.deltaTime);
    }
}

}
