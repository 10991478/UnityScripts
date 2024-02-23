using UnityEngine;

public class GeneralEnemyMethods : MonoBehaviour
{
    [SerializeField] private IntData intScore, intHealth;
    [SerializeField] private FloatData scoreMultiplier, damageMultiplier, floatScore, floatHealth;
    public void KillYourself()
    {
        Destroy(gameObject);
    }

    public void KillYourParent()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }

    public void AddToIntScore(int num)
    {
        intScore.AddValue((int)(scoreMultiplier.value*num));
    }

    public void AddToIntHealth(int num)
    {
        intHealth.AddValue((int)(damageMultiplier.value*num));
    }

    public void AddToFloatScore(float num)
    {
        floatScore.AddValue(scoreMultiplier.value * num);
    }

    public void AddToFloatHealth(float num)
    {
        floatHealth.AddValue(damageMultiplier.value * num);
    }
}
