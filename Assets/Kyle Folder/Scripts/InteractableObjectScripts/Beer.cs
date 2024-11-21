using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beer : InteractableObject
{
    public void BeerCollected()
    {
        SceneSwitcher.Invoke();
    }

    public override void ObjectTouched()
    {
        Debug.Log("Beer Collected");
        BeerCollected();
    }
}
