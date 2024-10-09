using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Elevator : MonoBehaviour
{
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    [SerializeField] public float speed = 2.0f;

    private bool switching = false;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (switching == false)
        {
            target = pointB;
        } else if (switching == true) {
            target = pointA;
        }

        if (transform.position == pointB.position)
        {
            switching = true;
        } else if (transform.position == pointA.position)
        {
            switching = false;
        }
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Elevator elevator = this;
            other.transform.parent = elevator.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
