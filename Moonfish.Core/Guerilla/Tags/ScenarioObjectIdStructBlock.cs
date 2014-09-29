using Moonfish.Model;
using Moonfish.Tags.BlamExtension;
using Moonfish.Tags;
using OpenTK;
using System;
using System.IO;

namespace Moonfish.Guerilla.Tags
{
    class ScenarioObjectIdstructBlock
    {
        int uniqueID;
        Moonfish.Tags.ShortBlockIndex1 originBSPIndex;
        Type type;
        Source source;
        internal  ScenarioObjectIdstructBlock(BinaryReader binaryReader)
        {
            this.uniqueID = binaryReader.ReadInt32();
            this.originBSPIndex = binaryReader.ReadShortBlockIndex1();
            this.type = (Type)binaryReader.ReadByte();
            this.source = (Source)binaryReader.ReadByte();
        }
        byte[] ReadData(BinaryReader binaryReader)
        {
            var blamPointer = binaryReader.ReadBlamPointer(1);
            var data = new byte[blamPointer.Count];
            if(blamPointer.Count > 0)
            {
                using (binaryReader.BaseStream.Pin())
                {
                    binaryReader.BaseStream.Position = blamPointer[0];
                    data = binaryReader.ReadBytes(blamPointer.Count);
                }
            }
            return data;
        }
        internal enum Type : byte
        {
            Biped = 0,
            Vehicle = 0,
            Weapon = 0,
            Equipment = 0,
            Garbage = 0,
            Projectile = 0,
            Scenery = 0,
            Machine = 0,
            Control = 0,
            LightFixture = 0,
            SoundScenery = 0,
            Crate = 0,
            Creature = 0,
        };
        internal enum Source : byte
        {
            Structure = 0,
            Editor = 0,
            Dynamic = 0,
            Legacy = 0,
        };
    };
}
