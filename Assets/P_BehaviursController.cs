using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_BehaviursController : MonoBehaviour
{
    public Animator patoAnimator;

    private void Start()
    {       
        patoAnimator = GetComponent<Animator>();
    }
    
    public void Jump()
    {
        patoAnimator.SetTrigger("Jump");
    }
    public void DashRight()
    {
        patoAnimator.SetTrigger("DashIzquierda");
    }
    public void DashLeft()
    {
        patoAnimator.SetTrigger("DashDerecha");
    }
}
