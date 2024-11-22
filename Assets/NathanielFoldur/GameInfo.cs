using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOGameInfo", menuName = "SOs/SOGameInfo")]
public class GameInfo : ScriptableObject
{
    public int NumberOfLoops;
    public GameScene CurrentScene;
}
public enum GameScene
{
    Divorce = 0,
    Mom = 1,
    Dad = 2,
    Party = 3,
    Friend = 4,
    Running = 5,
    Loss = 6,
}