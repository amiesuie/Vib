﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HapticManager : MonoBehaviour
{
    public OVRHapticsClip clip;

    public byte[] bytes;
    public string byteString;

    private int index;

    private void OnEnable()
    {
        bytes = System.Text.Encoding.UTF8.GetBytes(byteString);
        Debug.Log(bytes.Length);
        Debug.Log("SampleSizeInBytes is " + OVRHaptics.Config.SampleSizeInBytes);

        clip = new OVRHapticsClip(bytes, bytes.Length);
        Debug.Log("clip is *" +  clip + "*******");

        index = 0;
    }


    private void Update()
    {
        //index trigger down
		if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
		{
            Debug.Log("IndexTrigger down");

            VibKey key = (VibKey) index;

            index ++;
            if (index == 3)
                index = 0;
                
            OVRHaptics.LeftChannel.Mix(VibManager.vibDictionary[key]);
		}
    }



}
