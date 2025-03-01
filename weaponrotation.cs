
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponrotation : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D _rb2d;
    [SerializeField]
    private float _speed = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb2d.MoveRotation(_rb2d.rotation + _speed * Time.fixedDeltaTime);
    }


}
