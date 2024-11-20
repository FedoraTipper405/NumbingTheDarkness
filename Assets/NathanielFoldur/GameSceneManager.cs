using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{

    [SerializeField]GameInfo gameInfo;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ChangeScene()
    {
        if(gameInfo.CurrentScene == GameScene.Divorce)
        {
            gameInfo.CurrentScene = GameScene.Mom;
            //switch to mom scene
        }
        else if (gameInfo.CurrentScene == GameScene.Mom)
        {
            gameInfo.CurrentScene = GameScene.Dad;
            //switch to dad scene
        }
        else if (gameInfo.CurrentScene == GameScene.Dad)
        {
            gameInfo.CurrentScene = GameScene.Party;
            //switch to party scene
        }
        else if (gameInfo.CurrentScene == GameScene.Party && gameInfo.NumberOfLoops < 3)
        {
            gameInfo.NumberOfLoops++;
            gameInfo.CurrentScene = GameScene.Mom;
            //switch to mom scene
        }
        else if (gameInfo.CurrentScene == GameScene.Party && gameInfo.NumberOfLoops >= 3)
        {
            gameInfo.CurrentScene = GameScene.Friend;
            //switch to friend scene
        }
        else if (gameInfo.CurrentScene == GameScene.Friend)
        {
            gameInfo.CurrentScene = GameScene.Running;
            //switch to running scene
        }
        else if (gameInfo.CurrentScene == GameScene.Running)
        {
            gameInfo.CurrentScene = GameScene.Loss;
            //switch to "loss" screen
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
