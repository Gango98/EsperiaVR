using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    public Transform vrCamera;
    public float speed = 3.0f;
    public float angoloMin = 30.0f;
    public float angoloMax = 60.0f;
    private CharacterController cc;
    private bool moveForward;

	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
	}

    // Update is called once per frame
    void Update() {

        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        if (v != 0 || h != 0)
            cc.SimpleMove(((vrCamera.forward * v) + (vrCamera.right * h)) * speed);
        else {
            if (vrCamera.eulerAngles.x >= angoloMin && vrCamera.eulerAngles.x < angoloMax)
                moveForward = true;
            else
                moveForward = false;

            if (moveForward)
                cc.SimpleMove(vrCamera.forward * speed);
        }
    }
}
