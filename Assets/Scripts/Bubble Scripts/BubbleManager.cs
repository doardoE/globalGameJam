using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    public static BubbleManager instance;
    public List<bubbleProj> aliveBubbles = new List<bubbleProj>();

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance);
        }
        instance = this;
    }

    public void AddBubbles(bubbleProj currentBubble)
    {
        if (!aliveBubbles.Contains(currentBubble))
        {
            aliveBubbles.Add(currentBubble);
        }
    }

    public void RemoveBubbles(bubbleProj currentBubble)
    {
        if (aliveBubbles.Contains(currentBubble))
        {
            aliveBubbles.Remove(currentBubble);
        }
    }

    public bool HasBigBubble()
    {
        foreach (var bubble in aliveBubbles)
        {
            if (bubble.isBigBubble)
            {
                return true;
            }
        }
        return false;
    }
}
