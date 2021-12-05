using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Flight : MonoBehaviour
{


    public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public Animator birdAnim;

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
    public float originalDrag = 0.4f;

    public float forwardSpeed = 30;

    public bool alive = true;

    public Canvas hud;

    public Collider col;

    public Vector3 jump_vector = new Vector3(0, 10, 3);
    // Start is called before the first frame update
    void Start()
    {
        originalDrag = this.player_body.drag;
        hud.enabled = false;
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(player_body.velocity.magnitude > 100)
        {
            Debug.Log("You Died");

            if (alive)
            {
                Debug.Log(player_body.velocity.magnitude);
            }


            player_body.AddTorque(new Vector3(1500, 1500, 1500));

            FindObjectOfType<SoundEffects>().DeathSound();

            alive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {


        if (!alive)
        {
            hud.enabled = true;

            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

            return;
        }


        //flys toward the pointing direction
        if (Input.GetKeyDown(KeyCode.Space))
        {

            player_body.AddForce(new Vector3(this.transform.forward.x * 500 , this.transform.forward.y * 500 , this.transform.forward.z * 500), ForceMode.Impulse);
            birdAnim.SetTrigger("Flap");
        }
        

        //for gliding with simulated thrust
        if (Input.GetKey(KeyCode.F))
        {


            float f = Vector3.Magnitude(new Vector3(player_body.velocity.x, 0, player_body.velocity.z));

            Vector3 lift = new Vector3(0, f * (Physics.gravity.y * -0.025f), 0);


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
