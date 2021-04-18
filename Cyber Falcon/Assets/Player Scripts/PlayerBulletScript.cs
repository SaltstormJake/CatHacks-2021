using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    float speed = 0;
    [SerializeField] Vector3 direction = default;
    Vector3 target = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        //Vector3 direction = (target - this.transform.position).normalized;
        this.transform.position += (direction * speed);
        if (this.transform.position.z < -10)
            Destroy(this.gameObject);
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Target Range")
        {
            float magnitude = direction.magnitude;
            direction = new Vector3(0, 0, magnitude);
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }*/

    public void SetVelocity(Vector3 _target, float _speed)
    {
        speed = _speed;
        _target = target;
        direction = (target - this.transform.position).normalized;
    }
}
