using Moonfish.Guerilla.Tags;
using Moonfish.Model;
using OpenTK;
using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Moonfish.Tags
{
    [StructLayout(LayoutKind.Sequential, Size = 252, Pack = 0)]
    [TagClass("hlmt")]
    public partial class HierarchyModel
    {
        //FIELD_EXPLAINATION("MODEL", ""),
        [TagReference("mode")]
        public TagReference renderModel;
        [TagReference("coll")]
        public TagReference collisionModel;
        [TagReference("jmad")]
        public TagReference animation;
        [TagReference("phys")]
        public TagReference physics;
        [TagReference("phmo")]
        public TagReference physicsModel;
        //FIELD_EXPLAINATION("level of detail", "If a model is further away than the LOD reduction distance, it will be reduced to that LOD.<lb>So the L1 reduction distance should be really long and the L5 reduction distance should be really short.<lb>This means distances should be in descending order, e.g. 5 4 3 2 1.<lb><lb>Note that if we run out of memory or too many models are on screen at once, the engine may reduce<lb>models to a lower LOD BEFORE they reach the reduction distance for that LOD.<lb><lb>If a model has a begin fade distance and disappear distance, it will begin fading out at that distance,<lb>reaching zero alpha and disappearing at the disappear distance. These distances should be greater than all<lb>of the LOD reduction distances.<lb>"),
        public float disappearDistanceWorldUnits;
        public float beginFadeDistanceWorldUnits;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding;
        #endregion
        public float reduceToL1WorldUnitsSuperLow;
        public float reduceToL2WorldUnitsLow;
        public float reduceToL3WorldUnitsMedium;
        public float reduceToL4WorldUnitsHigh;
        public float reduceToL5WorldUnitsSuperHigh;
        #region skip
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] skip0;
        #endregion
        public ShadowFadeDistance shadowFadeDistance;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding1;
        #endregion
        [TagBlockField]
        public ModelVariantBlock[] variants;
        [TagBlockField]
        public ModelMaterialBlock[] materials;
        [TagBlockField]
        public GlobalDamageInfoBlock[] newDamageInfo;
        [TagBlockField]
        public ModelTargetBlock[] targets;
        [TagBlockField]
        public ModelRegionBlock[] modelRegionBlock;
        [TagBlockField]
        public ModelNodeBlock[] modelNodeBlock;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding2;
        #endregion
        [TagBlockField]
        public ModelObjectDataBlock[] modelObjectData;
        //FIELD_EXPLAINATION("more stuff", ""),
        [TagReference("udlg")]
        public TagReference defaultDialogueTheDefaultDialogueTagForThisModelOverridenByVariants;
        [TagReference("shad")]
        public TagReference uNUSED;
        public Flags flags;
        public StringID defaultDialogueEffectTheDefaultDialogueTagForThisModelOverridenByVariants;
        public struct RenderOnlyNodeFlags
        {
            public byte invalidName_;
            public RenderOnlyNodeFlags(BinaryReader binaryReader)
            {
                this.invalidName_ = binaryReader.ReadByte();
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public RenderOnlyNodeFlags[] renderOnlyNodeFlags;
        public struct RenderOnlySectionFlags
        {
            public byte invalidName_;
            public RenderOnlySectionFlags(BinaryReader binaryReader)
            {
                this.invalidName_ = binaryReader.ReadByte();
            }
        }
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public RenderOnlySectionFlags[] renderOnlySectionFlags;
        public RuntimeFlags runtimeFlags;
        [TagBlockField]
        public GlobalScenarioLoadParametersBlock[] scenarioLoadParameters;
        //FIELD_EXPLAINATION("HOLOGRAM", "hologram shader is applied whenever the control function from it's object is non-zero"),
        [TagReference("shad")]
        public TagReference hologramShader;
        public StringID hologramControlFunction;
        public HierarchyModel()
        {
        }
        public HierarchyModel(BinaryReader binaryReader)
        {
            this.renderModel = binaryReader.ReadTagReference();
            this.collisionModel = binaryReader.ReadTagReference();
            this.animation = binaryReader.ReadTagReference();
            this.physics = binaryReader.ReadTagReference();
            this.physicsModel = binaryReader.ReadTagReference();
            this.disappearDistanceWorldUnits = binaryReader.ReadSingle();
            this.beginFadeDistanceWorldUnits = binaryReader.ReadSingle();
            this.padding = binaryReader.ReadBytes(4);
            this.reduceToL1WorldUnitsSuperLow = binaryReader.ReadSingle();
            this.reduceToL2WorldUnitsLow = binaryReader.ReadSingle();
            this.reduceToL3WorldUnitsMedium = binaryReader.ReadSingle();
            this.reduceToL4WorldUnitsHigh = binaryReader.ReadSingle();
            this.reduceToL5WorldUnitsSuperHigh = binaryReader.ReadSingle();
            this.skip0 = binaryReader.ReadBytes(4);
            this.shadowFadeDistance = (ShadowFadeDistance)binaryReader.ReadInt16();
            this.padding1 = binaryReader.ReadBytes(2);
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ModelVariantBlock));
                this.variants = new ModelVariantBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.variants[i] = new ModelVariantBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ModelMaterialBlock));
                this.materials = new ModelMaterialBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.materials[i] = new ModelMaterialBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(GlobalDamageInfoBlock));
                this.newDamageInfo = new GlobalDamageInfoBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.newDamageInfo[i] = new GlobalDamageInfoBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ModelTargetBlock));
                this.targets = new ModelTargetBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.targets[i] = new ModelTargetBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ModelRegionBlock));
                this.modelRegionBlock = new ModelRegionBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.modelRegionBlock[i] = new ModelRegionBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ModelNodeBlock));
                this.modelNodeBlock = new ModelNodeBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.modelNodeBlock[i] = new ModelNodeBlock(binaryReader);
                    }
                }
            }
            this.padding2 = binaryReader.ReadBytes(4);
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ModelObjectDataBlock));
                this.modelObjectData = new ModelObjectDataBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.modelObjectData[i] = new ModelObjectDataBlock(binaryReader);
                    }
                }
            }
            this.defaultDialogueTheDefaultDialogueTagForThisModelOverridenByVariants = binaryReader.ReadTagReference();
            this.uNUSED = binaryReader.ReadTagReference();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.defaultDialogueEffectTheDefaultDialogueTagForThisModelOverridenByVariants = binaryReader.ReadStringID();
            this.renderOnlyNodeFlags = new RenderOnlyNodeFlags[32];
            for (int i = 0; i < 32; ++i)
            {
                this.renderOnlyNodeFlags[i] = new RenderOnlyNodeFlags(binaryReader);
            }
            this.renderOnlySectionFlags = new RenderOnlySectionFlags[32];
            for (int i = 0; i < 32; ++i)
            {
                this.renderOnlySectionFlags[i] = new RenderOnlySectionFlags(binaryReader);
            }
            this.runtimeFlags = (RuntimeFlags)binaryReader.ReadInt32();
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(GlobalScenarioLoadParametersBlock));
                this.scenarioLoadParameters = new GlobalScenarioLoadParametersBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.scenarioLoadParameters[i] = new GlobalScenarioLoadParametersBlock(binaryReader);
                    }
                }
            }
            this.hologramShader = binaryReader.ReadTagReference();
            this.hologramControlFunction = binaryReader.ReadStringID();

            Initialize();
        }
        public enum ShadowFadeDistance : short
        {
            FadeAtSuperHighDetailLevel = 0,
            FadeAtHighDetailLevel = 1,
            FadeAtMediumDetailLevel = 2,
            FadeAtLowDetailLevel = 3,
            FadeAtSuperLowDetailLevel = 4,
            FadeNever = 5,
        }
        [Flags]
        public enum Flags : int
        {
            ActiveCamoAlwaysOn = 1,
            ActiveCamoAlwaysMerge = 2,
            ActiveCamoNeverMerge = 4,
        }
        [Flags]
        public enum RuntimeFlags : int
        {
            ContainsRunTimeNodes = 1,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 24, Pack = 0)]
    public partial class ModelVariantStateBlock
    {
        public StringID permutationName;
        #region padding
        private byte padding;
        #endregion
        public PropertyFlags propertyFlags;
        public State state;
        [TagReference("effe")]
        public TagReference loopingEffectPlayedWhileTheModelIsInThisState;
        public StringID loopingEffectMarkerName;
        public float initialProbability;
        public ModelVariantStateBlock()
        {
        }
        public ModelVariantStateBlock(BinaryReader binaryReader)
        {
            this.permutationName = binaryReader.ReadStringID();
            this.padding = binaryReader.ReadByte();
            this.propertyFlags = (PropertyFlags)binaryReader.ReadByte();
            this.state = (State)binaryReader.ReadInt16();
            this.loopingEffectPlayedWhileTheModelIsInThisState = binaryReader.ReadTagReference();
            this.loopingEffectMarkerName = binaryReader.ReadStringID();
            this.initialProbability = binaryReader.ReadSingle();
        }
        [Flags]
        public enum PropertyFlags : byte
        {
            Blurred = 1,
            HellaBlurred = 2,
            Shielded = 4,
        }
        public enum State : short
        {
            Default = 0,
            MinorDamage = 1,
            MediumDamage = 2,
            MajorDamage = 3,
            Destroyed = 4,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 32, Pack = 0)]
    public partial class ModelVariantPermutationBlock
    {
        public StringID permutationName;
        #region padding
        private byte padding;
        #endregion
        public Flags flags;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding0;
        #endregion
        public float probability0Inf;
        [TagBlockField]
        public ModelVariantStateBlock[] states;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        private byte[] padding1;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
        private byte[] padding2;
        #endregion
        public ModelVariantPermutationBlock()
        {
        }
        public ModelVariantPermutationBlock(BinaryReader binaryReader)
        {
            this.permutationName = binaryReader.ReadStringID();
            this.padding = binaryReader.ReadByte();
            this.flags = (Flags)binaryReader.ReadByte();
            this.padding0 = binaryReader.ReadBytes(2);
            this.probability0Inf = binaryReader.ReadSingle();
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ModelVariantStateBlock));
                this.states = new ModelVariantStateBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.states[i] = new ModelVariantStateBlock(binaryReader);
                    }
                }
            }
            this.padding1 = binaryReader.ReadBytes(5);
            this.padding2 = binaryReader.ReadBytes(7);
        }
        [Flags]
        public enum Flags : byte
        {
            CopyStatesToAllPermutations = 1,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 0)]
    public partial class ModelVariantRegionBlock
    {
        public StringID regionNameMustMatchRegionNameInRenderModel;
        #region padding
        private byte padding;
        #endregion
        #region padding
        private byte padding0;
        #endregion
        public ShortBlockIndex1 parentVariant;
        [TagBlockField]
        public ModelVariantPermutationBlock[] permutations;
        public SortOrderNegativeValuesMeanCloserToTheCamera sortOrderNegativeValuesMeanCloserToTheCamera;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding1;
        #endregion
        public ModelVariantRegionBlock()
        {
        }
        public ModelVariantRegionBlock(BinaryReader binaryReader)
        {
            this.regionNameMustMatchRegionNameInRenderModel = binaryReader.ReadStringID();
            this.padding = binaryReader.ReadByte();
            this.padding0 = binaryReader.ReadByte();
            this.parentVariant = binaryReader.ReadShortBlockIndex1();
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ModelVariantPermutationBlock));
                this.permutations = new ModelVariantPermutationBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.permutations[i] = new ModelVariantPermutationBlock(binaryReader);
                    }
                }
            }
            this.sortOrderNegativeValuesMeanCloserToTheCamera = (SortOrderNegativeValuesMeanCloserToTheCamera)binaryReader.ReadInt16();
            this.padding1 = binaryReader.ReadBytes(2);
        }
        public enum SortOrderNegativeValuesMeanCloserToTheCamera : short
        {
            NoSorting = 0,
            invalidName_5Closest = 1,
            invalidName_4 = 2,
            invalidName_3 = 3,
            invalidName_2 = 4,
            invalidName_1 = 5,
            invalidName_0SameAsModel = 6,
            invalidName_10 = 7,
            invalidName_20 = 8,
            invalidName_30 = 9,
            invalidName_40 = 10,
            invalidName_5Farthest = 11,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 0)]
    public partial class ModelVariantObjectBlock
    {
        public StringID parentMarker;
        public StringID childMarker;
        [TagReference("obje")]
        public TagReference childObject;
        public ModelVariantObjectBlock()
        {
        }
        public ModelVariantObjectBlock(BinaryReader binaryReader)
        {
            this.parentMarker = binaryReader.ReadStringID();
            this.childMarker = binaryReader.ReadStringID();
            this.childObject = binaryReader.ReadTagReference();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 56, Pack = 0)]
    public partial class ModelVariantBlock
    {
        public StringID name;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
        private byte[] padding;
        #endregion
        [TagBlockField]
        public ModelVariantRegionBlock[] regions;
        [TagBlockField]
        public ModelVariantObjectBlock[] objects;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        private byte[] padding0;
        #endregion
        public StringID dialogueSoundEffect;
        [TagReference("udlg")]
        public TagReference dialogue;
        public ModelVariantBlock()
        {
        }
        public ModelVariantBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.padding = binaryReader.ReadBytes(16);
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ModelVariantRegionBlock));
                this.regions = new ModelVariantRegionBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.regions[i] = new ModelVariantRegionBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ModelVariantObjectBlock));
                this.objects = new ModelVariantObjectBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.objects[i] = new ModelVariantObjectBlock(binaryReader);
                    }
                }
            }
            this.padding0 = binaryReader.ReadBytes(8);
            this.dialogueSoundEffect = binaryReader.ReadStringID();
            this.dialogue = binaryReader.ReadTagReference();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 0)]
    public partial class ModelMaterialBlock
    {
        public StringID materialName;
        public MaterialType materialType;
        public ShortBlockIndex2 damageSection;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding0;
        #endregion
        public StringID globalMaterialName;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding1;
        #endregion
        public ModelMaterialBlock()
        {
        }
        public ModelMaterialBlock(BinaryReader binaryReader)
        {
            this.materialName = binaryReader.ReadStringID();
            this.materialType = (MaterialType)binaryReader.ReadInt16();
            this.damageSection = binaryReader.ReadShortBlockIndex2();
            this.padding = binaryReader.ReadBytes(2);
            this.padding0 = binaryReader.ReadBytes(2);
            this.globalMaterialName = binaryReader.ReadStringID();
            this.padding1 = binaryReader.ReadBytes(4);
        }
        public enum MaterialType : short
        {
            Dirt = 0,
            Sand = 1,
            Stone = 2,
            Snow = 3,
            Wood = 4,
            MetalHollow = 5,
            MetalThin = 6,
            MetalThick = 7,
            Rubber = 8,
            Glass = 9,
            ForceField = 10,
            Grunt = 11,
            HunterArmor = 12,
            HunterSkin = 13,
            Elite = 14,
            Jackal = 15,
            JackalEnergyShield = 16,
            EngineerSkin = 17,
            EngineerForceField = 18,
            FloodCombatForm = 19,
            FloodCarrierForm = 20,
            CyborgArmor = 21,
            CyborgEnergyShield = 22,
            HumanArmor = 23,
            HumanSkin = 24,
            Sentinel = 25,
            Monitor = 26,
            Plastic = 27,
            Water = 28,
            Leaves = 29,
            EliteEnergyShield = 30,
            Ice = 31,
            HunterShield = 32,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 0)]
    public partial class InstantaneousResponseDamageEffectStruct
    {
        [TagReference("jpt!")]
        public TagReference transitionDamageEffect;
        public InstantaneousResponseDamageEffectStruct()
        {
        }
        public InstantaneousResponseDamageEffectStruct(BinaryReader binaryReader)
        {
            this.transitionDamageEffect = binaryReader.ReadTagReference();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 4, Pack = 0)]
    public partial class InstantaneousResponseDamageEffectMarkerStruct
    {
        public StringID damageEffectMarkerName;
        public InstantaneousResponseDamageEffectMarkerStruct()
        {
        }
        public InstantaneousResponseDamageEffectMarkerStruct(BinaryReader binaryReader)
        {
            this.damageEffectMarkerName = binaryReader.ReadStringID();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 80, Pack = 0)]
    public partial class InstantaneousDamageRepsonseBlock
    {
        public ResponseType responseType;
        //FIELD_EXPLAINATION("Constraint damage type", "* if you specify a constraint group name (see lower section of this block)<lb>  you can specify a constraint damage<lb>* loosening a constraint takes it out of the rigid state - activates it<lb>* destroying a constraint sets the attached body free"),
        public ConstraintDamageType constraintDamageType;
        //FIELD_EXPLAINATION("Damage response flags", "* kills object: when the response fires the object dies regardless of its current health<lb>* inhibits <x>: from halo 1 - disallows basic behaviors for a unit<lb>* forces drop weapon: from halo 1 - makes the unit drop its current weapon<lb>* kills weapon <x> trigger: destroys the <x> trigger on the unit's current weapon<lb>* destroys object: when the response fires the object is destroyed"),
        public Flags flags;
        public float damageThresholdRepsonseFiresAfterCrossingThisThreshold1FullHealth;
        [TagReference("effe")]
        public TagReference transitionEffect;
        [TagStructField]
        public InstantaneousResponseDamageEffectStruct damageEffect;
        public StringID region;
        public NewState newState;
        public short runtimeRegionIndex;
        public StringID effectMarkerName;
        [TagStructField]
        public InstantaneousResponseDamageEffectMarkerStruct damageEffectMarker;
        //FIELD_EXPLAINATION("Response delay", "If desired, you can specify a delay until the response fires.This delay is pre-empted if another timed response for the same section fires.The delay effect plays while the timer is counting down"),
        public float responseDelayInSeconds;
        [TagReference("effe")]
        public TagReference delayEffect;
        public StringID delayEffectMarkerName;
        //FIELD_EXPLAINATION("Constraint destruction", "- a response can destroy a single constraint by naming it explicitly.<lb>- alternatively it can randomly destroy a single constraint from a specified group if the "destroy one group constraint" flag is set<lb>- also it can destroy all constraints in a specified group if the "destroy all group constraints" flag is set<lb>"),
        public StringID constraintGroupName;
        //FIELD_EXPLAINATION("seat ejaculation", ""),
        public StringID ejectingSeatLabel;
        //FIELD_EXPLAINATION("skip fraction", "0.0 always fires, 1.0 never fires"),
        public float skipFraction;
        //FIELD_EXPLAINATION("destroyed child object marker name", "when this response fires, any children objects created at the supplied marker name will be destroyed"),
        public StringID destroyedChildObjectMarkerName;
        //FIELD_EXPLAINATION("total damage threshold", "scale on total damage section vitality"),
        public float totalDamageThreshold;
        public InstantaneousDamageRepsonseBlock()
        {
        }
        public InstantaneousDamageRepsonseBlock(BinaryReader binaryReader)
        {
            this.responseType = (ResponseType)binaryReader.ReadInt16();
            this.constraintDamageType = (ConstraintDamageType)binaryReader.ReadInt16();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.damageThresholdRepsonseFiresAfterCrossingThisThreshold1FullHealth = binaryReader.ReadSingle();
            this.transitionEffect = binaryReader.ReadTagReference();
            this.damageEffect = new InstantaneousResponseDamageEffectStruct(binaryReader);
            this.region = binaryReader.ReadStringID();
            this.newState = (NewState)binaryReader.ReadInt16();
            this.runtimeRegionIndex = binaryReader.ReadInt16();
            this.effectMarkerName = binaryReader.ReadStringID();
            this.damageEffectMarker = new InstantaneousResponseDamageEffectMarkerStruct(binaryReader);
            this.responseDelayInSeconds = binaryReader.ReadSingle();
            this.delayEffect = binaryReader.ReadTagReference();
            this.delayEffectMarkerName = binaryReader.ReadStringID();
            this.constraintGroupName = binaryReader.ReadStringID();
            this.ejectingSeatLabel = binaryReader.ReadStringID();
            this.skipFraction = binaryReader.ReadSingle();
            this.destroyedChildObjectMarkerName = binaryReader.ReadStringID();
            this.totalDamageThreshold = binaryReader.ReadSingle();
        }
        public enum ResponseType : short
        {
            ReceivesAllDamage = 0,
            ReceivesAreaEffectDamage = 1,
            ReceivesLocalDamage = 2,
        }
        public enum ConstraintDamageType : short
        {
            None = 0,
            DestroyOneOfGroup = 1,
            DestroyEntireGroup = 2,
            LoosenOneOfGroup = 3,
            LoosenEntireGroup = 4,
        }
        [Flags]
        public enum Flags : int
        {
            KillsObject = 1,
            InhibitsMeleeAttack = 2,
            InhibitsWeaponAttack = 4,
            InhibitsWalking = 8,
            ForcesDropWeapon = 16,
            KillsWeaponPrimaryTrigger = 32,
            KillsWeaponSecondaryTrigger = 64,
            DestroysObject = 128,
            DamagesWeaponPrimaryTrigger = 256,
            DamagesWeaponSecondaryTrigger = 512,
            LightDamageLeftTurn = 1024,
            MajorDamageLeftTurn = 2048,
            LightDamageRightTurn = 4096,
            MajorDamageRightTurn = 8192,
            LightDamageEngine = 16384,
            MajorDamageEngine = 32768,
            KillsObjectNoPlayerSolo = 65536,
            CausesDetonation = 131072,
            DestroyAllGroupConstraints = 262144,
            KillsVariantObjects = 524288,
            ForceUnattachedEffects = 1048576,
            FiresUnderThreshold = 2097152,
            TriggersSpecialDeath = 4194304,
            OnlyOnSpecialDeath = 8388608,
            OnlyNOTOnSpecialDeath = 16777216,
        }
        public enum NewState : short
        {
            Default = 0,
            MinorDamage = 1,
            MediumDamage = 2,
            MajorDamage = 3,
            Destroyed = 4,
        }
    }

    [StructLayout(LayoutKind.Sequential, Size = 56, Pack = 0)]
    public partial class GlobalDamageSectionBlock
    {
        public StringID name;
        //FIELD_EXPLAINATION("damage section flags", "* absorbs body damage: damage to this section does not count against body vitality<lb>* headshottable: takes extra headshot damage when shot<lb>* ignores shields: damage to this section bypasses shields"),
        public Flags flags;
        public float vitalityPercentage01PercentageOfTotalObjectVitality;
        [TagBlockField]
        public InstantaneousDamageRepsonseBlock[] instantResponses;
        [TagBlockField]
        public GNullBlock[] gNullBlock;
        [TagBlockField]
        public GNullBlock[] gNullBlock0;
        public float stunTimeSeconds;
        public float rechargeTimeSeconds;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding;
        #endregion
        public StringID resurrectionRestoredRegionName;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding0;
        #endregion
        public GlobalDamageSectionBlock()
        {
        }
        public GlobalDamageSectionBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.flags = (Flags)binaryReader.ReadInt32();
            this.vitalityPercentage01PercentageOfTotalObjectVitality = binaryReader.ReadSingle();
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(InstantaneousDamageRepsonseBlock));
                this.instantResponses = new InstantaneousDamageRepsonseBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.instantResponses[i] = new InstantaneousDamageRepsonseBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(GNullBlock));
                this.gNullBlock = new GNullBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.gNullBlock[i] = new GNullBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(GNullBlock));
                this.gNullBlock0 = new GNullBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.gNullBlock0[i] = new GNullBlock(binaryReader);
                    }
                }
            }
            this.stunTimeSeconds = binaryReader.ReadSingle();
            this.rechargeTimeSeconds = binaryReader.ReadSingle();
            this.padding = binaryReader.ReadBytes(4);
            this.resurrectionRestoredRegionName = binaryReader.ReadStringID();
            this.padding0 = binaryReader.ReadBytes(4);
        }
        [Flags]
        public enum Flags : int
        {
            AbsorbsBodyDamage = 1,
            TakesFullDmgWhenObjectDies = 2,
            CannotDieWithRiders = 4,
            TakesFullDmgWhenObjDstryd = 8,
            RestoredOnRessurection = 16,
            Unused = 32,
            Unused0 = 64,
            Heatshottable = 128,
            IgnoresShields = 256,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 0)]
    public partial class GlobalDamageNodesBlock
    {
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding0;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
        private byte[] padding1;
        #endregion
        public GlobalDamageNodesBlock()
        {
        }
        public GlobalDamageNodesBlock(BinaryReader binaryReader)
        {
            this.padding = binaryReader.ReadBytes(2);
            this.padding0 = binaryReader.ReadBytes(2);
            this.padding1 = binaryReader.ReadBytes(12);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 0)]
    public partial class DamageSeatInfoBlock
    {
        public StringID seatLabel;
        public float directDamageScale0NoDamage1FullDamage;
        public float damageTransferFallOffRadius;
        public float maximumTransferDamageScale;
        public float minimumTransferDamageScale;
        public DamageSeatInfoBlock()
        {
        }
        public DamageSeatInfoBlock(BinaryReader binaryReader)
        {
            this.seatLabel = binaryReader.ReadStringID();
            this.directDamageScale0NoDamage1FullDamage = binaryReader.ReadSingle();
            this.damageTransferFallOffRadius = binaryReader.ReadSingle();
            this.maximumTransferDamageScale = binaryReader.ReadSingle();
            this.minimumTransferDamageScale = binaryReader.ReadSingle();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 0)]
    public partial class DamageConstraintInfoBlock
    {
        public StringID physicsModelConstraintName;
        public StringID damageConstraintName;
        public StringID damageConstraintGroupName;
        public float groupProbabilityScale;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding;
        #endregion
        public DamageConstraintInfoBlock()
        {
        }
        public DamageConstraintInfoBlock(BinaryReader binaryReader)
        {
            this.physicsModelConstraintName = binaryReader.ReadStringID();
            this.damageConstraintName = binaryReader.ReadStringID();
            this.damageConstraintGroupName = binaryReader.ReadStringID();
            this.groupProbabilityScale = binaryReader.ReadSingle();
            this.padding = binaryReader.ReadBytes(4);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 248, Pack = 0)]
    public partial class GlobalDamageInfoBlock
    {
        public Flags flags;
        public StringID globalIndirectMaterialNameAbsorbesAOEOrChildDamage;
        public ShortBlockIndex2 indirectDamageSectionAbsorbesAOEOrChildDamage;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding0;
        #endregion
        public CollisionDamageReportingType collisionDamageReportingType;
        public ResponseDamageReportingType responseDamageReportingType;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding1;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        private byte[] padding2;
        #endregion
        //FIELD_EXPLAINATION("body", ""),
        public float maximumVitality;
        public float minimumStunDamageTheMinimumDamageRequiredToStunThisObjectsHealth;
        public float stunTimeSecondsTheLengthOfTimeTheHealthStayStunnedDoNotRechargeAfterTakingDamage;
        public float rechargeTimeSecondsTheLengthOfTimeItWouldTakeForTheShieldsToFullyRechargeAfterBeingCompletelyDepleted;
        public float rechargeFraction0DefaultsTo1ToWhatMaximumLevelTheBodyHealthWillBeAllowedToRecharge;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
        private byte[] padding3;
        #endregion
        //FIELD_EXPLAINATION("shield", ""),
        [TagReference("shad")]
        public TagReference shieldDamagedFirstPersonShader;
        [TagReference("shad")]
        public TagReference shieldDamagedShader;
        public float maximumShieldVitalityTheDefaultInitialAndMaximumShieldVitalityOfThisObject;
        public StringID globalShieldMaterialName;
        public float minimumStunDamageTheMinimumDamageRequiredToStunThisObjectsShields;
        public float stunTimeSecondsTheLengthOfTimeTheShieldsStayStunnedDoNotRechargeAfterTakingDamage;
        public float rechargeTimeSecondsTheLengthOfTimeItWouldTakeForTheShieldsToFullyRechargeAfterBeingCompletelyDepleted0;
        public float shieldDamagedThreshold;
        [TagReference("effe")]
        public TagReference shieldDamagedEffect;
        [TagReference("effe")]
        public TagReference shieldDepletedEffect;
        [TagReference("effe")]
        public TagReference shieldRechargingEffect;
        [TagBlockField]
        public GlobalDamageSectionBlock[] damageSections;
        [TagBlockField]
        public GlobalDamageNodesBlock[] nodes;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding4;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding5;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding6;
        #endregion
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        private byte[] padding7;
        #endregion
        [TagBlockField]
        public DamageSeatInfoBlock[] damageSeats;
        [TagBlockField]
        public DamageConstraintInfoBlock[] damageConstraints;
        //FIELD_EXPLAINATION("overshield", ""),
        [TagReference("shad")]
        public TagReference overshieldFirstPersonShader;
        [TagReference("shad")]
        public TagReference overshieldShader;
        public GlobalDamageInfoBlock()
        {
        }
        public GlobalDamageInfoBlock(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.globalIndirectMaterialNameAbsorbesAOEOrChildDamage = binaryReader.ReadStringID();
            this.indirectDamageSectionAbsorbesAOEOrChildDamage = binaryReader.ReadShortBlockIndex2();
            this.padding = binaryReader.ReadBytes(2);
            this.padding0 = binaryReader.ReadBytes(4);
            this.collisionDamageReportingType = (CollisionDamageReportingType)binaryReader.ReadByte();
            this.responseDamageReportingType = (ResponseDamageReportingType)binaryReader.ReadByte();
            this.padding1 = binaryReader.ReadBytes(2);
            this.padding2 = binaryReader.ReadBytes(20);
            this.maximumVitality = binaryReader.ReadSingle();
            this.minimumStunDamageTheMinimumDamageRequiredToStunThisObjectsHealth = binaryReader.ReadSingle();
            this.stunTimeSecondsTheLengthOfTimeTheHealthStayStunnedDoNotRechargeAfterTakingDamage = binaryReader.ReadSingle();
            this.rechargeTimeSecondsTheLengthOfTimeItWouldTakeForTheShieldsToFullyRechargeAfterBeingCompletelyDepleted = binaryReader.ReadSingle();
            this.rechargeFraction0DefaultsTo1ToWhatMaximumLevelTheBodyHealthWillBeAllowedToRecharge = binaryReader.ReadSingle();
            this.padding3 = binaryReader.ReadBytes(64);
            this.shieldDamagedFirstPersonShader = binaryReader.ReadTagReference();
            this.shieldDamagedShader = binaryReader.ReadTagReference();
            this.maximumShieldVitalityTheDefaultInitialAndMaximumShieldVitalityOfThisObject = binaryReader.ReadSingle();
            this.globalShieldMaterialName = binaryReader.ReadStringID();
            this.minimumStunDamageTheMinimumDamageRequiredToStunThisObjectsShields = binaryReader.ReadSingle();
            this.stunTimeSecondsTheLengthOfTimeTheShieldsStayStunnedDoNotRechargeAfterTakingDamage = binaryReader.ReadSingle();
            this.rechargeTimeSecondsTheLengthOfTimeItWouldTakeForTheShieldsToFullyRechargeAfterBeingCompletelyDepleted0 = binaryReader.ReadSingle();
            this.shieldDamagedThreshold = binaryReader.ReadSingle();
            this.shieldDamagedEffect = binaryReader.ReadTagReference();
            this.shieldDepletedEffect = binaryReader.ReadTagReference();
            this.shieldRechargingEffect = binaryReader.ReadTagReference();
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(GlobalDamageSectionBlock));
                this.damageSections = new GlobalDamageSectionBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.damageSections[i] = new GlobalDamageSectionBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(GlobalDamageNodesBlock));
                this.nodes = new GlobalDamageNodesBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.nodes[i] = new GlobalDamageNodesBlock(binaryReader);
                    }
                }
            }
            this.padding4 = binaryReader.ReadBytes(2);
            this.padding5 = binaryReader.ReadBytes(2);
            this.padding6 = binaryReader.ReadBytes(4);
            this.padding7 = binaryReader.ReadBytes(4);
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(DamageSeatInfoBlock));
                this.damageSeats = new DamageSeatInfoBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.damageSeats[i] = new DamageSeatInfoBlock(binaryReader);
                    }
                }
            }
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(DamageConstraintInfoBlock));
                this.damageConstraints = new DamageConstraintInfoBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.damageConstraints[i] = new DamageConstraintInfoBlock(binaryReader);
                    }
                }
            }
            this.overshieldFirstPersonShader = binaryReader.ReadTagReference();
            this.overshieldShader = binaryReader.ReadTagReference();
        }
        [Flags]
        public enum Flags : int
        {
            TakesShieldDamageForChildren = 1,
            TakesBodyDamageForChildren = 2,
            AlwaysShieldsFriendlyDamage = 4,
            PassesAreaDamageToChildren = 8,
            ParentNeverTakesBodyDamageForUs = 16,
            OnlyDamagedByExplosives = 32,
            ParentNeverTakesShieldDamageForUs = 64,
            CannotDieFromDamage = 128,
            PassesAttachedDamageToRiders = 256,
        }
        public enum CollisionDamageReportingType : byte
        {
            TehGuardians11 = 0,
            FallingDamage = 1,
            GenericCollisionDamage = 2,
            GenericMeleeDamage = 3,
            GenericExplosion = 4,
            MagnumPistol = 5,
            PlasmaPistol = 6,
            Needler = 7,
            Smg = 8,
            PlasmaRifle = 9,
            BattleRifle = 10,
            Carbine = 11,
            Shotgun = 12,
            SniperRifle = 13,
            BeamRifle = 14,
            RocketLauncher = 15,
            FlakCannon = 16,
            BruteShot = 17,
            Disintegrator = 18,
            BrutePlasmaRifle = 19,
            EnergySword = 20,
            FragGrenade = 21,
            PlasmaGrenade = 22,
            FlagMeleeDamage = 23,
            BombMeleeDamage = 24,
            BombExplosionDamage = 25,
            BallMeleeDamage = 26,
            HumanTurret = 27,
            PlasmaTurret = 28,
            Banshee = 29,
            Ghost = 30,
            Mongoose = 31,
            Scorpion = 32,
            SpectreDriver = 33,
            SpectreGunner = 34,
            WarthogDriver = 35,
            WarthogGunner = 36,
            Wraith = 37,
            Tank = 38,
            SentinelBeam = 39,
            SentinelRpg = 40,
            Teleporter = 41,
        }
        public enum ResponseDamageReportingType : byte
        {
            TehGuardians11 = 0,
            FallingDamage = 1,
            GenericCollisionDamage = 2,
            GenericMeleeDamage = 3,
            GenericExplosion = 4,
            MagnumPistol = 5,
            PlasmaPistol = 6,
            Needler = 7,
            Smg = 8,
            PlasmaRifle = 9,
            BattleRifle = 10,
            Carbine = 11,
            Shotgun = 12,
            SniperRifle = 13,
            BeamRifle = 14,
            RocketLauncher = 15,
            FlakCannon = 16,
            BruteShot = 17,
            Disintegrator = 18,
            BrutePlasmaRifle = 19,
            EnergySword = 20,
            FragGrenade = 21,
            PlasmaGrenade = 22,
            FlagMeleeDamage = 23,
            BombMeleeDamage = 24,
            BombExplosionDamage = 25,
            BallMeleeDamage = 26,
            HumanTurret = 27,
            PlasmaTurret = 28,
            Banshee = 29,
            Ghost = 30,
            Mongoose = 31,
            Scorpion = 32,
            SpectreDriver = 33,
            SpectreGunner = 34,
            WarthogDriver = 35,
            WarthogGunner = 36,
            Wraith = 37,
            Tank = 38,
            SentinelBeam = 39,
            SentinelRpg = 40,
            Teleporter = 41,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 0)]
    public partial class ModelTargetLockOnDataStruct
    {
        //FIELD_EXPLAINATION("lock-on fields", ""),
        public Flags flags;
        public float lockOnDistance;
        public ModelTargetLockOnDataStruct()
        {
        }
        public ModelTargetLockOnDataStruct(BinaryReader binaryReader)
        {
            this.flags = (Flags)binaryReader.ReadInt32();
            this.lockOnDistance = binaryReader.ReadSingle();
        }
        [Flags]
        public enum Flags : int
        {
            LockedByHumanTracking = 1,
            LockedByPlasmaTracking = 2,
            Headshot = 4,
            Vulnerable = 8,
            AlwasLockedByPlasmaTracking = 16,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 28, Pack = 0)]
    public partial class ModelTargetBlock
    {
        public StringID markerNameMultipleMarkersBecomeMultipleSpheresOfTheSameRadius;
        public float sizeSphereRadius;
        public float coneAngleTheTargetIsOnlyVisibleWhenViewedWithinThisAngleOfTheMarkersXAxis;
        public ShortBlockIndex2 damageSectionTheTargetIsAssociatedWithThisDamageSection;
        public ShortBlockIndex1 variantTheTargetWillOnlyAppearWithThisVariant;
        public float targetingRelevanceHigherRelevancesTurnIntoStrongerMagnetisms;
        [TagStructField]
        public ModelTargetLockOnDataStruct lockOnData;
        public ModelTargetBlock()
        {
        }
        public ModelTargetBlock(BinaryReader binaryReader)
        {
            this.markerNameMultipleMarkersBecomeMultipleSpheresOfTheSameRadius = binaryReader.ReadStringID();
            this.sizeSphereRadius = binaryReader.ReadSingle();
            this.coneAngleTheTargetIsOnlyVisibleWhenViewedWithinThisAngleOfTheMarkersXAxis = binaryReader.ReadSingle();
            this.damageSectionTheTargetIsAssociatedWithThisDamageSection = binaryReader.ReadShortBlockIndex2();
            this.variantTheTargetWillOnlyAppearWithThisVariant = binaryReader.ReadShortBlockIndex1();
            this.targetingRelevanceHigherRelevancesTurnIntoStrongerMagnetisms = binaryReader.ReadSingle();
            this.lockOnData = new ModelTargetLockOnDataStruct(binaryReader);
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 8, Pack = 0)]
    public partial class ModelPermutationBlock
    {
        public StringID name;
        public Flags flags;
        public byte collisionPermutationIndex;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        public ModelPermutationBlock()
        {
        }
        public ModelPermutationBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.flags = (Flags)binaryReader.ReadByte();
            this.collisionPermutationIndex = binaryReader.ReadByte();
            this.padding = binaryReader.ReadBytes(2);
        }
        [Flags]
        public enum Flags : byte
        {
            CannotBeChosenRandomly = 1,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 16, Pack = 0)]
    public partial class ModelRegionBlock
    {
        public StringID name;
        public byte collisionRegionIndex;
        public byte physicsRegionIndex;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        [TagBlockField]
        public ModelPermutationBlock[] permutations;
        public ModelRegionBlock()
        {
        }
        public ModelRegionBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.collisionRegionIndex = binaryReader.ReadByte();
            this.physicsRegionIndex = binaryReader.ReadByte();
            this.padding = binaryReader.ReadBytes(2);
            {
                var count = binaryReader.ReadInt32();
                var address = binaryReader.ReadInt32();
                var elementSize = Marshal.SizeOf(typeof(ModelPermutationBlock));
                this.permutations = new ModelPermutationBlock[count];
                using (binaryReader.BaseStream.Pin())
                {
                    for (int i = 0; i < count; ++i)
                    {
                        binaryReader.BaseStream.Position = address + i * elementSize;
                        this.permutations[i] = new ModelPermutationBlock(binaryReader);
                    }
                }
            }
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 92, Pack = 0)]
    public partial class ModelNodeBlock
    {
        public StringID name;
        public ShortBlockIndex1 parentNode;
        public ShortBlockIndex1 firstChildNode;
        public ShortBlockIndex1 nextSiblingNode;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        public Vector3 defaultTranslation;
        public Vector4 defaultRotation;
        public float defaultInverseScale;
        public Vector3 defaultInverseForward;
        public Vector3 defaultInverseLeft;
        public Vector3 defaultInverseUp;
        public Vector3 defaultInversePosition;
        public ModelNodeBlock()
        {
        }
        public ModelNodeBlock(BinaryReader binaryReader)
        {
            this.name = binaryReader.ReadStringID();
            this.parentNode = binaryReader.ReadShortBlockIndex1();
            this.firstChildNode = binaryReader.ReadShortBlockIndex1();
            this.nextSiblingNode = binaryReader.ReadShortBlockIndex1();
            this.padding = binaryReader.ReadBytes(2);
            this.defaultTranslation = binaryReader.ReadVector3();
            this.defaultRotation = binaryReader.ReadVector4();
            this.defaultInverseScale = binaryReader.ReadSingle();
            this.defaultInverseForward = binaryReader.ReadVector3();
            this.defaultInverseLeft = binaryReader.ReadVector3();
            this.defaultInverseUp = binaryReader.ReadVector3();
            this.defaultInversePosition = binaryReader.ReadVector3();
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 20, Pack = 0)]
    public partial class ModelObjectDataBlock
    {
        public Type type;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        private byte[] padding;
        #endregion
        public Vector3 offset;
        public float radius;
        public ModelObjectDataBlock()
        {
        }
        public ModelObjectDataBlock(BinaryReader binaryReader)
        {
            this.type = (Type)binaryReader.ReadInt16();
            this.padding = binaryReader.ReadBytes(2);
            this.offset = binaryReader.ReadVector3();
            this.radius = binaryReader.ReadSingle();
        }
        public enum Type : short
        {
            NotSet = 0,
            UserDefined = 1,
            AutoGenerated = 2,
        }
    }


    [StructLayout(LayoutKind.Sequential, Size = 48, Pack = 0)]
    public partial class GlobalScenarioLoadParametersBlock
    {
        //FIELD_EXPLAINATION("SCENARIO LOAD PARAMETERS", "strip-variant <variant-name><lb>strips a given variant out of the model tag<lb>strip-dialogue<lb>strips all the dialogue for this model i.e. cinematic only"),
        [TagReference("scnr")]
        public TagReference scenario;
        #region padding
        [TagField, MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        private byte[] padding;
        #endregion
        public GlobalScenarioLoadParametersBlock()
        {
        }
        public GlobalScenarioLoadParametersBlock(BinaryReader binaryReader)
        {
            this.scenario = binaryReader.ReadTagReference();
            this.padding = binaryReader.ReadBytes(32);
        }
    }
}
