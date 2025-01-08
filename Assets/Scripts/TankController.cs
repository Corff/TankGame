using Unity.Burst.Intrinsics;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody rb;

    public Camera cam;

    public Vector3 movement;
    public Vector3 mousePos;
    public Vector3 lookPos;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        //mousePos.z = 0;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        movement.y = 0;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
        RotatePlayerAlongMousePosition();
    }
    
    void RotatePlayerAlongMousePosition () {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100)) {
            lookPos = hit.point;
        }

        Vector3 lookDir = lookPos - transform.position;
        lookDir.y = 0;

        transform.LookAt (transform.position + lookDir, Vector3.up);
    }
}
