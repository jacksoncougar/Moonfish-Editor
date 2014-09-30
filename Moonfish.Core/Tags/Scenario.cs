//using Moonfish.Model;
//using OpenTK;
//using System;
//using System.Runtime.InteropServices;
//using System.IO;

//namespace Moonfish.Tags
//{
//    [StructLayout(LayoutKind.Sequential, Size = 992, Pack = 4)]
//    [TagClass("scnr")]
//    public partial class Scenario
//    {
//        [TagReference("sbsp")]
//        public TagReference doNotUse;
//        [TagBlockField]
//        public ScenarioSkyReferenceBlock[] skies;
//        public Type type;
//        public Flags flags;
//        [TagBlockField]
//        public ScenarioChildScenarioBlock[] childScenarios;
//        public float localNorth;
//        [TagBlockField]
//        public PredictedResourceBlock[] predictedResources;
//        [TagBlockField]
//        public ScenarioFunctionBlock[] functions;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
//        private byte[] paddingeditorScenarioData;
//        #endregion
//        [TagBlockField]
//        public EditorCommentBlock[] comments;
//        [TagBlockField]
//        public DontUseMeScenarioEnvironmentObjectBlock[] dontUseMeScenarioEnvironmentObjectBlock;
//        [TagBlockField]
//        public ScenarioObjectNamesBlock[] objectNames;
//        [TagBlockField]
//        public ScenarioSceneryBlock[] scenery;
//        [TagBlockField]
//        public ScenarioSceneryPaletteBlock[] sceneryPalette;
//        [TagBlockField]
//        public ScenarioBipedBlock[] bipeds;
//        [TagBlockField]
//        public ScenarioBipedPaletteBlock[] bipedPalette;
//        [TagBlockField]
//        public ScenarioVehicleBlock[] vehicles;
//        [TagBlockField]
//        public ScenarioVehiclePaletteBlock[] vehiclePalette;
//        [TagBlockField]
//        public ScenarioEquipmentBlock[] equipment;
//        [TagBlockField]
//        public ScenarioEquipmentPaletteBlock[] equipmentPalette;
//        [TagBlockField]
//        public ScenarioWeaponBlock[] weapons;
//        [TagBlockField]
//        public ScenarioWeaponPaletteBlock[] weaponPalette;
//        [TagBlockField]
//        public DeviceGroupBlock[] deviceGroups;
//        [TagBlockField]
//        public ScenarioMachineBlock[] machines;
//        [TagBlockField]
//        public ScenarioMachinePaletteBlock[] machinePalette;
//        [TagBlockField]
//        public ScenarioControlBlock[] controls;
//        [TagBlockField]
//        public ScenarioControlPaletteBlock[] controlPalette;
//        [TagBlockField]
//        public ScenarioLightFixtureBlock[] lightFixtures;
//        [TagBlockField]
//        public ScenarioLightFixturePaletteBlock[] lightFixturesPalette;
//        [TagBlockField]
//        public ScenarioSoundSceneryBlock[] soundScenery;
//        [TagBlockField]
//        public ScenarioSoundSceneryPaletteBlock[] soundSceneryPalette;
//        [TagBlockField]
//        public ScenarioLightBlock[] lightVolumes;
//        [TagBlockField]
//        public ScenarioLightPaletteBlock[] lightVolumesPalette;
//        [TagBlockField]
//        public ScenarioProfilesBlock[] playerStartingProfile;
//        [TagBlockField]
//        public ScenarioPlayersBlock[] playerStartingLocations;
//        [TagBlockField]
//        public ScenarioTriggerVolumeBlock[] killTriggerVolumes;
//        [TagBlockField]
//        public RecordedAnimationBlock[] recordedAnimations;
//        [TagBlockField]
//        public ScenarioNetpointsBlock[] netgameFlags;
//        [TagBlockField]
//        public ScenarioNetgameEquipmentBlock[] netgameEquipment;
//        [TagBlockField]
//        public ScenarioStartingEquipmentBlock[] startingEquipment;
//        [TagBlockField]
//        public ScenarioBspSwitchTriggerVolumeBlock[] bSPSwitchTriggerVolumes;
//        [TagBlockField]
//        public ScenarioDecalsBlock[] decals;
//        [TagBlockField]
//        public ScenarioDecalPaletteBlock[] decalsPalette;
//        [TagBlockField]
//        public ScenarioDetailObjectCollectionPaletteBlock[] detailObjectCollectionPalette;
//        [TagBlockField]
//        public StylePaletteBlock[] stylePalette;
//        [TagBlockField]
//        public SquadGroupsBlock[] squadGroups;
//        [TagBlockField]
//        public SquadsBlock[] squads;
//        [TagBlockField]
//        public ZoneBlock[] zones;
//        [TagBlockField]
//        public AiSceneBlock[] missionScenes;
//        [TagBlockField]
//        public CharacterPaletteBlock[] characterPalette;
//        [TagBlockField]
//        public PathfindingDataBlock[] aIPathfindingData;
//        [TagBlockField]
//        public AiAnimationReferenceBlock[] aIAnimationReferences;
//        [TagBlockField]
//        public AiScriptReferenceBlock[] aIScriptReferences;
//        [TagBlockField]
//        public AiRecordingReferenceBlock[] aIRecordingReferences;
//        [TagBlockField]
//        public AiConversationBlock[] aIConversations;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
//        private byte[] paddingscriptSyntaxData;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
//        private byte[] paddingscriptStringData;
//        #endregion
//        [TagBlockField]
//        public HsScriptsBlock[] scripts;
//        [TagBlockField]
//        public HsGlobalsBlock[] globals;
//        [TagBlockField]
//        public HsReferencesBlock[] references;
//        [TagBlockField]
//        public HsSourceFilesBlock[] sourceFiles;
//        [TagBlockField]
//        public CsScriptDataBlock[] scriptingData;
//        [TagBlockField]
//        public ScenarioCutsceneFlagBlock[] cutsceneFlags;
//        [TagBlockField]
//        public ScenarioCutsceneCameraPointBlock[] cutsceneCameraPoints;
//        [TagBlockField]
//        public ScenarioCutsceneTitleBlock[] cutsceneTitles;
//        [TagReference("unic")]
//        public TagReference customObjectNames;
//        [TagReference("unic")]
//        public TagReference chapterTitleText;
//        [TagReference("hmt ")]
//        public TagReference hUDMessages;
//        [TagBlockField]
//        public ScenarioStructureBspReferenceBlock[] structureBsps;
//        [TagBlockField]
//        public ScenarioResourcesBlock[] scenarioResources;
//        [TagBlockField]
//        public OldUnusedStrucurePhysicsBlock[] scenarioResources0;
//        [TagBlockField]
//        public HsUnitSeatBlock[] hsUnitSeats;
//        [TagBlockField]
//        public ScenarioKillTriggerVolumesBlock[] scenarioKillTriggers;
//        [TagBlockField]
//        public SyntaxDatumBlock[] hsSyntaxDatums;
//        [TagBlockField]
//        public OrdersBlock[] orders;
//        [TagBlockField]
//        public TriggersBlock[] triggers;
//        [TagBlockField]
//        public StructureBspBackgroundSoundPaletteBlock[] backgroundSoundPalette;
//        [TagBlockField]
//        public StructureBspSoundEnvironmentPaletteBlock[] soundEnvironmentPalette;
//        [TagBlockField]
//        public StructureBspWeatherPaletteBlock[] weatherPalette;
//        [TagBlockField]
//        public GNullBlock[] eMPTYSTRING;
//        [TagBlockField]
//        public GNullBlock[] eMPTYSTRING0;
//        [TagBlockField]
//        public GNullBlock[] eMPTYSTRING1;
//        [TagBlockField]
//        public GNullBlock[] eMPTYSTRING2;
//        [TagBlockField]
//        public GNullBlock[] eMPTYSTRING3;
//        [TagBlockField]
//        public ScenarioClusterDataBlock[] scenarioClusterData;
//        public struct ObjectSalts
//        {
//            public int eMPTYSTRING;
//            public ObjectSalts(BinaryReader binaryReader)
//            {
//                this.eMPTYSTRING = binaryReader.ReadInt32();
//            }
//        }
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
//        public ObjectSalts[] objectSalts;
//        [TagBlockField]
//        public ScenarioSpawnDataBlock[] spawnData;
//        [TagReference("sfx+")]
//        public TagReference soundEffectCollection;
//        [TagBlockField]
//        public ScenarioCrateBlock[] crates;
//        [TagBlockField]
//        public ScenarioCratePaletteBlock[] cratesPalette;
//        [TagReference("gldf")]
//        public TagReference globalLighting;
//        [TagBlockField]
//        public ScenarioAtmosphericFogPalette[] atmosphericFogPalette;
//        [TagBlockField]
//        public ScenarioPlanarFogPalette[] planarFogPalette;
//        [TagBlockField]
//        public FlockDefinitionBlock[] flocks;
//        [TagReference("unic")]
//        public TagReference subtitles;
//        [TagBlockField]
//        public DecoratorPlacementDefinitionBlock[] decorators;
//        [TagBlockField]
//        public ScenarioCreatureBlock[] creatures;
//        [TagBlockField]
//        public ScenarioCreaturePaletteBlock[] creaturesPalette;
//        [TagBlockField]
//        public ScenarioDecoratorSetPaletteEntryBlock[] decoratorsPalette;
//        [TagBlockField]
//        public ScenarioBspSwitchTransitionVolumeBlock[] bSPTransitionVolumes;
//        [TagBlockField]
//        public ScenarioStructureBspSphericalHarmonicLightingBlock[] structureBSPLighting;
//        [TagBlockField]
//        public GScenarioEditorFolderBlock[] editorFolders;
//        [TagBlockField]
//        public ScenarioLevelDataBlock[] levelData;
//        [TagReference("unic")]
//        public TagReference territoryLocationNames;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
//        private byte[] padding;
//        #endregion
//        [TagBlockField]
//        public AiScenarioMissionDialogueBlock[] missionDialogue;
//        [TagReference("unic")]
//        public TagReference objectives;
//        [TagBlockField]
//        public ScenarioInterpolatorBlock[] interpolators;
//        [TagBlockField]
//        public HsReferencesBlock[] sharedReferences;
//        [TagBlockField]
//        public ScenarioScreenEffectReferenceBlock[] screenEffectReferences;
//        [TagBlockField]
//        public ScenarioSimulationDefinitionTableBlock[] simulationDefinitionTable;
//        public Scenario()
//        {
//        }
//        public Scenario(BinaryReader binaryReader)
//        {
//            this.doNotUse = binaryReader.ReadTagReference();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioSkyReferenceBlock));
//                this.skies = new ScenarioSkyReferenceBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.skies[i] = new ScenarioSkyReferenceBlock(binaryReader);
//                    }
//                }
//            }
//            this.type = (Type)binaryReader.ReadInt16();
//            this.flags = (Flags)binaryReader.ReadInt16();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioChildScenarioBlock));
//                this.childScenarios = new ScenarioChildScenarioBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.childScenarios[i] = new ScenarioChildScenarioBlock(binaryReader);
//                    }
//                }
//            }
//            this.localNorth = binaryReader.ReadSingle();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(PredictedResourceBlock));
//                this.predictedResources = new PredictedResourceBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.predictedResources[i] = new PredictedResourceBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioFunctionBlock));
//                this.functions = new ScenarioFunctionBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.functions[i] = new ScenarioFunctionBlock(binaryReader);
//                    }
//                }
//            }
//            this.paddingeditorScenarioData = binaryReader.ReadBytes(8);
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(EditorCommentBlock));
//                this.comments = new EditorCommentBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.comments[i] = new EditorCommentBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(DontUseMeScenarioEnvironmentObjectBlock));
//                this.dontUseMeScenarioEnvironmentObjectBlock = new DontUseMeScenarioEnvironmentObjectBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.dontUseMeScenarioEnvironmentObjectBlock[i] = new DontUseMeScenarioEnvironmentObjectBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioObjectNamesBlock));
//                this.objectNames = new ScenarioObjectNamesBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.objectNames[i] = new ScenarioObjectNamesBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioSceneryBlock));
//                this.scenery = new ScenarioSceneryBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.scenery[i] = new ScenarioSceneryBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioSceneryPaletteBlock));
//                this.sceneryPalette = new ScenarioSceneryPaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.sceneryPalette[i] = new ScenarioSceneryPaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioBipedBlock));
//                this.bipeds = new ScenarioBipedBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.bipeds[i] = new ScenarioBipedBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioBipedPaletteBlock));
//                this.bipedPalette = new ScenarioBipedPaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.bipedPalette[i] = new ScenarioBipedPaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioVehicleBlock));
//                this.vehicles = new ScenarioVehicleBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.vehicles[i] = new ScenarioVehicleBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioVehiclePaletteBlock));
//                this.vehiclePalette = new ScenarioVehiclePaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.vehiclePalette[i] = new ScenarioVehiclePaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioEquipmentBlock));
//                this.equipment = new ScenarioEquipmentBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.equipment[i] = new ScenarioEquipmentBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioEquipmentPaletteBlock));
//                this.equipmentPalette = new ScenarioEquipmentPaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.equipmentPalette[i] = new ScenarioEquipmentPaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioWeaponBlock));
//                this.weapons = new ScenarioWeaponBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.weapons[i] = new ScenarioWeaponBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioWeaponPaletteBlock));
//                this.weaponPalette = new ScenarioWeaponPaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.weaponPalette[i] = new ScenarioWeaponPaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(DeviceGroupBlock));
//                this.deviceGroups = new DeviceGroupBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.deviceGroups[i] = new DeviceGroupBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioMachineBlock));
//                this.machines = new ScenarioMachineBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.machines[i] = new ScenarioMachineBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioMachinePaletteBlock));
//                this.machinePalette = new ScenarioMachinePaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.machinePalette[i] = new ScenarioMachinePaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioControlBlock));
//                this.controls = new ScenarioControlBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.controls[i] = new ScenarioControlBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioControlPaletteBlock));
//                this.controlPalette = new ScenarioControlPaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.controlPalette[i] = new ScenarioControlPaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioLightFixtureBlock));
//                this.lightFixtures = new ScenarioLightFixtureBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.lightFixtures[i] = new ScenarioLightFixtureBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioLightFixturePaletteBlock));
//                this.lightFixturesPalette = new ScenarioLightFixturePaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.lightFixturesPalette[i] = new ScenarioLightFixturePaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioSoundSceneryBlock));
//                this.soundScenery = new ScenarioSoundSceneryBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.soundScenery[i] = new ScenarioSoundSceneryBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioSoundSceneryPaletteBlock));
//                this.soundSceneryPalette = new ScenarioSoundSceneryPaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.soundSceneryPalette[i] = new ScenarioSoundSceneryPaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioLightBlock));
//                this.lightVolumes = new ScenarioLightBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.lightVolumes[i] = new ScenarioLightBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioLightPaletteBlock));
//                this.lightVolumesPalette = new ScenarioLightPaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.lightVolumesPalette[i] = new ScenarioLightPaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioProfilesBlock));
//                this.playerStartingProfile = new ScenarioProfilesBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.playerStartingProfile[i] = new ScenarioProfilesBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioPlayersBlock));
//                this.playerStartingLocations = new ScenarioPlayersBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.playerStartingLocations[i] = new ScenarioPlayersBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioTriggerVolumeBlock));
//                this.killTriggerVolumes = new ScenarioTriggerVolumeBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.killTriggerVolumes[i] = new ScenarioTriggerVolumeBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(RecordedAnimationBlock));
//                this.recordedAnimations = new RecordedAnimationBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.recordedAnimations[i] = new RecordedAnimationBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioNetpointsBlock));
//                this.netgameFlags = new ScenarioNetpointsBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.netgameFlags[i] = new ScenarioNetpointsBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioNetgameEquipmentBlock));
//                this.netgameEquipment = new ScenarioNetgameEquipmentBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.netgameEquipment[i] = new ScenarioNetgameEquipmentBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioStartingEquipmentBlock));
//                this.startingEquipment = new ScenarioStartingEquipmentBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.startingEquipment[i] = new ScenarioStartingEquipmentBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioBspSwitchTriggerVolumeBlock));
//                this.bSPSwitchTriggerVolumes = new ScenarioBspSwitchTriggerVolumeBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.bSPSwitchTriggerVolumes[i] = new ScenarioBspSwitchTriggerVolumeBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioDecalsBlock));
//                this.decals = new ScenarioDecalsBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.decals[i] = new ScenarioDecalsBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioDecalPaletteBlock));
//                this.decalsPalette = new ScenarioDecalPaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.decalsPalette[i] = new ScenarioDecalPaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioDetailObjectCollectionPaletteBlock));
//                this.detailObjectCollectionPalette = new ScenarioDetailObjectCollectionPaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.detailObjectCollectionPalette[i] = new ScenarioDetailObjectCollectionPaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(StylePaletteBlock));
//                this.stylePalette = new StylePaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.stylePalette[i] = new StylePaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(SquadGroupsBlock));
//                this.squadGroups = new SquadGroupsBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.squadGroups[i] = new SquadGroupsBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(SquadsBlock));
//                this.squads = new SquadsBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.squads[i] = new SquadsBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ZoneBlock));
//                this.zones = new ZoneBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.zones[i] = new ZoneBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(AiSceneBlock));
//                this.missionScenes = new AiSceneBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.missionScenes[i] = new AiSceneBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(CharacterPaletteBlock));
//                this.characterPalette = new CharacterPaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.characterPalette[i] = new CharacterPaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(PathfindingDataBlock));
//                this.aIPathfindingData = new PathfindingDataBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.aIPathfindingData[i] = new PathfindingDataBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(AiAnimationReferenceBlock));
//                this.aIAnimationReferences = new AiAnimationReferenceBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.aIAnimationReferences[i] = new AiAnimationReferenceBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(AiScriptReferenceBlock));
//                this.aIScriptReferences = new AiScriptReferenceBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.aIScriptReferences[i] = new AiScriptReferenceBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(AiRecordingReferenceBlock));
//                this.aIRecordingReferences = new AiRecordingReferenceBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.aIRecordingReferences[i] = new AiRecordingReferenceBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(AiConversationBlock));
//                this.aIConversations = new AiConversationBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.aIConversations[i] = new AiConversationBlock(binaryReader);
//                    }
//                }
//            }
//            this.paddingscriptSyntaxData = binaryReader.ReadBytes(8);
//            this.paddingscriptStringData = binaryReader.ReadBytes(8);
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(HsScriptsBlock));
//                this.scripts = new HsScriptsBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.scripts[i] = new HsScriptsBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(HsGlobalsBlock));
//                this.globals = new HsGlobalsBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.globals[i] = new HsGlobalsBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(HsReferencesBlock));
//                this.references = new HsReferencesBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.references[i] = new HsReferencesBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(HsSourceFilesBlock));
//                this.sourceFiles = new HsSourceFilesBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.sourceFiles[i] = new HsSourceFilesBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(CsScriptDataBlock));
//                this.scriptingData = new CsScriptDataBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.scriptingData[i] = new CsScriptDataBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioCutsceneFlagBlock));
//                this.cutsceneFlags = new ScenarioCutsceneFlagBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.cutsceneFlags[i] = new ScenarioCutsceneFlagBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioCutsceneCameraPointBlock));
//                this.cutsceneCameraPoints = new ScenarioCutsceneCameraPointBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.cutsceneCameraPoints[i] = new ScenarioCutsceneCameraPointBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioCutsceneTitleBlock));
//                this.cutsceneTitles = new ScenarioCutsceneTitleBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.cutsceneTitles[i] = new ScenarioCutsceneTitleBlock(binaryReader);
//                    }
//                }
//            }
//            this.customObjectNames = binaryReader.ReadTagReference();
//            this.chapterTitleText = binaryReader.ReadTagReference();
//            this.hUDMessages = binaryReader.ReadTagReference();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioStructureBspReferenceBlock));
//                this.structureBsps = new ScenarioStructureBspReferenceBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.structureBsps[i] = new ScenarioStructureBspReferenceBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioResourcesBlock));
//                this.scenarioResources = new ScenarioResourcesBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.scenarioResources[i] = new ScenarioResourcesBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(OldUnusedStrucurePhysicsBlock));
//                this.scenarioResources0 = new OldUnusedStrucurePhysicsBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.scenarioResources0[i] = new OldUnusedStrucurePhysicsBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(HsUnitSeatBlock));
//                this.hsUnitSeats = new HsUnitSeatBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.hsUnitSeats[i] = new HsUnitSeatBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioKillTriggerVolumesBlock));
//                this.scenarioKillTriggers = new ScenarioKillTriggerVolumesBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.scenarioKillTriggers[i] = new ScenarioKillTriggerVolumesBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(SyntaxDatumBlock));
//                this.hsSyntaxDatums = new SyntaxDatumBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.hsSyntaxDatums[i] = new SyntaxDatumBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(OrdersBlock));
//                this.orders = new OrdersBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.orders[i] = new OrdersBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(TriggersBlock));
//                this.triggers = new TriggersBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.triggers[i] = new TriggersBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(StructureBspBackgroundSoundPaletteBlock));
//                this.backgroundSoundPalette = new StructureBspBackgroundSoundPaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.backgroundSoundPalette[i] = new StructureBspBackgroundSoundPaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(StructureBspSoundEnvironmentPaletteBlock));
//                this.soundEnvironmentPalette = new StructureBspSoundEnvironmentPaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.soundEnvironmentPalette[i] = new StructureBspSoundEnvironmentPaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(StructureBspWeatherPaletteBlock));
//                this.weatherPalette = new StructureBspWeatherPaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.weatherPalette[i] = new StructureBspWeatherPaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(GNullBlock));
//                this.eMPTYSTRING = new GNullBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.eMPTYSTRING[i] = new GNullBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(GNullBlock));
//                this.eMPTYSTRING0 = new GNullBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.eMPTYSTRING0[i] = new GNullBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(GNullBlock));
//                this.eMPTYSTRING1 = new GNullBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.eMPTYSTRING1[i] = new GNullBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(GNullBlock));
//                this.eMPTYSTRING2 = new GNullBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.eMPTYSTRING2[i] = new GNullBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(GNullBlock));
//                this.eMPTYSTRING3 = new GNullBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.eMPTYSTRING3[i] = new GNullBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioClusterDataBlock));
//                this.scenarioClusterData = new ScenarioClusterDataBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.scenarioClusterData[i] = new ScenarioClusterDataBlock(binaryReader);
//                    }
//                }
//            }
//            this.objectSalts = new ObjectSalts[32];
//            for (int i = 0; i < 32; ++i)
//            {
//                this.objectSalts[i] = new ObjectSalts(binaryReader);
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioSpawnDataBlock));
//                this.spawnData = new ScenarioSpawnDataBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.spawnData[i] = new ScenarioSpawnDataBlock(binaryReader);
//                    }
//                }
//            }
//            this.soundEffectCollection = binaryReader.ReadTagReference();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioCrateBlock));
//                this.crates = new ScenarioCrateBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.crates[i] = new ScenarioCrateBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioCratePaletteBlock));
//                this.cratesPalette = new ScenarioCratePaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.cratesPalette[i] = new ScenarioCratePaletteBlock(binaryReader);
//                    }
//                }
//            }
//            this.globalLighting = binaryReader.ReadTagReference();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioAtmosphericFogPalette));
//                this.atmosphericFogPalette = new ScenarioAtmosphericFogPalette[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.atmosphericFogPalette[i] = new ScenarioAtmosphericFogPalette(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioPlanarFogPalette));
//                this.planarFogPalette = new ScenarioPlanarFogPalette[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.planarFogPalette[i] = new ScenarioPlanarFogPalette(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(FlockDefinitionBlock));
//                this.flocks = new FlockDefinitionBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.flocks[i] = new FlockDefinitionBlock(binaryReader);
//                    }
//                }
//            }
//            this.subtitles = binaryReader.ReadTagReference();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(DecoratorPlacementDefinitionBlock));
//                this.decorators = new DecoratorPlacementDefinitionBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.decorators[i] = new DecoratorPlacementDefinitionBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioCreatureBlock));
//                this.creatures = new ScenarioCreatureBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.creatures[i] = new ScenarioCreatureBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioCreaturePaletteBlock));
//                this.creaturesPalette = new ScenarioCreaturePaletteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.creaturesPalette[i] = new ScenarioCreaturePaletteBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioDecoratorSetPaletteEntryBlock));
//                this.decoratorsPalette = new ScenarioDecoratorSetPaletteEntryBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.decoratorsPalette[i] = new ScenarioDecoratorSetPaletteEntryBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioBspSwitchTransitionVolumeBlock));
//                this.bSPTransitionVolumes = new ScenarioBspSwitchTransitionVolumeBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.bSPTransitionVolumes[i] = new ScenarioBspSwitchTransitionVolumeBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioStructureBspSphericalHarmonicLightingBlock));
//                this.structureBSPLighting = new ScenarioStructureBspSphericalHarmonicLightingBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.structureBSPLighting[i] = new ScenarioStructureBspSphericalHarmonicLightingBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(GScenarioEditorFolderBlock));
//                this.editorFolders = new GScenarioEditorFolderBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.editorFolders[i] = new GScenarioEditorFolderBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioLevelDataBlock));
//                this.levelData = new ScenarioLevelDataBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.levelData[i] = new ScenarioLevelDataBlock(binaryReader);
//                    }
//                }
//            }
//            this.territoryLocationNames = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(8);
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(AiScenarioMissionDialogueBlock));
//                this.missionDialogue = new AiScenarioMissionDialogueBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.missionDialogue[i] = new AiScenarioMissionDialogueBlock(binaryReader);
//                    }
//                }
//            }
//            this.objectives = binaryReader.ReadTagReference();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioInterpolatorBlock));
//                this.interpolators = new ScenarioInterpolatorBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.interpolators[i] = new ScenarioInterpolatorBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(HsReferencesBlock));
//                this.sharedReferences = new HsReferencesBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.sharedReferences[i] = new HsReferencesBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioScreenEffectReferenceBlock));
//                this.screenEffectReferences = new ScenarioScreenEffectReferenceBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.screenEffectReferences[i] = new ScenarioScreenEffectReferenceBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioSimulationDefinitionTableBlock));
//                this.simulationDefinitionTable = new ScenarioSimulationDefinitionTableBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.simulationDefinitionTable[i] = new ScenarioSimulationDefinitionTableBlock(binaryReader);
//                    }
//                }
//            }
//        }
//        public enum Type : short
//        {
//            Multiplayer = 1,
//        }
//        [Flags]
//        public enum Flags : short
//        {
//            CortanaHackSortsCortanaInFrontOfOtherTransparentGeometry = 1,
//            AlwaysDrawSkyAlwaysDrawsSky0EvenIfNoSkyPolygonsAreVisible = 2,
//            DontStripPathfindingAlwaysLeavesPathfindingInEvenForMultiplayerScenario = 4,
//            SymmetricMultiplayerMap = 8,
//            QuickLoadingCinematicOnlyScenario = 16,
//            CharactersUsePreviousMissionWeapons = 32,
//            LightmapsSmoothPalettesWithNeighbors = 64,
//            SnapToWhiteAtStart = 128,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class ScenarioSkyReferenceBlock
//    {
//        [TagReference("sky ")]
//        public TagReference sky;
//        public ScenarioSkyReferenceBlock()
//        {
//        }
//        public ScenarioSkyReferenceBlock(BinaryReader binaryReader)
//        {
//            this.sky = binaryReader.ReadTagReference();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 24, Pack = 4)]
//    public partial class ScenarioChildScenarioBlock
//    {
//        [TagReference("scnr")]
//        public TagReference childScenario;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
//        private byte[] padding;
//        #endregion
//        public ScenarioChildScenarioBlock()
//        {
//        }
//        public ScenarioChildScenarioBlock(BinaryReader binaryReader)
//        {
//            this.childScenario = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(16);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class PredictedResourceBlock
//    {
//        public Type type;
//        public short resourceIndex;
//        public int tagIndex;
//        public PredictedResourceBlock()
//        {
//        }
//        public PredictedResourceBlock(BinaryReader binaryReader)
//        {
//            this.type = (Type)binaryReader.ReadInt16();
//            this.resourceIndex = binaryReader.ReadInt16();
//            this.tagIndex = binaryReader.ReadInt32();
//        }
//        public enum Type : short
//        {
//            Bitmap = 0,
//            Sound = 1,
//            RenderModelGeometry = 2,
//            ClusterGeometry = 3,
//            ClusterInstancedGeometry = 4,
//            LightmapGeometryObjectBuckets = 5,
//            LightmapGeometryInstanceBuckets = 6,
//            LightmapClusterBitmaps = 7,
//            LightmapInstanceBitmaps = 8,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 120, Pack = 4)]
//    public partial class ScenarioFunctionBlock
//    {
//        public Flags flags;
//        public String32 name;
//        public float periodSecondsPeriodForAboveFunctionLowerValuesMakeFunctionOscillateQuicklyHigherValuesMakeItOscillateSlowly;
//        public ShortBlockIndex1 scalePeriodByMultiplyThisFunctionByAbovePeriod;
//        public Function function;
//        public ShortBlockIndex1 scaleFunctionByMultiplyThisFunctionByResultOfAboveFunction;
//        public WobbleFunctionCurveUsedForWobble wobbleFunctionCurveUsedForWobble;
//        public float wobblePeriodSecondsTimeItTakesForMagnitudeOfThisFunctionToCompleteAWobble;
//        public float wobbleMagnitudePercentAmountOfRandomWobbleInTheMagnitude;
//        public float squareWaveThresholdIfNonZeroAllValuesAboveSquareWaveThresholdAreSnappedTo10AndAllValuesBelowItAreSnappedTo00ToCreateASquareWave;
//        public short stepCountNumberOfDiscreteValuesToSnapToEGStepCountOf5SnapsFunctionTo000025050075Or100;
//        public MapTo mapTo;
//        public short sawtoothCountNumberOfTimesThisFunctionShouldRepeatEGSawtoothCountOf5GivesFunctionValueOf10AtEachOf025050And075AsWellAsAt10;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public ShortBlockIndex1 scaleResultByMultiplyThisFunctionEGFromAWeaponVehicleFinalResultOfAllOfTheAboveMath;
//        public BoundsModeControlsHowBoundsBelowAreUsed boundsModeControlsHowBoundsBelowAreUsed;
//        public float bounds;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] padding0;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding1;
//        #endregion
//        public ShortBlockIndex1 turnOffWithIfSpecifiedFunctionIsOffSoIsThisFunction;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
//        private byte[] padding2;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
//        private byte[] padding3;
//        #endregion
//        public ScenarioFunctionBlock()
//        {
//        }
//        public ScenarioFunctionBlock(BinaryReader binaryReader)
//        {
//            this.flags = (Flags)binaryReader.ReadInt32();
//            this.name = binaryReader.ReadString32();
//            this.periodSecondsPeriodForAboveFunctionLowerValuesMakeFunctionOscillateQuicklyHigherValuesMakeItOscillateSlowly = binaryReader.ReadSingle();
//            this.scalePeriodByMultiplyThisFunctionByAbovePeriod = binaryReader.ReadShortBlockIndex1();
//            this.function = (Function)binaryReader.ReadInt16();
//            this.scaleFunctionByMultiplyThisFunctionByResultOfAboveFunction = binaryReader.ReadShortBlockIndex1();
//            this.wobbleFunctionCurveUsedForWobble = (WobbleFunctionCurveUsedForWobble)binaryReader.ReadInt16();
//            this.wobblePeriodSecondsTimeItTakesForMagnitudeOfThisFunctionToCompleteAWobble = binaryReader.ReadSingle();
//            this.wobbleMagnitudePercentAmountOfRandomWobbleInTheMagnitude = binaryReader.ReadSingle();
//            this.squareWaveThresholdIfNonZeroAllValuesAboveSquareWaveThresholdAreSnappedTo10AndAllValuesBelowItAreSnappedTo00ToCreateASquareWave = binaryReader.ReadSingle();
//            this.stepCountNumberOfDiscreteValuesToSnapToEGStepCountOf5SnapsFunctionTo000025050075Or100 = binaryReader.ReadInt16();
//            this.mapTo = (MapTo)binaryReader.ReadInt16();
//            this.sawtoothCountNumberOfTimesThisFunctionShouldRepeatEGSawtoothCountOf5GivesFunctionValueOf10AtEachOf025050And075AsWellAsAt10 = binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            this.scaleResultByMultiplyThisFunctionEGFromAWeaponVehicleFinalResultOfAllOfTheAboveMath = binaryReader.ReadShortBlockIndex1();
//            this.boundsModeControlsHowBoundsBelowAreUsed = (BoundsModeControlsHowBoundsBelowAreUsed)binaryReader.ReadInt16();
//            this.bounds = binaryReader.ReadSingle();
//            this.padding0 = binaryReader.ReadBytes(4);
//            this.padding1 = binaryReader.ReadBytes(2);
//            this.turnOffWithIfSpecifiedFunctionIsOffSoIsThisFunction = binaryReader.ReadShortBlockIndex1();
//            this.padding2 = binaryReader.ReadBytes(16);
//            this.padding3 = binaryReader.ReadBytes(16);
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            ScriptedLevelScriptWillSetThisValueOtherSettingsHereWillBeIgnored = 1,
//            InvertResultOfFunctionIs1MinusActualResult = 2,
//            Additive = 4,
//            AlwaysActiveFunctionDoesNotDeactivateWhenAtOrBelowLowerBound = 8,
//        }
//        public enum Function : short
//        {
//            One = 0,
//            Zero = 1,
//            Cosine = 2,
//            CosineVariablePeriod = 3,
//            DiagonalWave = 4,
//            DiagonalWaveVariablePeriod = 5,
//            Slide = 6,
//            SlideVariablePeriod = 7,
//            Noise = 8,
//            Jitter = 9,
//            Wander = 10,
//            Spark = 11,
//        }
//        public enum WobbleFunctionCurveUsedForWobble : short
//        {
//            One = 0,
//            Zero = 1,
//            Cosine = 2,
//            CosineVariablePeriod = 3,
//            DiagonalWave = 4,
//            DiagonalWaveVariablePeriod = 5,
//            Slide = 6,
//            SlideVariablePeriod = 7,
//            Noise = 8,
//            Jitter = 9,
//            Wander = 10,
//            Spark = 11,
//        }
//        public enum MapTo : short
//        {
//            Linear = 0,
//            Early = 1,
//            VeryEarly = 2,
//            Late = 3,
//            VeryLate = 4,
//            Cosine = 5,
//            One = 6,
//            Zero = 7,
//        }
//        public enum BoundsModeControlsHowBoundsBelowAreUsed : short
//        {
//            Clip = 0,
//            ClipAndNormalize = 1,
//            ScaleToFit = 2,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 304, Pack = 4)]
//    public partial class EditorCommentBlock
//    {
//        public Vector3 position;
//        public Type type;
//        public String32 name;
//        public String256 comment;
//        public EditorCommentBlock()
//        {
//        }
//        public EditorCommentBlock(BinaryReader binaryReader)
//        {
//            this.position = binaryReader.ReadVector3();
//            this.type = (Type)binaryReader.ReadInt32();
//            this.name = binaryReader.ReadString32();
//            this.comment = binaryReader.ReadString256();
//        }
//        public enum Type : int
//        {
//            Generic = 0,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 64, Pack = 4)]
//    public partial class DontUseMeScenarioEnvironmentObjectBlock
//    {
//        public ShortBlockIndex1 bSP;
//        public short eMPTYSTRING;
//        public int uniqueID;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] padding;
//        #endregion
//        public TagClass objectDefinitionTag;
//        public int invalidName_object;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 44)]
//        private byte[] padding0;
//        #endregion
//        public DontUseMeScenarioEnvironmentObjectBlock()
//        {
//        }
//        public DontUseMeScenarioEnvironmentObjectBlock(BinaryReader binaryReader)
//        {
//            this.bSP = binaryReader.ReadShortBlockIndex1();
//            this.eMPTYSTRING = binaryReader.ReadInt16();
//            this.uniqueID = binaryReader.ReadInt32();
//            this.padding = binaryReader.ReadBytes(4);
//            this.objectDefinitionTag = binaryReader.ReadTagClass();
//            this.invalidName_object = binaryReader.ReadInt32();
//            this.padding0 = binaryReader.ReadBytes(44);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 36, Pack = 4)]
//    public partial class ScenarioObjectNamesBlock
//    {
//        public String32 name;
//        public ShortBlockIndex1 eMPTYSTRING;
//        public ShortBlockIndex2 eMPTYSTRING0;
//        public ScenarioObjectNamesBlock()
//        {
//        }
//        public ScenarioObjectNamesBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.eMPTYSTRING = binaryReader.ReadShortBlockIndex1();
//            this.eMPTYSTRING0 = binaryReader.ReadShortBlockIndex2();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class ScenarioObjectIdStruct
//    {
//        public int uniqueID;
//        public ShortBlockIndex1 originBSPIndex;
//        public Type type;
//        public Source source;
//        public ScenarioObjectIdStruct()
//        {
//        }
//        public ScenarioObjectIdStruct(BinaryReader binaryReader)
//        {
//            this.uniqueID = binaryReader.ReadInt32();
//            this.originBSPIndex = binaryReader.ReadShortBlockIndex1();
//            this.type = (Type)binaryReader.ReadByte();
//            this.source = (Source)binaryReader.ReadByte();
//        }
//        public enum Type : byte
//        {
//            Biped = 0,
//            Vehicle = 1,
//            Weapon = 2,
//            Equipment = 3,
//            Garbage = 4,
//            Projectile = 5,
//            Scenery = 6,
//            Machine = 7,
//            Control = 8,
//            LightFixture = 9,
//            SoundScenery = 10,
//            Crate = 11,
//            Creature = 12,
//        }
//        public enum Source : byte
//        {
//            Structure = 0,
//            Editor = 1,
//            Dynamic = 2,
//            Legacy = 3,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 48, Pack = 4)]
//    public partial class ScenarioObjectDatumStruct
//    {
//        public PlacementFlags placementFlags;
//        public Vector3 position;
//        public Vector3 rotation;
//        public float scale;
//        public TransformFlags transformFlags;
//        public BlockFlags16 manualBSPFlags;
//        [TagStructField]
//        public ScenarioObjectIdStruct objectID;
//        public BSPPolicy bSPPolicy;
//        #region padding
//        private byte padding;
//        #endregion
//        public ShortBlockIndex1 editorFolder;
//        public ScenarioObjectDatumStruct()
//        {
//        }
//        public ScenarioObjectDatumStruct(BinaryReader binaryReader)
//        {
//            this.placementFlags = (PlacementFlags)binaryReader.ReadInt32();
//            this.position = binaryReader.ReadVector3();
//            this.rotation = binaryReader.ReadVector3();
//            this.scale = binaryReader.ReadSingle();
//            this.transformFlags = (TransformFlags)binaryReader.ReadInt16();
//            this.manualBSPFlags = binaryReader.ReadBlockFlags16();
//            this.objectID = new ScenarioObjectIdStruct(binaryReader);
//            this.bSPPolicy = (BSPPolicy)binaryReader.ReadByte();
//            this.padding = binaryReader.ReadByte();
//            this.editorFolder = binaryReader.ReadShortBlockIndex1();
//        }
//        [Flags]
//        public enum PlacementFlags : int
//        {
//            NotAutomatically = 1,
//            Unused = 2,
//            Unused0 = 4,
//            Unused1 = 8,
//            LockTypeToEnvObject = 16,
//            LockTransformToEnvObject = 32,
//            NeverPlaced = 64,
//            LockNameToEnvObject = 128,
//            CreateAtRest = 256,
//        }
//        [Flags]
//        public enum TransformFlags : short
//        {
//            Mirrored = 1,
//        }
//        public enum BSPPolicy : byte
//        {
//            Default = 0,
//            AlwaysPlaced = 1,
//            ManualBSPPlacement = 2,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 4)]
//    public partial class ScenarioObjectPermutationStruct
//    {
//        public StringID variantName;
//        public ActiveChangeColors activeChangeColors;
//        public RGBColor primaryColor;
//        public RGBColor secondaryColor;
//        public RGBColor tertiaryColor;
//        public RGBColor quaternaryColor;
//        public ScenarioObjectPermutationStruct()
//        {
//        }
//        public ScenarioObjectPermutationStruct(BinaryReader binaryReader)
//        {
//            this.variantName = binaryReader.ReadStringID();
//            this.activeChangeColors = (ActiveChangeColors)binaryReader.ReadInt32();
//            this.primaryColor = binaryReader.ReadRGBColor();
//            this.secondaryColor = binaryReader.ReadRGBColor();
//            this.tertiaryColor = binaryReader.ReadRGBColor();
//            this.quaternaryColor = binaryReader.ReadRGBColor();
//        }
//        [Flags]
//        public enum ActiveChangeColors : int
//        {
//            Primary = 1,
//            Secondary = 2,
//            Tertiary = 4,
//            Quaternary = 8,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
//    public partial class PathfindingObjectIndexListBlock
//    {
//        public short bSPIndex;
//        public short pathfindingObjectIndex;
//        public PathfindingObjectIndexListBlock()
//        {
//        }
//        public PathfindingObjectIndexListBlock(BinaryReader binaryReader)
//        {
//            this.bSPIndex = binaryReader.ReadInt16();
//            this.pathfindingObjectIndex = binaryReader.ReadInt16();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
//    public partial class ScenarioSceneryDatumStructV4
//    {
//        public PathfindingPolicy pathfindingPolicy;
//        public LightmappingPolicy lightmappingPolicy;
//        [TagBlockField]
//        public PathfindingObjectIndexListBlock[] pathfindingReferences;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public ValidMultiplayerGames validMultiplayerGames;
//        public ScenarioSceneryDatumStructV4()
//        {
//        }
//        public ScenarioSceneryDatumStructV4(BinaryReader binaryReader)
//        {
//            this.pathfindingPolicy = (PathfindingPolicy)binaryReader.ReadInt16();
//            this.lightmappingPolicy = (LightmappingPolicy)binaryReader.ReadInt16();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(PathfindingObjectIndexListBlock));
//                this.pathfindingReferences = new PathfindingObjectIndexListBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.pathfindingReferences[i] = new PathfindingObjectIndexListBlock(binaryReader);
//                    }
//                }
//            }
//            this.padding = binaryReader.ReadBytes(2);
//            this.validMultiplayerGames = (ValidMultiplayerGames)binaryReader.ReadInt16();
//        }
//        public enum PathfindingPolicy : short
//        {
//            TagDefault = 0,
//            PathfindingDYNAMIC = 1,
//            PathfindingCUTOUT = 2,
//            PathfindingSTATIC = 3,
//            PathfindingNONE = 4,
//        }
//        public enum LightmappingPolicy : short
//        {
//            TagDefault = 0,
//            Dynamic = 1,
//            PerVertex = 2,
//        }
//        [Flags]
//        public enum ValidMultiplayerGames : short
//        {
//            CaptureTheFlag = 1,
//            Slayer = 2,
//            Oddball = 4,
//            KingOfTheHill = 8,
//            Juggernaut = 16,
//            Territories = 32,
//            Assault = 64,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 92, Pack = 4)]
//    public partial class ScenarioSceneryBlock
//    {
//        public ShortBlockIndex1 type;
//        public ShortBlockIndex1 name;
//        [TagStructField]
//        public ScenarioObjectDatumStruct objectData;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] paddingindexer;
//        #endregion
//        [TagStructField]
//        public ScenarioObjectPermutationStruct permutationData;
//        [TagStructField]
//        public ScenarioSceneryDatumStructV4 sceneryData;
//        public ScenarioSceneryBlock()
//        {
//        }
//        public ScenarioSceneryBlock(BinaryReader binaryReader)
//        {
//            this.type = binaryReader.ReadShortBlockIndex1();
//            this.name = binaryReader.ReadShortBlockIndex1();
//            this.objectData = new ScenarioObjectDatumStruct(binaryReader);
//            this.paddingindexer = binaryReader.ReadBytes(4);
//            this.permutationData = new ScenarioObjectPermutationStruct(binaryReader);
//            this.sceneryData = new ScenarioSceneryDatumStructV4(binaryReader);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class ScenarioSceneryPaletteBlock
//    {
//        [TagReference("scen")]
//        public TagReference name;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
//        private byte[] padding;
//        #endregion
//        public ScenarioSceneryPaletteBlock()
//        {
//        }
//        public ScenarioSceneryPaletteBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(32);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class ScenarioUnitStruct
//    {
//        public float bodyVitality01;
//        public Flags flags;
//        public ScenarioUnitStruct()
//        {
//        }
//        public ScenarioUnitStruct(BinaryReader binaryReader)
//        {
//            this.bodyVitality01 = binaryReader.ReadSingle();
//            this.flags = (Flags)binaryReader.ReadInt32();
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            Dead = 1,
//            Closed = 2,
//            NotEnterableByPlayer = 4,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 84, Pack = 4)]
//    public partial class ScenarioBipedBlock
//    {
//        public ShortBlockIndex1 type;
//        public ShortBlockIndex1 name;
//        [TagStructField]
//        public ScenarioObjectDatumStruct objectData;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] paddingindexer;
//        #endregion
//        [TagStructField]
//        public ScenarioObjectPermutationStruct permutationData;
//        [TagStructField]
//        public ScenarioUnitStruct unitData;
//        public ScenarioBipedBlock()
//        {
//        }
//        public ScenarioBipedBlock(BinaryReader binaryReader)
//        {
//            this.type = binaryReader.ReadShortBlockIndex1();
//            this.name = binaryReader.ReadShortBlockIndex1();
//            this.objectData = new ScenarioObjectDatumStruct(binaryReader);
//            this.paddingindexer = binaryReader.ReadBytes(4);
//            this.permutationData = new ScenarioObjectPermutationStruct(binaryReader);
//            this.unitData = new ScenarioUnitStruct(binaryReader);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class ScenarioBipedPaletteBlock
//    {
//        [TagReference("bipd")]
//        public TagReference name;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
//        private byte[] padding;
//        #endregion
//        public ScenarioBipedPaletteBlock()
//        {
//        }
//        public ScenarioBipedPaletteBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(32);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 84, Pack = 4)]
//    public partial class ScenarioVehicleBlock
//    {
//        public ShortBlockIndex1 type;
//        public ShortBlockIndex1 name;
//        [TagStructField]
//        public ScenarioObjectDatumStruct objectData;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] paddingindexer;
//        #endregion
//        [TagStructField]
//        public ScenarioObjectPermutationStruct permutationData;
//        [TagStructField]
//        public ScenarioUnitStruct unitData;
//        public ScenarioVehicleBlock()
//        {
//        }
//        public ScenarioVehicleBlock(BinaryReader binaryReader)
//        {
//            this.type = binaryReader.ReadShortBlockIndex1();
//            this.name = binaryReader.ReadShortBlockIndex1();
//            this.objectData = new ScenarioObjectDatumStruct(binaryReader);
//            this.paddingindexer = binaryReader.ReadBytes(4);
//            this.permutationData = new ScenarioObjectPermutationStruct(binaryReader);
//            this.unitData = new ScenarioUnitStruct(binaryReader);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class ScenarioVehiclePaletteBlock
//    {
//        [TagReference("vehi")]
//        public TagReference name;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
//        private byte[] padding;
//        #endregion
//        public ScenarioVehiclePaletteBlock()
//        {
//        }
//        public ScenarioVehiclePaletteBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(32);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
//    public partial class ScenarioEquipmentDatumStruct
//    {
//        public EquipmentFlags equipmentFlags;
//        public ScenarioEquipmentDatumStruct()
//        {
//        }
//        public ScenarioEquipmentDatumStruct(BinaryReader binaryReader)
//        {
//            this.equipmentFlags = (EquipmentFlags)binaryReader.ReadInt32();
//        }
//        [Flags]
//        public enum EquipmentFlags : int
//        {
//            InitiallyAtRestDoesNotFall = 1,
//            Obsolete = 2,
//            DoesAccelerateMovesDueToExplosions = 4,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 56, Pack = 4)]
//    public partial class ScenarioEquipmentBlock
//    {
//        public ShortBlockIndex1 type;
//        public ShortBlockIndex1 name;
//        [TagStructField]
//        public ScenarioObjectDatumStruct objectData;
//        [TagStructField]
//        public ScenarioEquipmentDatumStruct equipmentData;
//        public ScenarioEquipmentBlock()
//        {
//        }
//        public ScenarioEquipmentBlock(BinaryReader binaryReader)
//        {
//            this.type = binaryReader.ReadShortBlockIndex1();
//            this.name = binaryReader.ReadShortBlockIndex1();
//            this.objectData = new ScenarioObjectDatumStruct(binaryReader);
//            this.equipmentData = new ScenarioEquipmentDatumStruct(binaryReader);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class ScenarioEquipmentPaletteBlock
//    {
//        [TagReference("eqip")]
//        public TagReference name;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
//        private byte[] padding;
//        #endregion
//        public ScenarioEquipmentPaletteBlock()
//        {
//        }
//        public ScenarioEquipmentPaletteBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(32);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class ScenarioWeaponDatumStruct
//    {
//        public short roundsLeft;
//        public short roundsLoaded;
//        public Flags flags;
//        public ScenarioWeaponDatumStruct()
//        {
//        }
//        public ScenarioWeaponDatumStruct(BinaryReader binaryReader)
//        {
//            this.roundsLeft = binaryReader.ReadInt16();
//            this.roundsLoaded = binaryReader.ReadInt16();
//            this.flags = (Flags)binaryReader.ReadInt32();
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            InitiallyAtRestDoesNotFall = 1,
//            Obsolete = 2,
//            DoesAccelerateMovesDueToExplosions = 4,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 84, Pack = 4)]
//    public partial class ScenarioWeaponBlock
//    {
//        public ShortBlockIndex1 type;
//        public ShortBlockIndex1 name;
//        [TagStructField]
//        public ScenarioObjectDatumStruct objectData;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] paddingindexer;
//        #endregion
//        [TagStructField]
//        public ScenarioObjectPermutationStruct permutationData;
//        [TagStructField]
//        public ScenarioWeaponDatumStruct weaponData;
//        public ScenarioWeaponBlock()
//        {
//        }
//        public ScenarioWeaponBlock(BinaryReader binaryReader)
//        {
//            this.type = binaryReader.ReadShortBlockIndex1();
//            this.name = binaryReader.ReadShortBlockIndex1();
//            this.objectData = new ScenarioObjectDatumStruct(binaryReader);
//            this.paddingindexer = binaryReader.ReadBytes(4);
//            this.permutationData = new ScenarioObjectPermutationStruct(binaryReader);
//            this.weaponData = new ScenarioWeaponDatumStruct(binaryReader);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class ScenarioWeaponPaletteBlock
//    {
//        [TagReference("weap")]
//        public TagReference name;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
//        private byte[] padding;
//        #endregion
//        public ScenarioWeaponPaletteBlock()
//        {
//        }
//        public ScenarioWeaponPaletteBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(32);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class DeviceGroupBlock
//    {
//        public String32 name;
//        public float initialValue01;
//        public Flags flags;
//        public DeviceGroupBlock()
//        {
//        }
//        public DeviceGroupBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.initialValue01 = binaryReader.ReadSingle();
//            this.flags = (Flags)binaryReader.ReadInt32();
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            CanChangeOnlyOnce = 1,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class ScenarioDeviceStruct
//    {
//        public ShortBlockIndex1 powerGroup;
//        public ShortBlockIndex1 positionGroup;
//        public Flags flags;
//        public ScenarioDeviceStruct()
//        {
//        }
//        public ScenarioDeviceStruct(BinaryReader binaryReader)
//        {
//            this.powerGroup = binaryReader.ReadShortBlockIndex1();
//            this.positionGroup = binaryReader.ReadShortBlockIndex1();
//            this.flags = (Flags)binaryReader.ReadInt32();
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            InitiallyOpen10 = 1,
//            InitiallyOff00 = 2,
//            CanChangeOnlyOnce = 4,
//            PositionReversed = 8,
//            NotUsableFromAnySide = 16,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
//    public partial class ScenarioMachineStructV3
//    {
//        public Flags flags;
//        [TagBlockField]
//        public PathfindingObjectIndexListBlock[] pathfindingReferences;
//        public ScenarioMachineStructV3()
//        {
//        }
//        public ScenarioMachineStructV3(BinaryReader binaryReader)
//        {
//            this.flags = (Flags)binaryReader.ReadInt32();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(PathfindingObjectIndexListBlock));
//                this.pathfindingReferences = new PathfindingObjectIndexListBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.pathfindingReferences[i] = new PathfindingObjectIndexListBlock(binaryReader);
//                    }
//                }
//            }
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            DoesNotOperateAutomatically = 1,
//            OneSided = 2,
//            NeverAppearsLocked = 4,
//            OpenedByMeleeAttack = 8,
//            OneSidedForPlayer = 16,
//            DoesNotCloseAutomatically = 32,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 72, Pack = 4)]
//    public partial class ScenarioMachineBlock
//    {
//        public ShortBlockIndex1 type;
//        public ShortBlockIndex1 name;
//        [TagStructField]
//        public ScenarioObjectDatumStruct objectData;
//        [TagStructField]
//        public ScenarioDeviceStruct deviceData;
//        [TagStructField]
//        public ScenarioMachineStructV3 machineData;
//        public ScenarioMachineBlock()
//        {
//        }
//        public ScenarioMachineBlock(BinaryReader binaryReader)
//        {
//            this.type = binaryReader.ReadShortBlockIndex1();
//            this.name = binaryReader.ReadShortBlockIndex1();
//            this.objectData = new ScenarioObjectDatumStruct(binaryReader);
//            this.deviceData = new ScenarioDeviceStruct(binaryReader);
//            this.machineData = new ScenarioMachineStructV3(binaryReader);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class ScenarioMachinePaletteBlock
//    {
//        [TagReference("mach")]
//        public TagReference name;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
//        private byte[] padding;
//        #endregion
//        public ScenarioMachinePaletteBlock()
//        {
//        }
//        public ScenarioMachinePaletteBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(32);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class ScenarioControlStruct
//    {
//        public Flags flags;
//        public short dONtTOUCHTHIS;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public ScenarioControlStruct()
//        {
//        }
//        public ScenarioControlStruct(BinaryReader binaryReader)
//        {
//            this.flags = (Flags)binaryReader.ReadInt32();
//            this.dONtTOUCHTHIS = binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            UsableFromBothSides = 1,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 68, Pack = 4)]
//    public partial class ScenarioControlBlock
//    {
//        public ShortBlockIndex1 type;
//        public ShortBlockIndex1 name;
//        [TagStructField]
//        public ScenarioObjectDatumStruct objectData;
//        [TagStructField]
//        public ScenarioDeviceStruct deviceData;
//        [TagStructField]
//        public ScenarioControlStruct controlData;
//        public ScenarioControlBlock()
//        {
//        }
//        public ScenarioControlBlock(BinaryReader binaryReader)
//        {
//            this.type = binaryReader.ReadShortBlockIndex1();
//            this.name = binaryReader.ReadShortBlockIndex1();
//            this.objectData = new ScenarioObjectDatumStruct(binaryReader);
//            this.deviceData = new ScenarioDeviceStruct(binaryReader);
//            this.controlData = new ScenarioControlStruct(binaryReader);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class ScenarioControlPaletteBlock
//    {
//        [TagReference("ctrl")]
//        public TagReference name;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
//        private byte[] padding;
//        #endregion
//        public ScenarioControlPaletteBlock()
//        {
//        }
//        public ScenarioControlPaletteBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(32);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 24, Pack = 4)]
//    public partial class ScenarioLightFixtureStruct
//    {
//        public ColorR8G8B8 color;
//        public float intensity;
//        public float falloffAngleDegrees;
//        public float cutoffAngleDegrees;
//        public ScenarioLightFixtureStruct()
//        {
//        }
//        public ScenarioLightFixtureStruct(BinaryReader binaryReader)
//        {
//            this.color = binaryReader.ReadColorR8G8B8();
//            this.intensity = binaryReader.ReadSingle();
//            this.falloffAngleDegrees = binaryReader.ReadSingle();
//            this.cutoffAngleDegrees = binaryReader.ReadSingle();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 84, Pack = 4)]
//    public partial class ScenarioLightFixtureBlock
//    {
//        public ShortBlockIndex1 type;
//        public ShortBlockIndex1 name;
//        [TagStructField]
//        public ScenarioObjectDatumStruct objectData;
//        [TagStructField]
//        public ScenarioDeviceStruct deviceData;
//        [TagStructField]
//        public ScenarioLightFixtureStruct lightFixtureData;
//        public ScenarioLightFixtureBlock()
//        {
//        }
//        public ScenarioLightFixtureBlock(BinaryReader binaryReader)
//        {
//            this.type = binaryReader.ReadShortBlockIndex1();
//            this.name = binaryReader.ReadShortBlockIndex1();
//            this.objectData = new ScenarioObjectDatumStruct(binaryReader);
//            this.deviceData = new ScenarioDeviceStruct(binaryReader);
//            this.lightFixtureData = new ScenarioLightFixtureStruct(binaryReader);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class ScenarioLightFixturePaletteBlock
//    {
//        [TagReference("lifi")]
//        public TagReference name;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
//        private byte[] padding;
//        #endregion
//        public ScenarioLightFixturePaletteBlock()
//        {
//        }
//        public ScenarioLightFixturePaletteBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(32);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 28, Pack = 4)]
//    public partial class SoundSceneryDatumStruct
//    {
//        public VolumeType volumeType;
//        public float height;
//        public Range overrideDistanceBounds;
//        public Range overrideConeAngleBounds;
//        public float overrideOuterConeGainDb;
//        public SoundSceneryDatumStruct()
//        {
//        }
//        public SoundSceneryDatumStruct(BinaryReader binaryReader)
//        {
//            this.volumeType = (VolumeType)binaryReader.ReadInt32();
//            this.height = binaryReader.ReadSingle();
//            this.overrideDistanceBounds = binaryReader.ReadRange();
//            this.overrideConeAngleBounds = binaryReader.ReadRange();
//            this.overrideOuterConeGainDb = binaryReader.ReadSingle();
//        }
//        public enum VolumeType : int
//        {
//            Sphere = 0,
//            VerticalCylinder = 1,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 80, Pack = 4)]
//    public partial class ScenarioSoundSceneryBlock
//    {
//        public ShortBlockIndex1 type;
//        public ShortBlockIndex1 name;
//        [TagStructField]
//        public ScenarioObjectDatumStruct objectData;
//        [TagStructField]
//        public SoundSceneryDatumStruct soundScenery;
//        public ScenarioSoundSceneryBlock()
//        {
//        }
//        public ScenarioSoundSceneryBlock(BinaryReader binaryReader)
//        {
//            this.type = binaryReader.ReadShortBlockIndex1();
//            this.name = binaryReader.ReadShortBlockIndex1();
//            this.objectData = new ScenarioObjectDatumStruct(binaryReader);
//            this.soundScenery = new SoundSceneryDatumStruct(binaryReader);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class ScenarioSoundSceneryPaletteBlock
//    {
//        [TagReference("ssce")]
//        public TagReference name;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
//        private byte[] padding;
//        #endregion
//        public ScenarioSoundSceneryPaletteBlock()
//        {
//        }
//        public ScenarioSoundSceneryPaletteBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(32);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 48, Pack = 4)]
//    public partial class ScenarioLightStruct
//    {
//        public Type type;
//        public Flags flags;
//        public LightmapType lightmapType;
//        public LightmapFlags lightmapFlags;
//        public float lightmapHalfLife;
//        public float lightmapLightScale;
//        public Vector3 targetPoint;
//        public float widthWorldUnits;
//        public float heightScaleWorldUnits;
//        public float fieldOfViewDegrees;
//        public float falloffDistanceWorldUnits;
//        public float cutoffDistanceWorldUnitsFromFarPlane;
//        public ScenarioLightStruct()
//        {
//        }
//        public ScenarioLightStruct(BinaryReader binaryReader)
//        {
//            this.type = (Type)binaryReader.ReadInt16();
//            this.flags = (Flags)binaryReader.ReadInt16();
//            this.lightmapType = (LightmapType)binaryReader.ReadInt16();
//            this.lightmapFlags = (LightmapFlags)binaryReader.ReadInt16();
//            this.lightmapHalfLife = binaryReader.ReadSingle();
//            this.lightmapLightScale = binaryReader.ReadSingle();
//            this.targetPoint = binaryReader.ReadVector3();
//            this.widthWorldUnits = binaryReader.ReadSingle();
//            this.heightScaleWorldUnits = binaryReader.ReadSingle();
//            this.fieldOfViewDegrees = binaryReader.ReadSingle();
//            this.falloffDistanceWorldUnits = binaryReader.ReadSingle();
//            this.cutoffDistanceWorldUnitsFromFarPlane = binaryReader.ReadSingle();
//        }
//        public enum Type : short
//        {
//            Sphere = 0,
//            Orthogonal = 1,
//            Projective = 2,
//            Pyramid = 3,
//        }
//        [Flags]
//        public enum Flags : short
//        {
//            CustomGeometry = 1,
//            Unused = 2,
//            CinematicOnly = 4,
//        }
//        public enum LightmapType : short
//        {
//            UseLightTagSetting = 0,
//            DynamicOnly = 1,
//            DynamicWithLightmaps = 2,
//            LightmapsOnly = 3,
//        }
//        [Flags]
//        public enum LightmapFlags : short
//        {
//            Unused = 1,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 108, Pack = 4)]
//    public partial class ScenarioLightBlock
//    {
//        public ShortBlockIndex1 type;
//        public ShortBlockIndex1 name;
//        [TagStructField]
//        public ScenarioObjectDatumStruct objectData;
//        [TagStructField]
//        public ScenarioDeviceStruct deviceData;
//        [TagStructField]
//        public ScenarioLightStruct lightData;
//        public ScenarioLightBlock()
//        {
//        }
//        public ScenarioLightBlock(BinaryReader binaryReader)
//        {
//            this.type = binaryReader.ReadShortBlockIndex1();
//            this.name = binaryReader.ReadShortBlockIndex1();
//            this.objectData = new ScenarioObjectDatumStruct(binaryReader);
//            this.deviceData = new ScenarioDeviceStruct(binaryReader);
//            this.lightData = new ScenarioLightStruct(binaryReader);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class ScenarioLightPaletteBlock
//    {
//        [TagReference("ligh")]
//        public TagReference name;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
//        private byte[] padding;
//        #endregion
//        public ScenarioLightPaletteBlock()
//        {
//        }
//        public ScenarioLightPaletteBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(32);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 68, Pack = 4)]
//    public partial class ScenarioProfilesBlock
//    {
//        public String32 name;
//        public float startingHealthDamage01;
//        public float startingShieldDamage01;
//        [TagReference("weap")]
//        public TagReference primaryWeapon;
//        public short roundsLoaded;
//        public short roundsTotal;
//        [TagReference("weap")]
//        public TagReference secondaryWeapon;
//        public short roundsLoaded0;
//        public short roundsTotal0;
//        public byte startingFragmentationGrenadeCount;
//        public byte startingPlasmaGrenadeCount;
//        public byte startingUnknownGrenadeCount;
//        public byte startingUnknownGrenadeCount0;
//        public ScenarioProfilesBlock()
//        {
//        }
//        public ScenarioProfilesBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.startingHealthDamage01 = binaryReader.ReadSingle();
//            this.startingShieldDamage01 = binaryReader.ReadSingle();
//            this.primaryWeapon = binaryReader.ReadTagReference();
//            this.roundsLoaded = binaryReader.ReadInt16();
//            this.roundsTotal = binaryReader.ReadInt16();
//            this.secondaryWeapon = binaryReader.ReadTagReference();
//            this.roundsLoaded0 = binaryReader.ReadInt16();
//            this.roundsTotal0 = binaryReader.ReadInt16();
//            this.startingFragmentationGrenadeCount = binaryReader.ReadByte();
//            this.startingPlasmaGrenadeCount = binaryReader.ReadByte();
//            this.startingUnknownGrenadeCount = binaryReader.ReadByte();
//            this.startingUnknownGrenadeCount0 = binaryReader.ReadByte();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 52, Pack = 4)]
//    public partial class ScenarioPlayersBlock
//    {
//        public Vector3 position;
//        public float facingDegrees;
//        public TeamDesignator teamDesignator;
//        public short bSPIndex;
//        public GameType1 gameType1;
//        public GameType2 gameType2;
//        public GameType3 gameType3;
//        public GameType4 gameType4;
//        public SpawnType0 spawnType0;
//        public SpawnType1 spawnType1;
//        public SpawnType2 spawnType2;
//        public SpawnType3 spawnType3;
//        public StringID eMPTYSTRING;
//        public StringID eMPTYSTRING0;
//        public CampaignPlayerType campaignPlayerType;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
//        private byte[] padding;
//        #endregion
//        public ScenarioPlayersBlock()
//        {
//        }
//        public ScenarioPlayersBlock(BinaryReader binaryReader)
//        {
//            this.position = binaryReader.ReadVector3();
//            this.facingDegrees = binaryReader.ReadSingle();
//            this.teamDesignator = (TeamDesignator)binaryReader.ReadInt16();
//            this.bSPIndex = binaryReader.ReadInt16();
//            this.gameType1 = (GameType1)binaryReader.ReadInt16();
//            this.gameType2 = (GameType2)binaryReader.ReadInt16();
//            this.gameType3 = (GameType3)binaryReader.ReadInt16();
//            this.gameType4 = (GameType4)binaryReader.ReadInt16();
//            this.spawnType0 = (SpawnType0)binaryReader.ReadInt16();
//            this.spawnType1 = (SpawnType1)binaryReader.ReadInt16();
//            this.spawnType2 = (SpawnType2)binaryReader.ReadInt16();
//            this.spawnType3 = (SpawnType3)binaryReader.ReadInt16();
//            this.eMPTYSTRING = binaryReader.ReadStringID();
//            this.eMPTYSTRING0 = binaryReader.ReadStringID();
//            this.campaignPlayerType = (CampaignPlayerType)binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(6);
//        }
//        public enum TeamDesignator : short
//        {
//            RedAlpha = 0,
//            BlueBravo = 1,
//            YellowCharlie = 2,
//            GreenDelta = 3,
//            PurpleEcho = 4,
//            OrangeFoxtrot = 5,
//            BrownGolf = 6,
//            PinkHotel = 7,
//            NEUTRAL = 8,
//        }
//        public enum GameType1 : short
//        {
//            NONE = 0,
//            CaptureTheFlag = 1,
//            Slayer = 2,
//            Oddball = 3,
//            KingOfTheHill = 4,
//            Race = 5,
//            Headhunter = 6,
//            Juggernaut = 7,
//            Territories = 8,
//            Stub = 9,
//            Ignored3 = 10,
//            Ignored4 = 11,
//            AllGameTypes = 12,
//            AllExceptCTF = 13,
//            AllExceptCTFRace = 14,
//        }
//        public enum GameType2 : short
//        {
//            NONE = 0,
//            CaptureTheFlag = 1,
//            Slayer = 2,
//            Oddball = 3,
//            KingOfTheHill = 4,
//            Race = 5,
//            Headhunter = 6,
//            Juggernaut = 7,
//            Territories = 8,
//            Stub = 9,
//            Ignored3 = 10,
//            Ignored4 = 11,
//            AllGameTypes = 12,
//            AllExceptCTF = 13,
//            AllExceptCTFRace = 14,
//        }
//        public enum GameType3 : short
//        {
//            NONE = 0,
//            CaptureTheFlag = 1,
//            Slayer = 2,
//            Oddball = 3,
//            KingOfTheHill = 4,
//            Race = 5,
//            Headhunter = 6,
//            Juggernaut = 7,
//            Territories = 8,
//            Stub = 9,
//            Ignored3 = 10,
//            Ignored4 = 11,
//            AllGameTypes = 12,
//            AllExceptCTF = 13,
//            AllExceptCTFRace = 14,
//        }
//        public enum GameType4 : short
//        {
//            NONE = 0,
//            CaptureTheFlag = 1,
//            Slayer = 2,
//            Oddball = 3,
//            KingOfTheHill = 4,
//            Race = 5,
//            Headhunter = 6,
//            Juggernaut = 7,
//            Territories = 8,
//            Stub = 9,
//            Ignored3 = 10,
//            Ignored4 = 11,
//            AllGameTypes = 12,
//            AllExceptCTF = 13,
//            AllExceptCTFRace = 14,
//        }
//        public enum SpawnType0 : short
//        {
//            Both = 0,
//            InitialSpawnOnly = 1,
//            RespawnOnly = 2,
//        }
//        public enum SpawnType1 : short
//        {
//            Both = 0,
//            InitialSpawnOnly = 1,
//            RespawnOnly = 2,
//        }
//        public enum SpawnType2 : short
//        {
//            Both = 0,
//            InitialSpawnOnly = 1,
//            RespawnOnly = 2,
//        }
//        public enum SpawnType3 : short
//        {
//            Both = 0,
//            InitialSpawnOnly = 1,
//            RespawnOnly = 2,
//        }
//        public enum CampaignPlayerType : short
//        {
//            Masterchief = 0,
//            Dervish = 1,
//            ChiefMultiplayer = 2,
//            EliteMultiplayer = 3,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 68, Pack = 4)]
//    public partial class ScenarioTriggerVolumeBlock
//    {
//        public StringID name;
//        public ShortBlockIndex1 objectName;
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] skip;
//        #endregion
//        public StringID nodeName;
//        public struct EMPTYSTRING
//        {
//            public float eMPTYSTRING;
//            public EMPTYSTRING(BinaryReader binaryReader)
//            {
//                this.eMPTYSTRING = binaryReader.ReadSingle();
//            }
//        }
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
//        public EMPTYSTRING[] eMPTYSTRING;
//        public Vector3 position;
//        public Vector3 extents;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] padding0;
//        #endregion
//        public ShortBlockIndex1 killTriggerVolume;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding1;
//        #endregion
//        public ScenarioTriggerVolumeBlock()
//        {
//        }
//        public ScenarioTriggerVolumeBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadStringID();
//            this.objectName = binaryReader.ReadShortBlockIndex1();
//            this.skip = binaryReader.ReadBytes(2);
//            this.nodeName = binaryReader.ReadStringID();
//            this.eMPTYSTRING = new EMPTYSTRING[6];
//            for (int i = 0; i < 6; ++i)
//            {
//                this.eMPTYSTRING[i] = new EMPTYSTRING(binaryReader);
//            }
//            this.position = binaryReader.ReadVector3();
//            this.extents = binaryReader.ReadVector3();
//            this.padding0 = binaryReader.ReadBytes(4);
//            this.killTriggerVolume = binaryReader.ReadShortBlockIndex1();
//            this.padding1 = binaryReader.ReadBytes(2);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 52, Pack = 4)]
//    public partial class RecordedAnimationBlock
//    {
//        public String32 name;
//        public byte version;
//        public byte rawAnimationData;
//        public byte unitControlDataVersion;
//        #region padding
//        private byte padding;
//        #endregion
//        public short lengthOfAnimationTicks;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding0;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] padding1;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
//        private byte[] paddingrecordedAnimationEventStream;
//        #endregion
//        public RecordedAnimationBlock()
//        {
//        }
//        public RecordedAnimationBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.version = binaryReader.ReadByte();
//            this.rawAnimationData = binaryReader.ReadByte();
//            this.unitControlDataVersion = binaryReader.ReadByte();
//            this.padding = binaryReader.ReadByte();
//            this.lengthOfAnimationTicks = binaryReader.ReadInt16();
//            this.padding0 = binaryReader.ReadBytes(2);
//            this.padding1 = binaryReader.ReadBytes(4);
//            this.paddingrecordedAnimationEventStream = binaryReader.ReadBytes(8);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 4)]
//    public partial class ScenarioNetpointsBlock
//    {
//        public Vector3 position;
//        public float facingDegrees;
//        public Type type;
//        public TeamDesignator teamDesignator;
//        public short identifier;
//        public Flags flags;
//        public StringID eMPTYSTRING;
//        public StringID eMPTYSTRING0;
//        public ScenarioNetpointsBlock()
//        {
//        }
//        public ScenarioNetpointsBlock(BinaryReader binaryReader)
//        {
//            this.position = binaryReader.ReadVector3();
//            this.facingDegrees = binaryReader.ReadSingle();
//            this.type = (Type)binaryReader.ReadInt16();
//            this.teamDesignator = (TeamDesignator)binaryReader.ReadInt16();
//            this.identifier = binaryReader.ReadInt16();
//            this.flags = (Flags)binaryReader.ReadInt16();
//            this.eMPTYSTRING = binaryReader.ReadStringID();
//            this.eMPTYSTRING0 = binaryReader.ReadStringID();
//        }
//        public enum Type : short
//        {
//            CTFFlagSpawn = 0,
//            CTFFlagReturn = 1,
//            AssaultBombSpawn = 2,
//            AssaultBombReturn = 3,
//            OddballSpawn = 4,
//            Unused = 5,
//            RaceCheckpoint = 6,
//            TeleporterSrc = 7,
//            TeleporterDest = 8,
//            HeadhunterBin = 9,
//            TerritoriesFlag = 10,
//            KingHill0 = 11,
//            KingHill1 = 12,
//            KingHill2 = 13,
//            KingHill3 = 14,
//            KingHill4 = 15,
//            KingHill5 = 16,
//            KingHill6 = 17,
//            KingHill7 = 18,
//        }
//        public enum TeamDesignator : short
//        {
//            RedAlpha = 0,
//            BlueBravo = 1,
//            YellowCharlie = 2,
//            GreenDelta = 3,
//            PurpleEcho = 4,
//            OrangeFoxtrot = 5,
//            BrownGolf = 6,
//            PinkHotel = 7,
//            NEUTRAL = 8,
//        }
//        [Flags]
//        public enum Flags : short
//        {
//            MultipleFlagBomb = 1,
//            SingleFlagBomb = 2,
//            NeutralFlagBomb = 4,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
//    public partial class ScenarioNetgameEquipmentOrientationStruct
//    {
//        public Vector3 orientation;
//        public ScenarioNetgameEquipmentOrientationStruct()
//        {
//        }
//        public ScenarioNetgameEquipmentOrientationStruct(BinaryReader binaryReader)
//        {
//            this.orientation = binaryReader.ReadVector3();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 144, Pack = 4)]
//    public partial class ScenarioNetgameEquipmentBlock
//    {
//        public Flags flags;
//        public GameType1 gameType1;
//        public GameType2 gameType2;
//        public GameType3 gameType3;
//        public GameType4 gameType4;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public short spawnTimeInSeconds0Default;
//        public short respawnOnEmptyTimeSeconds;
//        public RespawnTimerStarts respawnTimerStarts;
//        public Classification classification;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
//        private byte[] padding0;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
//        private byte[] padding1;
//        #endregion
//        public Vector3 position;
//        [TagStructField]
//        public ScenarioNetgameEquipmentOrientationStruct orientation;
//        [TagReference("")]
//        public TagReference itemVehicleCollection;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
//        private byte[] padding2;
//        #endregion
//        public ScenarioNetgameEquipmentBlock()
//        {
//        }
//        public ScenarioNetgameEquipmentBlock(BinaryReader binaryReader)
//        {
//            this.flags = (Flags)binaryReader.ReadInt32();
//            this.gameType1 = (GameType1)binaryReader.ReadInt16();
//            this.gameType2 = (GameType2)binaryReader.ReadInt16();
//            this.gameType3 = (GameType3)binaryReader.ReadInt16();
//            this.gameType4 = (GameType4)binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            this.spawnTimeInSeconds0Default = binaryReader.ReadInt16();
//            this.respawnOnEmptyTimeSeconds = binaryReader.ReadInt16();
//            this.respawnTimerStarts = (RespawnTimerStarts)binaryReader.ReadInt16();
//            this.classification = (Classification)binaryReader.ReadByte();
//            this.padding0 = binaryReader.ReadBytes(3);
//            this.padding1 = binaryReader.ReadBytes(40);
//            this.position = binaryReader.ReadVector3();
//            this.orientation = new ScenarioNetgameEquipmentOrientationStruct(binaryReader);
//            this.itemVehicleCollection = binaryReader.ReadTagReference();
//            this.padding2 = binaryReader.ReadBytes(48);
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            Levitate = 1,
//            DestroyExistingOnNewSpawn = 2,
//        }
//        public enum GameType1 : short
//        {
//            NONE = 0,
//            CaptureTheFlag = 1,
//            Slayer = 2,
//            Oddball = 3,
//            KingOfTheHill = 4,
//            Race = 5,
//            Headhunter = 6,
//            Juggernaut = 7,
//            Territories = 8,
//            Stub = 9,
//            Ignored3 = 10,
//            Ignored4 = 11,
//            AllGameTypes = 12,
//            AllExceptCTF = 13,
//            AllExceptCTFRace = 14,
//        }
//        public enum GameType2 : short
//        {
//            NONE = 0,
//            CaptureTheFlag = 1,
//            Slayer = 2,
//            Oddball = 3,
//            KingOfTheHill = 4,
//            Race = 5,
//            Headhunter = 6,
//            Juggernaut = 7,
//            Territories = 8,
//            Stub = 9,
//            Ignored3 = 10,
//            Ignored4 = 11,
//            AllGameTypes = 12,
//            AllExceptCTF = 13,
//            AllExceptCTFRace = 14,
//        }
//        public enum GameType3 : short
//        {
//            NONE = 0,
//            CaptureTheFlag = 1,
//            Slayer = 2,
//            Oddball = 3,
//            KingOfTheHill = 4,
//            Race = 5,
//            Headhunter = 6,
//            Juggernaut = 7,
//            Territories = 8,
//            Stub = 9,
//            Ignored3 = 10,
//            Ignored4 = 11,
//            AllGameTypes = 12,
//            AllExceptCTF = 13,
//            AllExceptCTFRace = 14,
//        }
//        public enum GameType4 : short
//        {
//            NONE = 0,
//            CaptureTheFlag = 1,
//            Slayer = 2,
//            Oddball = 3,
//            KingOfTheHill = 4,
//            Race = 5,
//            Headhunter = 6,
//            Juggernaut = 7,
//            Territories = 8,
//            Stub = 9,
//            Ignored3 = 10,
//            Ignored4 = 11,
//            AllGameTypes = 12,
//            AllExceptCTF = 13,
//            AllExceptCTFRace = 14,
//        }
//        public enum RespawnTimerStarts : short
//        {
//            OnPickUp = 0,
//            OnBodyDepletion = 1,
//        }
//        public enum Classification : byte
//        {
//            Weapon = 0,
//            PrimaryLightLand = 1,
//            SecondaryLightLand = 2,
//            PrimaryHeavyLand = 3,
//            PrimaryFlying = 4,
//            SecondaryHeavyLand = 5,
//            PrimaryTurret = 6,
//            SecondaryTurret = 7,
//            Grenade = 8,
//            Powerup = 9,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 156, Pack = 4)]
//    public partial class ScenarioStartingEquipmentBlock
//    {
//        public Flags flags;
//        public GameType1 gameType1;
//        public GameType2 gameType2;
//        public GameType3 gameType3;
//        public GameType4 gameType4;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
//        private byte[] padding;
//        #endregion
//        [TagReference("itmc")]
//        public TagReference itemCollection1;
//        [TagReference("itmc")]
//        public TagReference itemCollection2;
//        [TagReference("itmc")]
//        public TagReference itemCollection3;
//        [TagReference("itmc")]
//        public TagReference itemCollection4;
//        [TagReference("itmc")]
//        public TagReference itemCollection5;
//        [TagReference("itmc")]
//        public TagReference itemCollection6;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
//        private byte[] padding0;
//        #endregion
//        public ScenarioStartingEquipmentBlock()
//        {
//        }
//        public ScenarioStartingEquipmentBlock(BinaryReader binaryReader)
//        {
//            this.flags = (Flags)binaryReader.ReadInt32();
//            this.gameType1 = (GameType1)binaryReader.ReadInt16();
//            this.gameType2 = (GameType2)binaryReader.ReadInt16();
//            this.gameType3 = (GameType3)binaryReader.ReadInt16();
//            this.gameType4 = (GameType4)binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(48);
//            this.itemCollection1 = binaryReader.ReadTagReference();
//            this.itemCollection2 = binaryReader.ReadTagReference();
//            this.itemCollection3 = binaryReader.ReadTagReference();
//            this.itemCollection4 = binaryReader.ReadTagReference();
//            this.itemCollection5 = binaryReader.ReadTagReference();
//            this.itemCollection6 = binaryReader.ReadTagReference();
//            this.padding0 = binaryReader.ReadBytes(48);
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            NoGrenades = 1,
//            PlasmaGrenades = 2,
//        }
//        public enum GameType1 : short
//        {
//            NONE = 0,
//            CaptureTheFlag = 1,
//            Slayer = 2,
//            Oddball = 3,
//            KingOfTheHill = 4,
//            Race = 5,
//            Headhunter = 6,
//            Juggernaut = 7,
//            Territories = 8,
//            Stub = 9,
//            Ignored3 = 10,
//            Ignored4 = 11,
//            AllGameTypes = 12,
//            AllExceptCTF = 13,
//            AllExceptCTFRace = 14,
//        }
//        public enum GameType2 : short
//        {
//            NONE = 0,
//            CaptureTheFlag = 1,
//            Slayer = 2,
//            Oddball = 3,
//            KingOfTheHill = 4,
//            Race = 5,
//            Headhunter = 6,
//            Juggernaut = 7,
//            Territories = 8,
//            Stub = 9,
//            Ignored3 = 10,
//            Ignored4 = 11,
//            AllGameTypes = 12,
//            AllExceptCTF = 13,
//            AllExceptCTFRace = 14,
//        }
//        public enum GameType3 : short
//        {
//            NONE = 0,
//            CaptureTheFlag = 1,
//            Slayer = 2,
//            Oddball = 3,
//            KingOfTheHill = 4,
//            Race = 5,
//            Headhunter = 6,
//            Juggernaut = 7,
//            Territories = 8,
//            Stub = 9,
//            Ignored3 = 10,
//            Ignored4 = 11,
//            AllGameTypes = 12,
//            AllExceptCTF = 13,
//            AllExceptCTFRace = 14,
//        }
//        public enum GameType4 : short
//        {
//            NONE = 0,
//            CaptureTheFlag = 1,
//            Slayer = 2,
//            Oddball = 3,
//            KingOfTheHill = 4,
//            Race = 5,
//            Headhunter = 6,
//            Juggernaut = 7,
//            Territories = 8,
//            Stub = 9,
//            Ignored3 = 10,
//            Ignored4 = 11,
//            AllGameTypes = 12,
//            AllExceptCTF = 13,
//            AllExceptCTFRace = 14,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 14, Pack = 4)]
//    public partial class ScenarioBspSwitchTriggerVolumeBlock
//    {
//        public ShortBlockIndex1 triggerVolume;
//        public short source;
//        public short destination;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding0;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding1;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding2;
//        #endregion
//        public ScenarioBspSwitchTriggerVolumeBlock()
//        {
//        }
//        public ScenarioBspSwitchTriggerVolumeBlock(BinaryReader binaryReader)
//        {
//            this.triggerVolume = binaryReader.ReadShortBlockIndex1();
//            this.source = binaryReader.ReadInt16();
//            this.destination = binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            this.padding0 = binaryReader.ReadBytes(2);
//            this.padding1 = binaryReader.ReadBytes(2);
//            this.padding2 = binaryReader.ReadBytes(2);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
//    public partial class ScenarioDecalsBlock
//    {
//        public ShortBlockIndex1 decalType;
//        public byte yaw127127;
//        public byte pitch127127;
//        public Vector3 position;
//        public ScenarioDecalsBlock()
//        {
//        }
//        public ScenarioDecalsBlock(BinaryReader binaryReader)
//        {
//            this.decalType = binaryReader.ReadShortBlockIndex1();
//            this.yaw127127 = binaryReader.ReadByte();
//            this.pitch127127 = binaryReader.ReadByte();
//            this.position = binaryReader.ReadVector3();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class ScenarioDecalPaletteBlock
//    {
//        [TagReference("deca")]
//        public TagReference reference;
//        public ScenarioDecalPaletteBlock()
//        {
//        }
//        public ScenarioDecalPaletteBlock(BinaryReader binaryReader)
//        {
//            this.reference = binaryReader.ReadTagReference();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class ScenarioDetailObjectCollectionPaletteBlock
//    {
//        [TagReference("dobc")]
//        public TagReference name;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
//        private byte[] padding;
//        #endregion
//        public ScenarioDetailObjectCollectionPaletteBlock()
//        {
//        }
//        public ScenarioDetailObjectCollectionPaletteBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(32);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class StylePaletteBlock
//    {
//        [TagReference("styl")]
//        public TagReference reference;
//        public StylePaletteBlock()
//        {
//        }
//        public StylePaletteBlock(BinaryReader binaryReader)
//        {
//            this.reference = binaryReader.ReadTagReference();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 36, Pack = 4)]
//    public partial class SquadGroupsBlock
//    {
//        public String32 name;
//        public ShortBlockIndex1 parent;
//        public ShortBlockIndex1 initialOrders;
//        public SquadGroupsBlock()
//        {
//        }
//        public SquadGroupsBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.parent = binaryReader.ReadShortBlockIndex1();
//            this.initialOrders = binaryReader.ReadShortBlockIndex1();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 100, Pack = 4)]
//    public partial class ActorStartingLocationsBlock
//    {
//        public StringID name;
//        public Vector3 position;
//        public short referenceFrame;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public Vector2 facingYawPitchDegrees;
//        public Flags flags;
//        public ShortBlockIndex1 characterType;
//        public ShortBlockIndex1 initialWeapon;
//        public ShortBlockIndex1 initialSecondaryWeapon;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding0;
//        #endregion
//        public ShortBlockIndex1 vehicleType;
//        public SeatType seatType;
//        public GrenadeType grenadeType;
//        public short swarmCountNumberOfCreturesInSwarmIfASwarmIsSpawnedAtThisLocation;
//        public StringID actorVariantName;
//        public StringID vehicleVariantName;
//        public float initialMovementDistanceBeforeDoingAnythingElseTheActorWillTravelTheGivenDistanceInItsForwardDirection;
//        public ShortBlockIndex1 emitterVehicle;
//        public InitialMovementMode initialMovementMode;
//        public String32 placementScript;
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] skip1;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding2;
//        #endregion
//        public ActorStartingLocationsBlock()
//        {
//        }
//        public ActorStartingLocationsBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadStringID();
//            this.position = binaryReader.ReadVector3();
//            this.referenceFrame = binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            this.facingYawPitchDegrees = binaryReader.ReadVector2();
//            this.flags = (Flags)binaryReader.ReadInt32();
//            this.characterType = binaryReader.ReadShortBlockIndex1();
//            this.initialWeapon = binaryReader.ReadShortBlockIndex1();
//            this.initialSecondaryWeapon = binaryReader.ReadShortBlockIndex1();
//            this.padding0 = binaryReader.ReadBytes(2);
//            this.vehicleType = binaryReader.ReadShortBlockIndex1();
//            this.seatType = (SeatType)binaryReader.ReadInt16();
//            this.grenadeType = (GrenadeType)binaryReader.ReadInt16();
//            this.swarmCountNumberOfCreturesInSwarmIfASwarmIsSpawnedAtThisLocation = binaryReader.ReadInt16();
//            this.actorVariantName = binaryReader.ReadStringID();
//            this.vehicleVariantName = binaryReader.ReadStringID();
//            this.initialMovementDistanceBeforeDoingAnythingElseTheActorWillTravelTheGivenDistanceInItsForwardDirection = binaryReader.ReadSingle();
//            this.emitterVehicle = binaryReader.ReadShortBlockIndex1();
//            this.initialMovementMode = (InitialMovementMode)binaryReader.ReadInt16();
//            this.placementScript = binaryReader.ReadString32();
//            this.skip1 = binaryReader.ReadBytes(2);
//            this.padding2 = binaryReader.ReadBytes(2);
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            InitiallyAsleep = 1,
//            InfectionFormExplode = 2,
//            NA = 4,
//            AlwaysPlace = 8,
//            InitiallyHidden = 16,
//        }
//        public enum SeatType : short
//        {
//            DEFAULT = 0,
//            Passenger = 1,
//            Gunner = 2,
//            Driver = 3,
//            SmallCargo = 4,
//            LargeCargo = 5,
//            NODriver = 6,
//            NOVehicle = 7,
//        }
//        public enum GrenadeType : short
//        {
//            NONE = 0,
//            HumanGrenade = 1,
//            CovenantPlasma = 2,
//        }
//        public enum InitialMovementMode : short
//        {
//            Default = 0,
//            Climbing = 1,
//            Flying = 2,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 116, Pack = 4)]
//    public partial class SquadsBlock
//    {
//        public String32 name;
//        public Flags flags;
//        public Team team;
//        public ShortBlockIndex1 parent;
//        public float squadDelayTimeSeconds;
//        public short normalDiffCountInitialNumberOfActorsOnNormalDifficulty;
//        public short insaneDiffCountInitialNumberOfActorsOnInsaneDifficultyHardDifficultyIsMidwayBetweenNormalAndInsane;
//        public MajorUpgrade majorUpgrade;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public ShortBlockIndex1 vehicleType;
//        public ShortBlockIndex1 characterType;
//        public ShortBlockIndex1 initialZone;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding0;
//        #endregion
//        public ShortBlockIndex1 initialWeapon;
//        public ShortBlockIndex1 initialSecondaryWeapon;
//        public GrenadeType grenadeType;
//        public ShortBlockIndex1 initialOrder;
//        public StringID vehicleVariant;
//        [TagBlockField]
//        public ActorStartingLocationsBlock[] startingLocations;
//        public String32 placementScript;
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] skip1;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding2;
//        #endregion
//        public SquadsBlock()
//        {
//        }
//        public SquadsBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.flags = (Flags)binaryReader.ReadInt32();
//            this.team = (Team)binaryReader.ReadInt16();
//            this.parent = binaryReader.ReadShortBlockIndex1();
//            this.squadDelayTimeSeconds = binaryReader.ReadSingle();
//            this.normalDiffCountInitialNumberOfActorsOnNormalDifficulty = binaryReader.ReadInt16();
//            this.insaneDiffCountInitialNumberOfActorsOnInsaneDifficultyHardDifficultyIsMidwayBetweenNormalAndInsane = binaryReader.ReadInt16();
//            this.majorUpgrade = (MajorUpgrade)binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            this.vehicleType = binaryReader.ReadShortBlockIndex1();
//            this.characterType = binaryReader.ReadShortBlockIndex1();
//            this.initialZone = binaryReader.ReadShortBlockIndex1();
//            this.padding0 = binaryReader.ReadBytes(2);
//            this.initialWeapon = binaryReader.ReadShortBlockIndex1();
//            this.initialSecondaryWeapon = binaryReader.ReadShortBlockIndex1();
//            this.grenadeType = (GrenadeType)binaryReader.ReadInt16();
//            this.initialOrder = binaryReader.ReadShortBlockIndex1();
//            this.vehicleVariant = binaryReader.ReadStringID();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ActorStartingLocationsBlock));
//                this.startingLocations = new ActorStartingLocationsBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.startingLocations[i] = new ActorStartingLocationsBlock(binaryReader);
//                    }
//                }
//            }
//            this.placementScript = binaryReader.ReadString32();
//            this.skip1 = binaryReader.ReadBytes(2);
//            this.padding2 = binaryReader.ReadBytes(2);
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            Unused = 1,
//            NeverSearch = 2,
//            StartTimerImmediately = 4,
//            NoTimerDelayForever = 8,
//            MagicSightAfterTimer = 16,
//            AutomaticMigration = 32,
//            DEPRECATED = 64,
//            RespawnEnabled = 128,
//            Blind = 256,
//            Deaf = 512,
//            Braindead = 1024,
//            invalidName_3DFiringPositions = 2048,
//            InitiallyPlaced = 4096,
//            UnitsNotEnterableByPlayer = 8192,
//        }
//        public enum Team : short
//        {
//            Default = 0,
//            Player = 1,
//            Human = 2,
//            Covenant = 3,
//            Flood = 4,
//            Sentinel = 5,
//            Heretic = 6,
//            Prophet = 7,
//            Unused8 = 8,
//            Unused9 = 9,
//            Unused10 = 10,
//            Unused11 = 11,
//            Unused12 = 12,
//            Unused13 = 13,
//            Unused14 = 14,
//            Unused15 = 15,
//        }
//        public enum MajorUpgrade : short
//        {
//            Normal = 0,
//            Few = 1,
//            Many = 2,
//            None = 3,
//            All = 4,
//        }
//        public enum GrenadeType : short
//        {
//            NONE = 0,
//            HumanGrenade = 1,
//            CovenantPlasma = 2,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 4)]
//    public partial class FiringPositionsBlock
//    {
//        public Vector3 positionLocal;
//        public short referenceFrame;
//        public Flags flags;
//        public ShortBlockIndex1 area;
//        public short clusterIndex;
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] skip;
//        #endregion
//        public Vector2 normal;
//        public FiringPositionsBlock()
//        {
//        }
//        public FiringPositionsBlock(BinaryReader binaryReader)
//        {
//            this.positionLocal = binaryReader.ReadVector3();
//            this.referenceFrame = binaryReader.ReadInt16();
//            this.flags = (Flags)binaryReader.ReadInt16();
//            this.area = binaryReader.ReadShortBlockIndex1();
//            this.clusterIndex = binaryReader.ReadInt16();
//            this.skip = binaryReader.ReadBytes(4);
//            this.normal = binaryReader.ReadVector2();
//        }
//        [Flags]
//        public enum Flags : short
//        {
//            Open = 1,
//            Partial = 2,
//            Closed = 4,
//            Mobile = 8,
//            WallLean = 16,
//            Perch = 32,
//            GroundPoint = 64,
//            DynamicCoverPoint = 128,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
//    public partial class FlightReferenceBlock
//    {
//        public short flightHintIndex;
//        public short poitIndex;
//        public FlightReferenceBlock()
//        {
//        }
//        public FlightReferenceBlock(BinaryReader binaryReader)
//        {
//            this.flightHintIndex = binaryReader.ReadInt16();
//            this.poitIndex = binaryReader.ReadInt16();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 136, Pack = 4)]
//    public partial class AreasBlock
//    {
//        public String32 name;
//        public AreaFlags areaFlags;
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
//        private byte[] skip;
//        #endregion
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] skip0;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
//        private byte[] padding1;
//        #endregion
//        public short manualReferenceFrame;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding2;
//        #endregion
//        [TagBlockField]
//        public FlightReferenceBlock[] flightHints;
//        public AreasBlock()
//        {
//        }
//        public AreasBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.areaFlags = (AreaFlags)binaryReader.ReadInt32();
//            this.skip = binaryReader.ReadBytes(20);
//            this.skip0 = binaryReader.ReadBytes(4);
//            this.padding1 = binaryReader.ReadBytes(64);
//            this.manualReferenceFrame = binaryReader.ReadInt16();
//            this.padding2 = binaryReader.ReadBytes(2);
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(FlightReferenceBlock));
//                this.flightHints = new FlightReferenceBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.flightHints[i] = new FlightReferenceBlock(binaryReader);
//                    }
//                }
//            }
//        }
//        [Flags]
//        public enum AreaFlags : int
//        {
//            VehicleArea = 1,
//            Perch = 2,
//            ManualReferenceFrame = 4,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 56, Pack = 4)]
//    public partial class ZoneBlock
//    {
//        public String32 name;
//        public Flags flags;
//        public ShortBlockIndex1 manualBsp;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        [TagBlockField]
//        public FiringPositionsBlock[] firingPositions;
//        [TagBlockField]
//        public AreasBlock[] areas;
//        public ZoneBlock()
//        {
//        }
//        public ZoneBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.flags = (Flags)binaryReader.ReadInt32();
//            this.manualBsp = binaryReader.ReadShortBlockIndex1();
//            this.padding = binaryReader.ReadBytes(2);
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(FiringPositionsBlock));
//                this.firingPositions = new FiringPositionsBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.firingPositions[i] = new FiringPositionsBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(AreasBlock));
//                this.areas = new AreasBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.areas[i] = new AreasBlock(binaryReader);
//                    }
//                }
//            }
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            ManualBspIndex = 1,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class TriggerReferences
//    {
//        public TriggerFlags triggerFlags;
//        public ShortBlockIndex1 trigger;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public TriggerReferences()
//        {
//        }
//        public TriggerReferences(BinaryReader binaryReader)
//        {
//            this.triggerFlags = (TriggerFlags)binaryReader.ReadInt32();
//            this.trigger = binaryReader.ReadShortBlockIndex1();
//            this.padding = binaryReader.ReadBytes(2);
//        }
//        [Flags]
//        public enum TriggerFlags : int
//        {
//            Not = 1,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
//    public partial class AiSceneTriggerBlock
//    {
//        public CombinationRule combinationRule;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        [TagBlockField]
//        public TriggerReferences[] triggers;
//        public AiSceneTriggerBlock()
//        {
//        }
//        public AiSceneTriggerBlock(BinaryReader binaryReader)
//        {
//            this.combinationRule = (CombinationRule)binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(TriggerReferences));
//                this.triggers = new TriggerReferences[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.triggers[i] = new TriggerReferences(binaryReader);
//                    }
//                }
//            }
//        }
//        public enum CombinationRule : short
//        {
//            OR = 0,
//            AND = 1,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
//    public partial class AiSceneRoleVariantsBlock
//    {
//        public StringID variantDesignation;
//        public AiSceneRoleVariantsBlock()
//        {
//        }
//        public AiSceneRoleVariantsBlock(BinaryReader binaryReader)
//        {
//            this.variantDesignation = binaryReader.ReadStringID();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
//    public partial class AiSceneRoleBlock
//    {
//        public StringID name;
//        public Group group;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        [TagBlockField]
//        public AiSceneRoleVariantsBlock[] roleVariants;
//        public AiSceneRoleBlock()
//        {
//        }
//        public AiSceneRoleBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadStringID();
//            this.group = (Group)binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(AiSceneRoleVariantsBlock));
//                this.roleVariants = new AiSceneRoleVariantsBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.roleVariants[i] = new AiSceneRoleVariantsBlock(binaryReader);
//                    }
//                }
//            }
//        }
//        public enum Group : short
//        {
//            Group1 = 0,
//            Group2 = 1,
//            Group3 = 2,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 24, Pack = 4)]
//    public partial class AiSceneBlock
//    {
//        public StringID name;
//        public Flags flags;
//        [TagBlockField]
//        public AiSceneTriggerBlock[] triggerConditions;
//        [TagBlockField]
//        public AiSceneRoleBlock[] roles;
//        public AiSceneBlock()
//        {
//        }
//        public AiSceneBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadStringID();
//            this.flags = (Flags)binaryReader.ReadInt32();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(AiSceneTriggerBlock));
//                this.triggerConditions = new AiSceneTriggerBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.triggerConditions[i] = new AiSceneTriggerBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(AiSceneRoleBlock));
//                this.roles = new AiSceneRoleBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.roles[i] = new AiSceneRoleBlock(binaryReader);
//                    }
//                }
//            }
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            SceneCanPlayMultipleTimes = 1,
//            EnableCombatDialogue = 2,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class CharacterPaletteBlock
//    {
//        [TagReference("char")]
//        public TagReference reference;
//        public CharacterPaletteBlock()
//        {
//        }
//        public CharacterPaletteBlock(BinaryReader binaryReader)
//        {
//            this.reference = binaryReader.ReadTagReference();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class SectorBlock
//    {
//        public PathFindingSectorFlags pathFindingSectorFlags;
//        public short hintIndex;
//        public int firstLinkDoNotSetManually;
//        public SectorBlock()
//        {
//        }
//        public SectorBlock(BinaryReader binaryReader)
//        {
//            this.pathFindingSectorFlags = (PathFindingSectorFlags)binaryReader.ReadInt16();
//            this.hintIndex = binaryReader.ReadInt16();
//            this.firstLinkDoNotSetManually = binaryReader.ReadInt32();
//        }
//        [Flags]
//        public enum PathFindingSectorFlags : short
//        {
//            SectorWalkable = 1,
//            SectorBreakable = 2,
//            SectorMobile = 4,
//            SectorBspSource = 8,
//            Floor = 16,
//            Ceiling = 32,
//            WallNorth = 64,
//            WallSouth = 128,
//            WallEast = 256,
//            WallWest = 512,
//            Crouchable = 1024,
//            Aligned = 2048,
//            SectorStep = 4096,
//            SectorInterior = 8192,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
//    public partial class SectorLinkBlock
//    {
//        public short vertex1;
//        public short vertex2;
//        public LinkFlags linkFlags;
//        public short hintIndex;
//        public short forwardLink;
//        public short reverseLink;
//        public short leftSector;
//        public short rightSector;
//        public SectorLinkBlock()
//        {
//        }
//        public SectorLinkBlock(BinaryReader binaryReader)
//        {
//            this.vertex1 = binaryReader.ReadInt16();
//            this.vertex2 = binaryReader.ReadInt16();
//            this.linkFlags = (LinkFlags)binaryReader.ReadInt16();
//            this.hintIndex = binaryReader.ReadInt16();
//            this.forwardLink = binaryReader.ReadInt16();
//            this.reverseLink = binaryReader.ReadInt16();
//            this.leftSector = binaryReader.ReadInt16();
//            this.rightSector = binaryReader.ReadInt16();
//        }
//        [Flags]
//        public enum LinkFlags : short
//        {
//            SectorLinkFromCollisionEdge = 1,
//            SectorIntersectionLink = 2,
//            SectorLinkBsp2dCreationError = 4,
//            SectorLinkTopologyError = 8,
//            SectorLinkChainError = 16,
//            SectorLinkBothSectorsWalkable = 32,
//            SectorLinkMagicHangingLink = 64,
//            SectorLinkThreshold = 128,
//            SectorLinkCrouchable = 256,
//            SectorLinkWallBase = 512,
//            SectorLinkLedge = 1024,
//            SectorLinkLeanable = 2048,
//            SectorLinkStartCorner = 4096,
//            SectorLinkEndCorner = 8192,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
//    public partial class RefBlock
//    {
//        public int nodeRefOrSectorRef;
//        public RefBlock()
//        {
//        }
//        public RefBlock(BinaryReader binaryReader)
//        {
//            this.nodeRefOrSectorRef = binaryReader.ReadInt32();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 4)]
//    public partial class SectorBsp2dNodesBlock
//    {
//        public Vector3 plane;
//        public int leftChild;
//        public int rightChild;
//        public SectorBsp2dNodesBlock()
//        {
//        }
//        public SectorBsp2dNodesBlock(BinaryReader binaryReader)
//        {
//            this.plane = binaryReader.ReadVector3();
//            this.leftChild = binaryReader.ReadInt32();
//            this.rightChild = binaryReader.ReadInt32();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
//    public partial class SurfaceFlagsBlock
//    {
//        public int flags;
//        public SurfaceFlagsBlock()
//        {
//        }
//        public SurfaceFlagsBlock(BinaryReader binaryReader)
//        {
//            this.flags = binaryReader.ReadInt32();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
//    public partial class SectorVertexBlock
//    {
//        public Vector3 point;
//        public SectorVertexBlock()
//        {
//        }
//        public SectorVertexBlock(BinaryReader binaryReader)
//        {
//            this.point = binaryReader.ReadVector3();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
//    public partial class EnvironmentObjectBspRefs
//    {
//        public int bspReference;
//        public int firstSector;
//        public int lastSector;
//        public short nodeIndex;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public EnvironmentObjectBspRefs()
//        {
//        }
//        public EnvironmentObjectBspRefs(BinaryReader binaryReader)
//        {
//            this.bspReference = binaryReader.ReadInt32();
//            this.firstSector = binaryReader.ReadInt32();
//            this.lastSector = binaryReader.ReadInt32();
//            this.nodeIndex = binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
//    public partial class EnvironmentObjectNodes
//    {
//        public short referenceFrameIndex;
//        public byte projectionAxis;
//        public ProjectionSign projectionSign;
//        public EnvironmentObjectNodes()
//        {
//        }
//        public EnvironmentObjectNodes(BinaryReader binaryReader)
//        {
//            this.referenceFrameIndex = binaryReader.ReadInt16();
//            this.projectionAxis = binaryReader.ReadByte();
//            this.projectionSign = (ProjectionSign)binaryReader.ReadByte();
//        }
//        [Flags]
//        public enum ProjectionSign : byte
//        {
//            ProjectionSign = 1,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 28, Pack = 4)]
//    public partial class EnvironmentObjectRefs
//    {
//        public Flags flags;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public int firstSector;
//        public int lastSector;
//        [TagBlockField]
//        public EnvironmentObjectBspRefs[] bsps;
//        [TagBlockField]
//        public EnvironmentObjectNodes[] nodes;
//        public EnvironmentObjectRefs()
//        {
//        }
//        public EnvironmentObjectRefs(BinaryReader binaryReader)
//        {
//            this.flags = (Flags)binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            this.firstSector = binaryReader.ReadInt32();
//            this.lastSector = binaryReader.ReadInt32();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(EnvironmentObjectBspRefs));
//                this.bsps = new EnvironmentObjectBspRefs[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.bsps[i] = new EnvironmentObjectBspRefs(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(EnvironmentObjectNodes));
//                this.nodes = new EnvironmentObjectNodes[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.nodes[i] = new EnvironmentObjectNodes(binaryReader);
//                    }
//                }
//            }
//        }
//        [Flags]
//        public enum Flags : short
//        {
//            Mobile = 1,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 4)]
//    public partial class PathfindingHintsBlock
//    {
//        public HintType hintType;
//        public short nextHintIndex;
//        public short hintData0;
//        public short hintData1;
//        public short hintData2;
//        public short hintData3;
//        public short hintData4;
//        public short hintData5;
//        public short hintData6;
//        public short hintData7;
//        public PathfindingHintsBlock()
//        {
//        }
//        public PathfindingHintsBlock(BinaryReader binaryReader)
//        {
//            this.hintType = (HintType)binaryReader.ReadInt16();
//            this.nextHintIndex = binaryReader.ReadInt16();
//            this.hintData0 = binaryReader.ReadInt16();
//            this.hintData1 = binaryReader.ReadInt16();
//            this.hintData2 = binaryReader.ReadInt16();
//            this.hintData3 = binaryReader.ReadInt16();
//            this.hintData4 = binaryReader.ReadInt16();
//            this.hintData5 = binaryReader.ReadInt16();
//            this.hintData6 = binaryReader.ReadInt16();
//            this.hintData7 = binaryReader.ReadInt16();
//        }
//        public enum HintType : short
//        {
//            IntersectionLink = 0,
//            JumpLink = 1,
//            ClimbLink = 2,
//            VaultLink = 3,
//            MountLink = 4,
//            HoistLink = 5,
//            WallJumpLink = 6,
//            BreakableFloor = 7,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
//    public partial class InstancedGeometryReferenceBlock
//    {
//        public short pathfindingObjectIndex;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public InstancedGeometryReferenceBlock()
//        {
//        }
//        public InstancedGeometryReferenceBlock(BinaryReader binaryReader)
//        {
//            this.pathfindingObjectIndex = binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
//    public partial class UserHintPointBlock
//    {
//        public Vector3 point;
//        public short referenceFrame;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public UserHintPointBlock()
//        {
//        }
//        public UserHintPointBlock(BinaryReader binaryReader)
//        {
//            this.point = binaryReader.ReadVector3();
//            this.referenceFrame = binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 28, Pack = 4)]
//    public partial class UserHintRayBlock
//    {
//        public Vector3 point;
//        public short referenceFrame;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public Vector3 vector;
//        public UserHintRayBlock()
//        {
//        }
//        public UserHintRayBlock(BinaryReader binaryReader)
//        {
//            this.point = binaryReader.ReadVector3();
//            this.referenceFrame = binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            this.vector = binaryReader.ReadVector3();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 36, Pack = 4)]
//    public partial class UserHintLineSegmentBlock
//    {
//        public Flags flags;
//        public Vector3 point0;
//        public short referenceFrame;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public Vector3 point1;
//        public short referenceFrame0;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding0;
//        #endregion
//        public UserHintLineSegmentBlock()
//        {
//        }
//        public UserHintLineSegmentBlock(BinaryReader binaryReader)
//        {
//            this.flags = (Flags)binaryReader.ReadInt32();
//            this.point0 = binaryReader.ReadVector3();
//            this.referenceFrame = binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            this.point1 = binaryReader.ReadVector3();
//            this.referenceFrame0 = binaryReader.ReadInt16();
//            this.padding0 = binaryReader.ReadBytes(2);
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            Bidirectional = 1,
//            Closed = 2,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 68, Pack = 4)]
//    public partial class UserHintParallelogramBlock
//    {
//        public Flags flags;
//        public Vector3 point0;
//        public short referenceFrame;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public Vector3 point1;
//        public short referenceFrame0;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding0;
//        #endregion
//        public Vector3 point2;
//        public short referenceFrame1;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding1;
//        #endregion
//        public Vector3 point3;
//        public short referenceFrame2;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding2;
//        #endregion
//        public UserHintParallelogramBlock()
//        {
//        }
//        public UserHintParallelogramBlock(BinaryReader binaryReader)
//        {
//            this.flags = (Flags)binaryReader.ReadInt32();
//            this.point0 = binaryReader.ReadVector3();
//            this.referenceFrame = binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            this.point1 = binaryReader.ReadVector3();
//            this.referenceFrame0 = binaryReader.ReadInt16();
//            this.padding0 = binaryReader.ReadBytes(2);
//            this.point2 = binaryReader.ReadVector3();
//            this.referenceFrame1 = binaryReader.ReadInt16();
//            this.padding1 = binaryReader.ReadBytes(2);
//            this.point3 = binaryReader.ReadVector3();
//            this.referenceFrame2 = binaryReader.ReadInt16();
//            this.padding2 = binaryReader.ReadBytes(2);
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            Bidirectional = 1,
//            Closed = 2,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
//    public partial class UserHintPolygonBlock
//    {
//        public Flags flags;
//        [TagBlockField]
//        public UserHintPointBlock[] points;
//        public UserHintPolygonBlock()
//        {
//        }
//        public UserHintPolygonBlock(BinaryReader binaryReader)
//        {
//            this.flags = (Flags)binaryReader.ReadInt32();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(UserHintPointBlock));
//                this.points = new UserHintPointBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.points[i] = new UserHintPointBlock(binaryReader);
//                    }
//                }
//            }
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            Bidirectional = 1,
//            Closed = 2,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class UserHintJumpBlock
//    {
//        public Flags flags;
//        public ShortBlockIndex1 geometryIndex;
//        public ForceJumpHeight forceJumpHeight;
//        public ControlFlags controlFlags;
//        public UserHintJumpBlock()
//        {
//        }
//        public UserHintJumpBlock(BinaryReader binaryReader)
//        {
//            this.flags = (Flags)binaryReader.ReadInt16();
//            this.geometryIndex = binaryReader.ReadShortBlockIndex1();
//            this.forceJumpHeight = (ForceJumpHeight)binaryReader.ReadInt16();
//            this.controlFlags = (ControlFlags)binaryReader.ReadInt16();
//        }
//        [Flags]
//        public enum Flags : short
//        {
//            Bidirectional = 1,
//            Closed = 2,
//        }
//        public enum ForceJumpHeight : short
//        {
//            NONE = 0,
//            Down = 1,
//            Step = 2,
//            Crouch = 3,
//            Stand = 4,
//            Storey = 5,
//            Tower = 6,
//            Infinite = 7,
//        }
//        [Flags]
//        public enum ControlFlags : short
//        {
//            MagicLift = 1,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
//    public partial class UserHintClimbBlock
//    {
//        public Flags flags;
//        public ShortBlockIndex1 geometryIndex;
//        public UserHintClimbBlock()
//        {
//        }
//        public UserHintClimbBlock(BinaryReader binaryReader)
//        {
//            this.flags = (Flags)binaryReader.ReadInt16();
//            this.geometryIndex = binaryReader.ReadShortBlockIndex1();
//        }
//        [Flags]
//        public enum Flags : short
//        {
//            Bidirectional = 1,
//            Closed = 2,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 4)]
//    public partial class UserHintWellPointBlock
//    {
//        public Type type;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public Vector3 point;
//        public short referenceFrame;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding0;
//        #endregion
//        public int sectorIndex;
//        public Vector2 normal;
//        public UserHintWellPointBlock()
//        {
//        }
//        public UserHintWellPointBlock(BinaryReader binaryReader)
//        {
//            this.type = (Type)binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            this.point = binaryReader.ReadVector3();
//            this.referenceFrame = binaryReader.ReadInt16();
//            this.padding0 = binaryReader.ReadBytes(2);
//            this.sectorIndex = binaryReader.ReadInt32();
//            this.normal = binaryReader.ReadVector2();
//        }
//        public enum Type : short
//        {
//            Jump = 0,
//            Climb = 1,
//            Hoist = 2,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
//    public partial class UserHintWellBlock
//    {
//        public Flags flags;
//        [TagBlockField]
//        public UserHintWellPointBlock[] points;
//        public UserHintWellBlock()
//        {
//        }
//        public UserHintWellBlock(BinaryReader binaryReader)
//        {
//            this.flags = (Flags)binaryReader.ReadInt32();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(UserHintWellPointBlock));
//                this.points = new UserHintWellPointBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.points[i] = new UserHintWellPointBlock(binaryReader);
//                    }
//                }
//            }
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            Bidirectional = 1,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
//    public partial class UserHintFlightPointBlock
//    {
//        public Vector3 point;
//        public UserHintFlightPointBlock()
//        {
//        }
//        public UserHintFlightPointBlock(BinaryReader binaryReader)
//        {
//            this.point = binaryReader.ReadVector3();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class UserHintFlightBlock
//    {
//        [TagBlockField]
//        public UserHintFlightPointBlock[] points;
//        public UserHintFlightBlock()
//        {
//        }
//        public UserHintFlightBlock(BinaryReader binaryReader)
//        {
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(UserHintFlightPointBlock));
//                this.points = new UserHintFlightPointBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.points[i] = new UserHintFlightPointBlock(binaryReader);
//                    }
//                }
//            }
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 72, Pack = 4)]
//    public partial class UserHintBlock
//    {
//        [TagBlockField]
//        public UserHintPointBlock[] pointGeometry;
//        [TagBlockField]
//        public UserHintRayBlock[] rayGeometry;
//        [TagBlockField]
//        public UserHintLineSegmentBlock[] lineSegmentGeometry;
//        [TagBlockField]
//        public UserHintParallelogramBlock[] parallelogramGeometry;
//        [TagBlockField]
//        public UserHintPolygonBlock[] polygonGeometry;
//        [TagBlockField]
//        public UserHintJumpBlock[] jumpHints;
//        [TagBlockField]
//        public UserHintClimbBlock[] climbHints;
//        [TagBlockField]
//        public UserHintWellBlock[] wellHints;
//        [TagBlockField]
//        public UserHintFlightBlock[] flightHints;
//        public UserHintBlock()
//        {
//        }
//        public UserHintBlock(BinaryReader binaryReader)
//        {
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(UserHintPointBlock));
//                this.pointGeometry = new UserHintPointBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.pointGeometry[i] = new UserHintPointBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(UserHintRayBlock));
//                this.rayGeometry = new UserHintRayBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.rayGeometry[i] = new UserHintRayBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(UserHintLineSegmentBlock));
//                this.lineSegmentGeometry = new UserHintLineSegmentBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.lineSegmentGeometry[i] = new UserHintLineSegmentBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(UserHintParallelogramBlock));
//                this.parallelogramGeometry = new UserHintParallelogramBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.parallelogramGeometry[i] = new UserHintParallelogramBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(UserHintPolygonBlock));
//                this.polygonGeometry = new UserHintPolygonBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.polygonGeometry[i] = new UserHintPolygonBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(UserHintJumpBlock));
//                this.jumpHints = new UserHintJumpBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.jumpHints[i] = new UserHintJumpBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(UserHintClimbBlock));
//                this.climbHints = new UserHintClimbBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.climbHints[i] = new UserHintClimbBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(UserHintWellBlock));
//                this.wellHints = new UserHintWellBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.wellHints[i] = new UserHintWellBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(UserHintFlightBlock));
//                this.flightHints = new UserHintFlightBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.flightHints[i] = new UserHintFlightBlock(binaryReader);
//                    }
//                }
//            }
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 116, Pack = 4)]
//    public partial class PathfindingDataBlock
//    {
//        [TagBlockField]
//        public SectorBlock[] sectors;
//        [TagBlockField]
//        public SectorLinkBlock[] links;
//        [TagBlockField]
//        public RefBlock[] refs;
//        [TagBlockField]
//        public SectorBsp2dNodesBlock[] bsp2dNodes;
//        [TagBlockField]
//        public SurfaceFlagsBlock[] surfaceFlags;
//        [TagBlockField]
//        public SectorVertexBlock[] vertices;
//        [TagBlockField]
//        public EnvironmentObjectRefs[] objectRefs;
//        [TagBlockField]
//        public PathfindingHintsBlock[] pathfindingHints;
//        [TagBlockField]
//        public InstancedGeometryReferenceBlock[] instancedGeometryRefs;
//        public int structureChecksum;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
//        private byte[] padding;
//        #endregion
//        [TagBlockField]
//        public UserHintBlock[] userPlacedHints;
//        public PathfindingDataBlock()
//        {
//        }
//        public PathfindingDataBlock(BinaryReader binaryReader)
//        {
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(SectorBlock));
//                this.sectors = new SectorBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.sectors[i] = new SectorBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(SectorLinkBlock));
//                this.links = new SectorLinkBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.links[i] = new SectorLinkBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(RefBlock));
//                this.refs = new RefBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.refs[i] = new RefBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(SectorBsp2dNodesBlock));
//                this.bsp2dNodes = new SectorBsp2dNodesBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.bsp2dNodes[i] = new SectorBsp2dNodesBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(SurfaceFlagsBlock));
//                this.surfaceFlags = new SurfaceFlagsBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.surfaceFlags[i] = new SurfaceFlagsBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(SectorVertexBlock));
//                this.vertices = new SectorVertexBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.vertices[i] = new SectorVertexBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(EnvironmentObjectRefs));
//                this.objectRefs = new EnvironmentObjectRefs[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.objectRefs[i] = new EnvironmentObjectRefs(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(PathfindingHintsBlock));
//                this.pathfindingHints = new PathfindingHintsBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.pathfindingHints[i] = new PathfindingHintsBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(InstancedGeometryReferenceBlock));
//                this.instancedGeometryRefs = new InstancedGeometryReferenceBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.instancedGeometryRefs[i] = new InstancedGeometryReferenceBlock(binaryReader);
//                    }
//                }
//            }
//            this.structureChecksum = binaryReader.ReadInt32();
//            this.padding = binaryReader.ReadBytes(32);
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(UserHintBlock));
//                this.userPlacedHints = new UserHintBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.userPlacedHints[i] = new UserHintBlock(binaryReader);
//                    }
//                }
//            }
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 52, Pack = 4)]
//    public partial class AiAnimationReferenceBlock
//    {
//        public String32 animationName;
//        [TagReference("jmad")]
//        public TagReference animationGraphLeaveThisBlankToUseTheUnitsNormalAnimationGraph;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
//        private byte[] padding;
//        #endregion
//        public AiAnimationReferenceBlock()
//        {
//        }
//        public AiAnimationReferenceBlock(BinaryReader binaryReader)
//        {
//            this.animationName = binaryReader.ReadString32();
//            this.animationGraphLeaveThisBlankToUseTheUnitsNormalAnimationGraph = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(12);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class AiScriptReferenceBlock
//    {
//        public String32 scriptName;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
//        private byte[] padding;
//        #endregion
//        public AiScriptReferenceBlock()
//        {
//        }
//        public AiScriptReferenceBlock(BinaryReader binaryReader)
//        {
//            this.scriptName = binaryReader.ReadString32();
//            this.padding = binaryReader.ReadBytes(8);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class AiRecordingReferenceBlock
//    {
//        public String32 recordingName;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
//        private byte[] padding;
//        #endregion
//        public AiRecordingReferenceBlock()
//        {
//        }
//        public AiRecordingReferenceBlock(BinaryReader binaryReader)
//        {
//            this.recordingName = binaryReader.ReadString32();
//            this.padding = binaryReader.ReadBytes(8);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 84, Pack = 4)]
//    public partial class AiConversationParticipantBlock
//    {
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
//        private byte[] padding;
//        #endregion
//        public ShortBlockIndex1 useThisObjectIfAUnitWithThisNameExistsWeTryToPickThemToStartTheConversation;
//        public ShortBlockIndex1 setNewNameOnceWePickAUnitWeNameItThis;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
//        private byte[] padding0;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
//        private byte[] padding1;
//        #endregion
//        public String32 encounterName;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] padding2;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
//        private byte[] padding3;
//        #endregion
//        public AiConversationParticipantBlock()
//        {
//        }
//        public AiConversationParticipantBlock(BinaryReader binaryReader)
//        {
//            this.padding = binaryReader.ReadBytes(8);
//            this.useThisObjectIfAUnitWithThisNameExistsWeTryToPickThemToStartTheConversation = binaryReader.ReadShortBlockIndex1();
//            this.setNewNameOnceWePickAUnitWeNameItThis = binaryReader.ReadShortBlockIndex1();
//            this.padding0 = binaryReader.ReadBytes(12);
//            this.padding1 = binaryReader.ReadBytes(12);
//            this.encounterName = binaryReader.ReadString32();
//            this.padding2 = binaryReader.ReadBytes(4);
//            this.padding3 = binaryReader.ReadBytes(12);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 76, Pack = 4)]
//    public partial class AiConversationLineBlock
//    {
//        public Flags flags;
//        public ShortBlockIndex1 participant;
//        public Addressee addressee;
//        public ShortBlockIndex1 addresseeParticipantThisFieldIsOnlyUsedIfTheAddresseeTypeIsParticipant;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] padding;
//        #endregion
//        public float lineDelayTime;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
//        private byte[] padding0;
//        #endregion
//        [TagReference("snd!")]
//        public TagReference variant1;
//        [TagReference("snd!")]
//        public TagReference variant2;
//        [TagReference("snd!")]
//        public TagReference variant3;
//        [TagReference("snd!")]
//        public TagReference variant4;
//        [TagReference("snd!")]
//        public TagReference variant5;
//        [TagReference("snd!")]
//        public TagReference variant6;
//        public AiConversationLineBlock()
//        {
//        }
//        public AiConversationLineBlock(BinaryReader binaryReader)
//        {
//            this.flags = (Flags)binaryReader.ReadInt16();
//            this.participant = binaryReader.ReadShortBlockIndex1();
//            this.addressee = (Addressee)binaryReader.ReadInt16();
//            this.addresseeParticipantThisFieldIsOnlyUsedIfTheAddresseeTypeIsParticipant = binaryReader.ReadShortBlockIndex1();
//            this.padding = binaryReader.ReadBytes(4);
//            this.lineDelayTime = binaryReader.ReadSingle();
//            this.padding0 = binaryReader.ReadBytes(12);
//            this.variant1 = binaryReader.ReadTagReference();
//            this.variant2 = binaryReader.ReadTagReference();
//            this.variant3 = binaryReader.ReadTagReference();
//            this.variant4 = binaryReader.ReadTagReference();
//            this.variant5 = binaryReader.ReadTagReference();
//            this.variant6 = binaryReader.ReadTagReference();
//        }
//        [Flags]
//        public enum Flags : short
//        {
//            AddresseeLookAtSpeaker = 1,
//            EveryoneLookAtSpeaker = 2,
//            EveryoneLookAtAddressee = 4,
//            WaitAfterUntilToldToAdvance = 8,
//            WaitUntilSpeakerNearby = 16,
//            WaitUntilEveryoneNearby = 32,
//        }
//        public enum Addressee : short
//        {
//            None = 0,
//            Player = 1,
//            Participant = 2,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 0, Pack = 4)]
//    public partial class GNullBlock
//    {
//        public GNullBlock()
//        {
//        }
//        public GNullBlock(BinaryReader binaryReader)
//        {
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 104, Pack = 4)]
//    public partial class AiConversationBlock
//    {
//        public String32 name;
//        public Flags flags;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public float triggerDistanceWorldUnitsDistanceThePlayerMustEnterBeforeTheConversationCanTrigger;
//        public float runToPlayerDistWorldUnitsIfTheInvolvesPlayerFlagIsSetWhenTriggeredTheConversationsParticipantSWillRunToWithinThisDistanceOfThePlayer;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
//        private byte[] padding0;
//        #endregion
//        [TagBlockField]
//        public AiConversationParticipantBlock[] participants;
//        [TagBlockField]
//        public AiConversationLineBlock[] lines;
//        [TagBlockField]
//        public GNullBlock[] gNullBlock;
//        public AiConversationBlock()
//        {
//        }
//        public AiConversationBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.flags = (Flags)binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            this.triggerDistanceWorldUnitsDistanceThePlayerMustEnterBeforeTheConversationCanTrigger = binaryReader.ReadSingle();
//            this.runToPlayerDistWorldUnitsIfTheInvolvesPlayerFlagIsSetWhenTriggeredTheConversationsParticipantSWillRunToWithinThisDistanceOfThePlayer = binaryReader.ReadSingle();
//            this.padding0 = binaryReader.ReadBytes(36);
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(AiConversationParticipantBlock));
//                this.participants = new AiConversationParticipantBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.participants[i] = new AiConversationParticipantBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(AiConversationLineBlock));
//                this.lines = new AiConversationLineBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.lines[i] = new AiConversationLineBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(GNullBlock));
//                this.gNullBlock = new GNullBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.gNullBlock[i] = new GNullBlock(binaryReader);
//                    }
//                }
//            }
//        }
//        [Flags]
//        public enum Flags : short
//        {
//            StopIfDeathThisConversationWillBeAbortedIfAnyParticipantDies = 1,
//            StopIfDamagedAnActorWillAbortThisConversationIfTheyAreDamaged = 2,
//            StopIfVisibleEnemyAnActorWillAbortThisConversationIfTheySeeAnEnemy = 4,
//            StopIfAlertedToEnemyAnActorWillAbortThisConversationIfTheySuspectAnEnemy = 8,
//            PlayerMustBeVisibleThisConversationCannotTakePlaceUnlessTheParticipantsCanSeeANearbyPlayer = 16,
//            StopOtherActionsParticipantsStopDoingWhateverTheyWereDoingInOrderToPerformThisConversation = 32,
//            KeepTryingToPlayIfThisConversationFailsInitiallyItWillKeepTestingToSeeWhenItCanPlay = 64,
//            PlayerMustBeLookingThisConversationWillNotStartUntilThePlayerIsLookingAtOneOfTheParticipants = 128,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class HsScriptsBlock
//    {
//        public String32 name;
//        public ScriptType scriptType;
//        public ReturnType returnType;
//        public int rootExpressionIndex;
//        public HsScriptsBlock()
//        {
//        }
//        public HsScriptsBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.scriptType = (ScriptType)binaryReader.ReadInt16();
//            this.returnType = (ReturnType)binaryReader.ReadInt16();
//            this.rootExpressionIndex = binaryReader.ReadInt32();
//        }
//        public enum ScriptType : short
//        {
//            Startup = 0,
//            Dormant = 1,
//            Continuous = 2,
//            Static = 3,
//            Stub = 4,
//            CommandScript = 5,
//        }
//        public enum ReturnType : short
//        {
//            Unparsed = 0,
//            SpecialForm = 1,
//            FunctionName = 2,
//            Passthrough = 3,
//            Void = 4,
//            Boolean = 5,
//            Real = 6,
//            Short = 7,
//            Long = 8,
//            String = 9,
//            Script = 10,
//            StringId = 11,
//            UnitSeatMapping = 12,
//            TriggerVolume = 13,
//            CutsceneFlag = 14,
//            CutsceneCameraPoint = 15,
//            CutsceneTitle = 16,
//            CutsceneRecording = 17,
//            DeviceGroup = 18,
//            Ai = 19,
//            AiCommandList = 20,
//            AiCommandScript = 21,
//            AiBehavior = 22,
//            AiOrders = 23,
//            StartingProfile = 24,
//            Conversation = 25,
//            StructureBsp = 26,
//            Navpoint = 27,
//            PointReference = 28,
//            Style = 29,
//            HudMessage = 30,
//            ObjectList = 31,
//            Sound = 32,
//            Effect = 33,
//            Damage = 34,
//            LoopingSound = 35,
//            AnimationGraph = 36,
//            DamageEffect = 37,
//            ObjectDefinition = 38,
//            Bitmap = 39,
//            Shader = 40,
//            RenderModel = 41,
//            StructureDefinition = 42,
//            LightmapDefinition = 43,
//            GameDifficulty = 44,
//            Team = 45,
//            ActorType = 46,
//            HudCorner = 47,
//            ModelState = 48,
//            NetworkEvent = 49,
//            Object = 50,
//            Unit = 51,
//            Vehicle = 52,
//            Weapon = 53,
//            Device = 54,
//            Scenery = 55,
//            ObjectName = 56,
//            UnitName = 57,
//            VehicleName = 58,
//            WeaponName = 59,
//            DeviceName = 60,
//            SceneryName = 61,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class HsGlobalsBlock
//    {
//        public String32 name;
//        public Type type;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public int initializationExpressionIndex;
//        public HsGlobalsBlock()
//        {
//        }
//        public HsGlobalsBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.type = (Type)binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            this.initializationExpressionIndex = binaryReader.ReadInt32();
//        }
//        public enum Type : short
//        {
//            Unparsed = 0,
//            SpecialForm = 1,
//            FunctionName = 2,
//            Passthrough = 3,
//            Void = 4,
//            Boolean = 5,
//            Real = 6,
//            Short = 7,
//            Long = 8,
//            String = 9,
//            Script = 10,
//            StringId = 11,
//            UnitSeatMapping = 12,
//            TriggerVolume = 13,
//            CutsceneFlag = 14,
//            CutsceneCameraPoint = 15,
//            CutsceneTitle = 16,
//            CutsceneRecording = 17,
//            DeviceGroup = 18,
//            Ai = 19,
//            AiCommandList = 20,
//            AiCommandScript = 21,
//            AiBehavior = 22,
//            AiOrders = 23,
//            StartingProfile = 24,
//            Conversation = 25,
//            StructureBsp = 26,
//            Navpoint = 27,
//            PointReference = 28,
//            Style = 29,
//            HudMessage = 30,
//            ObjectList = 31,
//            Sound = 32,
//            Effect = 33,
//            Damage = 34,
//            LoopingSound = 35,
//            AnimationGraph = 36,
//            DamageEffect = 37,
//            ObjectDefinition = 38,
//            Bitmap = 39,
//            Shader = 40,
//            RenderModel = 41,
//            StructureDefinition = 42,
//            LightmapDefinition = 43,
//            GameDifficulty = 44,
//            Team = 45,
//            ActorType = 46,
//            HudCorner = 47,
//            ModelState = 48,
//            NetworkEvent = 49,
//            Object = 50,
//            Unit = 51,
//            Vehicle = 52,
//            Weapon = 53,
//            Device = 54,
//            Scenery = 55,
//            ObjectName = 56,
//            UnitName = 57,
//            VehicleName = 58,
//            WeaponName = 59,
//            DeviceName = 60,
//            SceneryName = 61,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class HsReferencesBlock
//    {
//        [TagReference("")]
//        public TagReference reference;
//        public HsReferencesBlock()
//        {
//        }
//        public HsReferencesBlock(BinaryReader binaryReader)
//        {
//            this.reference = binaryReader.ReadTagReference();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class HsSourceFilesBlock
//    {
//        public String32 name;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
//        private byte[] paddingsource;
//        #endregion
//        public HsSourceFilesBlock()
//        {
//        }
//        public HsSourceFilesBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.paddingsource = binaryReader.ReadBytes(8);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 60, Pack = 4)]
//    public partial class CsPointBlock
//    {
//        public String32 name;
//        public Vector3 position;
//        public short referenceFrame;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public int surfaceIndex;
//        public Vector2 facingDirection;
//        public CsPointBlock()
//        {
//        }
//        public CsPointBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.position = binaryReader.ReadVector3();
//            this.referenceFrame = binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            this.surfaceIndex = binaryReader.ReadInt32();
//            this.facingDirection = binaryReader.ReadVector2();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 48, Pack = 4)]
//    public partial class CsPointSetBlock
//    {
//        public String32 name;
//        [TagBlockField]
//        public CsPointBlock[] points;
//        public ShortBlockIndex1 bspIndex;
//        public short manualReferenceFrame;
//        public Flags flags;
//        public CsPointSetBlock()
//        {
//        }
//        public CsPointSetBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(CsPointBlock));
//                this.points = new CsPointBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.points[i] = new CsPointBlock(binaryReader);
//                    }
//                }
//            }
//            this.bspIndex = binaryReader.ReadShortBlockIndex1();
//            this.manualReferenceFrame = binaryReader.ReadInt16();
//            this.flags = (Flags)binaryReader.ReadInt32();
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            ManualReferenceFrame = 1,
//            TurretDeployment = 2,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 128, Pack = 4)]
//    public partial class CsScriptDataBlock
//    {
//        [TagBlockField]
//        public CsPointSetBlock[] pointSets;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 120)]
//        private byte[] padding;
//        #endregion
//        public CsScriptDataBlock()
//        {
//        }
//        public CsScriptDataBlock(BinaryReader binaryReader)
//        {
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(CsPointSetBlock));
//                this.pointSets = new CsPointSetBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.pointSets[i] = new CsPointSetBlock(binaryReader);
//                    }
//                }
//            }
//            this.padding = binaryReader.ReadBytes(120);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 56, Pack = 4)]
//    public partial class ScenarioCutsceneFlagBlock
//    {
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] padding;
//        #endregion
//        public String32 name;
//        public Vector3 position;
//        public Vector2 facing;
//        public ScenarioCutsceneFlagBlock()
//        {
//        }
//        public ScenarioCutsceneFlagBlock(BinaryReader binaryReader)
//        {
//            this.padding = binaryReader.ReadBytes(4);
//            this.name = binaryReader.ReadString32();
//            this.position = binaryReader.ReadVector3();
//            this.facing = binaryReader.ReadVector2();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 64, Pack = 4)]
//    public partial class ScenarioCutsceneCameraPointBlock
//    {
//        public Flags flags;
//        public Type type;
//        public String32 name;
//        public Vector3 position;
//        public Vector3 orientation;
//        public float unused;
//        public ScenarioCutsceneCameraPointBlock()
//        {
//        }
//        public ScenarioCutsceneCameraPointBlock(BinaryReader binaryReader)
//        {
//            this.flags = (Flags)binaryReader.ReadInt16();
//            this.type = (Type)binaryReader.ReadInt16();
//            this.name = binaryReader.ReadString32();
//            this.position = binaryReader.ReadVector3();
//            this.orientation = binaryReader.ReadVector3();
//            this.unused = binaryReader.ReadSingle();
//        }
//        [Flags]
//        public enum Flags : short
//        {
//            EditAsRelative = 1,
//        }
//        public enum Type : short
//        {
//            Normal = 0,
//            IgnoreTargetOrientation = 1,
//            Dolly = 2,
//            IgnoreTargetUpdates = 3,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 36, Pack = 4)]
//    public partial class ScenarioCutsceneTitleBlock
//    {
//        public StringID name;
//        public Vector2 textBoundsOnScreen;
//        public Justification justification;
//        public Font font;
//        public RGBColor textColor;
//        public RGBColor shadowColor;
//        public float fadeInTimeSeconds;
//        public float upTimeSeconds;
//        public float fadeOutTimeSeconds;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] paddingpadding;
//        #endregion
//        public ScenarioCutsceneTitleBlock()
//        {
//        }
//        public ScenarioCutsceneTitleBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadStringID();
//            this.textBoundsOnScreen = binaryReader.ReadVector2();
//            this.justification = (Justification)binaryReader.ReadInt16();
//            this.font = (Font)binaryReader.ReadInt16();
//            this.textColor = binaryReader.ReadRGBColor();
//            this.shadowColor = binaryReader.ReadRGBColor();
//            this.fadeInTimeSeconds = binaryReader.ReadSingle();
//            this.upTimeSeconds = binaryReader.ReadSingle();
//            this.fadeOutTimeSeconds = binaryReader.ReadSingle();
//            this.paddingpadding = binaryReader.ReadBytes(2);
//        }
//        public enum Justification : short
//        {
//            Left = 0,
//            Right = 1,
//            Center = 2,
//            CustomTextEntry = 3,
//        }
//        public enum Font : short
//        {
//            TerminalFont = 0,
//            BodyTextFont = 1,
//            TitleFont = 2,
//            SuperLargeFont = 3,
//            LargeBodyTextFont = 4,
//            SplitScreenHudMessageFont = 5,
//            FullScreenHudMessageFont = 6,
//            EnglishBodyTextFont = 7,
//            HudNumberFont = 8,
//            SubtitleFont = 9,
//            MainMenuFont = 10,
//            TextChatFont = 11,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 68, Pack = 4)]
//    public partial class ScenarioStructureBspReferenceBlock
//    {
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
//        private byte[] padding;
//        #endregion
//        [TagReference("sbsp")]
//        public TagReference structureBSP;
//        [TagReference("ltmp")]
//        public TagReference structureLightmap;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] padding0;
//        #endregion
//        public float uNUSEDRadianceEstSearchDistance;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] padding1;
//        #endregion
//        public float uNUSEDLuminelsPerWorldUnit;
//        public float uNUSEDOutputWhiteReference;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
//        private byte[] padding2;
//        #endregion
//        public Flags flags;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding3;
//        #endregion
//        public ShortBlockIndex1 defaultSky;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding4;
//        #endregion
//        public ScenarioStructureBspReferenceBlock()
//        {
//        }
//        public ScenarioStructureBspReferenceBlock(BinaryReader binaryReader)
//        {
//            this.padding = binaryReader.ReadBytes(16);
//            this.structureBSP = binaryReader.ReadTagReference();
//            this.structureLightmap = binaryReader.ReadTagReference();
//            this.padding0 = binaryReader.ReadBytes(4);
//            this.uNUSEDRadianceEstSearchDistance = binaryReader.ReadSingle();
//            this.padding1 = binaryReader.ReadBytes(4);
//            this.uNUSEDLuminelsPerWorldUnit = binaryReader.ReadSingle();
//            this.uNUSEDOutputWhiteReference = binaryReader.ReadSingle();
//            this.padding2 = binaryReader.ReadBytes(8);
//            this.flags = (Flags)binaryReader.ReadInt16();
//            this.padding3 = binaryReader.ReadBytes(2);
//            this.defaultSky = binaryReader.ReadShortBlockIndex1();
//            this.padding4 = binaryReader.ReadBytes(2);
//        }
//        [Flags]
//        public enum Flags : short
//        {
//            DefaultSkyEnabled = 1,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class ScenarioResourceReferenceBlock
//    {
//        [TagReference("")]
//        public TagReference reference;
//        public ScenarioResourceReferenceBlock()
//        {
//        }
//        public ScenarioResourceReferenceBlock(BinaryReader binaryReader)
//        {
//            this.reference = binaryReader.ReadTagReference();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class ScenarioHsSourceReferenceBlock
//    {
//        [TagReference("hsc*")]
//        public TagReference reference;
//        public ScenarioHsSourceReferenceBlock()
//        {
//        }
//        public ScenarioHsSourceReferenceBlock(BinaryReader binaryReader)
//        {
//            this.reference = binaryReader.ReadTagReference();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class ScenarioAiResourceReferenceBlock
//    {
//        [TagReference("ai**")]
//        public TagReference reference;
//        public ScenarioAiResourceReferenceBlock()
//        {
//        }
//        public ScenarioAiResourceReferenceBlock(BinaryReader binaryReader)
//        {
//            this.reference = binaryReader.ReadTagReference();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 24, Pack = 4)]
//    public partial class ScenarioResourcesBlock
//    {
//        [TagBlockField]
//        public ScenarioResourceReferenceBlock[] references;
//        [TagBlockField]
//        public ScenarioHsSourceReferenceBlock[] scriptSource;
//        [TagBlockField]
//        public ScenarioAiResourceReferenceBlock[] aIResources;
//        public ScenarioResourcesBlock()
//        {
//        }
//        public ScenarioResourcesBlock(BinaryReader binaryReader)
//        {
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioResourceReferenceBlock));
//                this.references = new ScenarioResourceReferenceBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.references[i] = new ScenarioResourceReferenceBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioHsSourceReferenceBlock));
//                this.scriptSource = new ScenarioHsSourceReferenceBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.scriptSource[i] = new ScenarioHsSourceReferenceBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioAiResourceReferenceBlock));
//                this.aIResources = new ScenarioAiResourceReferenceBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.aIResources[i] = new ScenarioAiResourceReferenceBlock(binaryReader);
//                    }
//                }
//            }
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class OldUnusedObjectIdentifiersBlock
//    {
//        [TagStructField]
//        public ScenarioObjectIdStruct objectID;
//        public OldUnusedObjectIdentifiersBlock()
//        {
//        }
//        public OldUnusedObjectIdentifiersBlock(BinaryReader binaryReader)
//        {
//            this.objectID = new ScenarioObjectIdStruct(binaryReader);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 44, Pack = 4)]
//    public partial class OldUnusedStrucurePhysicsBlock
//    {
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
//        private byte[] paddingmoppCode;
//        #endregion
//        [TagBlockField]
//        public OldUnusedObjectIdentifiersBlock[] evironmentObjectIdentifiers;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] padding;
//        #endregion
//        public Vector3 moppBoundsMin;
//        public Vector3 moppBoundsMax;
//        public OldUnusedStrucurePhysicsBlock()
//        {
//        }
//        public OldUnusedStrucurePhysicsBlock(BinaryReader binaryReader)
//        {
//            this.paddingmoppCode = binaryReader.ReadBytes(8);
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(OldUnusedObjectIdentifiersBlock));
//                this.evironmentObjectIdentifiers = new OldUnusedObjectIdentifiersBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.evironmentObjectIdentifiers[i] = new OldUnusedObjectIdentifiersBlock(binaryReader);
//                    }
//                }
//            }
//            this.padding = binaryReader.ReadBytes(4);
//            this.moppBoundsMin = binaryReader.ReadVector3();
//            this.moppBoundsMax = binaryReader.ReadVector3();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class HsUnitSeatBlock
//    {
//        public int invalidName_;
//        public int invalidName_0;
//        public HsUnitSeatBlock()
//        {
//        }
//        public HsUnitSeatBlock(BinaryReader binaryReader)
//        {
//            this.invalidName_ = binaryReader.ReadInt32();
//            this.invalidName_0 = binaryReader.ReadInt32();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 4)]
//    public partial class ScenarioKillTriggerVolumesBlock
//    {
//        public ShortBlockIndex1 triggerVolume;
//        public ScenarioKillTriggerVolumesBlock()
//        {
//        }
//        public ScenarioKillTriggerVolumesBlock(BinaryReader binaryReader)
//        {
//            this.triggerVolume = binaryReader.ReadShortBlockIndex1();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 4)]
//    public partial class SyntaxDatumBlock
//    {
//        public short datumHeader;
//        public short scriptIndexFunctionIndexConstantTypeUnion;
//        public short type;
//        public short flags;
//        public int nextNodeIndex;
//        public int data;
//        public int sourceOffset;
//        public SyntaxDatumBlock()
//        {
//        }
//        public SyntaxDatumBlock(BinaryReader binaryReader)
//        {
//            this.datumHeader = binaryReader.ReadInt16();
//            this.scriptIndexFunctionIndexConstantTypeUnion = binaryReader.ReadInt16();
//            this.type = binaryReader.ReadInt16();
//            this.flags = binaryReader.ReadInt16();
//            this.nextNodeIndex = binaryReader.ReadInt32();
//            this.data = binaryReader.ReadInt32();
//            this.sourceOffset = binaryReader.ReadInt32();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class ZoneSetBlock
//    {
//        public AreaType areaType;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public ShortBlockIndex1 zone;
//        public ShortBlockIndex2 area;
//        public ZoneSetBlock()
//        {
//        }
//        public ZoneSetBlock(BinaryReader binaryReader)
//        {
//            this.areaType = (AreaType)binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            this.zone = binaryReader.ReadShortBlockIndex1();
//            this.area = binaryReader.ReadShortBlockIndex2();
//        }
//        public enum AreaType : short
//        {
//            Deault = 0,
//            Search = 1,
//            Goal = 2,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class SecondaryZoneSetBlock
//    {
//        public AreaType areaType;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public ShortBlockIndex1 zone;
//        public ShortBlockIndex2 area;
//        public SecondaryZoneSetBlock()
//        {
//        }
//        public SecondaryZoneSetBlock(BinaryReader binaryReader)
//        {
//            this.areaType = (AreaType)binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            this.zone = binaryReader.ReadShortBlockIndex1();
//            this.area = binaryReader.ReadShortBlockIndex2();
//        }
//        public enum AreaType : short
//        {
//            Deault = 0,
//            Search = 1,
//            Goal = 2,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
//    public partial class SecondarySetTriggerBlock
//    {
//        public CombinationRule combinationRule;
//        public DialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType dialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType;
//        [TagBlockField]
//        public TriggerReferences[] triggers;
//        public SecondarySetTriggerBlock()
//        {
//        }
//        public SecondarySetTriggerBlock(BinaryReader binaryReader)
//        {
//            this.combinationRule = (CombinationRule)binaryReader.ReadInt16();
//            this.dialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType = (DialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType)binaryReader.ReadInt16();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(TriggerReferences));
//                this.triggers = new TriggerReferences[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.triggers[i] = new TriggerReferences(binaryReader);
//                    }
//                }
//            }
//        }
//        public enum CombinationRule : short
//        {
//            OR = 0,
//            AND = 1,
//        }
//        public enum DialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType : short
//        {
//            None = 0,
//            Advance = 1,
//            Charge = 2,
//            FallBack = 3,
//            Retreat = 4,
//            Moveone = 5,
//            Arrival = 6,
//            EnterVehicle = 7,
//            ExitVehicle = 8,
//            FollowPlayer = 9,
//            LeavePlayer = 10,
//            Support = 11,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
//    public partial class SpecialMovementBlock
//    {
//        public SpecialMovement1 specialMovement1;
//        public SpecialMovementBlock()
//        {
//        }
//        public SpecialMovementBlock(BinaryReader binaryReader)
//        {
//            this.specialMovement1 = (SpecialMovement1)binaryReader.ReadInt32();
//        }
//        [Flags]
//        public enum SpecialMovement1 : int
//        {
//            Jump = 1,
//            Climb = 2,
//            Vault = 4,
//            Mount = 8,
//            Hoist = 16,
//            WallJump = 32,
//            NA = 64,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 4)]
//    public partial class OrderEndingBlock
//    {
//        public ShortBlockIndex1 nextOrder;
//        public CombinationRule combinationRule;
//        public float delayTime;
//        public DialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType dialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        [TagBlockField]
//        public TriggerReferences[] triggers;
//        public OrderEndingBlock()
//        {
//        }
//        public OrderEndingBlock(BinaryReader binaryReader)
//        {
//            this.nextOrder = binaryReader.ReadShortBlockIndex1();
//            this.combinationRule = (CombinationRule)binaryReader.ReadInt16();
//            this.delayTime = binaryReader.ReadSingle();
//            this.dialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType = (DialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType)binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(TriggerReferences));
//                this.triggers = new TriggerReferences[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.triggers[i] = new TriggerReferences(binaryReader);
//                    }
//                }
//            }
//        }
//        public enum CombinationRule : short
//        {
//            OR = 0,
//            AND = 1,
//        }
//        public enum DialogueTypeWhenThisEndingIsTriggeredLaunchADialogueEventOfTheGivenType : short
//        {
//            None = 0,
//            Advance = 1,
//            Charge = 2,
//            FallBack = 3,
//            Retreat = 4,
//            Moveone = 5,
//            Arrival = 6,
//            EnterVehicle = 7,
//            ExitVehicle = 8,
//            FollowPlayer = 9,
//            LeavePlayer = 10,
//            Support = 11,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 124, Pack = 4)]
//    public partial class OrdersBlock
//    {
//        public String32 name;
//        public ShortBlockIndex1 style;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public Flags flags;
//        public ForceCombatStatus forceCombatStatus;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding0;
//        #endregion
//        public String32 entryScript;
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] skip1;
//        #endregion
//        public ShortBlockIndex1 followSquad;
//        public float followRadius;
//        [TagBlockField]
//        public ZoneSetBlock[] primaryAreaSet;
//        [TagBlockField]
//        public SecondaryZoneSetBlock[] secondaryAreaSet;
//        [TagBlockField]
//        public SecondarySetTriggerBlock[] secondarySetTrigger;
//        [TagBlockField]
//        public SpecialMovementBlock[] specialMovement;
//        [TagBlockField]
//        public OrderEndingBlock[] orderEndings;
//        public OrdersBlock()
//        {
//        }
//        public OrdersBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.style = binaryReader.ReadShortBlockIndex1();
//            this.padding = binaryReader.ReadBytes(2);
//            this.flags = (Flags)binaryReader.ReadInt32();
//            this.forceCombatStatus = (ForceCombatStatus)binaryReader.ReadInt16();
//            this.padding0 = binaryReader.ReadBytes(2);
//            this.entryScript = binaryReader.ReadString32();
//            this.skip1 = binaryReader.ReadBytes(2);
//            this.followSquad = binaryReader.ReadShortBlockIndex1();
//            this.followRadius = binaryReader.ReadSingle();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ZoneSetBlock));
//                this.primaryAreaSet = new ZoneSetBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.primaryAreaSet[i] = new ZoneSetBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(SecondaryZoneSetBlock));
//                this.secondaryAreaSet = new SecondaryZoneSetBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.secondaryAreaSet[i] = new SecondaryZoneSetBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(SecondarySetTriggerBlock));
//                this.secondarySetTrigger = new SecondarySetTriggerBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.secondarySetTrigger[i] = new SecondarySetTriggerBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(SpecialMovementBlock));
//                this.specialMovement = new SpecialMovementBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.specialMovement[i] = new SpecialMovementBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(OrderEndingBlock));
//                this.orderEndings = new OrderEndingBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.orderEndings[i] = new OrderEndingBlock(binaryReader);
//                    }
//                }
//            }
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            Locked = 1,
//            AlwaysActive = 2,
//            DebugOn = 4,
//            StrictAreaDef = 8,
//            FollowClosestPlayer = 16,
//            FollowSquad = 32,
//            ActiveCamo = 64,
//            SuppressCombatUntilEngaged = 128,
//            InhibitVehicleUse = 256,
//        }
//        public enum ForceCombatStatus : short
//        {
//            NONE = 0,
//            Asleep = 1,
//            Idle = 2,
//            Alert = 3,
//            Combat = 4,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 56, Pack = 4)]
//    public partial class OrderCompletionCondition
//    {
//        public RuleType ruleType;
//        public ShortBlockIndex1 squad;
//        public ShortBlockIndex1 squadGroup;
//        public short a;
//        public float x;
//        public ShortBlockIndex1 triggerVolume;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public String32 exitConditionScript;
//        public short invalidName_0;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding1;
//        #endregion
//        public Flags flags;
//        public OrderCompletionCondition()
//        {
//        }
//        public OrderCompletionCondition(BinaryReader binaryReader)
//        {
//            this.ruleType = (RuleType)binaryReader.ReadInt16();
//            this.squad = binaryReader.ReadShortBlockIndex1();
//            this.squadGroup = binaryReader.ReadShortBlockIndex1();
//            this.a = binaryReader.ReadInt16();
//            this.x = binaryReader.ReadSingle();
//            this.triggerVolume = binaryReader.ReadShortBlockIndex1();
//            this.padding = binaryReader.ReadBytes(2);
//            this.exitConditionScript = binaryReader.ReadString32();
//            this.invalidName_0 = binaryReader.ReadInt16();
//            this.padding1 = binaryReader.ReadBytes(2);
//            this.flags = (Flags)binaryReader.ReadInt32();
//        }
//        public enum RuleType : short
//        {
//            AOrGreaterAlive = 0,
//            AOrFewerAlive = 1,
//            XOrGreaterStrength = 2,
//            XOrLessStrength = 3,
//            IfEnemySighted = 4,
//            AfterATicks = 5,
//            IfAlertedBySquadA = 6,
//            ScriptRefTRUE = 7,
//            ScriptRefFALSE = 8,
//            IfPlayerInTriggerVolume = 9,
//            IfALLPlayersInTriggerVolume = 10,
//            CombatStatusAOrMore = 11,
//            CombatStatusAOrLess = 12,
//            Arrived = 13,
//            InVehicle = 14,
//            SightedPlayer = 15,
//            AOrGreaterFighting = 16,
//            AOrFewerFighting = 17,
//            PlayerWithinXWorldUnits = 18,
//            PlayerShotMoreThanXSecondsAgo = 19,
//            GameSafeToSave = 20,
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            NOT = 1,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 48, Pack = 4)]
//    public partial class TriggersBlock
//    {
//        public String32 name;
//        public TriggerFlags triggerFlags;
//        public CombinationRule combinationRule;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        [TagBlockField]
//        public OrderCompletionCondition[] conditions;
//        public TriggersBlock()
//        {
//        }
//        public TriggersBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.triggerFlags = (TriggerFlags)binaryReader.ReadInt32();
//            this.combinationRule = (CombinationRule)binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(OrderCompletionCondition));
//                this.conditions = new OrderCompletionCondition[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.conditions[i] = new OrderCompletionCondition(binaryReader);
//                    }
//                }
//            }
//        }
//        [Flags]
//        public enum TriggerFlags : int
//        {
//            LatchONWhenTriggered = 1,
//        }
//        public enum CombinationRule : short
//        {
//            OR = 0,
//            AND = 1,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 100, Pack = 4)]
//    public partial class StructureBspBackgroundSoundPaletteBlock
//    {
//        public String32 name;
//        [TagReference("lsnd")]
//        public TagReference backgroundSound;
//        [TagReference("lsnd")]
//        public TagReference insideClusterSoundPlayOnlyWhenPlayerIsInsideCluster;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
//        private byte[] padding;
//        #endregion
//        public float cutoffDistance;
//        public ScaleFlags scaleFlags;
//        public float interiorScale;
//        public float portalScale;
//        public float exteriorScale;
//        public float interpolationSpeed1Sec;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
//        private byte[] padding0;
//        #endregion
//        public StructureBspBackgroundSoundPaletteBlock()
//        {
//        }
//        public StructureBspBackgroundSoundPaletteBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.backgroundSound = binaryReader.ReadTagReference();
//            this.insideClusterSoundPlayOnlyWhenPlayerIsInsideCluster = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(20);
//            this.cutoffDistance = binaryReader.ReadSingle();
//            this.scaleFlags = (ScaleFlags)binaryReader.ReadInt32();
//            this.interiorScale = binaryReader.ReadSingle();
//            this.portalScale = binaryReader.ReadSingle();
//            this.exteriorScale = binaryReader.ReadSingle();
//            this.interpolationSpeed1Sec = binaryReader.ReadSingle();
//            this.padding0 = binaryReader.ReadBytes(8);
//        }
//        [Flags]
//        public enum ScaleFlags : int
//        {
//            OverrideDefaultScale = 1,
//            UseAdjacentClusterAsPortalScale = 2,
//            UseAdjacentClusterAsExteriorScale = 4,
//            ScaleWithWeatherIntensity = 8,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 72, Pack = 4)]
//    public partial class StructureBspSoundEnvironmentPaletteBlock
//    {
//        public String32 name;
//        [TagReference("snde")]
//        public TagReference soundEnvironment;
//        public float cutoffDistance;
//        public float interpolationSpeed1Sec;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
//        private byte[] padding;
//        #endregion
//        public StructureBspSoundEnvironmentPaletteBlock()
//        {
//        }
//        public StructureBspSoundEnvironmentPaletteBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.soundEnvironment = binaryReader.ReadTagReference();
//            this.cutoffDistance = binaryReader.ReadSingle();
//            this.interpolationSpeed1Sec = binaryReader.ReadSingle();
//            this.padding = binaryReader.ReadBytes(24);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 136, Pack = 4)]
//    public partial class StructureBspWeatherPaletteBlock
//    {
//        public String32 name;
//        [TagReference("weat")]
//        public TagReference weatherSystem;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding0;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
//        private byte[] padding1;
//        #endregion
//        [TagReference("wind")]
//        public TagReference wind;
//        public Vector3 windDirection;
//        public float windMagnitude;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] padding2;
//        #endregion
//        public String32 windScaleFunction;
//        public StructureBspWeatherPaletteBlock()
//        {
//        }
//        public StructureBspWeatherPaletteBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadString32();
//            this.weatherSystem = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(2);
//            this.padding0 = binaryReader.ReadBytes(2);
//            this.padding1 = binaryReader.ReadBytes(32);
//            this.wind = binaryReader.ReadTagReference();
//            this.windDirection = binaryReader.ReadVector3();
//            this.windMagnitude = binaryReader.ReadSingle();
//            this.padding2 = binaryReader.ReadBytes(4);
//            this.windScaleFunction = binaryReader.ReadString32();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
//    public partial class ScenarioClusterBackgroundSoundsBlock
//    {
//        public ShortBlockIndex1 type;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public ScenarioClusterBackgroundSoundsBlock()
//        {
//        }
//        public ScenarioClusterBackgroundSoundsBlock(BinaryReader binaryReader)
//        {
//            this.type = binaryReader.ReadShortBlockIndex1();
//            this.padding = binaryReader.ReadBytes(2);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
//    public partial class ScenarioClusterSoundEnvironmentsBlock
//    {
//        public ShortBlockIndex1 type;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public ScenarioClusterSoundEnvironmentsBlock()
//        {
//        }
//        public ScenarioClusterSoundEnvironmentsBlock(BinaryReader binaryReader)
//        {
//            this.type = binaryReader.ReadShortBlockIndex1();
//            this.padding = binaryReader.ReadBytes(2);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
//    public partial class ScenarioClusterPointsBlock
//    {
//        public Vector3 centroid;
//        public ScenarioClusterPointsBlock()
//        {
//        }
//        public ScenarioClusterPointsBlock(BinaryReader binaryReader)
//        {
//            this.centroid = binaryReader.ReadVector3();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
//    public partial class ScenarioClusterWeatherPropertiesBlock
//    {
//        public ShortBlockIndex1 type;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public ScenarioClusterWeatherPropertiesBlock()
//        {
//        }
//        public ScenarioClusterWeatherPropertiesBlock(BinaryReader binaryReader)
//        {
//            this.type = binaryReader.ReadShortBlockIndex1();
//            this.padding = binaryReader.ReadBytes(2);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
//    public partial class ScenarioClusterAtmosphericFogPropertiesBlock
//    {
//        public ShortBlockIndex1 type;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public ScenarioClusterAtmosphericFogPropertiesBlock()
//        {
//        }
//        public ScenarioClusterAtmosphericFogPropertiesBlock(BinaryReader binaryReader)
//        {
//            this.type = binaryReader.ReadShortBlockIndex1();
//            this.padding = binaryReader.ReadBytes(2);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 52, Pack = 4)]
//    public partial class ScenarioClusterDataBlock
//    {
//        [TagReference("sbsp")]
//        public TagReference bSP;
//        [TagBlockField]
//        public ScenarioClusterBackgroundSoundsBlock[] backgroundSounds;
//        [TagBlockField]
//        public ScenarioClusterSoundEnvironmentsBlock[] soundEnvironments;
//        public int bSPChecksum;
//        [TagBlockField]
//        public ScenarioClusterPointsBlock[] clusterCentroids;
//        [TagBlockField]
//        public ScenarioClusterWeatherPropertiesBlock[] weatherProperties;
//        [TagBlockField]
//        public ScenarioClusterAtmosphericFogPropertiesBlock[] atmosphericFogProperties;
//        public ScenarioClusterDataBlock()
//        {
//        }
//        public ScenarioClusterDataBlock(BinaryReader binaryReader)
//        {
//            this.bSP = binaryReader.ReadTagReference();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioClusterBackgroundSoundsBlock));
//                this.backgroundSounds = new ScenarioClusterBackgroundSoundsBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.backgroundSounds[i] = new ScenarioClusterBackgroundSoundsBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioClusterSoundEnvironmentsBlock));
//                this.soundEnvironments = new ScenarioClusterSoundEnvironmentsBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.soundEnvironments[i] = new ScenarioClusterSoundEnvironmentsBlock(binaryReader);
//                    }
//                }
//            }
//            this.bSPChecksum = binaryReader.ReadInt32();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioClusterPointsBlock));
//                this.clusterCentroids = new ScenarioClusterPointsBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.clusterCentroids[i] = new ScenarioClusterPointsBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioClusterWeatherPropertiesBlock));
//                this.weatherProperties = new ScenarioClusterWeatherPropertiesBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.weatherProperties[i] = new ScenarioClusterWeatherPropertiesBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioClusterAtmosphericFogPropertiesBlock));
//                this.atmosphericFogProperties = new ScenarioClusterAtmosphericFogPropertiesBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.atmosphericFogProperties[i] = new ScenarioClusterAtmosphericFogPropertiesBlock(binaryReader);
//                    }
//                }
//            }
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
//    public partial class DynamicSpawnZoneOverloadBlock
//    {
//        public OverloadType overloadType;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public float innerRadius;
//        public float outerRadius;
//        public float weight;
//        public DynamicSpawnZoneOverloadBlock()
//        {
//        }
//        public DynamicSpawnZoneOverloadBlock(BinaryReader binaryReader)
//        {
//            this.overloadType = (OverloadType)binaryReader.ReadInt16();
//            this.padding = binaryReader.ReadBytes(2);
//            this.innerRadius = binaryReader.ReadSingle();
//            this.outerRadius = binaryReader.ReadSingle();
//            this.weight = binaryReader.ReadSingle();
//        }
//        public enum OverloadType : short
//        {
//            Enemy = 0,
//            Friend = 1,
//            EnemyVehicle = 2,
//            FriendlyVehicle = 3,
//            EmptyVehicle = 4,
//            OddballInclusion = 5,
//            OddballExclusion = 6,
//            HillInclusion = 7,
//            HillExclusion = 8,
//            LastRaceFlag = 9,
//            DeadAlly = 10,
//            ControlledTerritory = 11,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
//    public partial class StaticSpawnZoneDataStruct
//    {
//        public StringID name;
//        public RelevantTeam relevantTeam;
//        public RelevantGames relevantGames;
//        public Flags flags;
//        public StaticSpawnZoneDataStruct()
//        {
//        }
//        public StaticSpawnZoneDataStruct(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadStringID();
//            this.relevantTeam = (RelevantTeam)binaryReader.ReadInt32();
//            this.relevantGames = (RelevantGames)binaryReader.ReadInt32();
//            this.flags = (Flags)binaryReader.ReadInt32();
//        }
//        [Flags]
//        public enum RelevantTeam : int
//        {
//            RedAlpha = 1,
//            BlueBravo = 2,
//            YellowCharlie = 4,
//            GreenDelta = 8,
//            PurpleEcho = 16,
//            OrangeFoxtrot = 32,
//            BrownGolf = 64,
//            PinkHotel = 128,
//            NEUTRAL = 256,
//        }
//        [Flags]
//        public enum RelevantGames : int
//        {
//            Slayer = 1,
//            Oddball = 2,
//            KingOfTheHill = 4,
//            CaptureTheFlag = 8,
//            Race = 16,
//            Headhunter = 32,
//            Juggernaut = 64,
//            Territories = 128,
//        }
//        [Flags]
//        public enum Flags : int
//        {
//            DisabledIfFlagHome = 1,
//            DisabledIfFlagAway = 2,
//            DisabledIfBombHome = 4,
//            DisabledIfBombAway = 8,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 48, Pack = 4)]
//    public partial class StaticSpawnZoneBlock
//    {
//        [TagStructField]
//        public StaticSpawnZoneDataStruct data;
//        public Vector3 position;
//        public float lowerHeight;
//        public float upperHeight;
//        public float innerRadius;
//        public float outerRadius;
//        public float weight;
//        public StaticSpawnZoneBlock()
//        {
//        }
//        public StaticSpawnZoneBlock(BinaryReader binaryReader)
//        {
//            this.data = new StaticSpawnZoneDataStruct(binaryReader);
//            this.position = binaryReader.ReadVector3();
//            this.lowerHeight = binaryReader.ReadSingle();
//            this.upperHeight = binaryReader.ReadSingle();
//            this.innerRadius = binaryReader.ReadSingle();
//            this.outerRadius = binaryReader.ReadSingle();
//            this.weight = binaryReader.ReadSingle();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 96, Pack = 4)]
//    public partial class ScenarioSpawnDataBlock
//    {
//        public float dynamicSpawnLowerHeight;
//        public float dynamicSpawnUpperHeight;
//        public float gameObjectResetHeight;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 60)]
//        private byte[] padding;
//        #endregion
//        [TagBlockField]
//        public DynamicSpawnZoneOverloadBlock[] dynamicSpawnOverloads;
//        [TagBlockField]
//        public StaticSpawnZoneBlock[] staticRespawnZones;
//        [TagBlockField]
//        public StaticSpawnZoneBlock[] staticInitialSpawnZones;
//        public ScenarioSpawnDataBlock()
//        {
//        }
//        public ScenarioSpawnDataBlock(BinaryReader binaryReader)
//        {
//            this.dynamicSpawnLowerHeight = binaryReader.ReadSingle();
//            this.dynamicSpawnUpperHeight = binaryReader.ReadSingle();
//            this.gameObjectResetHeight = binaryReader.ReadSingle();
//            this.padding = binaryReader.ReadBytes(60);
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(DynamicSpawnZoneOverloadBlock));
//                this.dynamicSpawnOverloads = new DynamicSpawnZoneOverloadBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.dynamicSpawnOverloads[i] = new DynamicSpawnZoneOverloadBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(StaticSpawnZoneBlock));
//                this.staticRespawnZones = new StaticSpawnZoneBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.staticRespawnZones[i] = new StaticSpawnZoneBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(StaticSpawnZoneBlock));
//                this.staticInitialSpawnZones = new StaticSpawnZoneBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.staticInitialSpawnZones[i] = new StaticSpawnZoneBlock(binaryReader);
//                    }
//                }
//            }
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 76, Pack = 4)]
//    public partial class ScenarioCrateBlock
//    {
//        public ShortBlockIndex1 type;
//        public ShortBlockIndex1 name;
//        [TagStructField]
//        public ScenarioObjectDatumStruct objectData;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] paddingindexer;
//        #endregion
//        [TagStructField]
//        public ScenarioObjectPermutationStruct permutationData;
//        public ScenarioCrateBlock()
//        {
//        }
//        public ScenarioCrateBlock(BinaryReader binaryReader)
//        {
//            this.type = binaryReader.ReadShortBlockIndex1();
//            this.name = binaryReader.ReadShortBlockIndex1();
//            this.objectData = new ScenarioObjectDatumStruct(binaryReader);
//            this.paddingindexer = binaryReader.ReadBytes(4);
//            this.permutationData = new ScenarioObjectPermutationStruct(binaryReader);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class ScenarioCratePaletteBlock
//    {
//        [TagReference("bloc")]
//        public TagReference name;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
//        private byte[] padding;
//        #endregion
//        public ScenarioCratePaletteBlock()
//        {
//        }
//        public ScenarioCratePaletteBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(32);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
//    public partial class ScenarioAtmosphericFogMixerBlock
//    {
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] padding;
//        #endregion
//        public StringID atmosphericFogSourceFromScenarioAtmosphericFogPalette;
//        public StringID interpolatorFromScenarioInterpolators;
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] skip0;
//        #endregion
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] skip1;
//        #endregion
//        public ScenarioAtmosphericFogMixerBlock()
//        {
//        }
//        public ScenarioAtmosphericFogMixerBlock(BinaryReader binaryReader)
//        {
//            this.padding = binaryReader.ReadBytes(4);
//            this.atmosphericFogSourceFromScenarioAtmosphericFogPalette = binaryReader.ReadStringID();
//            this.interpolatorFromScenarioInterpolators = binaryReader.ReadStringID();
//            this.skip0 = binaryReader.ReadBytes(2);
//            this.skip1 = binaryReader.ReadBytes(2);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 244, Pack = 4)]
//    public partial class ScenarioAtmosphericFogPalette
//    {
//        public StringID name;
//        public ColorR8G8B8 color;
//        public float spreadDistanceWorldUnitsHowFarFogSpreadsIntoAdjacentClusters0DefaultsTo1;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] padding;
//        #endregion
//        public float maximumDensity01FogDensityClampsToThisValue;
//        public float startDistanceWorldUnitsBeforeThisDistanceThereIsNoFog;
//        public float opaqueDistanceWorldUnitsFogBecomesOpaqueMaximumDensityAtThisDistanceFromViewer;
//        public ColorR8G8B8 color0;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] padding0;
//        #endregion
//        public float maximumDensity01FogDensityClampsToThisValue0;
//        public float startDistanceWorldUnitsBeforeThisDistanceThereIsNoFog0;
//        public float opaqueDistanceWorldUnitsFogBecomesOpaqueMaximumDensityAtThisDistanceFromViewer0;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] padding1;
//        #endregion
//        public ColorR8G8B8 planarColor;
//        public float planarMaxDensity01;
//        public float planarOverrideAmount01;
//        public float planarMinDistanceBiasWorldUnitsDontAsk;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 44)]
//        private byte[] padding2;
//        #endregion
//        public ColorR8G8B8 patchyColor;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
//        private byte[] padding3;
//        #endregion
//        public float patchyDensity01;
//        public Range patchyDistanceWorldUnits;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
//        private byte[] padding4;
//        #endregion
//        [TagReference("fpch")]
//        public TagReference patchyFog;
//        [TagBlockField]
//        public ScenarioAtmosphericFogMixerBlock[] mixers;
//        public float amount01;
//        public float threshold01;
//        public float brightness01;
//        public float gammaPower;
//        public CameraImmersionFlags cameraImmersionFlags;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding5;
//        #endregion
//        public ScenarioAtmosphericFogPalette()
//        {
//        }
//        public ScenarioAtmosphericFogPalette(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadStringID();
//            this.color = binaryReader.ReadColorR8G8B8();
//            this.spreadDistanceWorldUnitsHowFarFogSpreadsIntoAdjacentClusters0DefaultsTo1 = binaryReader.ReadSingle();
//            this.padding = binaryReader.ReadBytes(4);
//            this.maximumDensity01FogDensityClampsToThisValue = binaryReader.ReadSingle();
//            this.startDistanceWorldUnitsBeforeThisDistanceThereIsNoFog = binaryReader.ReadSingle();
//            this.opaqueDistanceWorldUnitsFogBecomesOpaqueMaximumDensityAtThisDistanceFromViewer = binaryReader.ReadSingle();
//            this.color0 = binaryReader.ReadColorR8G8B8();
//            this.padding0 = binaryReader.ReadBytes(4);
//            this.maximumDensity01FogDensityClampsToThisValue0 = binaryReader.ReadSingle();
//            this.startDistanceWorldUnitsBeforeThisDistanceThereIsNoFog0 = binaryReader.ReadSingle();
//            this.opaqueDistanceWorldUnitsFogBecomesOpaqueMaximumDensityAtThisDistanceFromViewer0 = binaryReader.ReadSingle();
//            this.padding1 = binaryReader.ReadBytes(4);
//            this.planarColor = binaryReader.ReadColorR8G8B8();
//            this.planarMaxDensity01 = binaryReader.ReadSingle();
//            this.planarOverrideAmount01 = binaryReader.ReadSingle();
//            this.planarMinDistanceBiasWorldUnitsDontAsk = binaryReader.ReadSingle();
//            this.padding2 = binaryReader.ReadBytes(44);
//            this.patchyColor = binaryReader.ReadColorR8G8B8();
//            this.padding3 = binaryReader.ReadBytes(12);
//            this.patchyDensity01 = binaryReader.ReadSingle();
//            this.patchyDistanceWorldUnits = binaryReader.ReadRange();
//            this.padding4 = binaryReader.ReadBytes(32);
//            this.patchyFog = binaryReader.ReadTagReference();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioAtmosphericFogMixerBlock));
//                this.mixers = new ScenarioAtmosphericFogMixerBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.mixers[i] = new ScenarioAtmosphericFogMixerBlock(binaryReader);
//                    }
//                }
//            }
//            this.amount01 = binaryReader.ReadSingle();
//            this.threshold01 = binaryReader.ReadSingle();
//            this.brightness01 = binaryReader.ReadSingle();
//            this.gammaPower = binaryReader.ReadSingle();
//            this.cameraImmersionFlags = (CameraImmersionFlags)binaryReader.ReadInt16();
//            this.padding5 = binaryReader.ReadBytes(2);
//        }
//        [Flags]
//        public enum CameraImmersionFlags : short
//        {
//            DisableAtmosphericFog = 1,
//            DisableSecondaryFog = 2,
//            DisablePlanarFog = 4,
//            InvertPlanarFogPriorities = 8,
//            DisableWater = 16,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
//    public partial class ScenarioPlanarFogPalette
//    {
//        public StringID name;
//        [TagReference("fog ")]
//        public TagReference planarFog;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding0;
//        #endregion
//        public ScenarioPlanarFogPalette()
//        {
//        }
//        public ScenarioPlanarFogPalette(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadStringID();
//            this.planarFog = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(2);
//            this.padding0 = binaryReader.ReadBytes(2);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 28, Pack = 4)]
//    public partial class FlockSourceBlock
//    {
//        public Vector3 position;
//        public Vector2 startingYawPitchDegrees;
//        public float radius;
//        public float weightProbabilityOfProducingAtThisSource;
//        public FlockSourceBlock()
//        {
//        }
//        public FlockSourceBlock(BinaryReader binaryReader)
//        {
//            this.position = binaryReader.ReadVector3();
//            this.startingYawPitchDegrees = binaryReader.ReadVector2();
//            this.radius = binaryReader.ReadSingle();
//            this.weightProbabilityOfProducingAtThisSource = binaryReader.ReadSingle();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
//    public partial class FlockSinkBlock
//    {
//        public Vector3 position;
//        public float radius;
//        public FlockSinkBlock()
//        {
//        }
//        public FlockSinkBlock(BinaryReader binaryReader)
//        {
//            this.position = binaryReader.ReadVector3();
//            this.radius = binaryReader.ReadSingle();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 132, Pack = 4)]
//    public partial class FlockDefinitionBlock
//    {
//        public ShortBlockIndex1 bsp;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public ShortBlockIndex1 boundingVolume;
//        public Flags flags;
//        public float ecologyMarginWusDistanceFromEcologyBoundaryThatCreatureBeginsToBeRepulsed;
//        [TagBlockField]
//        public FlockSourceBlock[] sources;
//        [TagBlockField]
//        public FlockSinkBlock[] sinks;
//        public float productionFrequencyBoidsSecHowFrequentlyBoidsAreProducedAtOneOfTheSourcesLimitedByTheMaxBoidCount;
//        public Range scale;
//        [TagReference("crea")]
//        public TagReference creature;
//        public int boidCount;
//        public float neighborhoodRadiusWorldUnitsDistanceWithinWhichOneBoidIsAffectedByAnother;
//        public float avoidanceRadiusWorldUnitsDistanceThatABoidTriesToMaintainFromAnother;
//        public float forwardScale01WeightGivenToBoidsDesireToFlyStraightAhead;
//        public float alignmentScale01WeightGivenToBoidsDesireToAlignItselfWithNeighboringBoids;
//        public float avoidanceScale01WeightGivenToBoidsDesireToAvoidCollisionsWithOtherBoidsWhenWithinTheAvoidanceRadius;
//        public float levelingForceScale01WeightGivenToBoidsDesireToFlyLevel;
//        public float sinkScale01WeightGivenToBoidsDesireToFlyTowardsItsSinks;
//        public float perceptionAngleDegreesAngleFromForwardWithinWhichOneBoidCanPerceiveAndReactToAnother;
//        public float averageThrottle01ThrottleAtWhichBoidsWillNaturallyFly;
//        public float maximumThrottle01MaximumThrottleApplicable;
//        public float positionScale01WeightGivenToBoidsDesireToBeNearFlockCenter;
//        public float positionMinRadiusWusDistanceToFlockCenterBeyondWhichAnAttractingForceIsApplied;
//        public float positionMaxRadiusWusDistanceToFlockCenterAtWhichTheMaximumAttractingForceIsApplied;
//        public float movementWeightThresholdTheThresholdOfAccumulatedWeightOverWhichMovementOccurs;
//        public float dangerRadiusWusDistanceWithinWhichBoidsWillAvoidADangerousObjectEGThePlayer;
//        public float dangerScaleWeightGivenToBoidsDesireToAvoidDanger;
//        public float randomOffsetScale01WeightGivenToBoidsRandomHeadingOffset;
//        public Range randomOffsetPeriodSeconds;
//        public StringID flockName;
//        public FlockDefinitionBlock()
//        {
//        }
//        public FlockDefinitionBlock(BinaryReader binaryReader)
//        {
//            this.bsp = binaryReader.ReadShortBlockIndex1();
//            this.padding = binaryReader.ReadBytes(2);
//            this.boundingVolume = binaryReader.ReadShortBlockIndex1();
//            this.flags = (Flags)binaryReader.ReadInt16();
//            this.ecologyMarginWusDistanceFromEcologyBoundaryThatCreatureBeginsToBeRepulsed = binaryReader.ReadSingle();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(FlockSourceBlock));
//                this.sources = new FlockSourceBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.sources[i] = new FlockSourceBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(FlockSinkBlock));
//                this.sinks = new FlockSinkBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.sinks[i] = new FlockSinkBlock(binaryReader);
//                    }
//                }
//            }
//            this.productionFrequencyBoidsSecHowFrequentlyBoidsAreProducedAtOneOfTheSourcesLimitedByTheMaxBoidCount = binaryReader.ReadSingle();
//            this.scale = binaryReader.ReadRange();
//            this.creature = binaryReader.ReadTagReference();
//            this.boidCount = binaryReader.ReadInt32();
//            this.neighborhoodRadiusWorldUnitsDistanceWithinWhichOneBoidIsAffectedByAnother = binaryReader.ReadSingle();
//            this.avoidanceRadiusWorldUnitsDistanceThatABoidTriesToMaintainFromAnother = binaryReader.ReadSingle();
//            this.forwardScale01WeightGivenToBoidsDesireToFlyStraightAhead = binaryReader.ReadSingle();
//            this.alignmentScale01WeightGivenToBoidsDesireToAlignItselfWithNeighboringBoids = binaryReader.ReadSingle();
//            this.avoidanceScale01WeightGivenToBoidsDesireToAvoidCollisionsWithOtherBoidsWhenWithinTheAvoidanceRadius = binaryReader.ReadSingle();
//            this.levelingForceScale01WeightGivenToBoidsDesireToFlyLevel = binaryReader.ReadSingle();
//            this.sinkScale01WeightGivenToBoidsDesireToFlyTowardsItsSinks = binaryReader.ReadSingle();
//            this.perceptionAngleDegreesAngleFromForwardWithinWhichOneBoidCanPerceiveAndReactToAnother = binaryReader.ReadSingle();
//            this.averageThrottle01ThrottleAtWhichBoidsWillNaturallyFly = binaryReader.ReadSingle();
//            this.maximumThrottle01MaximumThrottleApplicable = binaryReader.ReadSingle();
//            this.positionScale01WeightGivenToBoidsDesireToBeNearFlockCenter = binaryReader.ReadSingle();
//            this.positionMinRadiusWusDistanceToFlockCenterBeyondWhichAnAttractingForceIsApplied = binaryReader.ReadSingle();
//            this.positionMaxRadiusWusDistanceToFlockCenterAtWhichTheMaximumAttractingForceIsApplied = binaryReader.ReadSingle();
//            this.movementWeightThresholdTheThresholdOfAccumulatedWeightOverWhichMovementOccurs = binaryReader.ReadSingle();
//            this.dangerRadiusWusDistanceWithinWhichBoidsWillAvoidADangerousObjectEGThePlayer = binaryReader.ReadSingle();
//            this.dangerScaleWeightGivenToBoidsDesireToAvoidDanger = binaryReader.ReadSingle();
//            this.randomOffsetScale01WeightGivenToBoidsRandomHeadingOffset = binaryReader.ReadSingle();
//            this.randomOffsetPeriodSeconds = binaryReader.ReadRange();
//            this.flockName = binaryReader.ReadStringID();
//        }
//        [Flags]
//        public enum Flags : short
//        {
//            HardBoundariesOnVolume = 1,
//            FlockInitiallyStopped = 2,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
//    public partial class GlobalGeometryBlockResourceBlock
//    {
//        public Type type;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
//        private byte[] padding;
//        #endregion
//        public short primaryLocator;
//        public short secondaryLocator;
//        public int resourceDataSize;
//        public int resourceDataOffset;
//        public GlobalGeometryBlockResourceBlock()
//        {
//        }
//        public GlobalGeometryBlockResourceBlock(BinaryReader binaryReader)
//        {
//            this.type = (Type)binaryReader.ReadByte();
//            this.padding = binaryReader.ReadBytes(3);
//            this.primaryLocator = binaryReader.ReadInt16();
//            this.secondaryLocator = binaryReader.ReadInt16();
//            this.resourceDataSize = binaryReader.ReadInt32();
//            this.resourceDataOffset = binaryReader.ReadInt32();
//        }
//        public enum Type : byte
//        {
//            TagBlock = 0,
//            TagData = 1,
//            VertexBuffer = 2,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 36, Pack = 4)]
//    public partial class GlobalGeometryBlockInfoStruct
//    {
//        public int blockOffset;
//        public int blockSize;
//        public int sectionDataSize;
//        public int resourceDataSize;
//        [TagBlockField]
//        public GlobalGeometryBlockResourceBlock[] resources;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] padding;
//        #endregion
//        public short ownerTagSectionOffset;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding0;
//        #endregion
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] padding1;
//        #endregion
//        public GlobalGeometryBlockInfoStruct()
//        {
//        }
//        public GlobalGeometryBlockInfoStruct(BinaryReader binaryReader)
//        {
//            this.blockOffset = binaryReader.ReadInt32();
//            this.blockSize = binaryReader.ReadInt32();
//            this.sectionDataSize = binaryReader.ReadInt32();
//            this.resourceDataSize = binaryReader.ReadInt32();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(GlobalGeometryBlockResourceBlock));
//                this.resources = new GlobalGeometryBlockResourceBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.resources[i] = new GlobalGeometryBlockResourceBlock(binaryReader);
//                    }
//                }
//            }
//            this.padding = binaryReader.ReadBytes(4);
//            this.ownerTagSectionOffset = binaryReader.ReadInt16();
//            this.padding0 = binaryReader.ReadBytes(2);
//            this.padding1 = binaryReader.ReadBytes(4);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 22, Pack = 4)]
//    public partial class DecoratorPlacementBlock
//    {
//        public int internalData1;
//        public int compressedPosition;
//        public RGBColor tintColor;
//        public RGBColor lightmapColor;
//        public int compressedLightDirection;
//        public int compressedLight2Direction;
//        public DecoratorPlacementBlock()
//        {
//        }
//        public DecoratorPlacementBlock(BinaryReader binaryReader)
//        {
//            this.internalData1 = binaryReader.ReadInt32();
//            this.compressedPosition = binaryReader.ReadInt32();
//            this.tintColor = binaryReader.ReadRGBColor();
//            this.lightmapColor = binaryReader.ReadRGBColor();
//            this.compressedLightDirection = binaryReader.ReadInt32();
//            this.compressedLight2Direction = binaryReader.ReadInt32();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 31, Pack = 4)]
//    public partial class DecalVerticesBlock
//    {
//        public Vector3 position;
//        public Vector2 texcoord0;
//        public Vector2 texcoord1;
//        public RGBColor color;
//        public DecalVerticesBlock()
//        {
//        }
//        public DecalVerticesBlock(BinaryReader binaryReader)
//        {
//            this.position = binaryReader.ReadVector3();
//            this.texcoord0 = binaryReader.ReadVector2();
//            this.texcoord1 = binaryReader.ReadVector2();
//            this.color = binaryReader.ReadRGBColor();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 2, Pack = 4)]
//    public partial class IndicesBlock
//    {
//        public short index;
//        public IndicesBlock()
//        {
//        }
//        public IndicesBlock(BinaryReader binaryReader)
//        {
//            this.index = binaryReader.ReadInt16();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 47, Pack = 4)]
//    public partial class SpriteVerticesBlock
//    {
//        public Vector3 position;
//        public Vector3 offset;
//        public Vector3 axis;
//        public Vector2 texcoord;
//        public RGBColor color;
//        public SpriteVerticesBlock()
//        {
//        }
//        public SpriteVerticesBlock(BinaryReader binaryReader)
//        {
//            this.position = binaryReader.ReadVector3();
//            this.offset = binaryReader.ReadVector3();
//            this.axis = binaryReader.ReadVector3();
//            this.texcoord = binaryReader.ReadVector2();
//            this.color = binaryReader.ReadRGBColor();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 136, Pack = 4)]
//    public partial class DecoratorCacheBlockDataBlock
//    {
//        [TagBlockField]
//        public DecoratorPlacementBlock[] placements;
//        [TagBlockField]
//        public DecalVerticesBlock[] decalVertices;
//        [TagBlockField]
//        public IndicesBlock[] decalIndices;
//        public VertexBuffer decalVertexBuffer;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
//        private byte[] padding;
//        #endregion
//        [TagBlockField]
//        public SpriteVerticesBlock[] spriteVertices;
//        [TagBlockField]
//        public IndicesBlock[] spriteIndices;
//        public VertexBuffer spriteVertexBuffer;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
//        private byte[] padding0;
//        #endregion
//        public DecoratorCacheBlockDataBlock()
//        {
//        }
//        public DecoratorCacheBlockDataBlock(BinaryReader binaryReader)
//        {
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(DecoratorPlacementBlock));
//                this.placements = new DecoratorPlacementBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.placements[i] = new DecoratorPlacementBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(DecalVerticesBlock));
//                this.decalVertices = new DecalVerticesBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.decalVertices[i] = new DecalVerticesBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(IndicesBlock));
//                this.decalIndices = new IndicesBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.decalIndices[i] = new IndicesBlock(binaryReader);
//                    }
//                }
//            }
//            this.decalVertexBuffer = binaryReader.ReadVertexBuffer();
//            this.padding = binaryReader.ReadBytes(16);
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(SpriteVerticesBlock));
//                this.spriteVertices = new SpriteVerticesBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.spriteVertices[i] = new SpriteVerticesBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(IndicesBlock));
//                this.spriteIndices = new IndicesBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.spriteIndices[i] = new IndicesBlock(binaryReader);
//                    }
//                }
//            }
//            this.spriteVertexBuffer = binaryReader.ReadVertexBuffer();
//            this.padding0 = binaryReader.ReadBytes(16);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 44, Pack = 4)]
//    public partial class DecoratorCacheBlockBlock
//    {
//        [TagStructField]
//        public GlobalGeometryBlockInfoStruct geometryBlockInfo;
//        [TagBlockField]
//        public DecoratorCacheBlockDataBlock[] cacheBlockData;
//        public DecoratorCacheBlockBlock()
//        {
//        }
//        public DecoratorCacheBlockBlock(BinaryReader binaryReader)
//        {
//            this.geometryBlockInfo = new GlobalGeometryBlockInfoStruct(binaryReader);
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(DecoratorCacheBlockDataBlock));
//                this.cacheBlockData = new DecoratorCacheBlockDataBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.cacheBlockData[i] = new DecoratorCacheBlockDataBlock(binaryReader);
//                    }
//                }
//            }
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 24, Pack = 4)]
//    public partial class DecoratorGroupBlock
//    {
//        public ByteBlockIndex1 decoratorSet;
//        public DecoratorType decoratorType;
//        public byte shaderIndex;
//        public byte compressedRadius;
//        public short cluster;
//        public ShortBlockIndex1 cacheBlock;
//        public short decoratorStartIndex;
//        public short decoratorCount;
//        public short vertexStartOffset;
//        public short vertexCount;
//        public short indexStartOffset;
//        public short indexCount;
//        public int compressedBoundingCenter;
//        public DecoratorGroupBlock()
//        {
//        }
//        public DecoratorGroupBlock(BinaryReader binaryReader)
//        {
//            this.decoratorSet = binaryReader.ReadByteBlockIndex1();
//            this.decoratorType = (DecoratorType)binaryReader.ReadByte();
//            this.shaderIndex = binaryReader.ReadByte();
//            this.compressedRadius = binaryReader.ReadByte();
//            this.cluster = binaryReader.ReadInt16();
//            this.cacheBlock = binaryReader.ReadShortBlockIndex1();
//            this.decoratorStartIndex = binaryReader.ReadInt16();
//            this.decoratorCount = binaryReader.ReadInt16();
//            this.vertexStartOffset = binaryReader.ReadInt16();
//            this.vertexCount = binaryReader.ReadInt16();
//            this.indexStartOffset = binaryReader.ReadInt16();
//            this.indexCount = binaryReader.ReadInt16();
//            this.compressedBoundingCenter = binaryReader.ReadInt32();
//        }
//        public enum DecoratorType : byte
//        {
//            Model = 0,
//            FloatingDecal = 1,
//            ProjectedDecal = 2,
//            ScreenFacingQuad = 3,
//            AxisRotatingQuad = 4,
//            CrossQuad = 5,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 24, Pack = 4)]
//    public partial class DecoratorCellCollectionBlock
//    {
//        public struct ChildIndices
//        {
//            public short childIndex;
//            public ChildIndices(BinaryReader binaryReader)
//            {
//                this.childIndex = binaryReader.ReadInt16();
//            }
//        }
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
//        public ChildIndices[] childIndices;
//        public ShortBlockIndex1 cacheBlockIndex;
//        public short groupCount;
//        public int groupStartIndex;
//        public DecoratorCellCollectionBlock()
//        {
//        }
//        public DecoratorCellCollectionBlock(BinaryReader binaryReader)
//        {
//            this.childIndices = new ChildIndices[8];
//            for (int i = 0; i < 8; ++i)
//            {
//                this.childIndices[i] = new ChildIndices(binaryReader);
//            }
//            this.cacheBlockIndex = binaryReader.ReadShortBlockIndex1();
//            this.groupCount = binaryReader.ReadInt16();
//            this.groupStartIndex = binaryReader.ReadInt32();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 64, Pack = 4)]
//    public partial class DecoratorProjectedDecalBlock
//    {
//        public ByteBlockIndex1 decoratorSet;
//        public byte decoratorClass;
//        public byte decoratorPermutation;
//        public byte spriteIndex;
//        public Vector3 position;
//        public Vector3 left;
//        public Vector3 up;
//        public Vector3 extents;
//        public Vector3 previousPosition;
//        public DecoratorProjectedDecalBlock()
//        {
//        }
//        public DecoratorProjectedDecalBlock(BinaryReader binaryReader)
//        {
//            this.decoratorSet = binaryReader.ReadByteBlockIndex1();
//            this.decoratorClass = binaryReader.ReadByte();
//            this.decoratorPermutation = binaryReader.ReadByte();
//            this.spriteIndex = binaryReader.ReadByte();
//            this.position = binaryReader.ReadVector3();
//            this.left = binaryReader.ReadVector3();
//            this.up = binaryReader.ReadVector3();
//            this.extents = binaryReader.ReadVector3();
//            this.previousPosition = binaryReader.ReadVector3();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 48, Pack = 4)]
//    public partial class DecoratorPlacementDefinitionBlock
//    {
//        public Vector3 gridOrigin;
//        public int cellCountPerDimension;
//        [TagBlockField]
//        public DecoratorCacheBlockBlock[] cacheBlocks;
//        [TagBlockField]
//        public DecoratorGroupBlock[] groups;
//        [TagBlockField]
//        public DecoratorCellCollectionBlock[] cells;
//        [TagBlockField]
//        public DecoratorProjectedDecalBlock[] decals;
//        public DecoratorPlacementDefinitionBlock()
//        {
//        }
//        public DecoratorPlacementDefinitionBlock(BinaryReader binaryReader)
//        {
//            this.gridOrigin = binaryReader.ReadVector3();
//            this.cellCountPerDimension = binaryReader.ReadInt32();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(DecoratorCacheBlockBlock));
//                this.cacheBlocks = new DecoratorCacheBlockBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.cacheBlocks[i] = new DecoratorCacheBlockBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(DecoratorGroupBlock));
//                this.groups = new DecoratorGroupBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.groups[i] = new DecoratorGroupBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(DecoratorCellCollectionBlock));
//                this.cells = new DecoratorCellCollectionBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.cells[i] = new DecoratorCellCollectionBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(DecoratorProjectedDecalBlock));
//                this.decals = new DecoratorProjectedDecalBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.decals[i] = new DecoratorProjectedDecalBlock(binaryReader);
//                    }
//                }
//            }
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 52, Pack = 4)]
//    public partial class ScenarioCreatureBlock
//    {
//        public ShortBlockIndex1 type;
//        public ShortBlockIndex1 name;
//        [TagStructField]
//        public ScenarioObjectDatumStruct objectData;
//        public ScenarioCreatureBlock()
//        {
//        }
//        public ScenarioCreatureBlock(BinaryReader binaryReader)
//        {
//            this.type = binaryReader.ReadShortBlockIndex1();
//            this.name = binaryReader.ReadShortBlockIndex1();
//            this.objectData = new ScenarioObjectDatumStruct(binaryReader);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 40, Pack = 4)]
//    public partial class ScenarioCreaturePaletteBlock
//    {
//        [TagReference("crea")]
//        public TagReference name;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
//        private byte[] padding;
//        #endregion
//        public ScenarioCreaturePaletteBlock()
//        {
//        }
//        public ScenarioCreaturePaletteBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadTagReference();
//            this.padding = binaryReader.ReadBytes(32);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class ScenarioDecoratorSetPaletteEntryBlock
//    {
//        [TagReference("DECR")]
//        public TagReference decoratorSet;
//        public ScenarioDecoratorSetPaletteEntryBlock()
//        {
//        }
//        public ScenarioDecoratorSetPaletteEntryBlock(BinaryReader binaryReader)
//        {
//            this.decoratorSet = binaryReader.ReadTagReference();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class ScenarioBspSwitchTransitionVolumeBlock
//    {
//        public int bSPIndexKey;
//        public ShortBlockIndex1 triggerVolume;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] padding;
//        #endregion
//        public ScenarioBspSwitchTransitionVolumeBlock()
//        {
//        }
//        public ScenarioBspSwitchTransitionVolumeBlock(BinaryReader binaryReader)
//        {
//            this.bSPIndexKey = binaryReader.ReadInt32();
//            this.triggerVolume = binaryReader.ReadShortBlockIndex1();
//            this.padding = binaryReader.ReadBytes(2);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 12, Pack = 4)]
//    public partial class ScenarioSphericalHarmonicLightingPoint
//    {
//        public Vector3 position;
//        public ScenarioSphericalHarmonicLightingPoint()
//        {
//        }
//        public ScenarioSphericalHarmonicLightingPoint(BinaryReader binaryReader)
//        {
//            this.position = binaryReader.ReadVector3();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 4)]
//    public partial class ScenarioStructureBspSphericalHarmonicLightingBlock
//    {
//        [TagReference("sbsp")]
//        public TagReference bSP;
//        [TagBlockField]
//        public ScenarioSphericalHarmonicLightingPoint[] lightingPoints;
//        public ScenarioStructureBspSphericalHarmonicLightingBlock()
//        {
//        }
//        public ScenarioStructureBspSphericalHarmonicLightingBlock(BinaryReader binaryReader)
//        {
//            this.bSP = binaryReader.ReadTagReference();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ScenarioSphericalHarmonicLightingPoint));
//                this.lightingPoints = new ScenarioSphericalHarmonicLightingPoint[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.lightingPoints[i] = new ScenarioSphericalHarmonicLightingPoint(binaryReader);
//                    }
//                }
//            }
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 260, Pack = 4)]
//    public partial class GScenarioEditorFolderBlock
//    {
//        public LongBlockIndex1 parentFolder;
//        public String256 name;
//        public GScenarioEditorFolderBlock()
//        {
//        }
//        public GScenarioEditorFolderBlock(BinaryReader binaryReader)
//        {
//            this.parentFolder = binaryReader.ReadLongBlockIndex1();
//            this.name = binaryReader.ReadString256();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 2896, Pack = 4)]
//    public partial class GlobalUiCampaignLevelBlock
//    {
//        public int campaignID;
//        public int mapID;
//        [TagReference("bitm")]
//        public TagReference bitmap;
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 576)]
//        private byte[] skip;
//        #endregion
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2304)]
//        private byte[] skip0;
//        #endregion
//        public GlobalUiCampaignLevelBlock()
//        {
//        }
//        public GlobalUiCampaignLevelBlock(BinaryReader binaryReader)
//        {
//            this.campaignID = binaryReader.ReadInt32();
//            this.mapID = binaryReader.ReadInt32();
//            this.bitmap = binaryReader.ReadTagReference();
//            this.skip = binaryReader.ReadBytes(576);
//            this.skip0 = binaryReader.ReadBytes(2304);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 3172, Pack = 4)]
//    public partial class GlobalUiMultiplayerLevelBlock
//    {
//        public int mapID;
//        [TagReference("bitm")]
//        public TagReference bitmap;
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 576)]
//        private byte[] skip;
//        #endregion
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2304)]
//        private byte[] skip0;
//        #endregion
//        public String256 path;
//        public int sortOrder;
//        public Flags flags;
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
//        private byte[] padding1;
//        #endregion
//        public byte maxTeamsNone;
//        public byte maxTeamsCTF;
//        public byte maxTeamsSlayer;
//        public byte maxTeamsOddball;
//        public byte maxTeamsKOTH;
//        public byte maxTeamsRace;
//        public byte maxTeamsHeadhunter;
//        public byte maxTeamsJuggernaut;
//        public byte maxTeamsTerritories;
//        public byte maxTeamsAssault;
//        public byte maxTeamsStub10;
//        public byte maxTeamsStub11;
//        public byte maxTeamsStub12;
//        public byte maxTeamsStub13;
//        public byte maxTeamsStub14;
//        public byte maxTeamsStub15;
//        public GlobalUiMultiplayerLevelBlock()
//        {
//        }
//        public GlobalUiMultiplayerLevelBlock(BinaryReader binaryReader)
//        {
//            this.mapID = binaryReader.ReadInt32();
//            this.bitmap = binaryReader.ReadTagReference();
//            this.skip = binaryReader.ReadBytes(576);
//            this.skip0 = binaryReader.ReadBytes(2304);
//            this.path = binaryReader.ReadString256();
//            this.sortOrder = binaryReader.ReadInt32();
//            this.flags = (Flags)binaryReader.ReadByte();
//            this.padding1 = binaryReader.ReadBytes(3);
//            this.maxTeamsNone = binaryReader.ReadByte();
//            this.maxTeamsCTF = binaryReader.ReadByte();
//            this.maxTeamsSlayer = binaryReader.ReadByte();
//            this.maxTeamsOddball = binaryReader.ReadByte();
//            this.maxTeamsKOTH = binaryReader.ReadByte();
//            this.maxTeamsRace = binaryReader.ReadByte();
//            this.maxTeamsHeadhunter = binaryReader.ReadByte();
//            this.maxTeamsJuggernaut = binaryReader.ReadByte();
//            this.maxTeamsTerritories = binaryReader.ReadByte();
//            this.maxTeamsAssault = binaryReader.ReadByte();
//            this.maxTeamsStub10 = binaryReader.ReadByte();
//            this.maxTeamsStub11 = binaryReader.ReadByte();
//            this.maxTeamsStub12 = binaryReader.ReadByte();
//            this.maxTeamsStub13 = binaryReader.ReadByte();
//            this.maxTeamsStub14 = binaryReader.ReadByte();
//            this.maxTeamsStub15 = binaryReader.ReadByte();
//        }
//        [Flags]
//        public enum Flags : byte
//        {
//            Unlockable = 1,
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 24, Pack = 4)]
//    public partial class ScenarioLevelDataBlock
//    {
//        [TagReference("unic")]
//        public TagReference levelDescription;
//        [TagBlockField]
//        public GlobalUiCampaignLevelBlock[] campaignLevelData;
//        [TagBlockField]
//        public GlobalUiMultiplayerLevelBlock[] multiplayer;
//        public ScenarioLevelDataBlock()
//        {
//        }
//        public ScenarioLevelDataBlock(BinaryReader binaryReader)
//        {
//            this.levelDescription = binaryReader.ReadTagReference();
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(GlobalUiCampaignLevelBlock));
//                this.campaignLevelData = new GlobalUiCampaignLevelBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.campaignLevelData[i] = new GlobalUiCampaignLevelBlock(binaryReader);
//                    }
//                }
//            }
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(GlobalUiMultiplayerLevelBlock));
//                this.multiplayer = new GlobalUiMultiplayerLevelBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.multiplayer[i] = new GlobalUiMultiplayerLevelBlock(binaryReader);
//                    }
//                }
//            }
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class AiScenarioMissionDialogueBlock
//    {
//        [TagReference("mdlg")]
//        public TagReference missionDialogue;
//        public AiScenarioMissionDialogueBlock()
//        {
//        }
//        public AiScenarioMissionDialogueBlock(BinaryReader binaryReader)
//        {
//            this.missionDialogue = binaryReader.ReadTagReference();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 1, Pack = 4)]
//    public partial class ByteBlock
//    {
//        public byte value;
//        public ByteBlock()
//        {
//        }
//        public ByteBlock(BinaryReader binaryReader)
//        {
//            this.value = binaryReader.ReadByte();
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class MappingFunction
//    {
//        [TagBlockField]
//        public ByteBlock[] data;
//        public MappingFunction()
//        {
//        }
//        public MappingFunction(BinaryReader binaryReader)
//        {
//            {
//                var count = binaryReader.ReadInt32();
//                var address = binaryReader.ReadInt32();
//                var elementSize = Marshal.SizeOf(typeof(ByteBlock));
//                this.data = new ByteBlock[count];
//                using (binaryReader.BaseStream.Pin())
//                {
//                    for (int i = 0; i < count; ++i)
//                    {
//                        binaryReader.BaseStream.Position = address + i * elementSize;
//                        this.data[i] = new ByteBlock(binaryReader);
//                    }
//                }
//            }
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 4)]
//    public partial class ScalarFunctionStruct
//    {
//        [TagStructField]
//        public MappingFunction function;
//        public ScalarFunctionStruct()
//        {
//        }
//        public ScalarFunctionStruct(BinaryReader binaryReader)
//        {
//            this.function = new MappingFunction(binaryReader);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 24, Pack = 4)]
//    public partial class ScenarioInterpolatorBlock
//    {
//        public StringID name;
//        public StringID acceleratorNameInterpolator;
//        public StringID multiplierNameInterpolator;
//        [TagStructField]
//        public ScalarFunctionStruct function;
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] skip;
//        #endregion
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] skip0;
//        #endregion
//        public ScenarioInterpolatorBlock()
//        {
//        }
//        public ScenarioInterpolatorBlock(BinaryReader binaryReader)
//        {
//            this.name = binaryReader.ReadStringID();
//            this.acceleratorNameInterpolator = binaryReader.ReadStringID();
//            this.multiplierNameInterpolator = binaryReader.ReadStringID();
//            this.function = new ScalarFunctionStruct(binaryReader);
//            this.skip = binaryReader.ReadBytes(2);
//            this.skip0 = binaryReader.ReadBytes(2);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 36, Pack = 4)]
//    public partial class ScenarioScreenEffectReferenceBlock
//    {
//        #region padding
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
//        private byte[] padding;
//        #endregion
//        [TagReference("egor")]
//        public TagReference screenEffect;
//        public StringID primaryInputInterpolator;
//        public StringID secondaryInputInterpolator;
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] skip0;
//        #endregion
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
//        private byte[] skip1;
//        #endregion
//        public ScenarioScreenEffectReferenceBlock()
//        {
//        }
//        public ScenarioScreenEffectReferenceBlock(BinaryReader binaryReader)
//        {
//            this.padding = binaryReader.ReadBytes(16);
//            this.screenEffect = binaryReader.ReadTagReference();
//            this.primaryInputInterpolator = binaryReader.ReadStringID();
//            this.secondaryInputInterpolator = binaryReader.ReadStringID();
//            this.skip0 = binaryReader.ReadBytes(2);
//            this.skip1 = binaryReader.ReadBytes(2);
//        }
//    }


//    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 4)]
//    public partial class ScenarioSimulationDefinitionTableBlock
//    {
//        #region skip
//        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
//        private byte[] skip;
//        #endregion
//        public ScenarioSimulationDefinitionTableBlock()
//        {
//        }
//        public ScenarioSimulationDefinitionTableBlock(BinaryReader binaryReader)
//        {
//            this.skip = binaryReader.ReadBytes(4);
//        }
//    }
//}
