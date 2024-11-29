using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene("House-Mom");
            //switch to mom scene
        }
        else if (gameInfo.CurrentScene == GameScene.Mom)
        {
            gameInfo.CurrentScene = GameScene.Dad;
            SceneManager.LoadScene("House-Dad");
            //switch to dad scene
        }
        else if (gameInfo.CurrentScene == GameScene.Dad)
        {
            gameInfo.CurrentScene = GameScene.Party;
            SceneManager.LoadScene("Party");
            //switch to party scene
        }
        else if (gameInfo.CurrentScene == GameScene.Party && gameInfo.NumberOfLoops < 3)
        {
            gameInfo.NumberOfLoops++;
            gameInfo.CurrentScene = GameScene.Mom;
            SceneManager.LoadScene("House-Mom");
            //switch to mom scene
        }
        else if (gameInfo.CurrentScene == GameScene.Party && gameInfo.NumberOfLoops >= 3)
        {
            gameInfo.CurrentScene = GameScene.Friend;
            SceneManager.LoadScene("Friend");
            //switch to friend scene
        }
        else if (gameInfo.CurrentScene == GameScene.Friend)
        {
            gameInfo.CurrentScene = GameScene.Running;
            SceneManager.LoadScene("Running");
            //switch to running scene
        }
    }
    public void SwitchToLoseScreen()
    {
        gameInfo.CurrentScene = GameScene.Loss;
        SceneManager.LoadScene("Death");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
