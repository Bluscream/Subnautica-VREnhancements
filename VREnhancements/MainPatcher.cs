using System;
using System.Linq;
using FMODUnity;
using Harmony;
using RootMotion.FinalIK;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;

namespace VREnhancements
{
	// Token: 0x02000002 RID: 2
	public class MainPatcher
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static void Patch()
		{
			if (XRSettings.enabled)
			{
				try
				{
					MainPatcher.harmony = HarmonyInstance.Create("com.whotnt.subnautica.vrenhancements.mod");
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(GameOptions), "GetVrAnimationMode", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("GetVrAnimationMode_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(uGUI_OptionsPanel), "AddGeneralTab", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("AddGeneralTab_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(uGUI_TabbedControlsPanel), "AddTab", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("AddTab_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(GameSettings), "SerializeVRSettings", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("SerializeVRSettings_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(MainCameraControl), "Update", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("MCC_Update_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(Vehicle), "OnPilotModeBegin", null, null), new HarmonyMethod(typeof(MainPatcher).GetMethod("OnPilotModeBegin_Prefix")), null, null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(Vehicle), "OnPilotModeEnd", null, null), new HarmonyMethod(typeof(MainPatcher).GetMethod("OnPilotModeEnd_Prefix")), null, null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(Subtitles), "Start", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("SubtitlesStart_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(PDA), "get_ui", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("PDA_getui_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(SNCameraRoot), "SetFov", null, null), new HarmonyMethod(typeof(MainPatcher).GetMethod("SNCamSetFov_Prefix")), null, null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(FPSInputModule), "GetCursorScreenPosition", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("GetCursorScreenPosition_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(FPSInputModule), "UpdateCursor", null, null), new HarmonyMethod(typeof(MainPatcher).GetMethod("UpdateCursor_Prefix")), null, null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(FPSInputModule), "UpdateCursor", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("UpdateCursor_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(HandReticle), "LateUpdate", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("HandRLateUpdate_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(Player), "Awake", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("Player_Awake_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(uGUI_SceneHUD), "Update", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("SceneHUD_Update_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(SNCameraRoot), "Awake", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("SNCam_Awake_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(uGUI_SceneLoading), "Init", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("Init_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(CyclopsExternalCams), "EnterCameraView", null, null), new HarmonyMethod(typeof(MainPatcher).GetMethod("EnterCameraView_Prefix")), null, null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(uGUI_BuilderMenu), "Close", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("BuilderMenuClose_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(uGUI_CameraDrone), "Awake", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("CameraDroneAwake_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(uGUI_CameraCyclops), "Awake", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("CameraCyclopsAwake_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(uGUI_MainMenu), "Awake", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("MainMenuAwake_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(PlayerCinematicController), "SkipCinematic", null, null), new HarmonyMethod(typeof(MainPatcher).GetMethod("SkipCinematic_Prefix")), null, null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(IngameMenu), "Awake", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("IGM_Awake_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(MainGameController), "ResetOrientation", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("ResetOrientation_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(PDA), "Open", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("PDA_Open_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(PDA), "Close", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("PDA_Close_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(PDA), "Update", null, null), new HarmonyMethod(typeof(MainPatcher).GetMethod("PDA_Update_Prefix")), null, null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(ArmsController), "Reconfigure", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("Reconfigure_Postfix")), null);
					MainPatcher.harmony.PatchVoid(AccessTools.Method(typeof(ArmsController), "Start", null, null), null, new HarmonyMethod(typeof(MainPatcher).GetMethod("ArmsCon_Start_Postfix")), null);
				}
				catch (Exception ex)
				{
					Debug.Log("Error with VREnhancements patching: " + ex.Message);
				}
			}
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000027D4 File Offset: 0x000009D4
		public static void GetVrAnimationMode_Postfix(ref bool __result)
		{
			__result = !GameOptions.enableVrAnimations;
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000027E0 File Offset: 0x000009E0
		public static void AddGeneralTab_Postfix(uGUI_OptionsPanel __instance)
		{
			__instance.AddHeading(MainPatcher.tabIndex, "Additional VR Options");
			__instance.AddToggleOption(MainPatcher.tabIndex, "Enable VR Animations", GameOptions.enableVrAnimations, delegate(bool v)
			{
				GameOptions.enableVrAnimations = v;
				if (Player.main != null)
				{
					Player.main.playerAnimator.SetBool("vr_active", !v);
				}
			});
			__instance.AddToggleOption(MainPatcher.tabIndex, "Look Down for HUD", MainPatcher.lookDownHUD, delegate(bool v)
			{
				MainPatcher.lookDownHUD = v;
				if (!v && MainPatcher.quickSlots != null && MainPatcher.barsPanel != null)
				{
					MainPatcher.quickSlots.transform.localScale = Vector3.one;
					MainPatcher.barsPanel.transform.localScale = Vector3.one;
				}
			});
			__instance.AddSliderOption(MainPatcher.tabIndex, "Walk Speed(Default: 60%)", VROptions.groundMoveScale * 100f, 50f, 100f, 60f, delegate(float v)
			{
				VROptions.groundMoveScale = v / 100f;
			});
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000028B0 File Offset: 0x00000AB0
		public static void AddTab_Postfix(int __result, string label)
		{
			if (label.Equals("General"))
			{
				MainPatcher.tabIndex = __result;
			}
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000028C8 File Offset: 0x00000AC8
		public static void SerializeVRSettings_Postfix(GameSettings.ISerializer serializer)
		{
			GameOptions.enableVrAnimations = serializer.Serialize("VR/EnableVRAnimations", GameOptions.enableVrAnimations);
			VROptions.groundMoveScale = serializer.Serialize("VR/GroundMoveScale", VROptions.groundMoveScale);
			MainPatcher.lookDownHUD = serializer.Serialize("VR/LookDownHUD", MainPatcher.lookDownHUD);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002914 File Offset: 0x00000B14
		public static void MCC_Update_Postfix(MainCameraControl __instance)
		{
			Transform forwardReference = __instance.GetComponentInParent<PlayerController>().forwardReference;
			if (MainPatcher.pdaIsClosing && MainPatcher.pdaCloseTimer < MainPatcher.pdaCloseDelay)
			{
				MainPatcher.pdaCloseTimer += Time.deltaTime;
			}
			else if (MainPatcher.pdaCloseTimer >= MainPatcher.pdaCloseDelay || (MainPatcher.pdaIsClosing && Player.main.GetPDA().state == null))
			{
				MainPatcher.pdaIsClosing = false;
				MainPatcher.pdaCloseTimer = 0f;
			}
			if (Player.main.GetPDA().state == 3)
			{
				MainPatcher.pdaIsClosing = true;
			}
			if (Player.main.GetPDA().state == 1 && !MainPatcher.pdaIsClosing)
			{
				if (Player.main.motorMode == 2)
				{
					__instance.viewModel.transform.localPosition = __instance.viewModel.transform.parent.worldToLocalMatrix.MultiplyPoint(forwardReference.position + forwardReference.up * MainPatcher.seaglideYOffset + forwardReference.forward * MainPatcher.seaglideZOffset);
					return;
				}
				if (Player.main.transform.position.y < Ocean.main.GetOceanLevel() + 1f && !Player.main.IsInside() && !Player.main.precursorOutOfWater)
				{
					string name = Player.main.playerAnimator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
					if (name == "Back_lean" || name == "view_surface_swim_forward")
					{
						__instance.viewModel.transform.localPosition = __instance.viewModel.transform.parent.worldToLocalMatrix.MultiplyPoint(forwardReference.position + __instance.viewModel.transform.up * (MainPatcher.swimYOffset - 0.1f) + __instance.viewModel.transform.forward * (MainPatcher.swimZOffset - 0.1f));
						return;
					}
					__instance.viewModel.transform.localPosition = __instance.viewModel.transform.parent.worldToLocalMatrix.MultiplyPoint(forwardReference.position + __instance.viewModel.transform.up * MainPatcher.swimYOffset + __instance.viewModel.transform.forward * MainPatcher.swimZOffset);
					return;
				}
				else if (!__instance.cinematicMode && Player.main.motorMode != 3 && Player.main.motorMode != 2)
				{
					if (Player.main.movementSpeed == 0f)
					{
						__instance.viewModel.transform.localPosition = __instance.viewModel.transform.parent.worldToLocalMatrix.MultiplyPoint(forwardReference.position + Vector3.up * MainPatcher.defaultYOffset + new Vector3(forwardReference.forward.x, 0f, forwardReference.forward.z).normalized * MainPatcher.defaultZOffset);
						return;
					}
					__instance.viewModel.transform.localPosition = __instance.viewModel.transform.parent.worldToLocalMatrix.MultiplyPoint(forwardReference.position + Vector3.up * MainPatcher.defaultYOffset + new Vector3(forwardReference.forward.x, 0f, forwardReference.forward.z).normalized * (MainPatcher.defaultZOffset - 0.1f));
				}
			}
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002CD9 File Offset: 0x00000ED9
		public static bool OnPilotModeBegin_Prefix(Vehicle __instance)
		{
			if (__instance.mainAnimator)
			{
				__instance.mainAnimator.SetBool("vr_active", GameOptions.GetVrAnimationMode());
			}
			return true;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002CD9 File Offset: 0x00000ED9
		public static bool OnPilotModeEnd_Prefix(Vehicle __instance)
		{
			if (__instance.mainAnimator)
			{
				__instance.mainAnimator.SetBool("vr_active", GameOptions.GetVrAnimationMode());
			}
			return true;
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002CFE File Offset: 0x00000EFE
		public static void SubtitlesStart_Postfix(Subtitles __instance)
		{
			__instance.popup.oy = 800f;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002D10 File Offset: 0x00000F10
		public static void PDA_getui_Postfix(PDA __instance)
		{
			uGUI_CanvasScaler component = Traverse.Create(__instance).Field("screen").GetValue<GameObject>().GetComponent<uGUI_CanvasScaler>();
			__instance.transform.localScale = new Vector3(MainPatcher.pdaScale, MainPatcher.pdaScale, 1f);
			component.transform.localScale = Vector3.one * MainPatcher.screenScale;
			component.SetAnchor(__instance.screenAnchor);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002D7B File Offset: 0x00000F7B
		public static bool SNCamSetFov_Prefix()
		{
			return false;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002D80 File Offset: 0x00000F80
		public static void GetCursorScreenPosition_Postfix(FPSInputModule __instance, ref Vector2 __result)
		{
			if (XRSettings.enabled)
			{
				if (Cursor.lockState == 1)
				{
					__result = GraphicsUtil.GetScreenSize() * 0.5f;
					return;
				}
				if (!MainPatcher.actualGazedBasedCursor)
				{
					__result = new Vector2(Input.mousePosition.x / (float)Screen.width * GraphicsUtil.GetScreenSize().x, Input.mousePosition.y / (float)Screen.height * GraphicsUtil.GetScreenSize().y);
				}
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002DFC File Offset: 0x00000FFC
		public static void UpdateCursor_Prefix()
		{
			MainPatcher.actualGazedBasedCursor = VROptions.gazeBasedCursor;
			if (Cursor.lockState != 1)
			{
				VROptions.gazeBasedCursor = true;
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002E18 File Offset: 0x00001018
		public static void UpdateCursor_Postfix(FPSInputModule __instance)
		{
			VROptions.gazeBasedCursor = MainPatcher.actualGazedBasedCursor;
			Canvas canvas = __instance._cursor.GetComponentInChildren<Graphic>().canvas;
			RaycastResult value = Traverse.Create(__instance).Field("lastRaycastResult").GetValue<RaycastResult>();
			if (canvas && value.isValid)
			{
				canvas.sortingLayerID = value.sortingLayer;
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002E73 File Offset: 0x00001073
		public static void HandRLateUpdate_Postfix(HandReticle __instance)
		{
			__instance.transform.position = new Vector3(0f, 0f, __instance.transform.position.z);
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002E9F File Offset: 0x0000109F
		public static void Player_Awake_Postfix(uGUI_SceneHUD __instance)
		{
			MainPatcher.barsPanel = GameObject.Find("BarsPanel");
			MainPatcher.quickSlots = GameObject.Find("QuickSlots");
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002EC0 File Offset: 0x000010C0
		public static void SceneHUD_Update_Postfix(uGUI_SceneHUD __instance)
		{
			if (MainPatcher.lookDownHUD && MainPatcher.quickSlots != null && MainPatcher.barsPanel != null)
			{
				if (Player.main != null && Vector3.Angle(MainCamera.camera.transform.forward, Player.main.transform.up) < 120f)
				{
					MainPatcher.quickSlots.transform.localScale = Vector3.zero;
					MainPatcher.barsPanel.transform.localScale = Vector3.zero;
					return;
				}
				MainPatcher.quickSlots.transform.localScale = Vector3.one;
				MainPatcher.barsPanel.transform.localScale = Vector3.one;
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002F80 File Offset: 0x00001180
		public static void SNCam_Awake_Postfix(SNCameraRoot __instance)
		{
			GameObject gameObject = __instance.transform.Find("MainCamera").gameObject;
			if (gameObject != null)
			{
				Object.DestroyImmediate(__instance.gameObject.GetComponent<AudioListener>());
				Object.DestroyImmediate(__instance.gameObject.GetComponent<StudioListener>());
				gameObject.AddComponent<StudioListener>();
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002FD4 File Offset: 0x000011D4
		public static void Init_Postfix(uGUI_SceneLoading __instance)
		{
			Image image = null;
			RectTransform rectTransform = null;
			RectTransform rectTransform2 = null;
			try
			{
				image = __instance.loadingBackground.transform.Find("LoadingArtwork").GetComponent<Image>();
				rectTransform = __instance.loadingText.gameObject.GetComponent<RectTransform>();
				rectTransform2 = __instance.loadingBackground.transform.Find("Logo").GetComponent<RectTransform>();
			}
			catch (Exception ex)
			{
				Debug.Log("VR Enhancements Mod: Error finding Loading Screen Elements: " + ex.Message);
				return;
			}
			Vector2 vector;
			vector..ctor(0.5f, 0.5f);
			if (image != null && rectTransform != null && rectTransform2 != null)
			{
				image.sprite = null;
				image.color = Color.black;
				rectTransform2.anchorMin = vector;
				rectTransform2.anchorMax = vector;
				rectTransform2.pivot = vector;
				rectTransform2.anchoredPosition = Vector2.zero;
				rectTransform.anchorMin = vector;
				rectTransform.anchorMax = vector;
				rectTransform.pivot = vector;
				rectTransform.anchoredPosition = new Vector2(0f, -200f);
				rectTransform.sizeDelta = new Vector2(400f, 100f);
				rectTransform.gameObject.GetComponent<Text>().alignment = 4;
			}
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00003114 File Offset: 0x00001314
		public static bool EnterCameraView_Prefix(CyclopsExternalCams __instance)
		{
			Traverse.Create(__instance).Field("usingCamera").SetValue(true);
			InputHandlerStack.main.Push(__instance);
			Player main = Player.main;
			MainCameraControl.main.enabled = false;
			Player.main.SetHeadVisible(true);
			__instance.cameraLight.enabled = true;
			Traverse.Create(__instance).Method("ChangeCamera", new object[]
			{
				0
			}).GetValue();
			if (__instance.lightingPanel)
			{
				__instance.lightingPanel.TempTurnOffFloodlights();
			}
			return false;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000031AE File Offset: 0x000013AE
		public static void BuilderMenuClose_Postfix()
		{
			MainCameraControl.main.ResetLockedVRViewModelAngle();
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000031BC File Offset: 0x000013BC
		public static void CameraDroneAwake_Postfix(uGUI_CameraDrone __instance)
		{
			GameObject gameObject = __instance.transform.Find("Content").Find("CameraScannerRoom").gameObject;
			if (gameObject != null)
			{
				gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.6f, 0.6f, 1f);
				return;
			}
			Debug.Log("VR Enhancements Mod: Cannot set Drone UI scale. Drone Camera Not Found");
		}

		// Token: 0x06000017 RID: 23 RVA: 0x0000321C File Offset: 0x0000141C
		public static void CameraCyclopsAwake_Postfix(uGUI_CameraCyclops __instance)
		{
			GameObject gameObject = __instance.transform.Find("Content").Find("CameraCyclops").gameObject;
			if (gameObject != null)
			{
				gameObject.GetComponent<RectTransform>().localScale = new Vector3(0.7f, 0.7f, 1f);
				return;
			}
			Debug.Log("VR Enhancements Mod: Cannot set CyclopsCamera UI scale. Cyclops Camera Not Found");
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000327C File Offset: 0x0000147C
		public static void MainMenuAwake_Postfix(uGUI_MainMenu __instance)
		{
			GameObject gameObject = __instance.transform.Find("Panel").Find("MainMenu").gameObject;
			if (gameObject != null)
			{
				gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0f, 385f);
				return;
			}
			Debug.Log("VR Enhancements Mod: Cannot set Main Menu Postions. MainMenu Not Found");
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000032D8 File Offset: 0x000014D8
		public static bool SkipCinematic_Prefix(PlayerCinematicController __instance, Player player)
		{
			Traverse.Create(__instance).Field("player").SetValue(player);
			if (player)
			{
				Transform component = player.GetComponent<Transform>();
				Transform component2 = MainCameraControl.main.GetComponent<Transform>();
				if (Traverse.Create(__instance).Method("UseEndTransform", new object[0]).GetValue<bool>())
				{
					player.playerController.SetEnabled(false);
					component.position = __instance.endTransform.position;
					component.rotation = __instance.endTransform.rotation;
					component2.rotation = component.rotation;
				}
				player.playerController.SetEnabled(true);
				player.cinematicModeActive = false;
			}
			if (__instance.informGameObject != null)
			{
				__instance.informGameObject.SendMessage("OnPlayerCinematicModeEnd", __instance, 1);
			}
			return false;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000033A4 File Offset: 0x000015A4
		public static void IGM_Awake_Postfix(IngameMenu __instance)
		{
			if (__instance != null && MainPatcher.recenterVRButton == null)
			{
				MainPatcher.recenterVRButton = Object.Instantiate<Button>(__instance.quitToMainMenuButton.transform.parent.GetChild(0).gameObject.GetComponent<Button>(), __instance.quitToMainMenuButton.transform.parent);
				MainPatcher.recenterVRButton.transform.SetSiblingIndex(1);
				MainPatcher.recenterVRButton.name = "RecenterVR";
				MainPatcher.recenterVRButton.onClick.RemoveAllListeners();
				MainPatcher.recenterVRButton.onClick.AddListener(delegate()
				{
					VRUtil.Recenter();
				});
				foreach (Text text in MainPatcher.recenterVRButton.GetComponents<Text>().Concat(MainPatcher.recenterVRButton.GetComponentsInChildren<Text>()))
				{
					text.text = "Recenter VR";
				}
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000034B8 File Offset: 0x000016B8
		public static void ResetOrientation_Postfix(MainGameController __instance)
		{
			MainCameraControl.main.cameraOffsetTransform.localPosition = new Vector3(0f, 0f, 0.15f);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000034E0 File Offset: 0x000016E0
		public static void PDA_Open_Postfix(PDA __instance, bool __result)
		{
			if (__result)
			{
				if (!MainPatcher.leftHandTarget)
				{
					MainPatcher.leftHandTarget = new GameObject();
				}
				MainPatcher.leftHandTarget.transform.parent = Player.main.camRoot.transform;
				if (Player.main.motorMode != 3)
				{
					MainPatcher.leftHandTarget.transform.localPosition = MainPatcher.leftHandTarget.transform.parent.transform.InverseTransformPoint(Player.main.playerController.forwardReference.position + Player.main.armsController.transform.right * MainPatcher.pdaXOffset + Vector3.up * -0.15f + new Vector3(Player.main.armsController.transform.forward.x, 0f, Player.main.armsController.transform.forward.z).normalized * MainPatcher.pdaZOffset);
				}
				else
				{
					MainPatcher.leftHandTarget.transform.localPosition = MainPatcher.leftHandTarget.transform.parent.transform.InverseTransformPoint(MainPatcher.leftHandTarget.transform.parent.transform.position + MainPatcher.leftHandTarget.transform.parent.transform.right * MainPatcher.pdaXOffset + MainPatcher.leftHandTarget.transform.parent.transform.forward * MainPatcher.pdaZOffset + MainPatcher.leftHandTarget.transform.parent.transform.up * -0.15f);
				}
				MainPatcher.leftHandTarget.transform.rotation = Player.main.armsController.transform.rotation * Quaternion.Euler(MainPatcher.pdaXRot, MainPatcher.pdaYRot, MainPatcher.pdaZRot);
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x000036F7 File Offset: 0x000018F7
		public static void PDA_Close_Postfix()
		{
			if (MainPatcher.leftHandTarget)
			{
				Object.Destroy(MainPatcher.leftHandTarget);
			}
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000370F File Offset: 0x0000190F
		public static bool PDA_Update_Prefix()
		{
			if (MainPatcher.leftHandTarget)
			{
				MainPatcher.myIK.solver.leftHandEffector.target = MainPatcher.leftHandTarget.transform;
			}
			return true;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x0000373C File Offset: 0x0000193C
		public static void Reconfigure_Postfix(ArmsController __instance)
		{
			Traverse.Create(__instance).Field("reconfigureWorldTarget").SetValue(false);
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000375A File Offset: 0x0000195A
		public static void ArmsCon_Start_Postfix(ArmsController __instance)
		{
			MainPatcher.myIK = Traverse.Create(__instance).Field("ik").GetValue<FullBodyBipedIK>();
		}

		// Token: 0x04000001 RID: 1
		private static HarmonyInstance harmony;

		// Token: 0x04000002 RID: 2
		private static int tabIndex;

		// Token: 0x04000003 RID: 3
		private static float pdaScale = 1.45f;

		// Token: 0x04000004 RID: 4
		private static float screenScale = 0.0003f;

		// Token: 0x04000005 RID: 5
		private static float defaultZOffset = 0.17f;

		// Token: 0x04000006 RID: 6
		private static float defaultYOffset = 0f;

		// Token: 0x04000007 RID: 7
		private static float pdaXOffset = -0.35f;

		// Token: 0x04000008 RID: 8
		private static float pdaZOffset = 0.28f;

		// Token: 0x04000009 RID: 9
		private static float seaglideZOffset = 0.1f;

		// Token: 0x0400000A RID: 10
		private static float seaglideYOffset = -0.15f;

		// Token: 0x0400000B RID: 11
		private static float swimZOffset = 0.08f;

		// Token: 0x0400000C RID: 12
		private static float swimYOffset = -0.02f;

		// Token: 0x0400000D RID: 13
		private static float pdaXRot = 220f;

		// Token: 0x0400000E RID: 14
		private static float pdaYRot = 30f;

		// Token: 0x0400000F RID: 15
		private static float pdaZRot = 75f;

		// Token: 0x04000010 RID: 16
		private static GameObject quickSlots;

		// Token: 0x04000011 RID: 17
		private static GameObject barsPanel;

		// Token: 0x04000012 RID: 18
		private static Button recenterVRButton;

		// Token: 0x04000013 RID: 19
		private static GameObject leftHandTarget;

		// Token: 0x04000014 RID: 20
		private static FullBodyBipedIK myIK;

		// Token: 0x04000015 RID: 21
		public static bool lookDownHUD = false;

		// Token: 0x04000016 RID: 22
		private static float pdaCloseTimer = 0f;

		// Token: 0x04000017 RID: 23
		private static bool pdaIsClosing = false;

		// Token: 0x04000018 RID: 24
		private static float pdaCloseDelay = 1f;

		// Token: 0x04000019 RID: 25
		private static bool actualGazedBasedCursor;
	}
}
