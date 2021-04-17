using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorRotationScript : MonoBehaviour
{
    Material material = default;
    [SerializeField] float scrollSpeed = 1.0f;
    void Awake()
    {
        material = this.GetComponent<Renderer>().material;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = material.mainTextureOffset;
        offset.y -= Time.deltaTime * scrollSpeed;
        material.mainTextureOffset = offset;
    }
}
