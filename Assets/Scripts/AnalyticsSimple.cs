using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;

public class AnalyticsSimple : MonoBehaviour
{
    private float runStartTime;
    public static AnalyticsSimple AccessInstance;

    async void Start()
    {
        AccessInstance = this;
        runStartTime = Time.time;
        await UnityServices.InitializeAsync();
        AnalyticsService.Instance.StartDataCollection();
        var runStartEvent = new CustomEvent("run_start")
        {
            { "start_time", runStartTime }
        };
        AnalyticsService.Instance.RecordEvent(runStartEvent);

        Debug.Log("Analytics event sent: run_start");
    }

    public void TrackRunEnd()
    {
        int score = PlayerMovement.Score;
        float runDuration = Time.time - runStartTime;
        var runEndEvent = new CustomEvent("run_end")
        {
            { "score", score },
            { "duration", runDuration }
        };
        AnalyticsService.Instance.RecordEvent(runEndEvent);

        Debug.Log($"Analytics event sent: run_end | score: {score}, duration: {runDuration}");
    }
}
