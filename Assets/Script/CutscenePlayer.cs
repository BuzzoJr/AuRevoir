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
    public MafiaOfficeLocked door;
    public AudioClip TvOn;
    public AudioClip TvOff;

    private AudioSource audioSource;
    private GameObject videocanvas;
    private VideoPlayer videoPlayer;
    private Animator animator;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
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
            var g = new GoTo();
            yield return StartCoroutine(g.GoToRoutine(new Vector3(transform.position.x + CustomWalkOffset.x, transform.position.y + CustomWalkOffset.y, transform.position.z + CustomWalkOffset.z), transform));

            // Action cancelled
            if (GameManager.Instance.State != GameManager.GameState.Interacting)
                yield break;
        }

        videocanvas.SetActive(true);
        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }
        audioSource.PlayOneShot(TvOn);
        videoPlayer.Play();

        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        animator = videoPlayer.gameObject.GetComponent<Animator>();
        animator.SetBool("Exit", true);
        audioSource.PlayOneShot(TvOff);
        float animationLength = animator.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSecondsRealtime(animationLength);
        videocanvas.SetActive(false);

        door.Unlock();

        GameManager.Instance.UpdateGameState(GameManager.GameState.Playing);
    }

    public void StopCutscene()
    {
        videoPlayer.Stop();
    }
}
