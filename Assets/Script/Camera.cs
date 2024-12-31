using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    [SerializeField] Canvas canvas;



    void Start()
    {


        if (offset == Vector3.zero)
        {
            offset = transform.position - target.position;
        }
    }


    void LateUpdate()
    {
        if (Gamemanager.instance.isMoveCamera)
        {
            Vector3 desiredPosition = target.position + offset;

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;


            if (transform.position == desiredPosition)
            {
                Gamemanager.instance.isMoveCamera = false;
                GroundManager.Instance.SpwanGround();
            }
        }

    }

 
}
