using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementController : MonoBehaviour
{

    [SerializeField]
    private int scoredPoints;

    public DartManager dart;
    
    // Start is called before the first frame update
    void Start()
    {
        dart = GameObject.FindObjectOfType<DartManager>();
    }

    // Update is called once per frame
    void Update()
    {
        dart.SubtractPoints(this.scoredPoints);
    }
}
