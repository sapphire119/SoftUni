public interface IMission 
{
    string MissionCodeName { get; }

    MissionType MissionState { get; set; }

    void CompleteMission();
}