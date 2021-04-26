using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class AddFishAsFollow : MonoBehaviour
{
    GameObject tPlayer;
    CinemachineVirtualCamera vcam;

    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
    }

    void Update()
    {
       
    }

    public void AddFishAsNewPlayerToFollow()
    {
        tPlayer = GameObject.FindWithTag("Player");
        vcam.Follow = tPlayer.transform;
    }
}
