using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReticlePositionScript : MonoBehaviour
{
    [SerializeField] GameObject ship = default;
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
        Vector3 forward = ship.transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        if (Physics.Raycast(ship.transform.position, forward, out hit, Mathf.Infinity, 1 << 7))
        {
            Vector3 pos = hit.point;
            pos.z -= 5.0f;
            this.transform.position = pos;
        }
       // Vector3 aimPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
       // this.transform.position = aimPoint;
    }
}
