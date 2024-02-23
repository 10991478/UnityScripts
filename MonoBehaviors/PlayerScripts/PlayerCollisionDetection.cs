using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerCollisionDetection : MonoBehaviour
{
    private Collider coll;
    public UnityEvent collideWithEnemyEvent, jumpOnEnemyEvent;
    [SerializeField] private ID coinID;
    [SerializeField] private UnityEvent coinEvent;
    private AudioSource playerAudio;
    public AudioClip coinSound, killEnemySound;

    [SerializeField] private BoolData gameOver;

    void Start()
    {
        coll = GetComponent<Collider>();
        playerAudio = GetComponent<AudioSource>();
    }

    private IEnumerator OnTriggerEnter(Collider other) {
        if (other.gameObject.layer == 6){
            if (OnTopOfEnemy(other)){
                jumpOnEnemyEvent.Invoke();
                playerAudio.PlayOneShot(killEnemySound, 0.5f);
                DestroyOtherAndParent(other);
            }
            else {
                collideWithEnemyEvent.Invoke();
            }
        }
        else if (other.gameObject.layer == 7){
            var tempID = other.GetComponent<IDContainer>().id;
            if (tempID == null)
            {
                yield break;
            }
            ID otherID = tempID;
            if (otherID == coinID)
            {
                coinEvent.Invoke();
                playerAudio.PlayOneShot(coinSound, 0.5f);
                DestroyOtherAndParent(other);
            }
        }
    }

    private bool OnTopOfEnemy(Collider enemyCollider){
        Vector3 boxCenter = coll.bounds.center;
        Vector3 halfExtents = coll.bounds.extents*0.8f;
 
        halfExtents.y = .025f;
        float maxDistance = coll.bounds.extents.y;
 
        RaycastHit[] colliders = Physics.BoxCastAll(boxCenter, halfExtents, Vector3.down, transform.rotation, maxDistance);
        
        bool onTop = false;
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].transform.gameObject.layer == 6){onTop = true; break;}
        }
        return onTop;
    }

    public void TesterMethod(bool onTop){
        Debug.Log(onTop);
    }

    public void DestroyOther(Collider other){
        Destroy(other.gameObject);
    }

    public void DestroyOtherAndParent(Collider other){
        Destroy(other.transform.parent.gameObject);
    }
}
