﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{

    public static AudioClip skeletonAttack, volstaggAttack, skeletonDeath, volstaggDeath, volstaggHit, pickUpKey, gateOpening, pickUpHeart, rokAttackingGate, skeletonGrunt, floorFalling, icePillarBreaking;
    public static AudioClip fireballImpact, fireballLaunch, wolfHit, wolfAttack, dragonFlyBy, dragonHit, dragonImpactRoar;
    static AudioSource audioSrc;
    // Use this for initialization
    void Start()
    {
        skeletonAttack = Resources.Load<AudioClip>("sword-slash-attack");
        volstaggAttack = Resources.Load<AudioClip>("volAttack-slash");
        skeletonDeath = Resources.Load<AudioClip>("skeleton-bones");
        volstaggDeath = Resources.Load<AudioClip>("volstagg-death");
        volstaggHit = Resources.Load<AudioClip>("volstagg-grunt");
        pickUpKey = Resources.Load<AudioClip>("pickupkey");
        gateOpening = Resources.Load<AudioClip>("gate-opening");
        pickUpHeart = Resources.Load<AudioClip>("pickup-heart");
        rokAttackingGate = Resources.Load<AudioClip>("rokAttackingGate");
        skeletonGrunt = Resources.Load<AudioClip>("skeletonGrunt");
        floorFalling = Resources.Load<AudioClip>("floorFalling");
        icePillarBreaking = Resources.Load<AudioClip>("icePillarBreaking");
        fireballImpact = Resources.Load<AudioClip>("fireballImpact");
        fireballLaunch = Resources.Load<AudioClip>("fireballLaunch");
        wolfHit = Resources.Load<AudioClip>("wolfHit");
        wolfAttack = Resources.Load<AudioClip>("wolfAttack");
        dragonFlyBy = Resources.Load<AudioClip>("dragonFlyBy");
        dragonHit = Resources.Load<AudioClip>("dragonHit");
        dragonImpactRoar = Resources.Load<AudioClip>("dragonImpactRoar");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "sword-slash-attack":
                audioSrc.PlayOneShot(skeletonAttack);
                break;
            case "volAttack-slash":
                audioSrc.PlayOneShot(volstaggAttack);
                break;
            case "skeleton-bones":
                audioSrc.PlayOneShot(skeletonDeath);
                break;
            case "volstagg-death":
                audioSrc.PlayOneShot(volstaggDeath);
                break;
            case "volstagg-grunt":
                audioSrc.PlayDelayed(0.8f);
                audioSrc.PlayOneShot(volstaggHit);
                break;
            case "pickupkey":
                audioSrc.PlayOneShot(pickUpKey);
                break;
            case "gate-opening":
                audioSrc.PlayOneShot(gateOpening);
                break;
            case "pickup-heart":
                audioSrc.PlayOneShot(pickUpHeart);
                break;
            case "rokAttackingGate":
                audioSrc.PlayOneShot(rokAttackingGate);
                break;
            case "skeletonGrunt":
                audioSrc.PlayOneShot(skeletonGrunt);
                break;
            case "floorFalling":
                audioSrc.PlayOneShot(floorFalling);
                break;
            case "icePillarBreaking":
                audioSrc.PlayOneShot(icePillarBreaking);
                break;
            case "fireballImpact":
                audioSrc.PlayOneShot(fireballImpact);
                break;
            case "fireballLaunch":
                audioSrc.PlayOneShot(fireballLaunch);
                break;
            case "wolfHit":
                audioSrc.PlayOneShot(wolfHit);
                break;
            case "wolfAttack":
                audioSrc.PlayOneShot(wolfAttack);
                break;
            case "dragonFlyBy":
                audioSrc.PlayOneShot(dragonFlyBy);
                break;
            case "dragonHit":
                audioSrc.PlayOneShot(dragonHit);
                break;
            case "dragonImpactRoar":
                audioSrc.PlayOneShot(dragonImpactRoar);
                break;
        }
    }
}