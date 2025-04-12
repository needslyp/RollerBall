using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAnimationController : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private string[] trigers;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void TriggerRandomAnimation(){
        _animator.SetTrigger(trigers[Random.Range(0, trigers.Length)]);
    }
}
