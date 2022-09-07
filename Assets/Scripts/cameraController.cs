using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public GameObject player;
    public float initialX;
    public float initialY;
    public float initialZ;
    // Start is called before the first frame update
    void Start()
    {
        initialX = this.gameObject.transform.position.x;
        initialY = this.gameObject.transform.position.y;
        initialZ = this.gameObject.transform.position.z;
        player = GameObject.Find("Player");     
    }

    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.position = new Vector3(player.transform.position.x + initialX, player.transform.position.y + initialY, player.transform.position.z + initialZ);
    }
}
