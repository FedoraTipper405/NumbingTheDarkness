using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother : InteractableObject
{
    public void MotherReached()
    {
        SceneSwitcher.Invoke();
    }

    public override void ObjectTouched()
    {
        Debug.Log("Mother Reached");
        MotherReached();
    }
}
