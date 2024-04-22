using UnityEngine;
using UnityEngine.Events;

public class GeneralCoinPurchaseScript : MonoBehaviour
{
    [SerializeField] private IntData coinsObj;
    [SerializeField] private UnityEvent canAffordPurchaseEvent, canNotAffordPurchaseEvent;

    public void TryToPurchaseItem(int itemCost)
    {
        if (coinsObj.AddedValueExceedsLowerBound((-1)*itemCost)) canNotAffordPurchaseEvent.Invoke();
        else canAffordPurchaseEvent.Invoke();
    }
}
