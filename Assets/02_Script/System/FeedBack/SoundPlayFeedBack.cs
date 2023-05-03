using FD.Dev;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayFeedBack : FeedBack
{

    [SerializeField] private List<AudioClip> playList;

    private AudioSource source;

    private void Awake()
    {
        
        source = GetComponent<AudioSource>();

    }

    public override void CreateFeedBack()
    {

        source.clip = FAED.Random(playList);
        source.Play();

    }

    public override void EndFeedBack()
    {

        

    }
}
