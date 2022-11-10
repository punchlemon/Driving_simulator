using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0.57f, 1.76f, -0.42f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Offset the camera behind the player by adding to the player's position
        //camera position is player position           + default camera position
        transform.rotation = player.transform.rotation;
        transform.position = player.transform.position + transform.rotation * offset;
    }
}
