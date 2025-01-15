using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimationController : MonoBehaviour
{
    private Animator animator;

    [SerializeField] private string[] trigers;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void TriggerRandomAnimation(){
        animator.SetTrigger(trigers[Random.Range(0, trigers.Length)]);
    }
}
