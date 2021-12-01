using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform player;

    public Vector3 offSet = new Vector3(11, 5.4f, -0.2f);

    private void LateUpdate()
    {
        
        this.transform.rotation = player.rotation;
       // this.transform.position = player.position + offSet;

    }

}


