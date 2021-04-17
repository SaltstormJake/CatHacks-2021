using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlShipScript : MonoBehaviour
{
    float farDistance = 20.0f;
    [SerializeField] float speed = 1.0f;
    [SerializeField] GameObject reticle = default;
    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TurnShip();
        MoveShip();
    }

    public void TurnShip()
    {
        Vector3 aimPoint = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, farDistance));
        //Vector3 aimPoint = new Vector3(reticle.transform.position.x, reticle.transform.position.y, farDistance);
        this.transform.LookAt(aimPoint);
    }

    private void MoveShip()
    {
        transform.position += new Vector3(transform.forward.x, transform.forward.y, 0) * Time.deltaTime * speed;
        Vector3 finalPosition = new Vector3(Mathf.Clamp(transform.position.x, -6, 6), Mathf.Clamp(transform.position.y, -5, 5), 0);
        transform.position = finalPosition;
    }
}
