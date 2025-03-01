using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1f;
    private Rigidbody2D _rd2d;
    private Transform _playerTransform;
    public bool stopped = false;
    [SerializeField]
    private GameObject _creabDead;

    public event Action OnDie = null;

    // Start is called before the first frame update
    void Start()
    {
        _rd2d = GetComponent<Rigidbody2D>();
        Player player = FindObjectOfType<Player>();
        if (player != null)
        {
            _playerTransform = player.transform;
        }
        else
        {
            stopped = true;
        }
    }

    
    void Update()
    {
        Move(); 
    }

    private void Move()
    {
        if (stopped || _playerTransform == null)
        {
            _rd2d.velocity = Vector3.zero;
            return;
        }
        Vector3 directionToPlayer = _playerTransform.position - transform.position;
        _rd2d.velocity = directionToPlayer.normalized * _speed;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Weapon"))
        {
            Vector3 spawnPosition = transform.position;
            Instantiate(_creabDead, spawnPosition, Quaternion.identity);
            Destroy(gameObject);
            if(OnDie != null)
            {
                OnDie();
            }
        }
    }
}
