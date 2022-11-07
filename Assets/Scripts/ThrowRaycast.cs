using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowRaycast : MonoBehaviour
{
    private bool hasHit;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        var theThrow = transform.parent;
        rb = theThrow.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasHit) ShootRaycast();

        if (hasHit)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        if (hasHit)
        {
            hasHit = false;
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }


    private void ShootRaycast()
    {
        hasHit = Physics.Raycast(transform.position, transform.up, out RaycastHit hit, 0.2f);
    }
}
