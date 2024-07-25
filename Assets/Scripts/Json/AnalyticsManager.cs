using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class AnalyticsManager : MonoBehaviour
{

    async void Start()
    {
        await UnityServices.InitializeAsync();
        
        if ( UnityServices.State == ServicesInitializationState.Initialized)
            Debug.Log("ServicesInitializationState.Initialized");
        
        AnalyticsService.Instance.StartDataCollection();

        Debug.Log($"Started UGS Analytics Sample with user ID: {AnalyticsService.Instance.GetAnalyticsUserID()}");
    }

    public void SendTestEvent()
    {
        CustomEvent testCustomEvent = new CustomEvent("test_Custom_Event")
        {
            {"test_Custom_Event","Testing Parameter"}
        };
        AnalyticsService.Instance.RecordEvent(testCustomEvent);
            
        Debug.Log("Recording Test Event");
    }

    public void RecordCrash()
    {
        CustomEvent crashCustomEvent = new CustomEvent("Bridge_Jumpers_CrashReport")
        {
            {"Crash_Report","Game Crash"}
        };
        AnalyticsService.Instance.RecordEvent(crashCustomEvent);
        
        Debug.Log("Recording Crash Event");
    }
}
