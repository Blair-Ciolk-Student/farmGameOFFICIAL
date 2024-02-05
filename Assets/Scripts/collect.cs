using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collect : MonoBehaviour
{
    public Collider2D pigCollider;
    public GameObject fertilizer;
    public int fertilizerAmount = 0;

    void Start()
    { 
        pigCollider = GetComponent<Collider2D>();

    }


    
}
