using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReportModel.Common
{
    public static class UtilityHelper
    {
        public static string ToSafeString(this object obj)
        {
            if (obj == null) return string.Empty;
            return obj.ToString();
        }

        public static string GetQueryString(this IDictionary<string, object> dic, string key = null, string val = null)
        {
            if (key != null)
            {
                if (dic.ContainsKey(key))
                {
                    dic[key] = val;
                }
                else
                {
                    dic.Add(key, val);
                }
            }

            List<string> param = new List<string>();

            foreach (var i in dic)
            {
                if (i.Value != null && !string.IsNullOrEmpty(i.Value.ToString()))
                    param.Add(string.Format("{0}={1}", i.Key, i.Value));
            }

            if (param.Count > 0)
            {
                return string.Concat("?", string.Join("&", param.ToArray()));
            }
            else
            {
                return string.Empty;
            }
        }

        public static string ToDayStr(this DateTime dt)
        {
            return dt.ToString("yyyy年MM月dd日");
        }

        public static string ToTimeStr(this DateTime dt)
        {
            return dt.ToString("HH:mm:ss");
        }

        /// <summary>
        /// 根据时间距加载时的时间的差(t)值显示具体格式
        /// 当t<=1分钟时,显示 X秒前 X向下取整
        /// 当t<=2小时时,显示 X分钟前 X向下取整
        /// 当2小时<t<=24小时,显示 X小时前 X向下取整
        /// 当24小时<t<=120小时,显示 X天前 X为日期直接相减,不管时分秒
        /// 当t>120小时,显示 2010-11-07 16:51 或 2010-11-07
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static string ToFriendlyStr(this DateTime dt)
        {
            DateTime d = dt.ToLocalTime();
            DateTime now = DateTime.Now;
            if (d >= now.AddMinutes(-1)) return string.Format("{0}秒前", (now - d).TotalSeconds.ToString("0"));

            if (d >= now.AddHours(-2)) return string.Format("{0}分钟前", (now - d).TotalMinutes.ToString("0"));

            if (d >= now.AddHours(-24)) return string.Format("{0}小时前", (now - d).TotalHours.ToString("0"));

            if (d >= now.AddHours(-120)) return string.Format("{0}天前", (now - d).TotalDays.ToString("0"));

            return d.ToString("yyyy-MM-dd HH:mm");
        }


        public static string ToFullStr(this DateTime dt)
        {
            return string.Concat(dt.ToDayStr(), " ", dt.ToTimeStr());
        }

    }
}
