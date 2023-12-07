using UnityEngine;
using Cinemachine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public Rigidbody behavior;
	public Camera view;
    public CinemachineVirtualCamera[] views;
    private int currentCameraState = 0;
    public GameObject blast;

    void Update()
    {
        MovementUpdate();
        CameraUpdate();
        if(transform.position.y <= -20)
        {
            FindObjectOfType<GameManager>().Loss();
        }
    }

    void MovementUpdate()
    {
        Vector3 lateralMotion = new Vector3();
        float rotationalMotion = 0;
        lateralMotion.z = Input.GetAxis("Vertical");
        if(Input.GetAxis("Sidestep") > 0.9f)
        {
            lateralMotion.x = Input.GetAxis("Horizontal");
        }
        else
        {
            rotationalMotion = Input.GetAxis("Horizontal") * rotationSpeed;
        }
        lateralMotion = transform.TransformDirection(lateralMotion) * speed;
        lateralMotion.y = behavior.velocity.y;
        behavior.velocity = lateralMotion; 
        behavior.angularVelocity = new Vector3(0, rotationalMotion, 0);
    }

    private bool switchCameraPressed = false;
    void CameraUpdate()
    {
        if(Input.GetAxis("SwitchCamera") > 0.9f && switchCameraPressed == false)
        {
            switchCameraPressed = true;
            views[currentCameraState].enabled = false;
            currentCameraState = (currentCameraState < views.Length - 1) ? currentCameraState + 1 : 0;
            views[currentCameraState].enabled = true;
        }
        else if (Input.GetAxis("SwitchCamera") < 9.0f)
        {
           switchCameraPressed = false;
        }
    }
    public void Detonate()
    {
        Instantiate(blast).transform.position = transform.position;
        Destroy(this.gameObject);
    }
}
