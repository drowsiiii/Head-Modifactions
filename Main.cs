﻿using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using GorillaGameModes;
using UnityEngine;
using static GTTemplate.Info;
 using Photon.Pun;
 using Photon.Voice.PUN;
 using Photon.Voice.Unity;
 using Utilla.Models;
 using Hashtable = ExitGames.Client.Photon.Hashtable;
using Random = System.Random;


namespace GTTemplate
{
    [BepInPlugin(GTTemplate.Info.Guid, Name, GTTemplate.Info.Version)]
    public class Main : BaseUnityPlugin
    {
        // Head Mods
        public bool LargeGeads = false;
        public bool upAndDownGeads = false;
        public bool chickenGheads = false;
        public bool greatWallofchinaheads = false;
        public bool strechedHeads = false;
        public bool HelicopterHead = false;
        public bool spazheadLimit = false;
        public bool spazheadbiggerLimit = false;
        public bool BringHeadsToHead = false;  
        public bool BringHeadsToHand = false; public bool BringHeadsToLeftHand = false; public bool BringHeadsToRightHand = true;
        public bool Bringheadsup =  false;
        
        
        
        // upAndDownDep
        bool IsSrink = true;
        bool IsGrowth = false;
        Vector3 MinScale = new Vector3((float)0.3, (float)0.3, (float)0.3);
        Vector3 MaxScale = new Vector3(3, 3, 3);
        
        // Modded Lobby And VRRIG list Finding and setting
        private bool allowed;
        private List<VRRig> rigs = new List<VRRig>(); // wh to rpeepcetn lagggg what did i do

        private void Awake()
        {
            GorillaTagger.OnPlayerSpawned(Init);
        }
    
        void Init()
        {
            // your on game start functions here

            Debug.Log("game initialized");
             PhotonNetwork.LocalPlayer.SetCustomProperties(new Hashtable()
            { { "drowsiiiheadmodfications", "drowsiiiheadmodfications" } }); // uh
            // subscribe to join/leave room events
            NetworkSystem.Instance.OnMultiplayerStarted += JoinedRoom;
            NetworkSystem.Instance.OnReturnedToSinglePlayer += OnLeaveRoom;
            NetworkSystem.Instance.OnPlayerJoined.Add(OnPlayerJoined);
            NetworkSystem.Instance.OnPlayerLeft.Add(OnPlayerLeft);
            
        }

        void FixedUpdate()
        {
            if (!allowed) return;
            // this method will run 50 times per second
        }

        void OnGUI()
        { // awsome hui
            GUI.color = Color.black;
            GUI.Box(new Rect(15, 20, 420, 360), "");
            GUI.color = new Color(244f / 255f, 210f / 255f, 220f / 255f);
            GUI.Label(new Rect(25, 30, 220, 25), "<b>Head Modifications</b>");
            LargeGeads = GUI.Toggle(new Rect(25, 60, 210, 20), LargeGeads, "Large Gorilla Heads");
            upAndDownGeads = GUI.Toggle(new Rect(25, 85, 210, 20), upAndDownGeads, "Pulsing Heads");
            chickenGheads = GUI.Toggle(new Rect(25, 110, 210, 20), chickenGheads, "Chicken Heads");
            greatWallofchinaheads = GUI.Toggle(new Rect(25, 135, 210, 20), greatWallofchinaheads, "Great Wall Heads");
            strechedHeads = GUI.Toggle(new Rect(25, 160, 210, 20), strechedHeads, "Stretched Heads");
            HelicopterHead = GUI.Toggle(new Rect(25, 185, 210, 20), HelicopterHead, "Flat Head");
            spazheadLimit = GUI.Toggle(new Rect(25, 210, 210, 20), spazheadLimit, "Spaz Head Limit");
            spazheadbiggerLimit = GUI.Toggle(new Rect(25, 235, 210, 20), spazheadbiggerLimit, "Spaz Head Bigger Limit");
            Bringheadsup = GUI.Toggle(new Rect(25, 260, 210, 20), Bringheadsup, "Heads Up");
            BringHeadsToHead = GUI.Toggle(new Rect(25, 285, 210, 20), BringHeadsToHead, "Heads to Your Head");
            BringHeadsToHand = GUI.Toggle(new Rect(25, 310, 210, 20), BringHeadsToHand, "Heads to Hand");
            BringHeadsToLeftHand = GUI.Toggle(new Rect(45, 335, 210, 20), BringHeadsToLeftHand, "Left Hand");
            BringHeadsToRightHand = GUI.Toggle(new Rect(45, 360, 210, 20), BringHeadsToRightHand, "Right Hand");
            


            
        }

        void Update()
        { // sssss

            if (allowed)
            {
                
                if (LargeGeads)
                {
                    foreach (VRRig rig in rigs)
                    {
                        if (!rig.isOfflineVRRig)
                        {
                            var head = rig.headMesh.transform;
                            head.localScale = new Vector3(3, 3, 3);
                        }

                    }

                }
                else if (chickenGheads)
                {
                    foreach (VRRig rig in rigs)
                    {
                        if (!rig.isOfflineVRRig)
                        {
                            var head = rig.headMesh.transform;
                            head.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                        }

                    }
                }
                else if (greatWallofchinaheads)
                {
                    foreach (VRRig rig in rigs)
                    {
                        if ( !rig.isOfflineVRRig)
                        {
                            var head = rig.headMesh.transform;
                            head.localScale = new Vector3(2f, 32f, 32f);
                        }

                    }
                }
                else if (strechedHeads)
                {
                    foreach (VRRig rig in rigs)
                    {
                        if (!rig.isOfflineVRRig)
                        {
                            var head = rig.headMesh.transform;
                            head.localScale = new Vector3(1f, 32f, 1f);
                        }
                            

                    }
                }
                else if(upAndDownGeads)
                {



                    foreach (VRRig rig in rigs)
                    {
                        if (!rig.isOfflineVRRig)
                        {
                            var HeadScale = rig.headMesh.transform.localScale;
                            var head = rig.headMesh.transform;

                            if (HeadScale == MaxScale)
                            {
                                IsSrink = true;
                                IsGrowth = false;
                            }
                            else if (HeadScale == MinScale)
                            {
                                IsGrowth = true;
                                IsSrink = false;
                            }

                            if (IsSrink)
                            {
                                head.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
                            }

                            if (IsGrowth)
                            {
                                head.localScale += new Vector3(0.1f, 0.1f, 0.1f);
                            }


                        }
                    }


                }
                else if (HelicopterHead)
                {
                    foreach (VRRig rig in rigs)
                    {
                        if (!rig.isOfflineVRRig)
                        {
                            
                            var HeadScale = rig.headMesh.transform.localScale;
                            var head = rig.headMesh.transform;
                            // var spinSpeed = 93f;
                            head.localScale = new Vector3(11f, 0.1f, 3f);
                            head.localPosition = new Vector3(0.1f, 0.1f, 0.1f);
                        }
                            
                        


                    }
                }
                else if (spazheadLimit)
                {
                    foreach (VRRig rig in rigs)
                    {
                        if (!rig.isOfflineVRRig)
                        {
                            Random random = new Random();
                            var headScale = rig.headMesh.transform.localScale;
                            var x = random.Next(-20, 20);
                            var y = random.Next(-20, 20);
                            var z = random.Next(-20, 20);
                            rig.headMesh.transform.localScale = new Vector3(x, y, z);
                        }
                        
                        


                    }
                    
                }
                else if (spazheadbiggerLimit)
                {
                    foreach (VRRig rig in rigs)
                    {
                        if (!rig.isOfflineVRRig)
                        {
                            Random random = new Random();
                            var headScale = rig.headMesh.transform.localScale;
                            var x = random.Next(-100, 100);
                            var y = random.Next(-100, 100); 
                            var z = random.Next(-100, 100);
                            rig.headMesh.transform.localScale = new Vector3(x, y, z);
                        }
                        
                        


                    }
                    
                }
                /*else if (talkingheads)
                {
                    
                    foreach (VRRig rig in rigs) // builtdd
                    {
                       //var speaking = rig.GetComponent<PhotonVoiceNetwork>();
                        if (!rig.isOfflineVRRig)
                        {
                            var aintilimitthing = 0.01f;
                            if (speaking.V)
                            {
                                rig.headMesh.transform.localScale = new Vector3(2f, 2f, 2f);
                            }
                            else
                            {
                                rig.headMesh.transform.localScale = new Vector3(1f, 1f, 1f);
                            }
                        }
                    }
                }*/
                else if (Bringheadsup)
                {
                    foreach (VRRig rig in rigs)
                    {
                        if (!rig.isOfflineVRRig)
                        {
                            var head = rig.headMesh.transform;
                            head.position = new  Vector3(0, 1, 0);
                        }
                    }
                }
                else if (BringHeadsToHand)
                {
                    if (BringHeadsToHand && BringHeadsToLeftHand)
                    {
                        foreach (VRRig rig in rigs)
                        {
                            var head = rig.headMesh.transform;
                            var LocalHandLeftPos = GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position;
                            head.position = LocalHandLeftPos;
                        }
                    }
                    else if (BringHeadsToHand && BringHeadsToRightHand)
                    {
                        foreach (VRRig rig in rigs)
                        {
                            var head = rig.headMesh.transform;
                            var LocalHandRightPos = GorillaLocomotion.GTPlayer.Instance.rightControllerTransform.position;
                            head.position = LocalHandRightPos;
                        }
                    }
                    else
                    {
                        foreach (VRRig rig in rigs)
                        {
                            var head = rig.headMesh.transform;
                            var LocalHandLeftPos = GorillaLocomotion.GTPlayer.Instance.leftControllerTransform.position;
                            head.position = LocalHandLeftPos;
                        }
                        Debug.Log("Nuh uh buddy your not doing any funny biss!! it going to right default LLLLL");
                        
                    }
                }
                else if (BringHeadsToHead)
                {
                    foreach (VRRig rig in rigs)
                    {
                        var head = rig.headMesh.transform;
                        var localHeadPos = GorillaLocomotion.GTPlayer.Instance.headCollider.transform.position; //BLINDNESS FLASH BANG (insert me throwing flash bang) GO!!!!! summons avengers
                        head.position = localHeadPos;
                    }
                }
                else
                {
                    foreach (VRRig rig in rigs)
                    {
                        if (!rig.isOfflineVRRig) // comment to build
                        {
                            var head = rig.headMesh.transform;
                            head.localScale = new Vector3(1, 1, 1);
                            head.localPosition = new Vector3(0, 0.3f, 0);
                        }

                    }
                }
            }
        }

        public void UpdateListie()
        {
            rigs = UnityEngine.Object.FindObjectsOfType<VRRig>().ToList();
        }

        void OnPlayerLeft(NetPlayer player)
        {
            UpdateListie();
        }

        void OnPlayerJoined(NetPlayer player)
        {
            UpdateListie();
        }
        void JoinedRoom()
        {
            allowed = NetworkSystem.Instance.GameModeString.Contains("MODDED");
            UpdateListie();

        }

        void OnLeaveRoom() // commment
        {
            allowed = false;
            UpdateListie();

        }

    }
}
