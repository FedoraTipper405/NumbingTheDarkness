using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class InteractableObject : MonoBehaviour, IObjectTouched
{
    public UnityEvent SceneSwitcher;
    public abstract void ObjectTouched();
}
