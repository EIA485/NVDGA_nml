using System.Linq;
using MelonLoader;
using UnityEngine;



namespace POCThatRendererCanBeChangedDumpass
{
    public class SettingsOption : MelonMod
    {

        int iSetting = 1;
        int iPrevSetting = 1;
        private float fGetValueFromTextFile(int iFile)
        {
            switch (iFile)
            {
                case 0:
                    string strLine = System.IO.File.ReadLines("NVGDAReprojectionSettings.txt").First();
                    return float.Parse(strLine);
                case 1:
                    string strLine2 = System.IO.File.ReadLines("NVGDAMaxFramerate.txt").First();
                    return float.Parse(strLine2);
                default:
                    return 99;
            }
        }

        public float fMinReprojectionValue = 45.0f;
        float[] flFpsForSetting = new float[]
        {
            90, //fpsvismax
            75, //fpsvishigh
            50, //fpsvismed
            35, //fpsvislow
            30  //fpsvisEMERGENCY
        };

        float fTargetFramerate = 90;
        float[] fKeptFrameDataForComparison = new float[10]; //keeps info for 10 checks, and compares if performance got better or worse, if better, put higher graphics up, if same - keep at low graphics.
        public float fCurrentFps;

        public override void OnApplicationLateStart()
        {
            fMinReprojectionValue = fGetValueFromTextFile(0);
            fTargetFramerate = fGetValueFromTextFile(1);
            LoggerInstance.Msg("Dynamic Visuals Adjuster is starting.");
            LoggerInstance.Msg("Min reprojection frames are set to: " + fMinReprojectionValue.ToString() + " frames.");
            LoggerInstance.Msg("Desired max framerate is set to: " + fTargetFramerate.ToString() + " frames.");
            ChangeSettingsUltimate3090SexySuperVideoCardModeThatYouWillNotBuyBecauseOfMiners(); //initial optimization, default shadows are too high res and too performance heavy anyway and they don't look very different compared to that setting.
            LoggerInstance.Msg("\n\nInitial Set Up. " +
                "\n\nMeasuring frames. This will take about a minute to kick in... " +
                "\n\nWant more frames? Disable SSAO using a third party SSAO disabler.\n\n");
            LoggerInstance.Msg("\n\n!!!Warning!!!: " +
                "\n\nNeos will likely change it's renderer eventually, making this plugin OBSOLETE!!! " +
                "\n\nKeep that in mind for the inevitable end of the world." +
                "\n\nThis plugin also can not be used on the HEADLESS client.\n\n\n\n");
            flFpsForSetting[0] = fTargetFramerate;
        }



        void ChangeSettingsPotato()
        {
            bRetainReprojection = true;
            LoggerInstance.Msg("MAJOR instability detected. Keeping last good framerate setting and increasing wait time...");
            flTimer = 30.0f;
            flInstabilityTimer = 30.0f;
            LoggerInstance.Msg("Emergency Settings to prevent motion sickness in any possible way.");
            QualitySettings.SetQualityLevel(0);
            QualitySettings.masterTextureLimit = 3;
            QualitySettings.shadowResolution = ShadowResolution.Low;
            QualitySettings.antiAliasing = 0;
            QualitySettings.pixelLightCount = 3;
            QualitySettings.shadowDistance = 1;
            QualitySettings.shadowCascades = 0;
            QualitySettings.lodBias = 1;
            QualitySettings.particleRaycastBudget = 32;
            QualitySettings.softParticles = false;
            QualitySettings.realtimeReflectionProbes = false;
            QualitySettings.streamingMipmapsActive = true;
            QualitySettings.streamingMipmapsMemoryBudget = 128;
            QualitySettings.streamingMipmapsAddAllCameras = false;

            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
        }

        void ChangeSettingsLow()
        {
            LoggerInstance.Msg("Low quality settings, your framerate might've dipped.");
            QualitySettings.SetQualityLevel(0);
            QualitySettings.masterTextureLimit = 2;
            QualitySettings.shadowResolution = ShadowResolution.Low;
            QualitySettings.antiAliasing = 0;
            QualitySettings.pixelLightCount = 16;
            QualitySettings.shadowDistance = 128;
            QualitySettings.shadowCascades = 2;
            QualitySettings.lodBias = 2;
            QualitySettings.particleRaycastBudget = 64;
            QualitySettings.softParticles = false;
            QualitySettings.realtimeReflectionProbes = false;
            QualitySettings.streamingMipmapsActive = true;
            QualitySettings.streamingMipmapsMemoryBudget = 256;
            QualitySettings.streamingMipmapsAddAllCameras = false;

            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Disable;
        }
        void ChangeSettingsNormal()
        {
            LoggerInstance.Msg("Normal quality settings, your framerate might've dipped.");
            QualitySettings.SetQualityLevel(1);
            QualitySettings.masterTextureLimit = 1;
            QualitySettings.shadowResolution = ShadowResolution.Medium;
            QualitySettings.antiAliasing = 0;
            QualitySettings.pixelLightCount = 32;
            QualitySettings.shadowDistance = 512;
            QualitySettings.shadowCascades = 2;
            QualitySettings.lodBias = 2;
            QualitySettings.particleRaycastBudget = 64;
            QualitySettings.softParticles = false;
            QualitySettings.realtimeReflectionProbes = true;
            QualitySettings.streamingMipmapsActive = true;
            QualitySettings.streamingMipmapsMemoryBudget = 512;
            QualitySettings.streamingMipmapsAddAllCameras = true;
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.Enable;
        }
        void ChangeSettingsHigh()
        {
            LoggerInstance.Msg("Set to the high setting.");
            QualitySettings.SetQualityLevel(2);
            QualitySettings.masterTextureLimit = 1;
            QualitySettings.antiAliasing = 0;
            QualitySettings.pixelLightCount = 64;
            QualitySettings.shadowDistance = 1024;
            QualitySettings.shadowCascades = 2;
            QualitySettings.lodBias = 2;
            QualitySettings.particleRaycastBudget = 128;
            QualitySettings.softParticles = false;
            QualitySettings.realtimeReflectionProbes = true;
            QualitySettings.streamingMipmapsActive = true;
            QualitySettings.streamingMipmapsMemoryBudget = 1024;
            QualitySettings.streamingMipmapsAddAllCameras = true;
            QualitySettings.masterTextureLimit = 0;
            QualitySettings.shadowResolution = ShadowResolution.High;
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
        }

        void ChangeSettingsUltimate3090SexySuperVideoCardModeThatYouWillNotBuyBecauseOfMiners()
        {
            // LoggerInstance.Msg("Set to the highest possible settings.");
            QualitySettings.SetQualityLevel(3);
            QualitySettings.antiAliasing = 0;
            QualitySettings.pixelLightCount = 128;
            QualitySettings.shadowDistance = 1024;
            QualitySettings.shadowCascades = 4;
            QualitySettings.lodBias = 2;
            QualitySettings.particleRaycastBudget = 256;
            QualitySettings.softParticles = true;
            QualitySettings.realtimeReflectionProbes = true;
            QualitySettings.streamingMipmapsActive = true;
            QualitySettings.streamingMipmapsMemoryBudget = 2048;
            QualitySettings.streamingMipmapsAddAllCameras = true;
            QualitySettings.masterTextureLimit = 0;
            QualitySettings.shadowResolution = ShadowResolution.VeryHigh;
            QualitySettings.anisotropicFiltering = AnisotropicFiltering.ForceEnable;
        }

        float flTimer = 0;
        float flInstabilityTimer = 0;
        int iSavedSlot;
        int iHowMany;

        bool bRetainReprojection;
        public override void OnUpdate()
        {
            fCurrentFps = 1 / Time.deltaTime;
            if (flInstabilityTimer <= 0)
            {
                if (iSavedSlot < 9)
                {
                    iSavedSlot++;
                }
                else
                {
                    iHowMany = 0;
                    for (int i = 0; i < fKeptFrameDataForComparison.Length; i++)
                    {
                        if (bRetainReprojection == false)
                        {
                            if (fKeptFrameDataForComparison[i] < fTargetFramerate - 5) //start kicking in auto settings if the game is below target framerate.
                            {
                                iHowMany++;

                            }

                        }
                        else
                        {
                            if (fKeptFrameDataForComparison[i] < fMinReprojectionValue - 3)
                            {
                                iHowMany++;

                            }
                        }
                    }
                    iSavedSlot = 0;
                }
                if (iHowMany != 0)
                {
                    if (bRetainReprojection == false)
                    {
                        LoggerInstance.Msg(iHowMany.ToString() + "0% instability.");
                    }
                    else LoggerInstance.Msg(iHowMany.ToString() + "0% reprojection mode.");
                }
                if (bRetainReprojection == true)
                {
                    flInstabilityTimer = 10.0f;
                }
                else flInstabilityTimer = 3.0f;
            }

            if (flTimer <= 0)
            {
                fKeptFrameDataForComparison[iSavedSlot] = fCurrentFps;
                if(fCurrentFps > fMinReprojectionValue + 2)
                {
                    bRetainReprojection = false;
                }
                if (iHowMany > 4)
                {
                    LoggerInstance.Msg("Minor Instability detected.");
                    ChangeSettings();
                }
                else if (fCurrentFps >= fTargetFramerate - 5 && bRetainReprojection == false)
                {
                    ChangeSettingsUltimate3090SexySuperVideoCardModeThatYouWillNotBuyBecauseOfMiners();
                }
                flTimer = 5.0f;

            }

            if (flTimer > 0)
            {
                flTimer -= Time.deltaTime;
            }
            if (flInstabilityTimer > 0)
            {
                flInstabilityTimer -= Time.deltaTime;
            }
        }



        void ChangeSettings()
        {
            if (fCurrentFps < Mathf.Infinity && fCurrentFps > flFpsForSetting[0] - 1) //using Mathf.Infinity here for unlocked framerate, so if your headset runs on higher, it wont break.
            {
                iSetting = 4;
            }
            else if (fCurrentFps < flFpsForSetting[0] && fCurrentFps > flFpsForSetting[1])
            {
                iSetting = 3;
            }
            else if (fCurrentFps < flFpsForSetting[1] && fCurrentFps > flFpsForSetting[2])
            {
                iSetting = 2;
            }
            else if (fCurrentFps < flFpsForSetting[3] && fCurrentFps > flFpsForSetting[4])
            {
                iSetting = 1;
            }
            else if (fCurrentFps < flFpsForSetting[4]) //emergency
            {
                iSetting = 0;
            }

            if (bRetainReprojection == false)
            {
                if (iPrevSetting != iSetting) //prevent from changing the stuff when it's already applied.
                {
                    // LoggerInstance.Msg("Changing settings to:");
                    switch (iSetting)
                    {
                        case 0:
                            ChangeSettingsPotato(); //hehe funni
                            break;
                        case 1:
                            ChangeSettingsLow();
                            break;
                        case 2:
                            ChangeSettingsNormal();
                            break;
                        case 3:
                            ChangeSettingsHigh();
                            break;
                        case 4:
                            ChangeSettingsUltimate3090SexySuperVideoCardModeThatYouWillNotBuyBecauseOfMiners();
                            break;
                    }
                }
                iSavedSlot = 0;
                iHowMany = 0;
                iPrevSetting = iSetting;

            }
            else ChangeSettingsPotato();
        }
    }
}