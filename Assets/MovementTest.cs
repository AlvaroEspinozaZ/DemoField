using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MovementTest : MonoBehaviour
{
    [SerializeField] NavMeshAgent nav;
    [SerializeField] Transform final;
    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
    }
    void Start()
    {
        nav.SetDestination(final.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            nav.enabled = false;
            transform.position = new Vector3(transform.position.x -3f,transform.position.y,transform.position.z);
            nav.enabled = true;
            nav.SetDestination(final.position);
            
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            nav.enabled = false;
            transform.position = new Vector3(transform.position.x + 3f, transform.position.y, transform.position.z);
            nav.enabled = true;
            nav.SetDestination(final.position);
        }
    }
}
 