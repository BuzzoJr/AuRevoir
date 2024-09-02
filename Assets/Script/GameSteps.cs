namespace Assets.Script
{
    public enum GameSteps
    {
        None = -1,
        // Chapter 1
        GetFirstMission = 0,
        CarCrashPoliceTalk,
        CarCrashClientDownload,
        BossFirstMission, //Não ta claro mas aqui é quando conversa com chefe antes do upload
        // Old
        PhoneAnswered,
        MissonReceived,
        CutsceneWatched,
        EndGame,
        AwakeBed,
    }
}