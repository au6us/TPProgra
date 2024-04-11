using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Conexiones")]
    private Rigidbody _rB;
    [SerializeField] private Transform _instancePoin1;
    [SerializeField] private GameObject _bulletPrefab1;
    private Animator _animator;

    [Header("Propiedades player")]
    [SerializeField] private float _xAxis;
    [SerializeField] private float _zAxis;
    private string _xAxisName = "xAxis";
    private string _zAxisName = "zAxis";
    private string _attack1 = "attack1";
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;

    [Header("Propiedades player")]
    [SerializeField] private Vector3 _direction;


    private void Awake()
    {
        _rB = this.GetComponent<Rigidbody>();
        _animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rB.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {
            //Attack1();
            _animator.SetTrigger(_attack1);
        }

        _xAxis = Input.GetAxis("Horizontal");
        _zAxis = Input.GetAxis("Vertical");

        _animator.SetFloat(_xAxisName, _xAxis);
        _animator.SetFloat(_zAxisName, _zAxis);
    }

    private void FixedUpdate()
    {
        if (_xAxis != 0 || _zAxis != 0)
        {
            Movement();
        }
    }

    private void Movement()
    {
        _direction = (this.transform.right * _xAxis + this.transform.forward * _zAxis) * _speed;
        _rB.velocity = new Vector3(_direction.x, _rB.velocity.y, _direction.z);
    }

    private void Attack1()
    {
       Instantiate(_bulletPrefab1, _instancePoin1.position, this.transform.rotation);
    }
}