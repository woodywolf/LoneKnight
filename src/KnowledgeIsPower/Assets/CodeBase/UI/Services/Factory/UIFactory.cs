﻿using System.Threading.Tasks;
using CodeBase.Infrastructure.AssetManagement;
using CodeBase.Infrastructure.Services.Ads;
using CodeBase.Infrastructure.Services.IAP;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.StaticData.Windows;
using CodeBase.UI.Services.Windows;
using CodeBase.UI.Windows;
using CodeBase.UI.Windows.Shop;
using UnityEngine;

namespace CodeBase.UI.Services.Factory
{
  public class UIFactory : IUIFactory
  {
    private readonly IAssets _assets;
    private readonly IIAPService _iapService;
    private readonly IStaticDataService _staticData;
    private readonly IPersistentProgressService _progressService;
    private readonly IAdsService _adsService;

    private Transform _uiRoot;

    public UIFactory(
      IAssets assets, 
      IStaticDataService staticData, 
      IPersistentProgressService progressService, 
      IAdsService adsService, IIAPService iapService)
    {
      _assets = assets;
      _staticData = staticData;
      _progressService = progressService;
      _adsService = adsService;
      _iapService = iapService;
    }

    public void CreateShop()
    {
      WindowConfig config = _staticData.ForWindow(WindowId.Shop);
      ShopWindow window = Object.Instantiate(config.Prefab, _uiRoot) as ShopWindow;
      window.Construct(_adsService, _progressService, _iapService, _assets);
    }

    public async Task CreateUIRoot()
    {
      var root = await _assets.Instantiate(AssetAddress.UIRootPath);
      _uiRoot = root.transform;
    }
  }
}