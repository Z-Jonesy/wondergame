using System;
using UnityEngine;

public class CharacterMove : MonoBehaviour {
    public CharacterSettings CharacterSettings;
    public float speed = 10f;
    public float TurnSmoothing = 20f;
    private Rigidbody _rigidbody;
    private Vector3 _movement;
    private Animator _animator;
    private AudioSource _audioSource;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
    }


    private void FixedUpdate()
    {
        var inputVertical = Input.GetAxis("Vertical");
        var inputHorizontal = Input.GetAxis("Horizontal");

        Move(inputHorizontal, inputVertical);
        SetAnimation(inputHorizontal, inputVertical);
        SetAudio(inputHorizontal, inputVertical);
    }

    private void SetAudio(float inputHorizontal, float inputVertical)
    {
        if (isMoving(inputHorizontal, inputVertical))
        {
            if (!_audioSource.isPlaying) _audioSource.Play();
        } else
        {
            if (_audioSource.isPlaying) _audioSource.Stop();
        }
    }

    private bool isMoving(float inputHorizontal, float inputVertical)
    {
        return Math.Abs(inputHorizontal) > 0 || Math.Abs(inputVertical) > 0;
    }

    private void Move(float inputHorizontal, float inputVertical)
    {
        _movement.Set(inputHorizontal, 0, inputVertical);
        _movement = _movement.normalized * speed * Time.deltaTime;
        _rigidbody.MovePosition(transform.position + _movement);

        if (isMoving(inputHorizontal, inputVertical))
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
