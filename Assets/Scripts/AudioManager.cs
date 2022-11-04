using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    #region Singleton

    private static AudioManager instance;

    private void Awake()
    {
        instance = this;
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
}
