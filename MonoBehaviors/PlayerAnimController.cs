using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] private UnityEvent pressRightEvent, pressLeftEvent;
    [SerializeField] private UnityEvent regularWalkEvent, sneakWalkEvent, runEvent, sneakIdleEvent, idleEvent,
        crouchEvent, extendEvent, fallEvent, landEvent, dieEvent;

    IDictionary<string, bool> animStates = new Dictionary<string, bool>();

    [SerializeField] private BoolData gameOver;
    [SerializeField] private FloatData speedMultiplier;
    private Animator thisAnimator;

    void Awake()
    {
        animStates.Add("Walking", false);
        animStates.Add("Sneaking", false);
        animStates.Add("Running", false);
        animStates.Add("Grounded", true);
        animStates.Add("Crouching", false);
        animStates.Add("Extending", false);
        FaceRight();
        thisAnimator = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (!gameOver.value){
    //Right button
            if (Input.GetKeyDown("right")){
                animStates["Walking"] = true;
                pressRightEvent.Invoke();
                if (animStates["Grounded"]) UpdateAnimState();
            }
            if (Input.GetKeyUp("right")){
                if (!Input.GetKey("left")) animStates["Walking"] = false;
                if (animStates["Grounded"]) UpdateAnimState();
            }
    //Left button
            if (Input.GetKeyDown("left")){
                animStates["Walking"] = true;
                pressLeftEvent.Invoke();
                if (animStates["Grounded"]) UpdateAnimState();
            }
            if (Input.GetKeyUp("left")){
                if (!Input.GetKey("right")) animStates["Walking"] = false;
                if (animStates["Grounded"]) UpdateAnimState();
            }
    //Left shift button
            if (Input.GetKeyDown(KeyCode.LeftShift)){
                animStates["Running"] = false;
                animStates["Sneaking"] = true;
                if (animStates["Grounded"]) UpdateAnimState();
            }
            if (Input.GetKeyUp(KeyCode.LeftShift)){
                animStates["Sneaking"] = false;
                if (animStates["Grounded"]) UpdateAnimState();
            }
    //Left control button
            if (Input.GetKeyDown(KeyCode.LeftControl)){
                animStates["Sneaking"] = false;
                animStates["Running"] = true;
                if (animStates["Grounded"]) UpdateAnimState();
            }
            if (Input.GetKeyUp(KeyCode.LeftControl)){
                animStates["Running"] = false;
                if (animStates["Grounded"]) UpdateAnimState();
            }
    //Jump button
            if (Input.GetButtonDown("Jump")){
                if (animStates["Grounded"]) {
                    animStates["Crouching"] = true;
                    animStates["Grounded"] = true;
                    UpdateAnimState();
                }
            }
            if (Input.GetButtonUp("Jump")){
                if (animStates["Grounded"]){
                    animStates["Crouching"] = false;
                    animStates["Extending"] = true;
                    UpdateAnimState();
                    animStates["Grounded"] = false;
                }
            }
        }
    }



    public void UpdateAnimState(){
        if (animStates["Crouching"]){
            crouchEvent.Invoke();
            return;
        }
        else if (animStates["Extending"]){
            extendEvent.Invoke();
            animStates["Extending"] = false;
            return;
        }
        if (animStates["Walking"]){
            if (animStates["Sneaking"]){
                sneakWalkEvent.Invoke();
                return;
            }
            else if (animStates["Running"]){
                runEvent.Invoke();
                return;
            }
            else {
                regularWalkEvent.Invoke();
                return;
            }
        }
        else {
            if (animStates["Sneaking"]){
                sneakIdleEvent.Invoke();
                return;
            }
            else {
                idleEvent.Invoke();
                return;
            }
        }
    }




    public void FaceRight(){
        transform.rotation = Quaternion.Euler(0, -75, 0);
    }

    public void FaceLeft(){
        transform.rotation = Quaternion.Euler(0, 105, 0);
    }

    public void Fall(){
        fallEvent.Invoke();
    }

    public void Land(){
        landEvent.Invoke();
        animStates["Grounded"] = true;
    }

    public void Die(){
        dieEvent.Invoke();
    }

    public void SetAnimatorSpeed(){
        thisAnimator.speed = speedMultiplier.value;
    }
}
