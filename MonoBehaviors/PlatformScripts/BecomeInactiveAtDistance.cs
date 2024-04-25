using UnityEngine;

public class BecomeInactiveAtDistance : MonoBehaviour
{
    [SerializeField] private Vector3Data targetVector;
    [SerializeField] private FloatData distance;
    [SerializeField] private int consideredAxisXYZ_012 = 2;
    [SerializeField] private GameObject GO;

    private void Update()
    {
        switch (consideredAxisXYZ_012)
        {
            case 0:
                if (Mathf.Abs(targetVector.GetValue().x - gameObject.transform.position.x) >= distance.value)
                {
                    GO.SetActive(false);
                }
                else
                {
                    GO.SetActive(true);
                }
                break;
            case 1:
                if (Mathf.Abs(targetVector.GetValue().y - gameObject.transform.position.y) >= distance.value)
                {
                    GO.SetActive(false);
                }
                else
                {
                    GO.SetActive(true);
                }
                break;
            default:
                if (Mathf.Abs(targetVector.GetValue().z - gameObject.transform.position.z) >= distance.value)
                {
                    GO.SetActive(false);
                }
                else
                {
                    GO.SetActive(true);
                }
                break;
        }
    }
}
