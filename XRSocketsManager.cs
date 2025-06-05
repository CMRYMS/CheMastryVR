// Decompiled with JetBrains decompiler
// Type: XRSocketsManager
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3ECD403C-AC13-4634-A454-4453E6DDC982
// Assembly location: C:\Users\ThaherTech\Desktop\CheMastryVr_Prototype\CheMastry_VR_Data\Managed\Assembly-CSharp.dll

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

#nullable disable
public class XRSocketsManager : MonoBehaviour
{
  public List<XRSocketInteractor> RequiredElements;
  public GameObject ActionButton;
  private Dictionary<XRSocketInteractor, bool> SocketIsFilledStatus = new Dictionary<XRSocketInteractor, bool>();

  private void Start()
  {
    foreach (XRSocketInteractor requiredElement in this.RequiredElements)
    {
      this.SocketIsFilledStatus[requiredElement] = false;
      requiredElement.selectEntered.AddListener(new UnityAction<SelectEnterEventArgs>(this.OnElementPlaced));
      requiredElement.selectExited.AddListener(new UnityAction<SelectExitEventArgs>(this.OnElementRemoved));
    }
    this.ActionButton.SetActive(false);
  }

  private void OnElementPlaced(SelectEnterEventArgs args)
  {
    XRSocketInteractor interactorObject = args.interactorObject as XRSocketInteractor;
    if (!((Object) interactorObject != (Object) null))
      return;
    this.SocketIsFilledStatus[interactorObject] = true;
    this.CheckCompoundSockets();
  }

  private void OnElementRemoved(SelectExitEventArgs args)
  {
    XRSocketInteractor interactorObject = args.interactorObject as XRSocketInteractor;
    if (!((Object) interactorObject != (Object) null))
      return;
    this.SocketIsFilledStatus[interactorObject] = false;
    this.CheckCompoundSockets();
  }

  private void CheckCompoundSockets()
  {
    foreach (bool flag in this.SocketIsFilledStatus.Values)
    {
      if (!flag)
      {
        this.ActionButton.SetActive(false);
        return;
      }
    }
    this.ActionButton.SetActive(true);
  }
}
