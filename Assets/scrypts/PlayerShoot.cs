using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public playerWeapon weapon;
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] int maxBullets;
    public int BulletsLeft;
    private bool noMoreBullets;

    [SerializeField] AudioSource gunSFX;
    [SerializeField] AudioSource gunSFX2;
    [SerializeField] AudioSource reloadSFX;

    void Start()
    {
        if(cam == null)
        {
            print("pas de cam assign�e");
            this.enabled = false;
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && BulletsLeft != 0)
        {
            Shoot();
        }
        if (Input.GetButtonDown("Fire2") && BulletsLeft != maxBullets)
        {
            Reload();
        }
    }

    private void Shoot()
    {
        BulletsLeft -= 1;
        RaycastHit hit;
        gunSFX.Play();
        gunSFX2.Play();
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, layerMask)) ;
        {
            print(hit.collider.name);
        }
    }

    private void Reload()
    {
        BulletsLeft = maxBullets;
        reloadSFX.Play();
    }
}
