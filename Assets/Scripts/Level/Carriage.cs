﻿using UnityEngine;
using System.Collections.Generic;

public class Carriage : MonoBehaviour {

    public Transform FrontMountPoint;
    public Transform RearMountPoint;

    public enum CarriageType {Story, Filler};
    public CarriageType Type;

    public Door CarriageDoor;

    public Transform NPCPosition;
    public Transform Puzzle3DPosition;
    public Transform Puzzle2DPosition;

    public CarriagePuzzleController PuzzleController;

    public delegate void CarriageEvent();
    //Used when ALL puzzles are done.

    public void Start() {
        SetupExtraEvents();
    }

    public void AllPuzzlesComplete() {
        UI.ShowMessage("The door was unlocked!");
        CarriageDoor.Unlock();
    }

    public void OnNPCDeath(NPC npc) {
        UI.ShowMessage(npc.name + " died. The door mysteriously opened itself...");
        CarriageDoor.Unlock();
    }

    public void Place3DPuzzle(GameObject puzzle3D) {
        GameObject puzzle = (GameObject)Instantiate(puzzle3D, Puzzle3DPosition.position, Puzzle3DPosition.rotation);
        puzzle.GetComponent<CogPuzzle>().PuzzleComplete += PuzzleController.OnPuzzleCompleted;
    }

    public void PlaceCarriageNPC(StoryNPC npc) {
        GameObject newNPC = (GameObject)Instantiate(npc.ModelPrefab, NPCPosition.position, NPCPosition.rotation);
        newNPC.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        StoryNPC newStoryNPC = newNPC.AddComponent<StoryNPC>();
        newStoryNPC.Name = npc.Name;
        newStoryNPC.MemoryItemKey = npc.MemoryItemKey;
        newStoryNPC.MemoryResponseTotal = npc.MemoryResponseTotal;
        newStoryNPC.InitialDialogueNodeName = npc.InitialDialogueNodeName;
        newStoryNPC.Health = npc.Health;
        newStoryNPC.Interactable = npc.Interactable;
        newStoryNPC.NPCDeath += OnNPCDeath;
    }

    public void PlaceCarriageNPC(FillerNPC npc) {
        GameObject newNPC = (GameObject)Instantiate(npc.ModelPrefab, NPCPosition.position, NPCPosition.rotation);
        newNPC.transform.localScale = new Vector3(3.5f, 3.5f, 3.5f);
        FillerNPC newFillerNPC = newNPC.AddComponent<FillerNPC>();
        newFillerNPC.Name = npc.Name;
        newFillerNPC.MemoryItemKey = npc.MemoryItemKey;
        newFillerNPC.MemoryResponseTotal = npc.MemoryResponseTotal;
        newFillerNPC.InitialDialogueNodeName = npc.InitialDialogueNodeName;
        newFillerNPC.Health = npc.Health;
        newFillerNPC.Interactable = npc.Interactable;
        newFillerNPC.NPCDeath += OnNPCDeath;
    }

    public void SetupExtraEvents() {
        PuzzleController.AllPuzzlesCompleted += AllPuzzlesComplete;
    }
}
