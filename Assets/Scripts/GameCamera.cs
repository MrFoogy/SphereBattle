using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCamera : MonoBehaviour {
    private Vector3 direction = Vector3.forward;
    public float distance = 10f;
    public float rotSpeed = 100f;
    private static float MIN_VERTICAL_ANGLE = 60f;
    private static float MAX_VERTICAL_ANGLE = -60f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.A))
        {
            RotateCamera(-Time.deltaTime * rotSpeed, 0f); 
        }		
        if (Input.GetKey(KeyCode.D))
        {
            RotateCamera(Time.deltaTime * rotSpeed, 0f); 
        }		
        if (Input.GetKey(KeyCode.W))
        {
            RotateCamera(0f, Time.deltaTime * rotSpeed); 
        }		
        if (Input.GetKey(KeyCode.S))
        {
            RotateCamera(0f, -Time.deltaTime * rotSpeed); 
        }
        UpdateTransform();
	}

    void RotateCamera(float xRot, float yRot)
    {
        Vector3 groundProjection = Vector3.ProjectOnPlane(direction, Vector3.up).normalized;
        float groundAngle = Vector3.Angle(groundProjection, direction);
        float sGroundAngle = Vector3.SignedAngle(groundProjection, direction, transform.right);

        float yRotSpeedFactor;
        float prog;
        if (yRot < 0) {
            prog = 1f - (Mathf.Abs(Mathf.Min(0f, sGroundAngle)) / (MAX_VERTICAL_ANGLE * -1.2f));
        } else
        {
            prog = 1f - (Mathf.Abs(Mathf.Max(0f, sGroundAngle)) / (MAX_VERTICAL_ANGLE * -1.2f));
        }
        yRotSpeedFactor = Mathf.SmoothStep(0f, 1f, prog);
        Debug.Log("Prog: " + prog);
        direction = Quaternion.AngleAxis(xRot, Vector3.up) * direction;
        direction = Quaternion.AngleAxis(yRot * yRotSpeedFactor, transform.right) * direction;

        // Limit the vertical rotation of the camera
        groundProjection = Vector3.ProjectOnPlane(direction, Vector3.up).normalized;
        groundAngle = Vector3.Angle(groundProjection, direction);
        
        // Limit vertical rotation
        if (direction.y > 0 && groundAngle > MIN_VERTICAL_ANGLE) {
            direction = Quaternion.AngleAxis(MIN_VERTICAL_ANGLE, Vector3.Cross(direction, Vector3.up)) * groundProjection;
        } else if (direction.y < 0 && -groundAngle < MAX_VERTICAL_ANGLE) {
            direction = Quaternion.AngleAxis(MAX_VERTICAL_ANGLE, Vector3.Cross(direction, Vector3.up)) * groundProjection;
        }
    }

    void UpdateTransform()
    {
        transform.position = -direction * distance;
        transform.rotation = Quaternion.LookRotation(direction);
    }
}
