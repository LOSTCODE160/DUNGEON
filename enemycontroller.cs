using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemycontroller : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyprefab;
    [SerializeField]
    private int _enemycount = 5;
    [SerializeField]
    private Transform _spawnTopLeft, _spawnTopRight, _spawnBottomRight, _spawnBottomLeft;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _enemycount; i++) // Fixed: Added 'int' for loop variable.
        {
            spawnEnemy();
        }
    }

    private void spawnEnemy()
    {
        Vector3 spawnPosition = selectRandomPosition();
        GameObject enemyObject = Instantiate(_enemyprefab,spawnPosition,Quaternion.identity);
        Enemy enemy = enemyObject.GetComponent<Enemy>();
        if (enemy != null) 
        { 
            enemy.OnDie += spawnEnemy;
        }

        // Instantiate enemy at the spawn position.
        Instantiate(_enemyprefab, spawnPosition, Quaternion.identity);
    }

    private Vector3 selectRandomPosition() // Fixed: Changed 'vector3' to 'Vector3' (case-sensitive).
    {
        Transform selectedTransform = null;
        int randomValue = Random.Range(0, 4);
        spawnPointType spawnType =(spawnPointType) randomValue;

        switch (spawnType)
        {
            case spawnPointType.TopLeft:
                selectedTransform = _spawnTopLeft;
                break;
            case spawnPointType.TopRight:
                selectedTransform = _spawnTopRight;
                break;
            case spawnPointType.BottomRight:
                selectedTransform = _spawnBottomRight;
                break;
            case spawnPointType.BottomLeft:
                selectedTransform = _spawnBottomLeft;
                break;
        }

        return selectedTransform.position + (Vector3)Random.insideUnitCircle; // Ensure the Transform is not null to avoid errors.
    }

    // Update is called once per frame
    void Update()
    {

    }
   
}

public enum spawnPointType
{
    TopLeft=0,
    TopRight=1,
    BottomLeft=2,
    BottomRight=3,
}
