// Decompiled with JetBrains decompiler
// Type: GameManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3ECD403C-AC13-4634-A454-4453E6DDC982
// Assembly location: C:\Users\ThaherTech\Desktop\CheMastryVr_Prototype\CheMastry_VR_Data\Managed\Assembly-CSharp.dll

using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

#nullable disable
public class GameManager : MonoBehaviour
{
  public static string bestMatch;
  public TextMeshPro DisplaySuggestion;
  public TextMeshPro DisplaySelection;
  public static Dictionary<string, int> UserSelection = new Dictionary<string, int>();
  private Dictionary<string, Dictionary<string, int>> MapOfCompounds = new Dictionary<string, Dictionary<string, int>>()
  {
    {
      "H2O",
      new Dictionary<string, int>() { { "H", 2 }, { "O", 1 } }
    },
    {
      "KNO3",
      new Dictionary<string, int>()
      {
        {
          "K",
          1
        },
        {
          "N",
          1
        },
        {
          "O",
          3
        }
      }
    },
    {
      "NaHCO3",
      new Dictionary<string, int>()
      {
        {
          "Na",
          1
        },
        {
          "H",
          1
        },
        {
          "C",
          1
        },
        {
          "O",
          3
        }
      }
    }
  };

  public static GameManager Instance { get; private set; }

  private void Awake()
  {
    if ((UnityEngine.Object) GameManager.Instance == (UnityEngine.Object) null)
      GameManager.Instance = this;
    else
      UnityEngine.Object.Destroy((UnityEngine.Object) this.gameObject);
  }

  public void AddElementToDictionary(string Elmt)
  {
    if (string.IsNullOrEmpty(Elmt))
      return;
    if (GameManager.UserSelection.ContainsKey(Elmt))
      GameManager.UserSelection[Elmt]++;
    else
      GameManager.UserSelection[Elmt] = 1;
    this.AddedHistory("You Have Selected: " + string.Join(", ", GameManager.UserSelection.Select<KeyValuePair<string, int>, string>((Func<KeyValuePair<string, int>, string>) (e => $"{e.Key}: {e.Value.ToString()}"))));
    this.Predict();
  }

  public void RemoveElementFromDictionary(string Elmt)
  {
    if (string.IsNullOrEmpty(Elmt) || !GameManager.UserSelection.ContainsKey(Elmt))
      return;
    if (GameManager.UserSelection[Elmt] > 1)
      GameManager.UserSelection[Elmt]--;
    else
      GameManager.UserSelection.Remove(Elmt);
    this.AddedHistory("You Have Selected: " + string.Join(", ", GameManager.UserSelection.Select<KeyValuePair<string, int>, string>((Func<KeyValuePair<string, int>, string>) (e => $"{e.Key}: {e.Value.ToString()}"))));
    this.Predict();
  }

  public void Predict()
  {
    List<string> SelectedCandidates = new List<string>();
    int num1 = 0;
    foreach (KeyValuePair<string, Dictionary<string, int>> mapOfCompound in this.MapOfCompounds)
    {
      int num2 = this.CalculteScores(mapOfCompound.Value);
      if (num2 > num1)
      {
        num1 = num2;
        SelectedCandidates = new List<string>()
        {
          mapOfCompound.Key
        };
      }
      else if (num2 == num1)
        SelectedCandidates.Add(mapOfCompound.Key);
    }
    if (SelectedCandidates.Count > 0)
    {
      GameManager.bestMatch = this.ChooseBest(SelectedCandidates);
      this.Suggestion("Try Making: " + GameManager.bestMatch);
      Debug.Log((object) $"System Suggests: {GameManager.bestMatch} match score is: {num1}");
    }
    else
      Debug.Log((object) "No match found. please generate more elements or try again");
    if (GameManager.UserSelection.Count != 0)
      return;
    SelectedCandidates.Clear();
    GameManager.bestMatch = " ";
    this.Suggestion("Try Making: ");
  }

  public int CalculteScores(Dictionary<string, int> ElementsOfCompound)
  {
    int num1 = 0;
    foreach (KeyValuePair<string, int> keyValuePair in ElementsOfCompound)
    {
      string key = keyValuePair.Key;
      int num2 = keyValuePair.Value;
      if (GameManager.UserSelection.ContainsKey(key))
      {
        if (GameManager.UserSelection[key] == num2)
          num1 += 2;
        else
          ++num1;
      }
    }
    return num1;
  }

  public string ChooseBest(List<string> SelectedCandidates)
  {
    if (SelectedCandidates.Count == 1)
      return SelectedCandidates[0];
    SelectedCandidates.Sort((Comparison<string>) ((a, b) => a.Length.CompareTo(b.Length)));
    int shortestLength = SelectedCandidates[0].Length;
    List<string> list = SelectedCandidates.Where<string>((Func<string, bool>) (c => c.Length == shortestLength)).ToList<string>();
    return list.Count == 1 ? list[0] : list[UnityEngine.Random.Range(0, list.Count)];
  }

  private void AddedHistory(string history)
  {
    if (!((UnityEngine.Object) this.DisplaySelection != (UnityEngine.Object) null))
      return;
    this.DisplaySelection.text = history;
  }

  private void Suggestion(string suggestion)
  {
    if (!((UnityEngine.Object) this.DisplaySuggestion != (UnityEngine.Object) null))
      return;
    this.DisplaySuggestion.text = suggestion;
  }
}
