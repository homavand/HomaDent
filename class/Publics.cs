using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Win32;
using System.Linq;
using System.Drawing;
using System.Reflection;
using System.Collections;
using Stimulsoft.Base.Json.Linq;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.CodeDom;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using FarsiMessageBox;
using System.IO;

namespace Dentistry
{
    public static class Publics
    {
        
   
        // Fields
        public static string AllowedEnglishCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ 0123456789";
        public static string AllowedExtendedEnglishCharacters = ("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ 0123456789" + ExtendedCharacters);
        public static string AllowedExtendedFarsiCharacters = ("ابپتثجچحخدذرزژسشصضطظعغفقكگلمنوهيآؤئءأ ً ٌ 0123456789" + ExtendedCharacters);
        public static string AllowedFarsiCharacters = "ابپتثجچحخدذرزژسشصضطظعغفقكگلمنوهيآؤئءأ ً ٌ 0123456789";
        public static string ExtendedCharacters = @"\/|>.<=+-_)(*&^%$#@!~";
        public static int ScreenW;
        public static int ScreenH;

    

        #region FetchSettings
        public static void FetchSettings()
        {
            
            string backupPath = DataProvider.GetSettings(); 
            
            Dentistry.AppConfigs.BackupPath = backupPath;


        }
        #endregion
        #region SaveSettings
        public static void SaveSettings()
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = Dentistry.AppConfigs.ConnectionString;
            if (sqlConnection.State == ConnectionState.Closed || sqlConnection.State == ConnectionState.Broken)
                sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = @" UPDATE Configs  SET 	BackupPath=@BackupPath WHERE Id=1 ";
            sqlCommand.Parameters.Add("@BackupPath", SqlDbType.NVarChar).Value = Dentistry.AppConfigs.BackupPath;

            sqlCommand.ExecuteNonQuery();

            if (sqlConnection.State != ConnectionState.Closed)
                sqlConnection.Close();

        }
        #endregion
        public static bool IsValidNationalCode(string input)
        {
            if (!Regex.IsMatch(input, @"^\d{10}$"))
                return false;

            var check = Convert.ToInt32(input.Substring(9, 1));
            var sum = Enumerable.Range(0, 9)
                .Select(x => Convert.ToInt32(input.Substring(x, 1)) * (10 - x))
                .Sum() % 11;

            return sum < 2 ? check == sum : check + sum == 11;
        }
        // Methods


        public static bool CheckLogin()
        {
            try
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\babaha");

                if ((key != null) && ((key.GetValue("acbv") != null)))
                {
                    if ((Convert.ToInt32(key.GetValue("acbv").ToString()) < 30))
                    {
                        Registry.CurrentUser.OpenSubKey(@"SOFTWARE\babaha", true).SetValue("acbv", (Convert.ToInt32(key.GetValue("acbv").ToString()) + 1).ToString(), RegistryValueKind.String);
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\babaha", true);
                if (key == null)
                {
                    key = Registry.CurrentUser.OpenSubKey("SOFTWARE", true);
                    key.CreateSubKey("babaha");
                    key.Close();
                    Registry.CurrentUser.OpenSubKey(@"SOFTWARE\babaha", true).SetValue("acbv", 0, RegistryValueKind.String);
                }

                if ((Convert.ToInt32(key.GetValue("acbv").ToString())) < 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
      
        public static string CreateHash(string toHash)
        {
            string hashStr = toHash.ToUpper();
            System.Security.Cryptography.MD5 md = new System.Security.Cryptography.MD5CryptoServiceProvider();
            byte[] bytes = new ASCIIEncoding().GetBytes(hashStr);
            string str = Convert.ToBase64String(md.ComputeHash(bytes)).Substring(0, 12);

            string[] chars = { ":", ",", "/", @"\", "-", "+" };
            foreach (string s in chars)
                str = str.Replace(s, "X");
            return str;
        }

        public static char FixTwoSomeCharacter(char chSrc)
        {
            switch (chSrc)
            {
                case 'ه':
                    return 'ه';

                case 'و':
                    return chSrc;

                case 'ى':
                    return 'ي';

                case 'ي':
                    return 'ي';

                case 'ٔ':
                    return 'ء';

                case 'ك':
                    return 'ك';

                case 'ئ':
                    return 'ي';

                case 'ة':
                    return 'ه';

                case 'ٲ':
                    return 'أ';

                case 'ٳ':
                    return chSrc;

                case 'ٴ':
                    return 'ء';

                case 'ٸ':
                    return 'ي';

                case 'ک':
                    return 'ك';

                case 'ڪ':
                    return 'ك';

                case 'ګ':
                    return 'ك';

                case 'ڬ':
                    return 'ك';

                case 'ڭ':
                    return 'ك';

                case 'ڮ':
                    return 'ك';

                case 'ۀ':
                    return 'ه';

                case 'ہ':
                    return 'ه';

                case 'ی':
                    return 'ي';

                case 'ۍ':
                    return 'ي';

                case 'ێ':
                    return 'ي';

                case 'ۏ':
                case 'ے':
                case 'ۓ':
                case '۔':
                    return chSrc;

                case 'ې':
                    return 'ي';

                case 'ۑ':
                    return 'ي';

                case 'ە':
                    return 'ه';
            }
            return chSrc;
        }

        public static string FixCharacters(string strSrc)
        {
            strSrc = strSrc.Replace('ة', 'ه');
            strSrc = strSrc.Replace('ه', 'ه');
            strSrc = strSrc.Replace('ۀ', 'ه');
            strSrc = strSrc.Replace('ہ', 'ه');
            strSrc = strSrc.Replace('ە', 'ه');
            strSrc = strSrc.Replace('ك', 'ك');
            strSrc = strSrc.Replace('ک', 'ك');
            strSrc = strSrc.Replace('ڪ', 'ك');
            strSrc = strSrc.Replace('ګ', 'ك');
            strSrc = strSrc.Replace('ڬ', 'ك');
            strSrc = strSrc.Replace('ڭ', 'ك');
            strSrc = strSrc.Replace('ڮ', 'ك');
            strSrc = strSrc.Replace('ۑ', 'ى');
            strSrc = strSrc.Replace('ې', 'ى');
            strSrc = strSrc.Replace('ێ', 'ى');
            strSrc = strSrc.Replace('ۍ', 'ى');
            strSrc = strSrc.Replace('ي', 'ى');
            strSrc = strSrc.Replace('ٸ', 'ى');
            strSrc = strSrc.Replace('ي', 'ى');
            strSrc = strSrc.Replace('ي', 'ى');
            strSrc = strSrc.Replace('ئ', 'ى');
            strSrc = strSrc.Replace('ٲ', 'أ');
            strSrc = strSrc.Replace('ٔ', 'ء');
            strSrc = strSrc.Replace('ٴ', 'ء');
            return strSrc;
        }

        public static void ComboBoxFullNameKeydown(object sender, KeyEventArgs e, int number)
        {
            ComboBox combo = (ComboBox)sender;
            if (e.KeyCode == Keys.Enter)
            {
                int num = number;
                bool flag = false;

                DataView dw = (DataView)combo.DataSource;

                for (int i = 0; i < dw.Table.Rows.Count; ++i)
                {
                    if (dw.Table.Rows[i][combo.ValueMember].ToString() == num.ToString())
                    {
                        combo.SelectedValue = num;
                        flag = true;
                        break;
                    }

                }
                if (!flag)
                {
                    combo.SelectedIndex = 0;
                }

            }
        }




        public static string EncodeDate(DateTime date)
        {
            string[] dateAlpha = { "D", "Z", "L", "M", "A", "G", "W", "P", "X", "I" };
            string year = date.Year.ToString();
            string month = date.Month < 10 ? "0" + date.Month.ToString() : date.Month.ToString();
            string day = date.Day < 10 ? "0" + date.Day.ToString() : date.Day.ToString();
            string key = "";
            for (int i = 0; i < year.Length; i++)
            {
                key += dateAlpha[int.Parse(year.Substring(i, 1))];
            }
            key += "S";
            for (int i = 0; i < month.Length; i++)
            {
                key += dateAlpha[int.Parse(month.Substring(i, 1))];
            }
            key += "R";
            for (int i = 0; i < day.Length; i++)
            {
                key += dateAlpha[int.Parse(day.Substring(i, 1))];
            }

            return key.ToString();
        }
        public static DateTime DecodeDate(string date)
        {
            string[] dateAlpha = { "D", "Z", "L", "M", "A", "G", "W", "P", "X", "I" };
            string year = "";
            string month = "";
            string day = "";

            for (int i = 0; i < date.IndexOf('S'); i++)
            {
                year += Find(date.Substring(i, 1));
            }
            for (int i = date.IndexOf('S') + 1; i < date.IndexOf('R'); i++)
            {
                month += Find(date.Substring(i, 1));
            }
            for (int i = date.IndexOf('R') + 1; i < date.Length; i++)
            {
                day += Find(date.Substring(i, 1));
            }

            return new DateTime(int.Parse(year), int.Parse(month), int.Parse(day));
        }



        public static int Find(string str)
        {
            string[] dateAlpha = { "D", "Z", "L", "M", "A", "G", "W", "P", "X", "I" };
            for (int i = 0; i < dateAlpha.Length; i++)
            {
                if (dateAlpha[i] == str)
                {
                    return i;
                }
            }
            return -1;
        }

        public static Control FindControl(Control parent, string name)
        {
            Control control = null;
            // Check the parent.
            if (parent.Name.ToLower().Trim() == name.ToLower().Trim()) return parent;

            if (parent.GetType() == typeof(BindingNavigator))
            {
                foreach (System.ComponentModel.Component ctl in ((BindingNavigator)parent).Items)
                {
                    control = FindControl(ctl as Control, name);
                    if (control != null)
                        return control;
                }
            }
            // Recursively search the parent's children.
            foreach (Control ctl in parent.Controls)
            {
                control = FindControl(ctl, name);
                if (control != null)
                    return control;
            }

            // If we still haven't found it, it's not here.
            return null;
        }


        public static Bitmap GetImageByName(string imageName)
        {
            System.Reflection.Assembly asm = System.Reflection.Assembly.GetExecutingAssembly();
            string resourceName = asm.GetName().Name + ".Properties.Resources";
            var rm = new System.Resources.ResourceManager(resourceName, asm);
            Bitmap img = (Bitmap)rm.GetObject(imageName);

            return img;
        }

        // AutoComplete
        public static void AutoComplete(ComboBox cb, dynamic data)
        {
            IEnumerable dd = data as IEnumerable;
            foreach (dynamic item in dd)
            {
                if (item.Title != null)
                    cb.AutoCompleteCustomSource.Add(item.Title);
            }

            cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cb.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }




        public static string RemoveSpaces(string str)
        {
            if (str.Contains("  "))
            {
                str = str.Replace("  ", " ");
                return RemoveSpaces(str);
            }
            else
                return str;

        }

        public static bool GetCurrentUserPermission(string appAction)
        { 
            return true;
        }


        public static bool GetCurrentUserPermission1(int appActionId)
        {
            bool flag = false;
            var userPermissions = Dentistry.AppConfigs.CurrentUserPermissions;

            if (userPermissions == null)
                goto exit;

            IEnumerable<dynamic> actionList = userPermissions != null && (Enumerable.Count(userPermissions) > 0) ?
                 (userPermissions as IEnumerable<dynamic>)
                 .Select(i =>
                    new
                    {
                        Id = (int)i.AppActionId,
                        Value = Convert.ToBoolean(i.Value),

                    }).ToList() : null;

            if (actionList == null)
                goto exit;

            foreach (var action in actionList)
            {
                if (action.Id == appActionId)
                {
                    flag = Convert.ToBoolean(action.Value);
                   
                }
            }


            exit:
            var appActionName = Enum.GetName(typeof(Enums.AppActions), appActionId);
            if (flag == false)
                FMessageBox.Show(Dentistry.AppConfigs.strPermission + "\n" + "[ " + appActionName + " ]", Dentistry.AppConfigs.strExclamation, FMessageBoxButtons.OK, FMessageBoxIcons.Question);

            return flag;
           
        }

        
        public static bool IsNumeric(string val)
        {
            try
            {
                double result = 0;
                return Double.TryParse(val, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.CurrentInfo, out result);
            }
            catch
            {
                return false;
            }
        }
      

        #region Clear&SetControls
        public static void ClearControls(Control obj)
        {
            if (obj is TextBox)
            {
                ((TextBox)obj).Text = string.Empty;
            }
            else if (obj is ComboBox)
            {
                if (((ComboBox)obj).DataSource != null)
                    ((ComboBox)obj).SelectedIndex = 0;
                else
                    if (((ComboBox)obj).Items.Count > 0)
                    ((ComboBox)obj).Text = string.Empty;
            }
            else if (obj is CheckBox)
            {
                ((CheckBox)obj).Checked = false;
            }
            else if (obj is RadioButton)
            {
                ((RadioButton)obj).Checked = false;
            }
            else
                foreach (Control c in obj.Controls)
                    ClearControls(c);
        }

        public static void SetControls(Control obj)
        {
            if (obj is TextBox)
            {
                ((TextBox)obj).Text = string.Empty;
                ((TextBox)obj).BackColor = Color.White;
            }
            else if (obj is ComboBox)
            {
                ((ComboBox)obj).Text = string.Empty;
                ((ComboBox)obj).BackColor = Color.White;
            }
            else if (obj is CheckBox)
            {
                ((CheckBox)obj).CheckState = CheckState.Unchecked;
            }
            else
                foreach (Control c in obj.Controls)
                    SetControls(c);
        }
        #endregion

       

        public static void DefaultScreen()
        {
            ScreenW = Screen.PrimaryScreen.Bounds.Width;
            ScreenH = Screen.PrimaryScreen.Bounds.Height;
        }
        public static DataTable GetDataTableFromDynamicObject(List<dynamic> listData)
        {
            DataTable table = new DataTable();
            if (listData.Count > 0)
            {
                var firstRow = (IEnumerable<KeyValuePair<string, JToken>>)(JObject)listData.First();

                foreach (KeyValuePair<string, JToken> property in firstRow.OrderBy(x => x.Key))
                    table.Columns.Add(new DataColumn(property.Key));

                foreach (var data in listData)
                {
                    DataRow row = table.NewRow();
                    var record = (IEnumerable<KeyValuePair<string, JToken>>)(JObject)data;

                    foreach (KeyValuePair<string, JToken> kvp in record)
                    {
                        row[kvp.Key] = kvp.Value;
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }
        //public static DataTable ToDataTable<T>(this List<T> items)
        //{
        //    var tb = new DataTable(typeof(T).Name);

        //    System.Reflection.PropertyInfo[] props = typeof(T).GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);

        //    foreach (var prop in props)
        //    {
        //        tb.Columns.Add(prop.Name, prop.PropertyType);
        //    }

        //    foreach (var item in items)
        //    {
        //        var values = new object[props.Length];
        //        for (var i = 0; i < props.Length; i++)
        //        {
        //            values[i] = props[i].GetValue(item, null);
        //        }

        //        tb.Rows.Add(values);
        //    }

        //    return tb;
        //}
        public static DataTable ToDataTable(this IEnumerable<dynamic> items)
        {
            var data = items.ToArray();
            if (data.Count() == 0) return null;

            var dt = new DataTable();
            foreach (var key in ((IDictionary<string, object>)data[0]).Keys)
            {
                dt.Columns.Add(key);
            }
            foreach (var d in data)
            {
                dt.Rows.Add(((IDictionary<string, object>)d).Values.ToArray());
            }
            return dt;
        }
        //public static void WriteErrorsToFile(string ErrorMessage)
        //{
        //    string FilePatch = string.Format(@"{0}\{1}", ClassError.Path, ClassError.FileName);
        //    if (System.IO.File.Exists(FilePatch) == false)
        //    {
        //        XmlTextWriter xmlTextWriter = new XmlTextWriter(ClassError.FileName, ASCIIEncoding.UTF8);
        //        xmlTextWriter.WriteStartDocument();
        //        xmlTextWriter.WriteComment("Dentistry Error XML File . Created By Mohammad Babaha");
        //        xmlTextWriter.WriteStartElement("Root");
        //        xmlTextWriter.WriteStartElement("Date");
        //        xmlTextWriter.WriteAttributeString("ErrorDate", Class.Date.ToSolar(DateTime.Now.ToString()));
        //        xmlTextWriter.WriteEndElement();
        //        xmlTextWriter.WriteStartElement("Error");
        //        xmlTextWriter.WriteAttributeString("ErrorMessage", ErrorMessage);
        //        xmlTextWriter.WriteEndElement();

        //        xmlTextWriter.WriteEndElement();
        //        xmlTextWriter.WriteEndDocument();
        //        xmlTextWriter.Close();
        //    }
        //}

        //public static void  IsUserAdministrator()
        //{
        //      try
        //      {
        //            WindowsIdentity   user  =  WindowsIdentity.GetCurrent();
        //            WindowsPrincipal  principal =  new  WindowsPrincipal(user);
        //            isAdmin  =  principal.IsInRole(WindowsBuiltInRole.Administrator);
        //      }
        //      catch (UnauthorizedAccessException  ex)
        //      {
        //            isAdmin = false;
        //            MessageBox.Show(ex.Message);
        //      }
        //      catch (Exception  ex)
        //      {
        //            isAdmin = false;
        //            MessageBox.Show(ex.Message);
        //      }

        //}


        public static int PSW { get { return ((GetBoardMaker() + GetProssesorId()) * 87952 + 105 - 2 / 6); } }
        public static int SER { get { return (GetBoardMaker() + GetProssesorId()); } }

        private static bool isfirstload = true;
        public static bool _IsFirstLoad { get { return isfirstload; } set { isfirstload = value; } }
     

        public static void ClearInputs(Control control)
        {
            foreach (Control ctl in control.Controls)
            {
                if (ctl is TextBox)
                    ctl.Text = string.Empty;
                if (ctl is ComboBox && ((ComboBox)ctl).Items.Count > 0)
                    ((ComboBox)ctl).SelectedIndex = 0;
            }
        }

        public static int GetProssesorId()
        {
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            string Id = string.Empty;
            foreach (ManagementObject mo in moc)
            {
                Id = mo.Properties["processorID"].Value.ToString();
                break;

            }
            return SetNumber(Id);
        }

        private static int GetBoardMaker()
        {
            string Val = string.Empty;
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "select * from win32_BaseBoard");
            foreach (ManagementObject wmi in searcher.Get())
            {
                try
                {
                    Val = wmi.GetPropertyValue("Manufacturer").ToString();
                }
                catch { }
            }
            Val = "Unknow MOB";
            return SetNumber(Val);
        }
        private static int SetNumber(string code)
        {

            int val = 0;

            if (code == "")
                code = "Efr0";
            foreach (char c in code)
            {
                val += Convert.ToInt32(c);
            }
            val = (val * 914 / 3) + 45896 + 205 * 87;
            return val;

        }


        public static void CreateType(string name, IDictionary<string, Type> props)
        {
            var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } });
            var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, "Test.Dynamic.dll", false);
            parameters.GenerateExecutable = false;

            var compileUnit = new CodeCompileUnit();
            var ns = new CodeNamespace("Test.Dynamic");
            compileUnit.Namespaces.Add(ns);
            ns.Imports.Add(new CodeNamespaceImport("System"));

            var classType = new CodeTypeDeclaration(name);
            classType.Attributes = MemberAttributes.Public;
            ns.Types.Add(classType);

            foreach (var prop in props)
            {
                var fieldName = "_" + prop.Key;
                var field = new CodeMemberField(prop.Value, fieldName);
                classType.Members.Add(field);

                var property = new CodeMemberProperty();
                property.Attributes = MemberAttributes.Public | MemberAttributes.Final;
                property.Type = new CodeTypeReference(prop.Value);
                property.Name = prop.Key;
                property.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName)));
                property.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), fieldName), new CodePropertySetValueReferenceExpression()));
                classType.Members.Add(property);
            }

            var results = csc.CompileAssemblyFromDom(parameters, compileUnit);
            results.Errors.Cast<CompilerError>().ToList().ForEach(error => Console.WriteLine(error.ErrorText));
        }

        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            if (image == null)
                return null;

            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        public static Bitmap MergeImage(Image[] imgages)
        {
            
            int imgCount = imgages.Length;
           
            int imgWidth = 30, imgHeight = 20;
         
            int width = (imgCount * imgWidth) + (imgCount * 10);
            int height = imgHeight + 10;
            
          
            var bitmap = new Bitmap(width, height, PixelFormat.Format64bppArgb);
            using (var g = Graphics.FromImage(bitmap))
            {
                int i = 0;
                foreach (var image in imgages)
                {
                    var img = ResizeImage(image, imgWidth, imgHeight);
                    g.DrawImage(img, (i * imgWidth) + 10 , 0);
                    i++;
                }
            }

            
            
            return bitmap;
        }


        public static byte[] PadLines(byte[] bytes, int rows, int columns)
        {
            int currentStride = columns; // 3
            int newStride = columns;  // 4
            byte[] newBytes = new byte[newStride * rows];
            for (int i = 0; i < rows; i++)
                Buffer.BlockCopy(bytes, currentStride * i, newBytes, newStride * i, currentStride);
            return newBytes;
        }

        public static string ToRial(double value)
        {
            return string.Format("{0:N0}", double.Parse(Convert.ToString(value).Replace(",", "")));
        }

        static dynamic MergeDynamic(dynamic item1, dynamic item2)
        {
            var dictionary1 = (IDictionary<string, object>)item1;
            var dictionary2 = (IDictionary<string, object>)item2;
            var result = new System.Dynamic.ExpandoObject();
            var d = result as IDictionary<string, object>; //work with the Expando as a Dictionary

            foreach (var pair in dictionary1.Concat(dictionary2))
            {
                d[pair.Key] = pair.Value;
            }

            return result;
        }
   

        public static T GetPropertyValue<T>(dynamic obj, string prop)
        {
            if (obj == null)
                return default(T);

            bool flag = false;
            dynamic value = null;
            if (obj is System.Dynamic.ExpandoObject)
                flag = ((IDictionary<string, object>)obj).ContainsKey(prop);

            flag = obj.GetType().GetProperty(prop) != null;

            if (flag)
            {
                value = obj.GetType().GetProperty(prop).GetValue(obj, null);
            }

            if (value == null)
                return default(T);

            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.String:
                    return Convert.ToString(value);

                case TypeCode.Boolean:
                    return Convert.ToBoolean(value);

                case TypeCode.Int32:
                    return Convert.ToInt32(value);
                    
                case TypeCode.Double:
                    return Convert.ToDouble(value);

            
                case TypeCode.DateTime:
                    return Convert.ToDateTime(value);
            }

            return value;
        }
        public static bool IsPropertyExist(dynamic obj, string prop)
        {
            if (obj is System.Dynamic.ExpandoObject)
                return ((IDictionary<string, object>)obj).ContainsKey(prop);

            return obj.GetType().GetProperty(prop) != null;
        }
        public static bool IsPropertyExistX(this System.Dynamic.ExpandoObject obj, string prop) 
        {
            if (obj is System.Dynamic.ExpandoObject)
                return ((IDictionary<string, object>)obj).ContainsKey(prop);

            return obj.GetType().GetProperty(prop) != null;
        }

        public static string ConvertDateToString(DateTime? dt)
        {
            if (dt == null)
                return null;

            string date = dt.Value.ToString("yyyy-MM-dd");
            return date;

        }
        public static string ConvertDateTimeToString(DateTime? dt)
        {
            if (dt == null)
                return null;

            string date = dt.Value.ToString("yyyy-MM-dd HH:mm");
            return date;

        }
        public static DateTime ConvertStringToDateTime(string str)
        {
            string pattern = @"(\d{4})-(\d{2})-(\d{2}) (\d{2}):(\d{2})";
            if (Regex.IsMatch(str, pattern))
            {
                Match match = Regex.Match(str, pattern);
                int year = Convert.ToInt32(match.Groups[1].Value);
                int month = Convert.ToInt32(match.Groups[2].Value);
                int day = Convert.ToInt32(match.Groups[3].Value);
                int hour = Convert.ToInt32(match.Groups[4].Value);
                int minute = Convert.ToInt32(match.Groups[5].Value);
               
                return new DateTime(year, month, day, hour, minute, 0, 0);
            }
            else
            {
                throw new Exception("Unable to parse.");
            }
        }

        public static int GetComboIndex(ComboBox cbo, object value)
        {
            if (cbo.Items.Count > 0)
            {               
                for (int i = 0; i < cbo.Items.Count; i++)
                {
                    object item = cbo.Items[i];
                    Type itemType = item.GetType();

                    if (itemType.Name == "DataRowView")
                        continue;

                    PropertyInfo itemValueMember = itemType.GetProperty(cbo.ValueMember);
                    object thisValue = itemValueMember.GetValue(item);
                    if(thisValue != null &&  thisValue.ToString() == value.ToString())
                        return i;
                  
                }                             
            }
            return -1;
        }


        public static void BackupDB(string filePath, string srcFilename, string destFilename)
        {
            var srcFile = Path.Combine(filePath, srcFilename);
            var destFile = Path.Combine(filePath, destFilename);

            if (File.Exists(destFile))
                File.Delete(destFile);

            File.Copy(srcFile, destFile);
        }
        public static void RestoreDB(string filePath, string srcFilename, string destFilename, bool isCopy = false)
        {
            var srcFile = Path.Combine(filePath, srcFilename);
            var destFile = Path.Combine(filePath, destFilename);

            if (File.Exists(destFile))
            {
                var sql = DB.GetConnection();
                sql.Close();
                System.Data.SQLite.SQLiteConnection.ClearAllPools();
                GC.Collect();
                GC.WaitForPendingFinalizers();

               

                File.Delete(destFile);
            }
            if (isCopy == true) // if True copy file, otherwise move it
                BackupDB(filePath, srcFilename, destFilename);
            else
                File.Move(srcFile, destFile);
        }

        public static int GetAge(dynamic date)
        {
            if (date == null)
                return 0;


            string dateStr = Convert.ToDateTime(date).ToString();
            DateTime dateValue;
            if (DateTime.TryParse(dateStr, out dateValue))
            {
                var age = DateTime.Now.Year - dateValue.Year;
                return age;
            }
            return 0;
        }

        public static string GetSolarDate(dynamic date)
        {
            if (date == null)
                return "";

            string dateStr = Convert.ToDateTime(date).ToString();
            DateTime dateValue;
            if (DateTime.TryParse(dateStr, out dateValue))
            {
                return new PersianDateTime(dateValue).ToString("yyyy/MM/dd");
            }
            return "";
        }
        public static string GetSolarDateTime(dynamic date)
        {
            if (date == null)
                return "";

            string dateStr = Convert.ToString(date);
            DateTime dateValue;
            if (DateTime.TryParse(dateStr, out dateValue))
            {
                return new PersianDateTime(dateValue).ToString("yyyy/MM/dd  HH:mm");
            }
            return "";
        }
        public static DateTime? GetDate(dynamic date)
        {
            if (date == null)
                return (DateTime?)null;

            string dateStr = Convert.ToString(date);
            DateTime dateValue;
            if (DateTime.TryParse(dateStr, out dateValue))
            {
                return dateValue;
            }
            return (DateTime?)null;
        }

        public static IEnumerable<dynamic> AddDefaultItemToComboDynamicList(IEnumerable<dynamic> data)
        {

            IEnumerable<dynamic> list = data != null && (Enumerable.Count(data) > 0) ? (data as IEnumerable<dynamic>).Select(i =>
                new
                {
                    Id = i.Id,
                    Title = i.Title,
                }
            ).OrderBy(i => i.Id).ToList() : Enumerable.Empty<dynamic>();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            foreach (var i in list)
                dt.Rows.Add(i.Id, i.Title);

            DataRow dr = dt.NewRow();
            dr["Id"] = -1;
            dr["Title"] = "...";

            dt.Rows.InsertAt(dr, 0);

            list = dt.AsEnumerable().ToList().Select(r =>
               new
               {
                   Id = r["Id"],
                   Title = r["Title"]
               }
            ).OrderBy(i => i.Id).ToList() ;

            return list;
        }
    }
}
