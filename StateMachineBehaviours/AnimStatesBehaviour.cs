using UnityEngine;
using UnityEngine.Events;

public class AnimStatesBehaviour : StateMachineBehaviour
{
    [SerializeField] private UnityEvent onStateEnterEvent, onStateUpdateEvent, onStateExitEvent;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        onStateEnterEvent.Invoke();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        onStateUpdateEvent.Invoke();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex) {
        onStateExitEvent.Invoke();
    }
}
