using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] GameInfo gameInfo;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void StartGame()
    {
        gameInfo.CurrentScene = GameScene.Divorce;
        gameInfo.NumberOfLoops = 1;
        SceneManager.LoadScene("Bedroom-Divorce");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
