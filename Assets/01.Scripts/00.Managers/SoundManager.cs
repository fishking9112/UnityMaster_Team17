using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    [Header("모든 오디오 클립")]
    [SerializeField] private AudioClip[] audioClips;

    [SerializeField][Range(0,1)] private float bgmVolume = 1f;
    [SerializeField][Range(0,1)] private float sfxVolume = 1f;

    private Dictionary<string, AudioClip> soundDictionary;
    private AudioSource bgmPlayer;

    protected override void Awake()
    {
        base.Awake();

        InitSoundManager();
    }

    private void InitSoundManager()
    {
        soundDictionary = new Dictionary<string, AudioClip>();

        foreach(var clip in audioClips)
        {
            soundDictionary[clip.name] = clip;
        }

        bgmPlayer = gameObject.AddComponent<AudioSource>();
        bgmPlayer.loop = true;
        bgmPlayer.volume = bgmVolume;

        // 3D 음향 효과 제거
        bgmPlayer.spatialBlend = 0f;
        bgmPlayer.rolloffMode = AudioRolloffMode.Linear;
        bgmPlayer.dopplerLevel = 0f;
        bgmPlayer.spread = 0f;
    }

    /// <summary>
    /// SFX 재생
    /// </summary>
    /// <param name="clipName"> 재생할 SFX 이름 </param>
    /// <param name="position"> SFX이 생성될 위치 </param>
    public void PlayerSFX(string sfxName, Vector3 position)
    {
        if(soundDictionary.TryGetValue(sfxName, out var clip))
        {
            AudioSource.PlayClipAtPoint(clip, position, sfxVolume);
        }
        else
        {
            Debug.Log($"{sfxName} - 해당 클립이 존재하지 않습니다.");
        }
    }

    /// <summary>
    /// BGM 재생
    /// </summary>
    /// <param name="bgmName"> 재생할 BGM 이름 </param>
    public void PlayBGM(string bgmName)
    {
        if(soundDictionary.TryGetValue(bgmName,out var clip))
        {
            if(bgmPlayer.clip != clip)
            {
                bgmPlayer.clip = clip;
                bgmPlayer.volume = bgmVolume;
                bgmPlayer.Play();
            }
        }
    }
}
