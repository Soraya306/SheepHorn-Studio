using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [Header("Data")]
    public Transform Player;
    public Vector3 OffLength;

    private void Awake()
    {
        transform.position = new Vector3(transform.position.x, transform.position.z);

    }
    private void Update()
    {
        transform.position = Player.position + OffLength;
    }
}
