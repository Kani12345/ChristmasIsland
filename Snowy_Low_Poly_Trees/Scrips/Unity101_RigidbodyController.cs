using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Unity101_RigidbodyController : MonoBehaviour
{

    public float Speed = 5f;
    private float _defaultSpeed;
    public float JumpHeight = 2f;
    public float GroundDistance = 0.5f;
    public float RunSpeedCoef = 2f;
    public LayerMask Ground;
    public Transform GroundChecker;

    private Rigidbody _body;
    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded = true;
    private bool _allCollected = false;
    private Animator _anim;
   
    private static Unity101_RigidbodyController _instance;
    




    public static Unity101_RigidbodyController Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Player is null");
            }
            return Instance;
        }
    }

    void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        _body = GetComponent<Rigidbody>();
        _anim = GetComponent<Animator>();

        _defaultSpeed = Speed;
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(GroundChecker.position, GroundDistance, Ground, QueryTriggerInteraction.Ignore);


        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");
        _allCollected = (CollectibleCount.count == Collectible.total);

        //Movements
        if (_inputs == Vector3.zero)
        {
            _anim.SetBool("isWalking", false);
            _anim.SetBool("isRunning", false);
        }
        else
        {
            _anim.SetBool("isWalking", true);
        }
        // Jumping
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _body.AddForce(Vector3.up * Mathf.Sqrt(JumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
            _anim.SetTrigger("Jump");
        }
        // Running
        if (Input.GetKeyDown(KeyCode.LeftShift) && _isGrounded)
        {
            Speed *= RunSpeedCoef;
            if (_inputs != Vector3.zero)
            {
                _anim.SetBool("isRunning", true);
            }
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Speed = _defaultSpeed;
            _anim.SetBool("isRunning", false);

        }
        
    }


    void FixedUpdate()
    {
        MovePlayer(_inputs);
    }

    private void MovePlayer(Vector3 direction)
    {
        direction = _body.rotation * direction;
        if (_allCollected)
        {
        }

        else
        {

           _body.MovePosition(_body.position + direction * Speed * Time.fixedDeltaTime);
        }
    }

   
}
