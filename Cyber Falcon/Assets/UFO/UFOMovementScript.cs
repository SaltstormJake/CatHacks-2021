using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMovementScript : MonoBehaviour
{
    [SerializeField] float health = 100.0f;
    [SerializeField] float speed = 1.0f;
    [SerializeField] float upperXBound = 5.0f;
    [SerializeField] float lowerXBound = -5.0f;
    [SerializeField] float upperYBound = 5.0f;
    [SerializeField] float lowerYBound = 5.0f;
    Vector2 trajectory = default;
    public bool isMoving = false;
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
        if (isMoving)
        {
            Vector3 position = this.transform.position;
            position.x += trajectory.x;
            position.y += trajectory.y;
            this.transform.position = position;
            if (this.transform.position.x < lowerXBound)
                BounceLeft();
            else if (this.transform.position.x > upperXBound)
                BounceRight();
            else if (this.transform.position.y < lowerYBound)
                BounceBottom();
            else if (this.transform.position.y > upperYBound)
                BounceTop();
        }
    }

    public void FindNewTrajectory()
    {
        float xProportion = Random.value;
        int xDir = Random.Range(0, 2);
        if (xDir == 0)
            xDir = -1;
        int yDir = Random.Range(0, 2);
        if (yDir == 0)
            yDir = -1;
        trajectory = new Vector2(xProportion * speed * xDir, (1 - xProportion) * speed * yDir);
    }

    public void Spin()
    {
        //TODO
    }

    public void MakeEntrance(Vector3 destination)
    {
        StartCoroutine(_MakeEntrance(destination));
    }

    IEnumerator _MakeEntrance(Vector3 destination)
    {
        while(Vector3.Distance(this.transform.position, destination) > 0.1f)
        {
            Vector3 direction = (destination - this.transform.position).normalized;
            //this.transform.Translate(destination * Time.deltaTime * speed);
            this.transform.position += (direction * Time.deltaTime * speed * 50);
            yield return null;
        }
        this.transform.position = destination;
    }

    void BounceLeft()
    {
        FindNewTrajectory();
        if (trajectory.x < 0)
            trajectory.x *= -1;
    }

    void BounceRight()
    {
        FindNewTrajectory();
        if (trajectory.x > 0)
            trajectory.x *= -1;
    }

    void BounceTop()
    {
        FindNewTrajectory();
        if (trajectory.y > 0)
            trajectory.y *= -1;
    }

    void BounceBottom()
    {
        FindNewTrajectory();
        if (trajectory.y < 0)
            trajectory.y *= -1;
    }
}
