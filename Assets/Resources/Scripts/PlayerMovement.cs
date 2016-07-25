using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public int _speed = 10;
    public GameObject fpsCamera;

    public float xAimSensitivity = 300;
    //public float yAimSensitivity = 300;

    public bool cursorToggle = false;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        Debug_ToggleCursor();

        Look();
        Move();
	}
    
    //Aim Camera
    void Look () {
        float camXRotation = xAimSensitivity * Input.GetAxis("Mouse X") * Time.deltaTime;
        //float camYRotation = -yAimSensitivity * Input.GetAxis("Mouse Y") * Time.deltaTime;

        fpsCamera.transform.localEulerAngles += new Vector3(0, camXRotation, 0);
    }

    //WASD Move
    void Move () {
        Vector3 groundedCameraForward = new Vector3(fpsCamera.transform.forward.x, 0, fpsCamera.transform.forward.z);
        Vector3 wsMovement = Input.GetAxisRaw("Vertical") * groundedCameraForward.normalized * _speed * Time.deltaTime;
        Vector3 adMovement = Input.GetAxisRaw("Horizontal") * fpsCamera.transform.right * _speed * Time.deltaTime;

        transform.localPosition += wsMovement;
        transform.localPosition += adMovement;
    }

    void Debug_ToggleCursor () {
        //Toggle Cursor
        if (!cursorToggle && Input.GetKeyDown(KeyCode.LeftAlt)) {
            cursorToggle = true;
        }else if (cursorToggle && Input.GetKeyDown(KeyCode.LeftAlt)) {
            cursorToggle = false;
        }

        if (cursorToggle) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }else {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
