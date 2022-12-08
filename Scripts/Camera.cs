using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private Transform player;

    private Vector3 followPlayer;

   [SerializeField]
   private float minX, maxX;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        followPlayer = transform.position;
        followPlayer.x = player.position.x;

        if (followPlayer.x < minX)
            followPlayer.x = minX;

        if (followPlayer.x > maxX)
            followPlayer.x = maxX;

        transform.position = followPlayer;
    }
}
