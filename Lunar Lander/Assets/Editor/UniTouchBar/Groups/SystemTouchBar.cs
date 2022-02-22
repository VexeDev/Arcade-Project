using System.Collections;
using System.Collections.Generic;
using Uni;
using UnityEditor;
using UnityEngine;
/// <summary>
/// Main TouchBar - shown on all windows.
/// </summary>
[InitializeOnLoad]

public class SystemTouchBar : MonoBehaviour
{
    public static TouchBar.Group systemGroup;
    public static TouchBar.Button escapeButton;

    static SystemTouchBar()
    {
        TouchBar.Manager.OnReady += TouchBar_Manager_OnReady;
    }

    static void TouchBar_Manager_OnReady()
    {
        TouchBar.Manager.OnReady -= TouchBar_Manager_OnReady;
        systemGroup = new TouchBar.Group("system", 0);

        escapeButton = systemGroup.AddTextButton("escape", "esc", () => {
            EditorWindow.focusedWindow.SendEvent(Event.KeyboardEvent("escape"));
        });

        systemGroup.ShowOnWindow(TouchBar.Windows.ALL);
        TouchBar.AddGroup(systemGroup);
    }
}
