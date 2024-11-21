using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : InteractableObject
{
    public void PillCollected()
    {
        SceneSwitcher.Invoke();
    }

    public override void ObjectTouched()
    {
        Debug.Log("Pill Collected");
        PillCollected();
    }
}
