using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clouds : MonoBehaviour
{
    [SerializeField]
    private Transform[] _clouds = new Transform[6];
    [SerializeField]
    private float _speed = 1.0f;

    [SerializeField]
    private float _XLimit = 12.5f;

    // Start is called before the first frame update
    void Start()
    {
       // Debug.Log("cloud at index 0" + _clouds[0]);
       // Debug.Log("cloud at index" + _clouds.Length + _clouds[^1]);
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _clouds.Length; i++)
        {
            _clouds[i].position = _clouds[i].position + Vector3.right * Time.deltaTime;

            if (_clouds[i].position.x > _XLimit)
            {
                _clouds[i].position -= new Vector3(2 * _XLimit, 0, 0);

            }
        }
    }
}
    

