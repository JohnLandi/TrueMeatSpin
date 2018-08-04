using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    //movespeed for character float
    public float moveSpeed;

    private float vertTranslation;
    private float horiTranslation;

    private float rx;
    private float ry;
    private float angle;
    public float rotationSpeed;

    private Rigidbody2D rb2D;

    // Use this for initialization
    void Start () {
        rb2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void FixedUpdate() {

        vertTranslation = Input.GetAxis("Vertical") * moveSpeed;
        horiTranslation = Input.GetAxis("Horizontal") * moveSpeed;

        // Make it move 10 meters per second instead of 10 meters per frame...
        vertTranslation *= Time.deltaTime;
        horiTranslation *= Time.deltaTime;



        // Move translation along the object's z-axis
        //transform.Translate(horiTranslation, vertTranslation, 0, Space.World);


        rb2D.AddForce(new Vector2(horiTranslation, vertTranslation ) * moveSpeed);

        rx = Input.GetAxis("Horizontal2");
        ry = Input.GetAxis("Vertical2");

        float angle = Mathf.Atan2(-rx, ry) * Mathf.Rad2Deg;

        Debug.Log(angle);


        if (rx != 0 || ry != 0)
            rb2D.MoveRotation(angle);

        /* float angle = Mathf.Atan2(-rx, ry);

         if (rx != 0 || ry != 0)
         {
             //rb2D.AddTorque(

             transform.rotation = Quaternion.EulerAngles(0, 0, angle);
         }

     */

    }
}
