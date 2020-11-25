using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    public Transform referenceTransform;
    public float collisionOffset = 0.2f; //To prevent Camera from clipping through Objects
    Vector3 defaultPos;
    Vector3 directionNormalized;
    Transform parentTransform;
    float defaultDistance;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        defaultPos =  transform.localPosition;
        directionNormalized = defaultPos.normalized;
        parentTransform = transform.parent;
        defaultDistance = Vector3.Distance(defaultPos, Vector3.zero);
    }

    // FixedUpdate for physics calculations
    void FixedUpdate()
    {
        //For RightMouse Click Zoom to 30 FieldOfView
        if (Input.GetMouseButton(1))
        {
            Camera.main.fieldOfView = 30;
        }
        else
        {
            Camera.main.fieldOfView = 60;
        }

        Vector3 currentPos = defaultPos;
        RaycastHit hit;
        Vector3 dirTmp = parentTransform.TransformPoint(defaultPos) - referenceTransform.position;
        if (Physics.SphereCast(referenceTransform.position,  collisionOffset, dirTmp, out hit, defaultDistance))
        {
            currentPos = (directionNormalized * (hit.distance - collisionOffset));
        }

        transform.localPosition = Vector3.Lerp(transform.localPosition, currentPos, Time.deltaTime * 15f);
    }
}
