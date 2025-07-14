using UnityEngine;

public class PlayerControl : MonoBehaviour

{
    //wheelCollider
    public WheelCollider wheelFL, wheelFR, wheelBL, wheelBR;

    //wheelMesh
    public Transform wheelMeshFL, wheelMeshFR, wheelMeshBL, wheelMeshBR;

    //basic speed
    public float motorForce= 100.0f;//前进的基本速度
    public float maxSteerAngle = 30.0f; //转弯的基本速度

    //input
    public float horizontalInput ;
    public float verticalInput;




    void Update()
    {
        //player can control the vechile to move;
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }



    private void FixedUpdate()
    {
   
    
    //tires
    //back tires
    float motor = verticalInput * motorForce;
          //front tires
        float steerAngle = horizontalInput * maxSteerAngle ;

        //front wheel steering
        wheelFL.steerAngle = steerAngle;
        wheelFR.steerAngle = steerAngle;
        //wheel motoring
        wheelBL.motorTorque = motor;
        wheelBR.motorTorque = motor;

        //Visually Update wheelMesh rotation and status
        UpdateWheels(wheelFL, wheelMeshFL);
        UpdateWheels(wheelFR, wheelMeshFR);
        UpdateWheels(wheelBR, wheelMeshBR);
        UpdateWheels(wheelBL, wheelMeshBL);

    }

    void UpdateWheels(WheelCollider collider, Transform wheelMesh)
    {
        Vector3 pos;
        Quaternion qua;
        collider.GetWorldPose(out pos, out qua); //getworldpose give true location and rotation of the wheel

        wheelMesh.position = pos;
        wheelMesh.rotation = qua; 
    }

}
