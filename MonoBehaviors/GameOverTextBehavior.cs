using UnityEngine;

public class GameOverTextBehavior : MonoBehaviour
{
    [SerializeField] private GameObject gameOverText;
    private void Awake(){
        gameOverText.SetActive(false);
    }

    public void Activate(){
        gameOverText.SetActive(true);
    }
}
