using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager inst;
    private void Awake()
    {
        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public Transform thirdPerson;
    public GameObject RTSCameraRig;
    public GameObject YawNode;   // Child of RTSCameraRig
    public GameObject PitchNode; // Child of YawNode
    public GameObject RollNode;  // Child of PitchNode
    //Camera is child of RollNode

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            setCamera(thirdPerson);
        }
    }

    public void setCamera(Transform pov)
    {
        if (isRTSMode)
        {
            YawNode.transform.SetParent(pov);
            YawNode.transform.localPosition = Vector3.zero;
            YawNode.transform.localEulerAngles = Vector3.zero;
        }
        else
        {
            YawNode.transform.SetParent(RTSCameraRig.transform);
            YawNode.transform.localPosition = Vector3.zero;
            YawNode.transform.localEulerAngles = Vector3.zero;
        }
        isRTSMode = !isRTSMode;
    }

    public bool isRTSMode = true;
}

