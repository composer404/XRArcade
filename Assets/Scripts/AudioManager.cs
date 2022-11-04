using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    #region Singleton

    private static AudioManager instance;

    private AudioSource[] memoryButtonSounds = new AudioSource[8];

    private void Awake()
    {
        instance = this;

        memoryButtonSounds[0] = doNode;
        memoryButtonSounds[1] = reNode;
        memoryButtonSounds[2] = miNode;
        memoryButtonSounds[3] = faNode;
        memoryButtonSounds[4] = solNode;
        memoryButtonSounds[5] = laNode;
        memoryButtonSounds[6] = siNode;
        memoryButtonSounds[7] = dooNode;
    }

    public static AudioManager GetInstance()
    {
        return instance;
    }

    #endregion

    [SerializeField]
    private AudioSource doNode;

    [SerializeField]
    private AudioSource reNode;

    [SerializeField]
    private AudioSource miNode;

    [SerializeField]
    private AudioSource faNode;

    [SerializeField]
    private AudioSource solNode;

    [SerializeField]
    private AudioSource laNode;

    [SerializeField]
    private AudioSource siNode;

    [SerializeField]
    private AudioSource dooNode;


    public void PlayDoNode()
    {
        doNode.Play();
    }

    public void PlayReNode()
    {
        reNode.Play();
    }

    public void PlayMiNode()
    {
        miNode.Play();
    }

    public void PlayFaNode()
    {
        faNode.Play();
    }

    public void PlaySolNode()
    {
        solNode.Play();
    }

    public void PlayLaNode()
    {
        laNode.Play();
    }

    public void PlaySiNode()
    {
        siNode.Play();
    }

    public void PlayDooNode()
    {
        dooNode.Play();
    }

    public AudioSource[] GetMemoryButtonSounds()
    {
        return memoryButtonSounds;
    }
}
