using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web;

namespace JenkinsService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "JenkinsCrossService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select JenkinsCrossService.svc or JenkinsCrossService.svc.cs at the Solution Explorer and start debugging.
    public class JenkinsCrossService : IJenkinsCrossService
    {
        public void DoWork()
        {
        }
        public string GetData()
        {
            return string.Format("Hello World");
        }
        public void FetchDataFromRemedy(string remedyValues)
        {
            WriteLog(remedyValues);
            RemedyValuesModel values = new RemedyValuesModel();
            // values.BusinessOwner= 
            string resultUrl = string.Empty;
            string QueryString = GetQueryString(values);
            Uri result = default(Uri);
            if (Uri.TryCreate(
            string.Concat("52.160.97.191:8080", "/job/", "projectname", "/buildWithParameters/", QueryString),
             UriKind.Absolute, out result))
            {
                resultUrl = result.AbsoluteUri;
            }
            else
            {
                throw new ArgumentException(
                "The Parameterized Queue Build Url was not created correctly.");
            }
        }
        public static void WriteLog(string strLog)
        {
            StreamWriter log;
            FileStream fileStream = null;
            DirectoryInfo logDirInfo = null;
            FileInfo logFileInfo;

            string logFilePath = "C:\\Logs\\";
            logFilePath = logFilePath + "Log-" + System.DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
            logFileInfo = new FileInfo(logFilePath);
            logDirInfo = new DirectoryInfo(logFileInfo.DirectoryName);
            if (!logDirInfo.Exists) logDirInfo.Create();
            if (!logFileInfo.Exists)
            {
                fileStream = logFileInfo.Create();
            }
            else
            {
                fileStream = new FileStream(logFilePath, FileMode.Append);
            }
            log = new StreamWriter(fileStream);
            log.WriteLine(strLog);
            log.Close();
        }
        public string GetQueryString(RemedyValuesModel obj)
        {
            var result = new List<string>();
            var props = obj.GetType().GetProperties().Where(p => p.GetValue(obj, null) != null);
            foreach (var p in props)
            {
                var value = p.GetValue(obj, null);
                var enumerable = value as ICollection<string>;
                if (enumerable != null)
                {
                    result.AddRange(from object v in enumerable select string.Format("{0}={1}", p.Name, HttpUtility.UrlEncode(v.ToString())));
                }
                else
                {
                    result.Add(string.Format("{0}={1}", p.Name, HttpUtility.UrlEncode(value.ToString())));
                }
            }

            return string.Join("&", result.ToArray());
        }

    }
}

