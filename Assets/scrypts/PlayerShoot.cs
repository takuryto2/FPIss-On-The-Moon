using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public playerWeapon weapon;
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] AudioSource gunSFX;


    void Start()
    {
        if(cam == null)
        {
            print("pas de cam assignée");
            this.enabled = false;
        }
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        RaycastHit hit;
        gunSFX.Play();
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, weapon.range, layerMask));
        {
            print(hit.collider.name);
        }
    }
}
