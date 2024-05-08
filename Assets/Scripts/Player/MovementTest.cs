using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MovementTest : MonoBehaviour
{
    [SerializeField] Rigidbody rgb;
    [SerializeField] float impulse=1;
    Vector2 initPos; // Guarda la posici�n inicial del toque
    bool touchStarted;
    int timer=0;
    private void Awake()
    {
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
            //transform.position = new Vector3(transform.position.x - 5f, transform.position.y, transform.position.z);
            rgb.AddForce(Vector3.left* impulse, ForceMode.Impulse);

        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            //transform.position = new Vector3(transform.position.x + 5f, transform.position.y, transform.position.z);
            rgb.AddForce(Vector3.left * impulse, ForceMode.Impulse);
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
                    //transform.position = new Vector3(transform.position.x + 5f, transform.position.y, transform.position.z);
                    rgb.AddForce(Vector3.left * impulse, ForceMode.Impulse);
                    //nav.SetDestination(transform.position);
                }
                else if (direction < 0)
                {
                    //transform.position = new Vector3(transform.position.x - 5f, transform.position.y, transform.position.z);
                    rgb.AddForce(Vector3.right * impulse, ForceMode.Impulse);
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Objeto")
        {
            
        }
    }
}
 