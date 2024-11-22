using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessMovement : MonoBehaviour
{
    public float DarknessSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetDarkSpeed(float newSpeed)
    {
        DarknessSpeed = newSpeed;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 DarkPos = new Vector2(DarknessSpeed,0);
        transform.position += (Vector3) DarkPos;
    }
}
