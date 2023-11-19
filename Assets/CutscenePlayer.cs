using Assets.Script.Interaction;
using Assets.Script.Locale;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class CutscenePlayer : MonoBehaviour, ILook
{
    public bool shouldWalk = true;
    [SerializeField] private Vector3 CustomWalkOffset = Vector3.zero;
    public VideoPlayer videoPlayerENUS;
    public VideoPlayer videoPlayerPTBR;
    public PlayerData playerData;
    public DoorController door;

    private GameObject videocanvas;
    private VideoPlayer videoPlayer;

    public void Look(GameObject who)
    {
        if (Locale.Lang == Lang.ptBR)
            videoPlayer = videoPlayerPTBR;
        else
            videoPlayer = videoPlayerENUS;
        videocanvas = videoPlayer.gameObject;

        StartCoroutine(PlayVideo());
    }

    private IEnumerator PlayVideo()
    {
        GameManager.Instance.UpdateGameState(GameManager.GameState.Interacting);

        if (shouldWalk)
        {
            PlayerController.navMeshAgent.destination = new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z);

            yield return null;
            yield return new WaitUntil(() => !PlayerController.anim.GetBool("Walk"));
        }

        videocanvas.SetActive(true);
        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        videoPlayer.Play();

        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        videocanvas.SetActive(false);

        playerData.cutsceneWatched = true;
        door.SetLock(false);

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }
}
