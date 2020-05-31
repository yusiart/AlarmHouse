using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
[RequireComponent(typeof(AudioSource))]
public class VolumeChanger : Alarm
{
    [SerializeField] private Transform _doorTransform;
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Alarm _alarm;

    private float _distanceBetweenObjects;
    private AudioSource _myAudioSource;
    private bool _play;
    private float _speedFade = 0.005f;


    private void OnEnable()
    {
        _myAudioSource = GetComponent<AudioSource>();
        _alarm.VolumeChange += OnVolumeChange;
    }

    private void OnDisable()
    {
        _alarm.VolumeChange -= OnVolumeChange;
    }

    private void Update()
    {
        if (_play)
        {
            _distanceBetweenObjects = _enemy.transform.position.x - _doorTransform.transform.position.x;
            _myAudioSource.volume += _speedFade * _distanceBetweenObjects;
        }
    }

    private void OnVolumeChange()
    {
        _play = true;
        _myAudioSource.Play();
    }
}
