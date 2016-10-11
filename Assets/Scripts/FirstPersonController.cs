using UnityEngine;
using System.Collections;

public class FirstPersonController : MonoBehaviour {

    CharacterController cc;

    public float movementSpeed = 10f;
    public float mouseSense = 5f;

    private float verticalRotation = 0f;
    public float verticalRange = 60f;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {

        //Rotation
        float rotLeftRight = Input.GetAxis("Mouse X") * mouseSense;
        transform.Rotate(0, rotLeftRight, 0);

        float rotUpDown = Input.GetAxis("Mouse Y") * mouseSense;

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSense;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalRange, verticalRange);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //Movement
        float forwardSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float sideSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 speed = new Vector3(sideSpeed, 0, forwardSpeed);
        speed = transform.rotation * speed;

        cc.SimpleMove(speed);
	}
}
