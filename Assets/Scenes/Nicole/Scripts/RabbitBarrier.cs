using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitBarrier : MonoBehaviour
{
    BoxCollider collider;
    //[SerializeField] List<BoxCollider> antiHareColliders = new List<BoxCollider>();
    [SerializeField] LayerMask playerLayer;

    void Start()
    {
        // foreach (BoxCollider a in antiHareColliders)
        // {
        //     BoxCollider rabbitBarrier = GetComponent<BoxCollider>();
        //     rabbitBarrier.excludeLayers = playerLayer;
        //     Debug.Log("exclude player");
        // }
        collider = GetComponent<BoxCollider>();
        collider.excludeLayers = playerLayer;
    }
}
