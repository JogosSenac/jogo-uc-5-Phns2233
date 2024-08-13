using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VidaS : MonoBehaviour
{
    public GameObject player;
    public float px;
    public float py;
    public Vector3 posInincial;
    // Start is called before the first frame update
    void Start()
    {
        posInincial = transform.position;
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            px = player.transform.position.x;
            py = player.transform.position.y;
        }
        if(px > -1000 && py > -1000)
        {
            transform.position = new Vector3(px, py, -1);
        }
        if(player ==null)
        {
             player = GameObject.FindWithTag("Player");
             transform.position = posInincial;

        }
    }

}
