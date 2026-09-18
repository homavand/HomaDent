using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Web.Routing;
using System.Windows.Forms;

namespace Dentistry.Class
{

    class PatientService
    {     
        private static readonly Dictionary<string, Bitmap> _toothImageCache = new Dictionary<string, Bitmap>();

        public PatientService()
        {
        }


        public PatientService(dynamic obj)
        {
            
            this.Id = Convert.ToInt32(obj.PatientServiceId);
            this.PatientId = Convert.ToInt32(obj.PatientId);
            this.PatientName = obj.PatientName;
            this.DoctorId = Convert.ToInt32(obj.DoctorId);
            this.DoctorTitle = obj.DoctorTitle;
            this.BasicInsurerId = Convert.ToInt32(obj.BasicInsurerId);
            this.BasicInsurerTitle = obj.BasicInsurerTitle;
            this.ServiceGroupId = Convert.ToInt32(obj.ServiceGroupId);
            this.ServiceGroupTitle = obj.ServiceGroupTitle;
            this.ServiceId = Convert.ToInt32(obj.ServiceId);
            this.ServiceTitle = obj.ServiceTitle;

            this.IsHadMoreTooth = Convert.ToBoolean(obj.IsHadMoreTooth);
            this.Date = Convert.ToDateTime(obj.Date);
            this.SolarDate = obj.SolarDate;
            this.SolarDateTime = obj.SolarDateTime;
            this.Comment = obj.Comment;
            this.CheckupTypeCode = obj.CheckupTypeCode;
            this.ProviderStaffId = Convert.ToInt32(obj.ProviderDoctorId);
            this.ProviderStaffTitle = obj.ProviderDoctorTitle;

            this.ActionPrice = Convert.ToDecimal(obj.ActionPrice);
            this.ServicePrice = Convert.ToDecimal(obj.ServicePrice);
            this.InsurerPrice = Convert.ToDecimal(obj.InsurerPrice);
            this.InsurerShare = Convert.ToDecimal(obj.InsurerShare);
            this.FranchiseShare = Convert.ToDecimal(obj.FranchiseShare);
            this.FreeShare = Convert.ToDecimal(obj.FreeShare);
            this.ToothIds = obj.ToothIds;
            this.ToothCount = Convert.ToInt32(obj.ToothCount);
            this.Tooths = obj.Tooths;
        }
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }
        public string DoctorTitle { get; set; }
        public int BasicInsurerId { get; set; }
        public string BasicInsurerTitle { get; set; }
        public int ServiceGroupId { get; set; }
        public string ServiceGroupTitle { get; set; }
        public int ServiceId { get; set; }
        public string ServiceTitle { get; set; }
        public int ServiceCount { get; set; }

        public bool IsHadMoreTooth { get; set; }
        public DateTime Date { get; set; }
        public string SolarDate { get; set; }
        public string SolarDateTime { get; set; }

        public string Comment { get; set; }


        public int CheckupTypeId { get; set; }
        public string CheckupTypeCode { get; set; }
        public int ProviderStaffId { get; set; }
        public string ProviderStaffTitle { get; set; }
        public int ProviderStaffPercent { get; set; }
        public int ToothCount { get; set; }
        public decimal ServicePrice { get; set; }
        public decimal InsurerPrice { get; set; }
        public decimal ActionPrice { get; set; }


        public decimal InsurerShare { get; set; }
        public decimal FranchiseShare { get; set; }
        public decimal FreeShare { get; set; }

        public decimal PatientShare
        {
            get
            {
                return this.FranchiseShare + FreeShare;
            }
        }



        public string ToothIds { get; set; }
        public IEnumerable<dynamic> Tooths { get; set; }

        public List<int> ToothIdList
        {
            get
            {
                if (this.Tooths == null)
                    return null;
                return this.ToothIds.Trim().Split(',').Select(i => Convert.ToInt32(i.Trim())).ToList();

            }
        }

        public string ToothId
        {
            get
            {
                if (this.Tooths == null)
                    return "";
                return string.Join("  -  ", this.Tooths.Select(i => string.Format("{0}", i.ToothId)).ToList());

            }
        }
        public string ToothName
        {
            get
            {
                if (this.Tooths == null)
                    return "";
                return string.Join("  -  ", this.Tooths.Select(i => i.ToothName != null ? string.Format("({0})", i.ToothName) : "").ToList());

            }
        }

        public string ToothTitle
        {
            get
            {
                if (this.Tooths == null)
                    return "";
                return string.Join("  -  ", this.Tooths.Select(i => string.Format("({0})", i.ToothTitle)).ToList());

            }
        }

        public string Tooth
        {
            get
            {
                if (this.Tooths == null)
                    return "";
                return string.Join("  -  ", this.Tooths.Select(i => i.ToothName != null ? string.Format("({0}){1}", i.ToothName, i.ToothTitle) : "").ToList());

            }
        }

        public System.Drawing.Bitmap ToothImage
        {
            get
            {
                if (this.Tooths == null)
                    return null;

                // Cache key: which teeth (and in what combination) this
                // row shows. Empty/null ToothIds -> nothing to cache/draw.
                var cacheKey = this.ToothIds;
                if (string.IsNullOrEmpty(cacheKey))
                    return null;

                if (_toothImageCache.TryGetValue(cacheKey, out var cachedImage))
                    return cachedImage;

                Bitmap computed = ComputeToothImage();

                // Cache even a null result so we don't keep retrying a
                // combination that fails to decode.
                _toothImageCache[cacheKey] = computed;
                return computed;
            }
        }

        private Bitmap ComputeToothImage()
        {
            var imgCount = this.Tooths.Count();
            if (imgCount == 1)
            {
                var item = this.Tooths.ElementAt(0);

                if (item == null || item.ToothImage == null)
                    return null;

                byte[] imgByte = item.ToothImage;

                System.IO.MemoryStream tempstream = new System.IO.MemoryStream(imgByte);
                Image img = Image.FromStream(tempstream);
                Bitmap im = new Bitmap(img, 35, 30);

                return im;

            }
            else if (this.ToothCount > 0 && this.ToothCount < 4)
            {
                Image[] imgages = new Image[this.ToothCount];
                for (int i = 0; i < imgCount; i++)
                {
                    dynamic item = this.Tooths.ElementAt(i);
                    if (item == null && item.ToothImage == null)
                        continue;

                    byte[] imgByte = item.ToothImage;
                    System.IO.MemoryStream tempstream = new System.IO.MemoryStream(imgByte);
                    imgages[i] = Image.FromStream(tempstream);
                }

                return Publics.MergeImage(imgages);
            }

            return null;
        }
    }

    class PatientService2
    {
        public PatientService2()
        {
        }

        public PatientService2(dynamic obj)
        {
            var x = new RouteValueDictionary(obj);
            
          
            if (x.HasValue("PatientServiceId"))
                this.Id = x.GetValue<int>("PatientServiceId");
            if (x.HasValue("PatientId"))
                this.PatientId = x.GetValue<int>("PatientId");

            
            if (x.HasValue("PatientName"))
                this.PatientName = x.GetValue<string>("PatientName");
            if (x.HasValue("DoctorId"))
                this.DoctorId = x.GetValue<int>("DoctorId");
            if (x.HasValue("DoctorTitle"))
                this.DoctorTitle = x.GetValue<string>("DoctorTitle");
            if (x.HasValue("BasicInsurerId"))
                this.BasicInsurerId = x.GetValue<int>("BasicInsurerId");            
            if (x.HasValue("BasicInsurerTitle"))
                this.BasicInsurerTitle = x.GetValue<string>("BasicInsurerTitle");
            if (x.HasValue("ServiceGroupId"))
                this.ServiceGroupId = x.GetValue<int>("ServiceGroupId");
            if (x.HasValue("ServiceGroupTitle"))
                this.ServiceGroupTitle = x.GetValue<string>("ServiceGroupTitle");
            if (x.HasValue("ServiceId"))
                this.ServiceId = x.GetValue<int>("ServiceId");
            if (x.HasValue("ServiceTitle"))
                this.ServiceTitle = x.GetValue<string>("ServiceTitle");
            if (x.HasValue("ServiceCount"))
                this.ServiceCount = x.GetValue<int>("ServiceCount");
            
            if (x.HasValue("IsHadMoreTooth"))
                this.IsHadMoreTooth = x.GetValue<bool>("IsHadMoreTooth");
            if (x.HasValue("Date"))
                this.Date = x.GetValue<DateTime>("Date");
            if (x.HasValue("SolarDate"))
                this.SolarDate = x.GetValue<string>("SolarDate");
            if (x.HasValue("SolarDateTime"))
                this.SolarDateTime = x.GetValue<string>("SolarDateTime");
            if (x.HasValue("Comment"))
                this.Comment = x.GetValue<string>("Comment");
            if (x.HasValue("CheckupTypeId"))
                this.CheckupTypeId = x.GetValue<int>("CheckupTypeId");
            if (x.HasValue("CheckupTypeCode"))
                this.CheckupTypeCode = x.GetValue<string>("CheckupTypeCode");
            if (x.HasValue("ProviderStaffId"))
                this.ProviderStaffId = x.GetValue<int>("ProviderStaffId");
            if (x.HasValue("ProviderStaffTitle"))
                this.ProviderStaffTitle = x.GetValue<string>("ProviderStaffTitle");

            if (x.HasValue("ProviderStaffPercent"))
                this.ProviderStaffPercent = x.GetValue<int>("ProviderStaffPercent");

            if (x.HasValue("ToothCount"))
                this.ToothCount = x.GetValue<int>("ToothCount");

            if (x.HasValue("ActionPrice"))
                this.ActionPrice = x.GetValue<double>("ActionPrice");
            if (x.HasValue("ServicePrice"))
                this.ServicePrice = x.GetValue<double>("ServicePrice");
            if (x.HasValue("InsurerPrice"))
                this.InsurerPrice = x.GetValue<double>("InsurerPrice");
            if (x.HasValue("InsurerShare"))
                this.InsurerShare = x.GetValue<double>("InsurerShare");
            if (x.HasValue("FranchiseShare"))
                this.FranchiseShare = x.GetValue<double>("FranchiseShare");
            if (x.HasValue("FreeShare"))
                this.FreeShare = x.GetValue<double>("FreeShare");
            if (x.HasValue("ToothIds"))
                this.ToothIds = x.GetValue<string>("ToothIds");
            if (x.HasValue("Tooths"))
                this.Tooths = x.GetValue<IEnumerable<dynamic>>("Tooths");
        }
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int DoctorId { get; set; }        
        public string DoctorTitle { get; set; }
        public int BasicInsurerId { get; set; }
        public string BasicInsurerTitle { get; set; }
        public int ServiceGroupId { get; set; }
        public string ServiceGroupTitle { get; set; }
        public int ServiceId { get; set; }
        public string ServiceTitle { get; set; }
        public int ServiceCount { get; set; }
        
        public bool IsHadMoreTooth { get; set; }
        public DateTime Date { get; set; }
        public string SolarDate { get; set; }
        public string SolarDateTime { get; set; }
        
        public string Comment { get; set; }


        public int CheckupTypeId { get; set; }
        public string CheckupTypeCode { get; set; }
        public int ProviderStaffId { get; set; }
        public string ProviderStaffTitle { get; set; }
        public int ProviderStaffPercent { get; set; }
        public int ToothCount { get; set; }
        public double ServicePrice { get; set; }
        public double InsurerPrice { get; set; }
        public double ActionPrice { get; set; }


        public double InsurerShare { get; set; }
        public double FranchiseShare { get; set; }
        public double FreeShare { get; set; }

        public double PatientShare {
            get
            {
                return this.FranchiseShare + FreeShare;
            }
        }


        
        public string ToothIds { get; set; }
        public IEnumerable<dynamic> Tooths { get; set; }

        public List<int> ToothIdList
        {
            get
            {
                if (this.Tooths == null)
                    return null;
                return this.ToothIds.Trim().Split(',').Select(i => Convert.ToInt32(i.Trim())).ToList();

            }
        }

        public string ToothId
        {
            get
            {
                if (this.Tooths == null)
                    return "";
                return string.Join("  -  ", this.Tooths.Select(i => string.Format("{0}", i.ToothId)).ToList());

            }
        }
        public string ToothName
        {
            get
            {
                if (this.Tooths == null)
                    return "";
                return string.Join("  -  ", this.Tooths.Select(i => i.ToothName != null ? string.Format("({0})", i.ToothName) : "").ToList());

            }
        }

        public string ToothTitle
        {
            get
            {
                if (this.Tooths == null)
                    return "";
                return string.Join("  -  ", this.Tooths.Select(i => string.Format("({0})", i.ToothTitle)).ToList());

            }
        }

        public string Tooth
        {
            get
            {
                if (this.Tooths == null)
                    return "";
                return string.Join("  -  ", this.Tooths.Select(i => i.ToothName != null ? string.Format("({0}){1}", i.ToothName, i.ToothTitle) : "").ToList());

            }
        }
        public System.Drawing.Bitmap ToothImage
        {
            get
            {
                if (this.Tooths == null)
                    return null;
                var imgCount = this.Tooths.Count();
                if (imgCount == 1)
                {
                    var item = this.Tooths.ElementAt(0);

                    if (item == null || item.ToothImage == null)
                        return null;

                    byte[] imgByte = item.ToothImage;
                 
                    System.IO.MemoryStream tempstream = new System.IO.MemoryStream(imgByte);
                    Image img = Image.FromStream(tempstream);
                    Bitmap im = new Bitmap(img, 35, 30);             

                    return im;

                }
                else if (this.ToothCount > 0 && this.ToothCount < 4)
                {
                    Image[] imgages = new Image[this.ToothCount];
                    for (int i = 0; i < imgCount; i++)
                    {
                        dynamic item = this.Tooths.ElementAt(i);
                        if (item == null && item.ToothImage == null)
                            continue;

                        byte[] imgByte = item.ToothImage;
                        System.IO.MemoryStream tempstream = new System.IO.MemoryStream(imgByte);
                        imgages[i] = Image.FromStream(tempstream);
                    }

                    return Publics.MergeImage(imgages);
                }

                return null;
            }
        }


        
    }

    
}
