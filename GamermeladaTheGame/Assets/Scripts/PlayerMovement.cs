using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Components "attached"
    public GameObject Mesh = null;
    public GameObject Particles = null;
    public GameObject ParentParticles = null;
    public GameObject Explosion = null;
    public GameObject ParticleCamera = null;
    public GameObject ChestIndicator = null;
    public CameraMovement CameraMovement = null;


    private Vector3 MeshInitialOffset;
    private Vector3 ParticlesInitialOffset;
    private Vector3 ExplosionInitialOffset;
    private Vector3 ParticleCameraInitialOffset;
    private Vector3 ChestIndicatorInitialOffset;

    PlayerInput OwnerInput = null;

    // Forward movement variables
    public float AccelerationForce = 0.0f;
    public float MaxSpeed = 0.0f;

    private Rigidbody OwnerRB = null;

    public float RotationRate = 1.0f;
    public float MaxRotationSpeed = 2.0f;

    // Air movement variables
    public GameObject WaterPlane = null;
    public float GravityForce = 1.0f;
    public float BouyancyForce = 1.0f;
    public int MaxBounces = 3;
    public float MaxSpeedY = 50.0f;

    private float PlaneInitialOffsetY;
    private bool InAir = false;
    private bool InWater = false;
    private int Bounces = 0;

    //Ramp Variables
    public float RampBoostForce = 1.0f;
    [HideInInspector]
    public bool InRamp = false;

    //Explosion variables
    Vector3 InitialPos;
    Quaternion InitialRot;

    void Start()
    {
        InitialPos = transform.position;
        InitialRot = transform.rotation;

        MeshInitialOffset = Mesh.transform.position - transform.position;
        ParticlesInitialOffset = Particles.transform.position - transform.position;
        ExplosionInitialOffset = Explosion.transform.position - transform.position;
        ParticleCameraInitialOffset = ParticleCamera.transform.position - transform.position;

        ChestIndicatorInitialOffset = ChestIndicator.transform.position - transform.position;

        PlaneInitialOffsetY = WaterPlane.transform.position.y - transform.position.y;

        OwnerRB = GetComponent<Rigidbody>();
        OwnerInput = GetComponent<PlayerInput>();
    }

    void UpdateChildTransfrom()
    {
        Mesh.transform.position = transform.position + MeshInitialOffset;
        
        if(!InRamp)
        {
            Mesh.transform.eulerAngles = new Vector3(Mesh.transform.eulerAngles.x, transform.eulerAngles.y + 180.0f, Mesh.transform.eulerAngles.z);
        }

        ParticleCamera.transform.position = transform.position + ParticleCameraInitialOffset;
        ParticleCamera.transform.rotation = transform.rotation;

        ParentParticles.transform.position = new Vector3(Mesh.transform.position.x, 110.0f, Mesh.transform.position.z);
        Explosion.transform.position = transform.position + ExplosionInitialOffset;
        ChestIndicator.transform.position = transform.position + ChestIndicatorInitialOffset;
    }

    void ForwardMovement()
    {
        Vector3 Direction = -Mesh.transform.forward;
        Vector3 DirectionXZ = new Vector3(Direction.x, 0.0f, Direction.z);

        Vector3 VelocityXZ = new Vector3(OwnerRB.velocity.x, 0.0f, OwnerRB.velocity.z);
        float CurrentSpeed = Vector3.SqrMagnitude(VelocityXZ);

        if (CurrentSpeed < MaxSpeed * MaxSpeed)
        {
            OwnerRB.AddForce(DirectionXZ * AccelerationForce);
        }
        else if (CurrentSpeed > MaxSpeed * MaxSpeed)
        {
            OwnerRB.AddForce(-VelocityXZ.normalized * AccelerationForce);
        }
    }

    void DirectionControl()
    {
        bool RightKeyDown = OwnerInput.Right;
        bool LeftKeyDown = OwnerInput.Left;

        if (RightKeyDown && LeftKeyDown){}
        else if(RightKeyDown)
        {
            OwnerRB.AddTorque(Vector3.down * RotationRate);
        }
        else if(LeftKeyDown)
        {
            OwnerRB.AddTorque(Vector3.up * RotationRate);
        }
        else
        {
            OwnerRB.AddTorque(-OwnerRB.angularVelocity * (1.0f / RotationRate));
        }

        OwnerRB.angularVelocity = new Vector3(OwnerRB.angularVelocity.x, Mathf.Clamp(OwnerRB.angularVelocity.y, -MaxRotationSpeed, MaxRotationSpeed), OwnerRB.angularVelocity.z);
    }

    void AirControl()
    {
        float PlaneOffsetY = WaterPlane.transform.position.y - transform.position.y;

        if (PlaneOffsetY > PlaneInitialOffsetY)
        {
            InWater = true;

            if(InAir)
                Bounces++;
        }
        else
            InWater = false;

        if (PlaneOffsetY < PlaneInitialOffsetY)
            InAir = true;
        else
            InAir = false;

        float DistanceToPlaneY = Mathf.Abs(PlaneOffsetY - PlaneInitialOffsetY);

        if (InAir)
            OwnerRB.AddForce(Vector3.down * GravityForce * DistanceToPlaneY);

        if(InWater)
        {
            if(Bounces < MaxBounces)
            {
                OwnerRB.AddForce(Vector3.up * BouyancyForce * DistanceToPlaneY);

                float CurrentMaxY = Mathf.Lerp(MaxSpeedY, MaxSpeedY / 2.5f, Bounces / MaxBounces);
                OwnerRB.velocity = new Vector3(OwnerRB.velocity.x, Mathf.Clamp(OwnerRB.velocity.y, -CurrentMaxY, CurrentMaxY), OwnerRB.velocity.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, WaterPlane.transform.position.y - PlaneInitialOffsetY, transform.position.z);
                OwnerRB.velocity = new Vector3(OwnerRB.velocity.x, 0.0f, OwnerRB.velocity.z);
                Bounces = 0;
            }
        }
    }

    void NotInRamp()
    {
        InRamp = false;
        OwnerRB.angularVelocity = Vector3.zero;
        OwnerRB.constraints = RigidbodyConstraints.None;

        if(!InWater)
            transform.forward = new Vector3(OwnerRB.velocity.x, 0.0f, OwnerRB.velocity.z);
    }

    void ReactivateParticles()
    {
        Particles.SetActive(true);
    }

    void Exploded()
    {
        transform.position = InitialPos;
        transform.rotation = InitialRot;
        Mesh.SetActive(true);
        GetComponent<SphereCollider>().enabled = true;
        GetComponent<Rigidbody>().isKinematic = false;

        Invoke("ReactivateParticles", 0.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 9)
        {
            Explosion.GetComponent<Explosion>().Play();
            Mesh.SetActive(false);
            Particles.SetActive(false);
            GetComponent<SphereCollider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;

            Invoke("Exploded", 2.5f);

            return;
        }

        if (!InRamp)
        {
            InRamp = true;
            OwnerRB.angularVelocity = Vector3.zero;
            OwnerRB.constraints = RigidbodyConstraints.FreezeRotationY;

            if(!InWater)
                OwnerRB.velocity = -Mesh.transform.forward * RampBoostForce;
        }
        else
        {
            CancelInvoke("NotInRamp");
        }

        if (!InWater)
            Bounces = 0;
    }

    private void OnCollisionExit(Collision collision)
    {
        Invoke("NotInRamp", 0.15f);
    }

    void Update()
    {
        if (Equals(PauseMenu.game_timescale, 0.0f))
            return;

        UpdateChildTransfrom();
        DirectionControl();
        AirControl();

        if (!InRamp)
        {
            ForwardMovement();
        }
    }
}
