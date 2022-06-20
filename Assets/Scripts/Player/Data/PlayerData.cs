using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName ="Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Movement State")]
    public float moveVelo = 10f;
    [Header("Jump State")]
    public float jumpVelo = 15f;
    public int totalJump = 1;
    [Header("In Air State")]
    public float coyTime = 0.2f;
    public float varJumpHeightMultipier = 0.5f;
    [Header("Checker")]
    public float groundCheckRadius = 0.3f;
    public LayerMask isThatGround;
}
