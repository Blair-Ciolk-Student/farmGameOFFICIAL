using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private float smoothTime = 0.25f;
    [SerializeField] private Transform target;

    
   

    

    public Vector3 offset = new Vector3(0f, 0f, -3f);
    private Vector3 velocity = Vector3.zero;




    // Update is called once per frame
    void Update()
    {
       Follow();

    }

     void Follow()
    {
         Vector3 targetPosition = target.position + offset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
