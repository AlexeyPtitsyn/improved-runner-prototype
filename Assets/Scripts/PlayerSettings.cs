/**
 * Just for settings.
 */
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    public GameObject HisShip;
    public GameObject MainObject;

    [SerializeField, Range(1f, 100f)]
    public float ForwardSpeed = 4;

    [SerializeField, Range(1f, 500f)]
    public float MoveSpeed = 5;

    [SerializeField, Range(300, 500)]
    public float JumpForce = 400;
}
