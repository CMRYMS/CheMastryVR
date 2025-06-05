// Decompiled with JetBrains decompiler
// Type: ButtonFollow
// Assembly: Assembly-CSharp, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 3ECD403C-AC13-4634-A454-4453E6DDC982
// Assembly location: C:\Users\ThaherTech\Desktop\CheMastryVr_Prototype\CheMastry_VR_Data\Managed\Assembly-CSharp.dll

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

#nullable disable
public class ButtonFollow : MonoBehaviour
{
  public GameObject Element;
  public Vector3 ElementSpawnpoint;
  public Vector3 ElementLocalAxis = new Vector3(0.0f, -1f, 0.0f);
  public float ElementBtnResetSpeed = 5f;
  public float ButtonFollowAngle = 45f;
  private bool Stop = false;
  private Vector3 LocalPos;
  public Transform ButtonVisual;
  private Vector3 ButtonMove;
  private Transform ButtonPokeTransform;
  private XRBaseInteractable Interactable;
  private bool ButtonIsFollowStatus = false;

  private void Start()
  {
    this.LocalPos = this.ButtonVisual.localPosition;
    this.Interactable = this.GetComponent<XRBaseInteractable>();
    this.Interactable.hoverEntered.AddListener(new UnityAction<HoverEnterEventArgs>(this.Follow));
    this.Interactable.hoverExited.AddListener(new UnityAction<HoverExitEventArgs>(this.Reset));
    this.Interactable.selectEntered.AddListener(new UnityAction<SelectEnterEventArgs>(this.Freeze));
  }

  public void Follow(BaseInteractionEventArgs hover)
  {
    if (!(hover.interactorObject is XRPokeInteractor))
      return;
    XRPokeInteractor interactorObject = (XRPokeInteractor) hover.interactorObject;
    this.ButtonIsFollowStatus = true;
    this.Stop = false;
    this.ButtonPokeTransform = interactorObject.attachTransform;
    this.ButtonMove = this.ButtonVisual.position - this.ButtonPokeTransform.position;
    if ((double) Vector3.Angle(this.ButtonMove, this.ButtonVisual.TransformDirection(this.ElementLocalAxis)) > (double) this.ButtonFollowAngle)
    {
      this.ButtonIsFollowStatus = false;
      this.Stop = true;
    }
  }

  public void Reset(BaseInteractionEventArgs hover)
  {
    if (!(hover.interactorObject is XRPokeInteractor))
      return;
    this.ButtonIsFollowStatus = false;
    this.Stop = false;
  }

  public void Freeze(BaseInteractionEventArgs hover)
  {
    if (!(hover.interactorObject is XRPokeInteractor))
      return;
    this.Stop = true;
    if ((Object) this.Element != (Object) null)
      Object.Instantiate<GameObject>(this.Element, this.ElementSpawnpoint, Quaternion.identity);
  }

  private void Update()
  {
    if (this.Stop)
      return;
    if (this.ButtonIsFollowStatus)
      this.ButtonVisual.position = this.ButtonVisual.TransformPoint(Vector3.Project(this.ButtonVisual.InverseTransformPoint(this.ButtonPokeTransform.position + this.ButtonMove), this.ElementLocalAxis));
    else
      this.ButtonVisual.localPosition = Vector3.Lerp(this.ButtonVisual.localPosition, this.LocalPos, Time.deltaTime * this.ElementBtnResetSpeed);
  }
}
