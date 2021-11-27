using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Flight : MonoBehaviour
{


    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;

    public float minimumY = -60F;
    public float maximumY = 60F;

    float rotationY = 0F;

    float velocity = 0.0f;
    float accel = -0.1f;

    public Rigidbody player_body;
    public float jumpForce;
    public float speed = 5;

    public float originalMass = 7;
    public float originalDrag = 10;

    public Vector3 jump_vector = new Vector3(0, 10, 3);
    // Start is called before the first frame update
    void Start()
    {
        originalDrag = this.player_body.drag;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {

            player_body.velocity = (new Vector3(this.transform.forward.x * 3.0f, 10, this.transform.forward.z * 3.0f));
        }
        else if (Input.GetKey(KeyCode.Space))
        {


            float f = Vector3.Magnitude(Vector3.Project(player_body.velocity, transform.forward));

            Vector3 lift = new Vector3(0, f * (Physics.gravity.y * -0.5f), 0);


            Debug.Log(lift + "lift");

            this.player_body.AddForce(lift);

        }


        if (axes == RotationAxes.MouseXAndY)
        {
            float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;

            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
        }
        else if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
        }
        else
        {
            rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
            rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

            transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
        }
        transform.Rotate(new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0) * Time.deltaTime * speed);
    }
}
