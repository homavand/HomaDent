using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Windows.Forms;

namespace Dentistry
{
    internal class SysInfo
{

    // Fields
    private string boardId;
    private string currDir = "";
    private StringBuilder FSName = new StringBuilder(0x100);
    private string macId = "";
    private uint maxCompLen;
    private uint serialNum;
    private string softId;
    private uint VolFlags;
    private StringBuilder VolLabel = new StringBuilder(0x100);


    // Methods
    public string GetBIOSId()
    {
        string str = string.Empty;
        ManagementClass class2 = new ManagementClass("Win32_BIOS");
        foreach (ManagementObject obj2 in class2.GetInstances())
        {
            if (str == string.Empty)
            {
                str = obj2.Properties["Version"].Value.ToString();
            }
        }
      
        return str.Trim(); 
    }

    public string GetCPUId()
    {
        ManagementObjectCollection mbsList = null;
        ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
        mbsList = mbs.Get();
        string id = string.Empty;
        foreach (ManagementObject mo in mbsList)
        {
            id = mo["ProcessorID"].ToString();
        }

        return id.Trim(); 
    }

    public string GetDiskId()
    {
        ManagementObject dsk = new ManagementObject(@"win32_logicaldisk.deviceid=""c:""");
        dsk.Get();
        string id = dsk["VolumeSerialNumber"].ToString();

       
        return id.Trim(); 
    }

    public string GetMACAddress()
    {
        ManagementObjectCollection instances = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances();
        string str = string.Empty;
        foreach (ManagementObject obj2 in instances)
        {
            if (str == string.Empty && Convert.ToBoolean(obj2["IPEnabled"]) == true )
            {
                str = obj2["MacAddress"].ToString();
            }
            obj2.Dispose();
        }
      
        return str.Trim(); 
    }

    public string GetMotherBoardId()
    {
        ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM Win32_BaseBoard");
        ManagementObjectCollection moc = mos.Get();
        string id = "";
        foreach (ManagementObject mo in moc)
        {
            id = (string)mo["SerialNumber"];
        }

      
        return id.Trim(); 
    }

    public string GetVolumeSerial(string strDriveLetter)
    {
        if (string.IsNullOrEmpty(strDriveLetter ))
        {
            strDriveLetter = "C";
        }
        ManagementObject obj2 = new ManagementObject("win32_logicaldisk.deviceid=\"" + strDriveLetter + ":\"");
        obj2.Get();
        string str = obj2["VolumeSerialNumber"].ToString();
        
        return str.Trim(); 
    }


    [System.Runtime.InteropServices.DllImport("kernel32.dll")]
    private static extern long GetVolumeInformation(string PathName, StringBuilder VolumeNameBuffer, uint VolumeNameSize, ref uint VolumeSerialNumber, ref uint MaximumComponentLength, ref uint FileSystemFlags, StringBuilder FileSystemNameBuffer, uint FileSystemNameSize);


    public string GetActivationId()
    {
        string activationStr = "";
        string s1, s2, s3, s4, s5;
        

        //this.boardId = GetMotherBoardId().ToString();
        //if (GetBIOSId() != string.Empty)
        //{
        //    s1 = Convert.ToString(GetBIOSId().Trim());
        //}
        //else
        //{
        //    Random ran = new Random();
        //    s1 = ran.Next(1000,9999).ToString();
        //}

        if (GetCPUId() != string.Empty)
        {
            s2 = Convert.ToString(GetCPUId().Trim());
        }
        else
        {
            Random ran = new Random();
            s2 = ran.Next(1000, 9999).ToString();
        }

        if (GetDiskId() != string.Empty)
        {
            s3 = Convert.ToString(GetDiskId().Trim());
        }
        else
        {
            Random ran = new Random();
            s3 = ran.Next(1000, 9999).ToString();
        }

        if (GetMACAddress() != string.Empty)
        {
            s4 = Convert.ToString(GetMACAddress().Trim());
        }
        else
        {
            Random ran = new Random();
            s4 = ran.Next(1000, 9999).ToString();
        }

        //if (GetMotherBoardId() != string.Empty)
        //{
        //    s5 = Convert.ToString(GetMotherBoardId().Trim());
        //}
        //else
        //{
        //    Random ran = new Random();
        //    s5 = ran.Next(1000, 9999).ToString();
        //}


        activationStr = s2 + s3 + s4 ;
        activationStr = activationStr.Substring(0, 16);
        activationStr = Convert.ToString(activationStr).ToUpper();

        return activationStr ;
    }

    public string GetActivationId2()
    {
        string activationStr = "";
        this.currDir = Application.ExecutablePath.Substring(0, 1).ToString() + @":\";
        GetVolumeInformation(this.currDir, this.VolLabel, (uint)this.VolLabel.Capacity, ref this.serialNum, ref this.maxCompLen, ref this.VolFlags, this.FSName, (uint)this.FSName.Capacity);
        //SysInfo info = new SysInfo();
        this.boardId = GetMotherBoardId().ToString();
        if (GetMACAddress() != string.Empty)
        {
            this.macId = GetMACAddress().ToString();
            this.softId = Convert.ToString(this.boardId.Trim()) + Convert.ToString(this.serialNum).Trim() + Convert.ToString(this.macId).Trim();
        }
        else
        {
            this.softId = this.boardId.Trim().ToString() + this.serialNum.ToString();
        }
        //this.softId = Convert.ToString(System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major) + this.softId;
        activationStr = Convert.ToString(this.softId).ToUpper();

        return activationStr;
    }
}

 

 

}
