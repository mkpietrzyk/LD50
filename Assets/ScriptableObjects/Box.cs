using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Box : ScriptableObject
{
    public Sprite sprite;
    public Guid guid;
    public AudioClip destroyedAudioClip;
    public AudioClip hitAudioClip;
    public int reward;
}
