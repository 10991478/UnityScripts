using UnityEngine;

public class GeneralEnemyMethods : MonoBehaviour
{
    public void KillYourself()
    {
        Destroy(gameObject);
    }

    public void KillYourParent()
    {
        Destroy(gameObject.transform.parent.gameObject);
    }
}
