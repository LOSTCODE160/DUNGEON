using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
   // [SerializeField]
    //private string _horizontalAxis = "Horizontal", _verticalAxis = "Vertical";
    [SerializeField]
    private Rigidbody2D _rb2d ;
    private Vector2 _input;
    [SerializeField]
    private float _speed = 3.0f;

    public UnityEvent OnPlayerDie;
    
    private void FixedUpdate()
    {
        _rb2d.velocity = _input*_speed;
    }
    void Update()
    {
        float HorizontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Vertical");
        _input= new Vector2(HorizontalInput, VerticalInput);
        _input.Normalize(); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(OnPlayerDie != null)
        {
             OnPlayerDie.Invoke();
        }

        Destroy(gameObject);
    }
}
