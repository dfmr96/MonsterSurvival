using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDefines : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        Debug.Log("Unity Editor");
        Application.targetFrameRate = 60;
#endif
#if UNITY_IOS
        Application.targetFramerate = 120;
#endif

#if UNITY_STANDALONE_OSX
        Debug.Log("Standalone OSX");
#endif

#if UNITY_STANDALONE_WIN
        Debug.Log("Standalone Windows");
#endif

    }
}
