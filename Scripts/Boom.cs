using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DestroyBoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyBoom()
    {
        Destroy(gameObject, 1f);
        }

}
