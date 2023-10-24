using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectType : MonoBehaviour 
{
    
    public enum Type
    {
        Cloud,
        Catus
    }

    private Type myType;

    public Type InitType;

    public void Awake()
    {
        myType = InitType;

        if(isType(Type.Cloud) is true)
        {
        }

    }

    public bool isType(Type type)
    {
        return myType == type;
    }

    public bool isCloud()
    {
        return myType == Type.Cloud;
    }

    public bool isCatus()
    {
        return myType == Type.Catus;
    }

}
