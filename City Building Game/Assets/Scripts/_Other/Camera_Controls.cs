using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controls : MonoBehaviour {

    public float turn_speed;
    public float speed;
    public float scroll_speed;

    public float max_height;
    public float min_height;

    public GameObject main_camera;

    public Rigidbody rb;

    void FixedUpdate ()
    {

        //Rotates clockwise
        if (Input.GetKey("q") == true){
            transform.Rotate(Vector3.up, turn_speed * Time.deltaTime);}

        //Rotates anti-clockwise
        if (Input.GetKey("e") == true){
            transform.Rotate(Vector3.up, -turn_speed * Time.deltaTime);}

        //Moves right
        if (Input.GetKey("d") == true){
            rb.AddForce(transform.right * speed);}

        //Moves left
        if (Input.GetKey("a") == true){
            rb.AddForce(transform.right * -speed);}

        //Moves forward
        if (Input.GetKey("w") == true){
            rb.AddForce(transform.forward * speed);}

        //Moves backwards
        if (Input.GetKey("s") == true){
            rb.AddForce(transform.forward * -speed);}

        //Adds force in the y-axis direction multiplied by input by the scroll speed and by the variable "scroll_speed".
        rb.AddForce(transform.up * Input.GetAxis("Mouse ScrollWheel") * -scroll_speed);
        //Clamps the y position of the object between the variables "min_height" and "max_height".
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, min_height, max_height), transform.position.z);
        //Makes the x rotation of the camera object stay between the 25 and 75.
        //Has the x rotation change depending on the ration between the actual height and the max_height.
        main_camera.transform.localRotation = Quaternion.Euler(((transform.position.y / max_height) * 45) + 30, 0, 0);

    }

}
