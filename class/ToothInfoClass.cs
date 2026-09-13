using System;
using System.Collections.Generic;
using System.Text;

namespace Dentistry
{
    public class ToothInfoClass
    {
        private string toothModel;
        private string toothRegion;
        private string toothName;
        private int toothID;

        public ToothInfoClass()
        {

        }

        public string ToothModel
        {
            get { return toothModel; }
            set { toothModel = value; }
        }

        public string ToothRegion
        {
            get { return toothRegion; }
            set { toothRegion = value; }
        }

        public string ToothName
		{
            get { return toothName; }
            set { toothName = value; }
        }

        public int ToothId
        {
            get { return toothID; }
            set { toothID = value; }
        }



        public override bool Equals(object obj)
        {
            if (obj == null || this.GetType() != obj.GetType())
                return false;
            ToothInfoClass That = (ToothInfoClass)obj;
            return (this.ToothId == That.ToothId && this.ToothName == That.ToothName);
        }

		public static int ToothNameToToothId(string toothName)
		{
			var toothNum = 0;
			bool flag = Int32.TryParse(toothName, out toothNum);

			if (flag && toothNum > 0 && toothNum < 33 )
				return Convert.ToInt32(toothNum);

			switch (toothName)
			{
				default: return 0;				
				case "A": return 33;
				case "B": return 34;
				case "C": return 35;
				case "D": return 36;
				case "E": return 37;
				case "F": return 38;
				case "G": return 39;
				case "H": return 40;
				case "I": return 41;
				case "J": return 42;
				case "K": return 43;
				case "L": return 44;
				case "M": return 45;
				case "N": return 46;
				case "O": return 47;
				case "P": return 48;
				case "Q": return 49;
				case "R": return 50;
				case "S": return 51;
				case "T": return 52;
			}
		}

		public static string ToothIdToToothName(int toothId)
		{
			if (toothId > 0 && toothId < 33)
				return toothId.ToString();

			switch (toothId)
			{
				default: return "";
				case 33: return "A";
				case 34: return "B";
				case 35: return "C";
				case 36: return "D";
				case 37: return "E";
				case 38: return "F";
				case 39: return "G";
				case 40: return "H";
				case 41: return "I";
				case 42: return "J";
				case 43: return "K";
				case 44: return "L";
				case 45: return "M";
				case 46: return "N";
				case 47: return "O";
				case 48: return "P";
				case 49: return "Q";
				case 50: return "R";
				case 51: return "S";
				case 52: return "T";
			}
		}
	}
}
