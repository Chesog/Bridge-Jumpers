using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Event = Unity.Services.Analytics.Event;

public class CrashEvent : Event
{
    public CrashEvent() : base("Bridge_Jumpers_CrashReport")
    {
    }
    public string CrashReport{ set { SetParameter("Game Crashed", value); } }
}
