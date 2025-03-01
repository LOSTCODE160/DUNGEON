using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    [SerializeField]
    private int rotationSpeed = 200; 
    [SerializeField]
    private Vector3 RotationTime = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float rotationAmount = CalculationRotationAmount(Time.deltaTime);
        transform.RotateAround(RotationTime, Vector3.forward, rotationAmount);
        return;
    }

    private float CalculationRotationAmount(float delta)
    {
        return rotationSpeed * delta;
    }
}
