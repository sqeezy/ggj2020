using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform TargetTranform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var targetTranformPosition = TargetTranform.position;
        var gameObjectTransform = gameObject.transform;
        gameObjectTransform.position = new Vector3(targetTranformPosition.x, targetTranformPosition.y, gameObjectTransform.position.z);
    }
}
