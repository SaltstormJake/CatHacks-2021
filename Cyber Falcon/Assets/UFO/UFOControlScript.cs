using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOControlScript : MonoBehaviour
{
    [SerializeField] Vector3 startingPos = default;
    [SerializeField] Vector3 entrancePos = default;
    [SerializeField] GameObject bullet = default;
    [SerializeField] GameObject player = default;
    UFOMovementScript movement = default;

    void Awake()
    {
        movement = this.GetComponent<UFOMovementScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = startingPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F2))
        {
            movement.MakeEntrance(entrancePos);
        }
        if (Input.GetKeyDown(KeyCode.F3))
        {
            movement.FindNewTrajectory();
            movement.isMoving = !movement.isMoving;
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            FireBullet(player.transform.position);
        }
    }

    public void FireBullet(Vector3 playerPosition)
    {
        Vector3 position = this.gameObject.transform.position;
        GameObject projectile = Instantiate(bullet, position, Quaternion.identity);
        PlayerBulletScript bulletScript = projectile.GetComponent<PlayerBulletScript>();
        bulletScript.SetVelocity(playerPosition, 5);
    }
}
