using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    public const string HORIZONTAL = "Horizontal", VERTICAL = "Vertical";
    private float inputTol = 0.2f;
    private float xInput, yInput;

    private bool IsWalking;
    public Vector2 LastDirection;
    private Animator _animator;

    private Rigidbody2D _rigidbody;

    public static bool playerCreated;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        playerCreated = true;
    }

    void Update()
    {
        xInput = Input.GetAxisRaw(HORIZONTAL);
        yInput = Input.GetAxisRaw(VERTICAL);
        IsWalking = false;


        //HORIZONTAL
        if (Mathf.Abs(xInput) > inputTol)
        {
            _rigidbody.velocity = new Vector2(xInput*speed,0);
            
            //Vector3 translation = new Vector3(xInput * speed * Time.deltaTime, 0, 0);
            //transform.Translate(translation);
            IsWalking = true;
            LastDirection = new Vector2(xInput, 0);
        }

        
        //VERTICAL
        if (Mathf.Abs(yInput) > inputTol)
        {
            _rigidbody.velocity = new Vector2(0, yInput * speed);

            //Vector3 translationY = new Vector3(0, yInput * speed * Time.deltaTime, 0);
            //transform.Translate(translationY);
            IsWalking = true;
            LastDirection = new Vector2(0, yInput);
        }
    }

    private void LateUpdate()
    {
        if (!IsWalking)
        {
            _rigidbody.velocity = Vector2.zero;
        }
        _animator.SetFloat(HORIZONTAL, xInput);
        _animator.SetFloat(VERTICAL, yInput);
        _animator.SetFloat("LastHorizontal", LastDirection.x);
        _animator.SetFloat("LastVertical", LastDirection.y);
        _animator.SetBool("IsWalking", IsWalking);
    }
}
