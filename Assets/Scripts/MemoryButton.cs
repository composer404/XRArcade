using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryButton
{
    public int id { get; set; }

    public GameObject gameObject { get; set; }

    public MemoryButton(int id, GameObject gameObject)
    {
        this.id = id;
        this.gameObject = gameObject;
    }
}
