using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessMovement : MonoBehaviour
{
    public float DarknessSpeed;
    [SerializeField] float RunningAcceleration;
    [SerializeField] GameInfo gameInfo;
    [SerializeField] private float speedPerLoop;
    [SerializeField] private float pillChange;
    // Start is called before the first frame update
    void Start()
    {
        DarknessSpeed += speedPerLoop * gameInfo.NumberOfLoops;
    }
    public void SetDarkPillSpeed(float PillSpeed)
    {
        float tempSpeed = PillSpeed + pillChange * gameInfo.NumberOfLoops;
        SetDarkSpeed(tempSpeed);
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
        if(gameInfo.CurrentScene == GameScene.Running)
        {
            DarknessSpeed += RunningAcceleration;
        }
    }
}
