using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed = 1f;
    public Vector2 directionToMove;

    private Rigidbody2D _rigidbody;
    private bool isMoving;


    [SerializeField] private float timebetweanSteps;
    private float timebetweanStepsCounter;

    [SerializeField] private float timeToMakeStep;
    private float timeToMakeStepCounter;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        timebetweanStepsCounter = timebetweanSteps;
        timeToMakeStepCounter = timeToMakeStep;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            timeToMakeStepCounter -= Time.deltaTime;
            _rigidbody.velocity = speed * directionToMove;
            if (timebetweanStepsCounter < 0)
            {
                isMoving = false;
                timebetweanStepsCounter = timebetweanSteps;
                _rigidbody.velocity = Vector2.zero;
            }
        }
        else
        {
            timebetweanStepsCounter -= Time.deltaTime;
            if (timebetweanStepsCounter > 0)
            {
                isMoving = true;
                timeToMakeStepCounter = timeToMakeStep;
                directionToMove = new Vector2(Random.Range(-1, 2), Random.Range(-1,2));
            }
        }
    }
}
