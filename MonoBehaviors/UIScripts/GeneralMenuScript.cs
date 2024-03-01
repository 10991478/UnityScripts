using UnityEngine;
using UnityEngine.SceneManagement;

//this script has functions for switching to scoreboard and level01 scenes and also for quitting the game
public class GeneralMenuScript : MonoBehaviour
{
    public int level01SceneNum;
    public int scoreboardSceneNum;


    public void StartGame() //loads the level1 scene (this is where the gameplay takes place)
    {
        SceneManager.LoadScene(level01SceneNum); // scene to load
        Debug.Log("Level 1 loaded");
    }

    public void QuitGame() //quits the game
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }

    public void AccessScoreboard() //loads the scoreboard
    {
        SceneManager.LoadScene(scoreboardSceneNum); // scene to load
        Debug.Log("Scoreboard loaded");
    }
}