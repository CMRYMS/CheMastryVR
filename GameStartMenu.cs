// Decompiled with JetBrains decompiler
// Type: GameStartMenu
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3ECD403C-AC13-4634-A454-4453E6DDC982
// Assembly location: C:\Users\ThaherTech\Desktop\CheMastryVr_Prototype\CheMastry_VR_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

#nullable disable
public class GameStartMenu : MonoBehaviour
{
  [Header("UI Pages")]
  public GameObject mainMenu;
  public GameObject options;
  public GameObject about;
  [Header("Main Menu Buttons")]
  public Button startButton;
  public Button optionButton;
  public Button aboutButton;
  public Button quitButton;
  public List<Button> returnButtons;

  private void Start()
  {
    this.EnableMainMenu();
    this.startButton.onClick.AddListener(new UnityAction(this.StartGame));
    this.optionButton.onClick.AddListener(new UnityAction(this.EnableOption));
    this.aboutButton.onClick.AddListener(new UnityAction(this.EnableAbout));
    this.quitButton.onClick.AddListener(new UnityAction(this.QuitGame));
    foreach (Button returnButton in this.returnButtons)
      returnButton.onClick.AddListener(new UnityAction(this.EnableMainMenu));
  }

  public void QuitGame() => Application.Quit();

  public void StartGame()
  {
    this.HideAll();
    SceneTransitionManager.singleton.GoToSceneAsync(1);
  }

  public void HideAll()
  {
    this.mainMenu.SetActive(false);
    this.options.SetActive(false);
    this.about.SetActive(false);
  }

  public void EnableMainMenu()
  {
    this.mainMenu.SetActive(true);
    this.options.SetActive(false);
    this.about.SetActive(false);
  }

  public void EnableOption()
  {
    this.mainMenu.SetActive(false);
    this.options.SetActive(true);
    this.about.SetActive(false);
  }

  public void EnableAbout()
  {
    this.mainMenu.SetActive(false);
    this.options.SetActive(false);
    this.about.SetActive(true);
  }
}
