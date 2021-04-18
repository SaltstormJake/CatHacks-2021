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
        explosion.Play();
        Vector3 forward = this.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        int mask = ~((1 << 7) | (1 << 5) | (1 << 8));
        Ray ray = Camera.main.ScreenPointToRay(reticle.transform.position);
        ray = Camera.main.ViewportPointToRay(reticle.transform.position);
       // if(Physics.Raycast(reticle.transform.position, reticle.transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, mask))
        if (Physics.Raycast(ray, out hit, 1000.0f, mask))
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
