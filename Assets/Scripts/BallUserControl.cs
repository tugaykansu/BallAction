using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

//namespace UnityStandardAssets.Vehicles.Ball

    public class BallUserControl : MonoBehaviour
    {
        private Ball ball; // Reference to the ball controller.

        private Vector3 move;
        // the world-relative desired move direction, calculated from the camForward and user input.

        private Transform cam; // A reference to the main camera in the scenes transform
        private Vector3 camForward; // The current forward direction of the camera
        
        [SerializeField] private float planeY = 0;

        private Vector3 previousMousePos;


        private void Awake()
        {
            // Set up the reference.
            ball = GetComponent<Ball>();


            // get the transform of the main camera
            if (Camera.main != null)
            {
                cam = Camera.main.transform;
            }
            else
            {
                Debug.LogWarning(
                    "Warning: no main camera found. Ball needs a Camera tagged \"MainCamera\", for camera-relative controls.");
                // we use world-relative controls in this case, which may not be what the user wants, but hey, we warned them!
            }
            
            previousMousePos = Vector3.zero;
        }

        
        // untested
        
        private void Update()
        {
            Debug.Log(Input.mousePosition - previousMousePos);

            move = Input.mousePosition - previousMousePos;
            move = new Vector3(move.y, 0 ,-move.x);
            
            previousMousePos = Input.mousePosition;
        } 
        
        // old update to follow pointer
        /*
        private void Update()
        {
            Plane plane = new Plane(Vector3.up,new Vector3(0, planeY, 0));
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float distance;
            if(plane.Raycast(ray, out distance)) {
                move = ray.GetPoint(distance);
            }
            move = Vector3.Cross(transform.position - move, Vector3.up);
        }*/

        // old update for keyboard input
        /*private void Update()
        {
            // Get the axis and jump input.

            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            // calculate move direction
            if (cam != null)
            {
                // calculate camera relative direction to move:
                camForward = Vector3.Scale(cam.forward, new Vector3(1, 0, 1)).normalized;
                move = (v*camForward + h*cam.right).normalized;
            }
            else
            {
                // we use world-relative directions in the case of no main camera
                move = (v*Vector3.forward + h*Vector3.right).normalized;
            }
        }*/


        private void FixedUpdate()
        {
            // Call the Move function of the ball controller
            ball.Move(move);
        }
    }

