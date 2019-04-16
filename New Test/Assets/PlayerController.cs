using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public LayerMask movementMask;
    public Camera cam;
    PlayerMotor motor;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                Debug.Log("hit " + hit.collider.name + " " + hit.point);
                motor.MoveToPoint(hit.point);
                // Move to place



                // stop focusing object
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, movementMask))
            {
                // Check if hit interactable and set as focus
            }
        }
    }
}
