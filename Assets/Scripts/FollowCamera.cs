// Smooth towards the target

using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour
{
    public Transform target;
    public float dampTime = 0.15f;

    private Vector3 velocity = Vector3.zero;
    private Vector3 verticalOffset = new Vector3(0f, 1.5f, 0f);
    /*
    public float smoothTime = 0.3F;
    public float posY;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;


    void Update()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, posY, -10));

        // Smoothly move the camera towards that target position
        Vector3 desiredPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = new Vector3(Mathf.Clamp(desiredPosition.x, minX, maxX), Mathf.Clamp(desiredPosition.y, minY, maxY), desiredPosition.z);
    }
    */

    // Update is called once per frame
    void Update() {
        if (target) {
            Vector3 point = Camera.main.WorldToViewportPoint(target.position);
            Vector3 delta = target.position - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
            Vector3 destination = transform.position + delta + verticalOffset;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
        }

    }
}