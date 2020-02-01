using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MoveCamera : MonoBehaviour
{
    public float Speed;
    public float DistanceWeight; 

    private float _activeSpeed;
    private GameModel _model;

    [Inject]
    public void Init(GameModel model)
    {
        _model = model;
    }

    // Start is called before the first frame update
    void Start()
    {
        _activeSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
       CheckSpeedByPlayer();
        var pos = transform.position;
        pos.y += _activeSpeed * Time.deltaTime;
        transform.position = pos;
        
        
    }

    private void CheckSpeedByPlayer()
    {
        var player = _model.GetFirstPlayer();
        if (player != null)
        {
            var distance = player.PlayerData.CarData.Position.y - transform.position.y;
            _activeSpeed = _activeSpeed + (distance * DistanceWeight * Time.deltaTime);
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        var influencer = other.gameObject.GetComponent<CameraMoveInfuencer>();
        if (influencer != null)
        {
            _activeSpeed = influencer.CameraSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var influencer = other.gameObject.GetComponent<CameraMoveInfuencer>();
        if (influencer != null)
        {
            _activeSpeed = Speed;
        }
    }
}
