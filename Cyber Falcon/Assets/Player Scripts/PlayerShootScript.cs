using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootScript : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab = default;
    [SerializeField] float shootInterval = 0.2f;
    [SerializeField] float bulletSpeed = 100.0f;
    [SerializeField] GameObject reticle = default;
    ParticleSystem explosion = default;
    bool canShoot = true;
    void Awake()
    {
        explosion = this.transform.GetChild(2).gameObject.GetComponent<ParticleSystem>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canShoot)
        {
            FireBullet();
        }
    }

    void FireBullet()
    {
        canShoot = false;
        /*Vector3 bulletLoc = this.transform.position + this.transform.forward * 2.0f;
        GameObject bullet = Instantiate(bulletPrefab, bulletLoc, this.transform.rotation);
        bullet.GetComponent<PlayerBulletScript>().SetVelocity(this.gameObject, reticle, bulletSpeed);*/
        /* Ray ray = Camera.main.ScreenPointToRay(reticle.transform.position);
         RaycastHit hit = default;
         if(Physics.Raycast(ray, out hit, Mathf.Infinity))
         {
             if(hit.transform.gameObject.tag == "Ground")
             {
                 Debug.Log("Hit ground");
             }
         }*/
        explosion.Play();
        Vector3 forward = this.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        int mask = ~((1 << 7) | (1 << 5) | (1 << 8));
        Ray ray = Camera.main.ScreenPointToRay(reticle.transform.position);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, mask))
        {
            Debug.DrawRay(ray.origin, ray.direction * 1000f);
            Debug.Log(hit.point);
            Debug.Log(hit.collider.gameObject.name);
        }
        else
            Debug.Log("Hit nothing");
        Invoke("EnableCanShoot", shootInterval);
    }

    void EnableCanShoot()
    {
        canShoot = true;
    }


}
