using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        // distance bewteen camera transform posoition and the player's
        offset = transform.position - player.transform.position;
    }

    // LateUpdate is called once per frame
    void LateUpdate() // used for follow cameras, procedural animation and gathering last known states
    {
        // in this case before the system updates it knows the player has moved and then updates

        // make the camera follow with the player
        transform.position = player.transform.position + offset;
    }
}
