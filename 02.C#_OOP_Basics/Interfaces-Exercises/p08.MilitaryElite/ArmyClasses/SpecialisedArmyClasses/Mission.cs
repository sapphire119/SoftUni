public class Mission : IMission
{
    public Mission() { }

    public Mission(string missionCodeName, MissionType missionState)
        : this()
    {
        this.MissionCodeName = missionCodeName;
        this.MissionState = missionState;
    }

    public string MissionCodeName { get; private set; }

    public MissionType MissionState { get;  set; }

    public void CompleteMission()
    {
        this.MissionState = MissionType.Finished;
    }
}