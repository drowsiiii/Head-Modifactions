using System;
using System.Collections.Generic;
using System.Linq;
using BepInEx;
using UnityEngine;
using static GTTemplate.Info;
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
        public bool RotationHead = false;
        public bool spazheadLimit = false;
        public bool spazheadbiggerLimit = false;
        
        
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
            GUI.Box(new Rect(15, 495, 250, 370), "");
            GUI.color = new Color(244f / 255f, 210f / 255f, 220f/255f); 
            GUI.Label(new Rect(20, 500, 220, 25), "Head Modifications");
            GUI.Label(new Rect(20, 530, 220, 20), "<> Allowed Mods");
            GUI.Label(new Rect(20, 555, 220, 20), "------------------------------------");
            this.LargeGeads = GUI.Toggle(new Rect(20, 585, 220, 25), LargeGeads, "Large Gorilla Heads");
            this.upAndDownGeads = GUI.Toggle(new Rect(20, 615, 220, 25), upAndDownGeads, "Pulsing Heads");
            this.chickenGheads = GUI.Toggle(new Rect(20, 645, 220, 25), chickenGheads, "Chicken (Small) Gorilla Heads");
            this.greatWallofchinaheads = GUI.Toggle(new Rect(20, 675, 220, 25), greatWallofchinaheads, "Great Wall Of China Heads");
            this.strechedHeads = GUI.Toggle(new Rect(20, 705, 220, 25), strechedHeads, "Stretched Heads");
            this.HelicopterHead = GUI.Toggle(new Rect(20, 735, 220, 25), HelicopterHead, "Flat Head");
            this.spazheadLimit = GUI.Toggle(new Rect(20, 765, 220, 25), spazheadLimit, "Spaz Head Limit");
            this.spazheadbiggerLimit = GUI.Toggle(new Rect(20, 795, 220, 25), spazheadbiggerLimit, "Spaz Head Bigger Limit");
            GUI.color = Color.white;


            
        }

        void Update()
        { // sssss

            if (allowed)
            {
                
                if (LargeGeads)
                {
                    foreach (VRRig rig in rigs)
                    {
                        var head = rig.headMesh.transform;
                        head.localScale = new Vector3(3, 3, 3);
                    }

                }
                else if (chickenGheads)
                {
                    foreach (VRRig rig in rigs)
                    {
                        var head = rig.headMesh.transform;
                        head.localScale = new Vector3(0.1f, 0.1f, 0.1f);
                    }
                }
                else if (greatWallofchinaheads)
                {
                    foreach (VRRig rig in rigs)
                    {
                        var head = rig.headMesh.transform;
                        head.localScale = new Vector3(2f, 32f, 32f);
                    }
                }
                else if (strechedHeads)
                {
                    foreach (VRRig rig in rigs)
                    {
                        var head = rig.headMesh.transform;
                        head.localScale = new Vector3(1f, 32f, 1f);
                    }
                }
                else if(upAndDownGeads)
                {
                   
                    
                    
                    foreach (VRRig rig in rigs)
                    {

                        var HeadScale = rig.headMesh.transform.localScale;
                        var head = rig.headMesh.transform;
                        
                        if (HeadScale == MaxScale )
                        {
                            IsSrink = true;
                            IsGrowth = false;
                        }
                        else if (HeadScale == MinScale)
                        {
                            IsGrowth = true;
                            IsSrink =  false;
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
                else if (HelicopterHead)
                {
                    foreach (VRRig rig in rigs)
                    {
                        var HeadScale = rig.headMesh.transform.localScale;
                        var head = rig.headMesh.transform;
                        // var spinSpeed = 93f;
                        head.localScale = new Vector3(11f, 0.1f, 3f);
                        


                    }
                }
                else if (spazheadLimit)
                {
                    foreach (VRRig rig in rigs)
                    {
                        Random random = new Random();
                        var headScale = rig.headMesh.transform.localScale;
                        var x = random.Next(-20, 20);
                        var y = random.Next(-20, 20);
                        var z = random.Next(-20, 20);
                        rig.headMesh.transform.localScale = new Vector3(x, y, z);
                        


                    }
                    
                }
                else if (spazheadbiggerLimit)
                {
                    foreach (VRRig rig in rigs)
                    {
                        Random random = new Random();
                        var headScale = rig.headMesh.transform.localScale;
                        var x = random.Next(-100, 100);
                        var y = random.Next(-100, 100); 
                        var z = random.Next(-100, 100);
                        rig.headMesh.transform.localScale = new Vector3(x, y, z);
                        


                    }
                    
                }
                else
                {
                    foreach (VRRig rig in rigs)
                    {
                        var head = rig.headMesh.transform;
                        head.localScale = new Vector3(1, 1, 1);
                    }
                }//
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
