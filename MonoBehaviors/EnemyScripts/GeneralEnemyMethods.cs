using UnityEngine;
using System;

public class GeneralEnemyMethods : MonoBehaviour
{
    [SerializeField] private IntData intScore, intHealth;
    [SerializeField] private FloatData scoreMultiplier, damageMultiplier, floatScore, floatHealth;
    [SerializeField] private GameObject[] pickupDropList;
    [SerializeField] private FloatData pickupDropChance;
    private System.Random rand = new System.Random();
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

    public void AddToIntScoreNoMultiplier(int num)
    {
        intScore.AddValue(num);
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

    public void DropPickupRandom(){
        if (rand.NextDouble() <= pickupDropChance.value){
            int randInt = rand.Next(pickupDropList.Length);
            Instantiate(pickupDropList[randInt], transform.position, new Quaternion(0,0,0,0));
        }
    }
}
