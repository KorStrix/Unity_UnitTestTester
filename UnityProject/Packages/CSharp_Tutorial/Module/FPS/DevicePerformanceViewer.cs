using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

/// <summary>
/// 기기의 퍼포먼스를 볼 수 있는 뷰어
/// <para><see cref="DoUpdate"/>를 Update때 호출해야 합니다.</para>
/// </summary>
public class DevicePerformanceViewer
{
    float _fDeltaTime = 0.0f;
    StringBuilder _pStringBuilder = new StringBuilder();

    public void DoUpdate()
    {
        _fDeltaTime += (Time.unscaledDeltaTime - _fDeltaTime) * 0.1f;
    }

    public float GetCPU_ElpaseTime_MicroSecond()
    {
        return _fDeltaTime * 1000.0f;
    }

    public string GetCPU_ElpaseTime_MicroSecond_String()
    {
        return string.Format("{0:0.0} ms", _fDeltaTime * 1000.0f);
    }

    public float GetCPU_FPS()
    {
        return 1.0f / _fDeltaTime;
    }

    public string GetCPU_FPS_String()
    {
        return string.Format("{0} FPS", (int)(1.0f / _fDeltaTime));
    }

    public int GetCPU_MHZ()
    {
        return SystemInfo.processorFrequency;
    }

    public string GetCPU_MHZ_String()
    {
        return string.Format("{0} MHz", SystemInfo.processorFrequency);
    }
}
