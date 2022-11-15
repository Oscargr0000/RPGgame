using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 1f;
    private Vector2 directionToMove;

    private Rigidbody2D _rigidbody;
    private bool isMoving;


    [SerializeField] private float timebetweanSteps;
    private float timebetweanStepsCounter;

    [SerializeField] private float timeToMakeStep;
    private float timeToMakeStepCounter;

    [Tooltip("If enemy movement is not random, enemyDirections needs to have at least two elements")]
    [SerializeField] private bool hasRandomMove;
    [Tooltip("Directions the enemy will follow to complete a path. The idea is that it should be cyclical.Components must be - 1, 0 or 1")]
    [SerializeField] private Vector2[] enemyDirections;
    private int indexDirection;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        timebetweanStepsCounter = timebetweanSteps * (hasRandomMove ? Random.Range(0.5f, 1.5f) : 1);


        timeToMakeStepCounter = timeToMakeStep * (hasRandomMove ? Random.Range(0.5f, 1.5f) : 1);

        directionToMove = hasRandomMove ? new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)): enemyDirections[indexDirection];
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            timeToMakeStepCounter -= Time.deltaTime;
            _rigidbody.velocity = speed * directionToMove;

            if (timeToMakeStepCounter < 0)
            {
                isMoving = false;
                timebetweanStepsCounter = timebetweanSteps;
                _rigidbody.velocity = Vector2.zero;
            }
        }
        else
        {
            timebetweanStepsCounter -= Time.deltaTime;
            if (timebetweanStepsCounter < 0)
            {
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;

                if (hasRandomMove) //MOVIMIENTO ALEATORIO
                {
                    directionToMove = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
                }
                else //MOVIMIENTO MANUAL
                {
                    indexDirection++;
                    if (indexDirection >= enemyDirections.Length)
                    {
                        indexDirection = 0;
                    }
                    directionToMove = enemyDirections[indexDirection];
                }
            }
        }

        
        }
    }
