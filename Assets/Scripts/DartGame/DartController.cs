using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    private DartManager dart;

    // Start is called before the first frame update
    void Start()
    {
        this.dart = GameObject.FindObjectOfType<DartManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        if(other.tag == "DartBoard") {
            int points = other.gameObject.GetComponent<ElementController>().GetScorePoints();
            dart.SubtractPoints(points);
            rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
            AudioManager.GetInstance().PlayDartHit();
            return;
        }
        rb.useGravity = true;
        print("Dart collision" + other.tag);
        rb.isKinematic = false;
    }
}
