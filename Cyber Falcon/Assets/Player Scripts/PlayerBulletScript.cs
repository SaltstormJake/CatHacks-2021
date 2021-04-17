using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{
    float speed = 0;
    [SerializeField] Vector3 direction = default;

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
        if(this.transform.position.z > 20.0f)
        {
            float magnitude = direction.magnitude;
            direction = new Vector3(0, 0, magnitude);
            this.transform.eulerAngles = new Vector3(0, 0, 0);
        }
        this.transform.Translate(direction * speed);
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

    public void SetVelocity(GameObject origin, GameObject target, float _speed)
    {
        Debug.Log(Camera.main.ViewportToWorldPoint(target.transform.position));
        direction = Camera.main.ViewportToWorldPoint(target.transform.position) - origin.transform.forward;
        speed = _speed;
    }
}
