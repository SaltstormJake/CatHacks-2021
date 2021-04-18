using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBarrelRollScript : MonoBehaviour
{
    public bool isRolling = false;
    bool canRoll = true;
    float spinRate = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1) && canRoll)
        {
           StartCoroutine(Roll());
        }
    }

    IEnumerator Roll()
    {
        isRolling = true;
        canRoll = false;

        Vector3 original = this.transform.eulerAngles;
        float spinFund = 360 * 2;

        while (spinFund > 0)
        {
            Vector3 newAngle = this.transform.eulerAngles;
            float spin = Time.deltaTime * spinRate;
            newAngle.z += spin;
            spinFund -= spin;
            //Debug.Log(spinFund);
            this.transform.eulerAngles = newAngle;
            yield return null;
        }

        this.transform.eulerAngles = original;

        isRolling = false;
        Invoke("CanRollAgain", 1.0f);
    }

    void CanRollAgain()
    {
        canRoll = true;
    }


}
