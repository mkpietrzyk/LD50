using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{ 
    [SerializeField]
    private System.Guid uuid;

    private void OnEnable()
    {
        uuid = new Guid();
    }
}
