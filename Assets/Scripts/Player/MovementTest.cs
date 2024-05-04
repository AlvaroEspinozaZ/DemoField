using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MovementTest : MonoBehaviour
{
    [SerializeField] NavMeshAgent nav;
    [SerializeField] Transform final;
    [SerializeField] Rigidbody rgb;
    [SerializeField] float impulse=1;
    Vector2 initPos; // Guarda la posición inicial del toque
    bool touchStarted;
    int timer=0;
    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        rgb = GetComponent<Rigidbody>();
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MoveWithTouch();
        //MoveWithKeryboard();
    }
    void MoveWithKeryboard()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            nav.enabled = false;
            //transform.position = new Vector3(transform.position.x - 5f, transform.position.y, transform.position.z);
            rgb.AddForce(Vector3.left* impulse, ForceMode.Impulse);
            nav.enabled = true;
            nav.SetDestination(transform.position);

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            nav.enabled = false;
            //transform.position = new Vector3(transform.position.x + 5f, transform.position.y, transform.position.z);
            rgb.AddForce(Vector3.left * impulse, ForceMode.Impulse);
            nav.enabled = true;
            nav.SetDestination(transform.position);
        }
    }
    void MoveWithTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
           

            if (touch.phase == TouchPhase.Began)
            {
                initPos = touch.position;
                touchStarted = true;
            }
            if (touchStarted && Input.GetTouch(0).phase == TouchPhase.Moved)
            {                
                float direction = touch.position.x - initPos.x;

                if (direction > 0)
                {
                    nav.enabled = false;
                    //transform.position = new Vector3(transform.position.x + 5f, transform.position.y, transform.position.z);
                    rgb.AddForce(Vector3.left * impulse, ForceMode.Impulse);
                    nav.enabled = true;
                    //nav.SetDestination(transform.position);
                }
                else if (direction < 0)
                {
                    nav.enabled = false;
                    //transform.position = new Vector3(transform.position.x - 5f, transform.position.y, transform.position.z);
                    rgb.AddForce(Vector3.right * impulse, ForceMode.Impulse);
                    nav.enabled = true;
                    //nav.SetDestination(transform.position);
                }

                touchStarted = false;
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                touchStarted = false;
                rgb.velocity = Vector3.zero;
            }
        }
    }

}
 