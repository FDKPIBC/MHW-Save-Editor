using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using MHW_Save_Editor.SaveSlot;

namespace MHW_Save_Editor.SlotEditing
{
    public enum GenderEnum {
        Male = 0, 
        Female = 1
    }
    
    public class CharacterSlotViewModel
    {
        private CharacterSlot charslot;
        public CharacterSlotViewModel(CharacterSlot charslot)
        {
            this.charslot = charslot;
        }

        public string HunterName{ get => charslot.HunterName; set => charslot.HunterName = value; }
        public string PalicoName { get => charslot.PalicoName; set => charslot.PalicoName = value; }
        public UInt32 HunterRank { get => charslot.HunterRank; set => charslot.HunterRank = value; }
        public UInt32 Zenny  { get => charslot.Zenny; set => charslot.Zenny = value; }
        public UInt32 ResearchPoints { get => charslot.ResearchPoints; set => charslot.ResearchPoints = value; }
        public UInt32 HunterXP { get => charslot.HunterXP; set => charslot.HunterXP = value; }
        public UInt32 trapper { get => charslot.trapper; set => charslot.trapper = value; }
        public UInt32 protector { get => charslot.protector; set => charslot.protector = value; }
        public UInt32 trouper { get => charslot.trouper; set => charslot.trouper = value; }
        public UInt32 plunder { get => charslot.plunder; set => charslot.plunder = value; }
        public UInt32 gaja { get => charslot.gaja; set => charslot.gaja = value; }
        public GenderEnum Gender{ get => charslot.Gender==0?GenderEnum.Male:GenderEnum.Female; set => charslot.Gender = (UInt32) (value==GenderEnum.Male?0:1);}
        
        public Int32 seconds { 
                get => (Int32) (charslot.PlayTime) % 60; 
                set => charslot.PlayTime = charslot.PlayTime - (charslot.PlayTime % 60 - (UInt32) value);
        }
        public Int32 minutes
        {
            get => (Int32) (charslot.PlayTime / (60)) % 60; 
            set => charslot.PlayTime = charslot.PlayTime - (charslot.PlayTime / (60) % 60 - (UInt32) value)*60;
        }
        public Int32 hours
        {
            get => (Int32) (charslot.PlayTime / (60 * 60)); 
            set => charslot.PlayTime = charslot.PlayTime - (charslot.PlayTime / (60*60) - (UInt32) value)*60*60;
        }

        
        //public HunterAppearance HunterAppearance;
        //public PalicoAppearance PalicoAppearance;
        //public GuildCard GuildCard;
        //public List<GuildCard> SharedGC;
        //public List<ItemLoadout> ItemLoadouts;
        //public List<InventoryArea> ItemBox;
        //public List<Investigation> InvestigationList;
        //public List<EquipLoadout> EquipmentLoadouts;
        public List<CharacterSlot.DLC> DLCClaimed;

        public void Commit(byte[] savefile, int offset)
        {
            charslot.Serialize().CopyTo(savefile,offset);
            BitConverter.GetBytes(charslot.Gender).CopyTo(savefile, offset + 0xb0);
            charslot.serializePalico().CopyTo(savefile, offset + charslot.palicoOffset);
            charslot.serializeUnity().CopyTo(savefile, offset + charslot.unityOffset);
        }
    }
    
    public class EnumBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value.Equals(parameter);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((bool)value) ? parameter : Binding.DoNothing;
        }
    }
    
    public class UnityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if(value is uint)
            {
                uint unity = (uint) value;
                if(unity<0x64){return "1";}
                if(unity<0xFA){return "2";}
                if(unity<0x1C2){return "3";}
                if(unity<0x2BC){return "4";}

                return "5";
            }
            return "0";
        }

        public object ConvertBack(object value, Type targetType, object parameter,
            System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}