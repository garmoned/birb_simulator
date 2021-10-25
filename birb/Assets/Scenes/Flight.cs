using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flight : MonoBehaviour
{

    float velocity = 0.0f;
    float accel = -0.1f;

    public GameObject camera;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        camera.transform.Translate(new Vector3(0, velocity, 0));
        velocity += accel;
    }
}