using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public GameObject CmVcam;
    private CinemachineVirtualCamera vcam;
    private CinemachineTrackedDolly dolly;
    private float pathPositionMax;
    private float pathPositionMin;

    public GameObject[] TargetObj;
    private List<Transform> TargetTransforms = new List<Transform>();

    private float scroll;
    private float scrollSpeed = - 0.1f;
    public Vector2[] swithPoints;
    


    private float chargingScroll=0.0f;
    // Start is called before the first frame update
    void Start()
    {
        vcam = CmVcam.GetComponent<CinemachineVirtualCamera>();
        // get dolly componen, the gameobject has cinemachine track dolly component.
        dolly = vcam.GetCinemachineComponent<CinemachineTrackedDolly>(); 

        pathPositionMax = dolly.m_Path.MaxPos;
        pathPositionMin = dolly.m_Path.MinPos;

        for(int i =0; i< TargetObj.Length; i++)
        {
            TargetTransforms.Add(TargetObj[i].transform);
        }

        if(TargetObj.Length != swithPoints.Length)
        {
            Debug.Log("Warning::: Set Swith Points(x = startPos, y = swithPos");
        }
    }

    // Update is called once per frame
    void Update()
    {
        scroll = Input.GetAxis("Mouse ScrollWheel");

        scroll = scroll * scrollSpeed; // maping
        //print(scroll);

        CamSwithes(dolly.m_PathPosition);

        if (dolly.m_PathPosition >= pathPositionMin && dolly.m_PathPosition <= pathPositionMax)
        {
            dolly.m_PathPosition += scroll;
        }
        else if (dolly.m_PathPosition < pathPositionMin)
        {
            dolly.m_PathPosition = pathPositionMin;
        }
        else if (dolly.m_PathPosition > pathPositionMax)
        {
            dolly.m_PathPosition = pathPositionMax;
        }
        
    }

    void CamSwithes(float _mPathPosition)
    {
        
        var lookAtTarget = dolly.LookAtTarget;
        for(int i =0; i< TargetTransforms.Count; i++)
        {
            if (swithPoints[i].x < _mPathPosition && swithPoints[i].y >= _mPathPosition)
            {
                lookAtTarget.position = TargetTransforms[i].position;
            }
        }
        
        
    }
}
