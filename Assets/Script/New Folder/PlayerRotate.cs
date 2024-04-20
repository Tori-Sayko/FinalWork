using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _rotate;
    [SerializeField] private float _clamX, _clamY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) { _rigidbody.velocity = new Vector3(0, _speed, 0); }
        if (Input.GetKey(KeyCode.W)) { _rigidbody.velocity = new Vector3(0, 0, _speed); }
        if (Input.GetKey(KeyCode.S)) { _rigidbody.velocity = new Vector3(0, 0, -_speed); }
        if (Input.GetKey(KeyCode.A)) { _rigidbody.velocity = new Vector3(-_speed, 0, 0); }
        if (Input.GetKey(KeyCode.D)) { _rigidbody.velocity = new Vector3(_speed, 0, 0); }
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        _rotate += new Vector3(-vertical, horizontal, 0);
        transform.rotation = Quaternion.Euler(_rotate);
        _rotate.x = Mathf.Clamp(_rotate.x, -_clamX, _clamX);
        _rotate.y = Mathf.Clamp(_rotate.y, -_clamY, _clamY);
    }
}
