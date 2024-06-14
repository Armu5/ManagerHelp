using UnityEngine;
using System.Collections.Generic;

public class PartyManager : MonoBehaviour
{
    public static PartyManager Instance { get; private set; }

    private List<CrewMember> partyMembers = new List<CrewMember>();
    private int maxPartySize = 5;

    private void Awake()
    {
        if (Instance == null)
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
        return partyMembers.Count < maxPartySize;
    }

    public void AddCrewMember(CrewMember crewMember)
    {
        if (CanHireMore())
        {
            partyMembers.Add(crewMember);
        }
    }

    public List<CrewMember> GetPartyMembers()
    {
        return partyMembers;
    }
}
