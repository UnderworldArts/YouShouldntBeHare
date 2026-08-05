using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBarrier : MonoBehaviour
{
    BoxCollider rabbitCollider;
    [SerializeField] LayerMask playerLayer;

    void Start()
    {
        // foreach (BoxCollider a in antiHareColliders)
        // {
        //     BoxCollider rabbitBarrier = GetComponent<BoxCollider>();
        //     rabbitBarrier.excludeLayers = playerLayer;
        //     Debug.Log("exclude player");
        // }
        rabbitCollider = GetComponent<BoxCollider>();
        rabbitCollider.excludeLayers = playerLayer;
    }
}
