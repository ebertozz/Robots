using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{

    public GameObject player; // create reference to the player object and slot in inspector
    public Vector3 offset;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //actually the move the camera - after any other actions are done
        transform.position = player.transform.position + 0.4f * offset;
    }
}
