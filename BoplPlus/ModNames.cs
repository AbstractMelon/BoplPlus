using UnityEngine;
using TMPro;
using System.Reflection;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Collections;

namespace BoplPlus
{
    public static class ModnamesStuff
    {

        public static GameObject mainMenuOverlayObject;

        public static void RunMainMenuModifications()
        {
            // Create a new canvas
            mainMenuOverlayObject = new GameObject();
            Canvas canvas = mainMenuOverlayObject.AddComponent<Canvas>();
            CanvasScaler scaler = mainMenuOverlayObject.AddComponent<CanvasScaler>();

            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            canvas.worldCamera = Camera.current;

            canvas.sortingLayerName = "behind Walls Infront of everything else";
            canvas.sortingOrder = 1;

            scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

            // create the version info GameObject and set the parent to the canvas
            GameObject versionInfoText = new GameObject("Splotch_Version_info", typeof(RectTransform), typeof(TextMeshProUGUI));
            TextMeshProUGUI textComponent = versionInfoText.GetComponent<TextMeshProUGUI>();
            versionInfoText.transform.SetParent(canvas.transform);

            // set the text to the version info
            AssemblyName name = Assembly.GetExecutingAssembly().GetName();

            textComponent.text = "hello";

            // change settings
            // textComponent.font = LocalizedText.localizationTable.GetFont(Settings.Get().Language, false);
            textComponent.color = Color.Lerp(Color.blue, Color.black, 0.6f);

            // not sure what this is I stole it from WackyModer lol  -- Melon, It stops the text from being clickced and blocking the buttons I think
            textComponent.raycastTarget = false;

            textComponent.fontSize = 13;
            textComponent.alignment = TextAlignmentOptions.BottomRight;

            // set the position of the text to the bottom right of the screen
            RectTransform rectTransform = versionInfoText.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(1f, 0f);
            rectTransform.anchorMax = new Vector2(1f, 0f);
            rectTransform.pivot = new Vector2(1, 0);
            rectTransform.sizeDelta = new Vector2(1200, 0);
            rectTransform.anchoredPosition = new Vector2(-10, 30);
        }
    }
}
