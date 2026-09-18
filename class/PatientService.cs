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
        // --------------------------------------------------------------
        // Cache of already-decoded/resized tooth images, keyed by the raw
        // ToothIds string ("12,13" etc.). Only a small, bounded number of
        // distinct tooth combinations actually occur in practice (there
        // are only 32 teeth total), so this cache stays small for the
        // whole lifetime of the app - but every row that shares the same
        // combination (which is most rows, over time) skips the
        // Image.FromStream/Bitmap resize/MergeImage work entirely and
        // just returns the cached Bitmap.
        //
        // NOTE: WinForms UI code runs on a single (UI) thread, so a plain
        // Dictionary is safe here. If ToothImage is ever accessed from a
        // background thread, switch to ConcurrentDictionary.
        // --------------------------------------------------------------
        private static readonly Dictionary<string, Bitmap> _toothImageCache = new Dictionary<string, Bitmap>();

        public PatientService()
        {
        }


        public PatientService(dynamic obj)
        {
            // Previously this went through `new RouteValueDictionary(obj)` +
            // ~30 HasValue()/GetValue<T>() calls. For an anonymous-type
            // source (which is exactly what GetPatientServicesX returns),
            // RouteValueDictionary's constructor uses reflection
            // (TypeDescriptor.GetProperties) to discover every property -
            // a one-time, several-second cost the FIRST time any object of
            // that particular anonymous-type shape is ever passed through
            // it in the process (cached after that, which is why later
            // rows/calls looked instant).
            //
            // GetPatientServicesX's shape is fixed and known (we control
            // both ends), so there's no need for the reflection/HasValue
            // indirection at all - direct dynamic property access below
            // uses a much cheaper DLR call site per property and has no
            // comparable cold-start cliff.
            //
            // NOTE: this assumes every field is always present in the
            // source object (true for GetPatientServicesX's finalResult).
            // If this constructor is ever called with a partial/different
            // shaped object, wrap individual assignments in try/catch or
            // restore the HasValue-guarded version for those specific
            // fields.

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

            this.ActionPrice = Convert.ToInt64(obj.ActionPrice);
            this.ServicePrice = Convert.ToInt64(obj.ServicePrice);
            this.InsurerPrice = Convert.ToInt64(obj.InsurerPrice);
            this.InsurerShare = Convert.ToInt64(obj.InsurerShare);
            this.FranchiseShare = Convert.ToInt64(obj.FranchiseShare);
            this.FreeShare = Convert.ToInt64(obj.FreeShare);
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
        public long ServicePrice { get; set; }
        public long InsurerPrice { get; set; }
        public long ActionPrice { get; set; }


        public long InsurerShare { get; set; }
        public long FranchiseShare { get; set; }
        public long FreeShare { get; set; }

        public long PatientShare
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


}
