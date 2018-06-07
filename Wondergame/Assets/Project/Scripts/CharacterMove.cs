using System;
using UnityEngine;

public class CharacterMove : MonoBehaviour {
    public CharacterSettings CharacterSettings;
    public float speed = 10f;
    public float TurnSmoothing = 20f;
    private Rigidbody _rigidbody;
    private Vector3 _movement;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }


	// Use this for initialization
	private void Start () {
		
	}
	
	// Update is called once per frame
	private void Update () {
		
	}

    private void FixedUpdate()
    {
        var inputVertical = Input.GetAxis("Vertical");
        var inputHorizontal = Input.GetAxis("Horizontal");

        Move(inputHorizontal, inputVertical);
        SetAnimation(inputHorizontal, inputVertical);
    }

    private void Move(float inputHorizontal, float inputVertical)
    {
        _movement.Set(inputHorizontal, 0, inputVertical);
        _movement = _movement.normalized * speed * Time.deltaTime;
        _rigidbody.MovePosition(transform.position + _movement);

        if (inputHorizontal != 0 || inputVertical !=0)
        {
            Rotate(inputHorizontal, inputVertical);
        }
    }

    private void Rotate(float inputHorizontal, float inputVertical)
    {
        var targetDirection = new Vector3(inputHorizontal, 0, inputVertical);
        var targetRotation = Quaternion.LookRotation(targetDirection, Vector3.up);
        var newRotation = Quaternion. Lerp(_rigidbody.rotation, targetRotation, Time.deltaTime * TurnSmoothing);
        _rigidbody.MoveRotation(newRotation); 
    }

    private void SetAnimation(float inputHorizontal, float inputVertical)
    {
        var isRunning = inputHorizontal != 0 || inputVertical != 0;
        _animator.SetBool("IsRunning", isRunning);
    }

    
}
