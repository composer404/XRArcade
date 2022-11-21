using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementController : MonoBehaviour
{

    [SerializeField]
    private int scoredPoints;

    private DartManager dart;
    
    // Start is called before the first frame update
    void Start()
    {
        this.dart = GameObject.FindObjectOfType<DartManager>();
    }

    // Update is called once per frame
    // void Update()
    //{
    //    dart.SubtractPoints(this.scoredPoints);
    //}

    public int GetScorePoints() {
        return this.scoredPoints;
    }
}
