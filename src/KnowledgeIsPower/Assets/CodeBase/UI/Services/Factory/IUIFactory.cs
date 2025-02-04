﻿using System.Threading.Tasks;
using CodeBase.Infrastructure.Services;

namespace CodeBase.UI.Services.Factory
{
  public interface IUIFactory : IService
  {
    void CreateShop();
    Task CreateUIRoot();
  }
}