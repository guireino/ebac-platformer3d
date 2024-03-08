using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayerSetup : ScriptableObject{

    public Animator player;
    public SOString SOStringName;

    [Header("Speed setup")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speed, speedRun, forceJump = 2;

    [Header("Animation setup")]
    public Ease ease = Ease.OutBack;
    public float jumpScaleY = 1.5f, jumpScaleX = 0.7f, animationDuration = .3f;

    [Header("Animation Player")]
    private float _currentSpeed;
    private bool _isRunning = false;
    public float playerSwipeDuration = .1f;
    public string boolRun = "Run", triggerDeath = "Death";

}