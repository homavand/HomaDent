using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
 

namespace Dentistry.UserControls
{
    public partial class ToothLabel : UserControl
    {
        public ToothLabel(ToothInfoClass toothInfo)
        {
            InitializeComponent();

            this.Tag = toothInfo;
            DrawTooth(toothInfo);
        }

        private void DrawTooth(ToothInfoClass toothInfo)
        {
            switch (toothInfo.ToothRegion)
            {
                case "TL":
                    {
                        this.ToothInfoBorder.BorderTopWidth = 0;
                        this.ToothInfoBorder.BorderBottomWidth = 5;
                        this.ToothInfoBorder.BorderLeftWidth = 5;
                        this.ToothInfoBorder.BorderRightWidth = 0;
                        this.ToothLbl.Text = toothInfo.ToothName;
                        break;
                    }
                case "TR":
                    {
                        this.ToothInfoBorder.BorderTopWidth = 0;
                        this.ToothInfoBorder.BorderBottomWidth = 5;
                        this.ToothInfoBorder.BorderLeftWidth = 0;
                        this.ToothInfoBorder.BorderRightWidth = 5;
                        this.ToothLbl.Text = toothInfo.ToothName;
                        break;
                    }
                case "BL":
                    {
                        this.ToothInfoBorder.BorderTopWidth = 5;
                        this.ToothInfoBorder.BorderBottomWidth = 0;
                        this.ToothInfoBorder.BorderLeftWidth = 5;
                        this.ToothInfoBorder.BorderRightWidth = 0;
                        this.ToothLbl.Text = toothInfo.ToothName;
                        break;
                    }
                case "BR":
                    {
                        this.ToothInfoBorder.BorderTopWidth = 5;
                        this.ToothInfoBorder.BorderBottomWidth = 0;
                        this.ToothInfoBorder.BorderLeftWidth = 0;
                        this.ToothInfoBorder.BorderRightWidth = 5;
                        this.ToothLbl.Text = toothInfo.ToothName;
                        break;
                    }
                default:
                    {
                        this.ToothInfoBorder.BorderTopWidth = 0;
                        this.ToothInfoBorder.BorderBottomWidth = 0;
                        this.ToothInfoBorder.BorderLeftWidth = 0;
                        this.ToothInfoBorder.BorderRightWidth = 0;
                        break;
                    }
            }
           
        }

        private void ToothInfoBorder_Load(object sender, EventArgs e)
        {

        }

        private void ToothInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
