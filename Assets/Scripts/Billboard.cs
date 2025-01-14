using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private BillboardType billboardType;

    [SerializeField] private Camera currentCamera;
    public enum BillboardType { LookAtCamera, CameraForward };


    private void LateUpdate()
    {
        switch (billboardType)
        {
            case BillboardType.LookAtCamera:
                transform.LookAt(currentCamera.transform.position, Vector3.up);
                transform.Rotate(new Vector3(0, 0, 180));
                break;

            case BillboardType.CameraForward:
                transform.forward = currentCamera.transform.forward;
                transform.Rotate(new Vector3(0, 0, 180));
                break;

            default:
                break;
        }
    }

}
