using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public enum Type
    {
        Cloud,
        Cactus
    }

    private Type mytype;
    public Type MyType => mytype;

    // Start is called before the first frame update
    void Start()
    {
        mytype = Type.Cloud;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
