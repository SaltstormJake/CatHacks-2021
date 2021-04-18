using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHealthScript : MonoBehaviour
{
    [SerializeField] Image healthBar = default;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject);
            Vector2 size = healthBar.rectTransform.sizeDelta;
            size.x -= 33;
            healthBar.rectTransform.sizeDelta = size;
            Debug.Log("Hit");
        }
    }
}
