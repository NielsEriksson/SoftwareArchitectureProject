using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Deck", menuName = "SavedDeck")]
public class SavedDeck : ScriptableObject
{
   public List<Card> savedCards = new List<Card>();
}
