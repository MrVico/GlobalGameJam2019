using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float smoothTime = 0.3F;
    public float posY;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector3 velocity = Vector3.zero;

    private void Start()
    {

        //AkSoundEngine.PostEvent("Play_MusicIntroHouse", gameObject);
    }

    void Update()
    {
        // Define a target position above and behind the target transform
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, posY, -10));

        // Smoothly move the camera towards that target position
        Vector3 desiredPosition = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = new Vector3(Mathf.Clamp(desiredPosition.x, minX, maxX), Mathf.Clamp(desiredPosition.y, minY, maxY), desiredPosition.z);
    }

    private void OnDestroy()
    {
        if (SceneManager.GetActiveScene().Equals("Menu"))
        {
            //AkSoundEngine.PostEvent("Stop_MusicIntroHouse", this.gameObject);
        }
    }

}
