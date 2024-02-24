using UnityEngine;

public class SetTimeScale : MonoBehaviour
{
    public void SetScale(float num)
    {
        Time.timeScale = num;
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }
}
