using UnityEngine;
using System.Collections.Generic;
using System;

public class PartyManager : MonoBehaviour
{
    public static PartyManager Instance { get; private set; }

    public int MaxPartySize = 5;

    public List<CrewMember> partyMembers = new List<CrewMember>();

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public bool CanHireMore()
    {
        return partyMembers.Count < MaxPartySize;
    }

    public void AddCrewMember(CrewMember crewMember)
    {
        if(CanHireMore())
        {
            partyMembers.Add(crewMember);
        }
    }

    public List<CrewMember> GetPartyMembers()
    {
        return partyMembers;
    }

    internal void RemoveCrewMember(CrewMember member)
    {
        partyMembers.Remove(member);
    }
}
