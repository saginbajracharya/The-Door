using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCameraFollowPlayer : MonoBehaviour
{
    public Transform Player;

    void LateUpdate()
    {
        Vector3 CameraFollowPosition = Player.position;
        CameraFollowPosition.y = transform.position.y;
        transform.position  = CameraFollowPosition;
    }
}
