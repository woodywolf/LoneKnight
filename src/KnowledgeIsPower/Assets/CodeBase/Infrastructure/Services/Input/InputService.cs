﻿using UnityEngine;

namespace CodeBase.Infrastructure.Services.Input
{
  public abstract class InputService : IInputService
  {
    protected const string Horizontal = "Horizontal";
    protected const string Vertical = "Vertical";
    private const string Button = "Fire";

    public abstract Vector2 Axis { get; }

    public bool IsAttackButtonUp() =>
      SimpleInput.GetButtonUp(Button);

    protected static Vector2 SimpleInputAxis() =>
      new Vector2(SimpleInput.GetAxis(Horizontal), SimpleInput.GetAxis(Vertical));

    protected static Vector2 UnityAxis() =>
      new Vector2(UnityEngine.Input.GetAxis(Horizontal), UnityEngine.Input.GetAxis(Vertical));
  }
}