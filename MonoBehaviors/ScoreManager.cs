using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public IntData score;
    public void AddToScore(int value){
        score.AddValue(value);
    }
}
