using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    
    public Quaternion startQuaternion;

    public Vector3 quaternionToVector;

    public float lerpTime = 1;

    public bool rotated;
    public bool hasToRotate=false;

    public bool rotateConstantly;

    public float RotateAmount = 1;
    
    void Start()
    {
        startQuaternion = transform.rotation;
        quaternionToVector = startQuaternion.eulerAngles;
    }

    void Update()
    {
        Debug.Log(hasToRotate);
        if (hasToRotate)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-180,180,0), Time.deltaTime * lerpTime );
           
        }
        else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-180,0,0), Time.deltaTime * lerpTime );

        }
    }

    public void onClick()
    {
        if (hasToRotate==false)
        {
            hasToRotate = true;
        }
        else
        {
            hasToRotate = false;
        }
    }
    
    public void snapRotation()
    {
        transform.rotation = startQuaternion;
    }
}
