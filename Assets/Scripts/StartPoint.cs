using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPoint : MonoBehaviour
{
    private PlayerController player;

    [SerializeField]private Vector2 facingDirection;

    public string uuid; // uuid = universal unique identifier

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if (!player.nextToUUID.Equals(uuid))
        {
            return;
        }

        player.transform.position = this.transform.position;

        player.LastDirection = facingDirection;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
