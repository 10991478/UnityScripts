using UnityEngine;

public class PlayerGunControllerTopDown : MonoBehaviour
{
    private float timeSinceLastShot, shootingDirection = 0;
    [SerializeField] private IntData currentAmmoType;
    [SerializeField] private FloatData shotCooldown;
    [SerializeField] private GameObject[] ammoObjects;

    void Awake()
    {
        timeSinceLastShot = Time.time;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) shootingDirection = 1f;
        else if (Input.GetKeyDown(KeyCode.RightArrow)) shootingDirection = 2f;
        else if (Input.GetKeyDown(KeyCode.DownArrow)) shootingDirection = 3f;
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) shootingDirection = 4f;
        else if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftArrow)) shootingDirection = 0f;

        if (shootingDirection != 0f && Time.time - timeSinceLastShot >= shotCooldown.value)
        {
            Shoot(shootingDirection);
            timeSinceLastShot = Time.time;
        }

        //SWITCHING AMMO TYPE
        int currentAmmoInt = currentAmmoType.value;
        if (Input.GetKeyDown(KeyCode.E)) currentAmmoInt++;
        if (Input.GetKeyDown(KeyCode.Q)) currentAmmoInt--;

        if (currentAmmoInt < 0) currentAmmoInt = ammoObjects.Length - 1;
        else if (currentAmmoInt >= ammoObjects.Length) currentAmmoInt = 0;

        currentAmmoType.SetValue(currentAmmoInt);
    }

    public void Shoot(float direction)
    {
        Instantiate(ammoObjects[currentAmmoType.value], transform.position, transform.rotation * Quaternion.Euler(0, 90 * (shootingDirection - 1), 0));

    }
}
