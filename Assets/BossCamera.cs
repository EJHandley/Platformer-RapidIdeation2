using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BossCamera : MonoBehaviour
{
    public GameObject boss;

    public CinemachineVirtualCamera vcam;

    // Update is called once per frame
    void Update()
    {
        if(boss.activeSelf == true)
        {
            vcam.m_Lens.OrthographicSize = 15;
        }
    }
}
