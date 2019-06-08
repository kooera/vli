/**
*
* 功 能： 该转换来源网上代码，农历转换
* 类 名： ChineseCalendarInfo
* 作 者： weili
* 时 间： 2019/5/12 0:07:57
* 版 本： 1.0.0.0
* 版 权： Copyright (c) 2019 Mainki. All rights reserved.
*
*/


using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Vli.Extension;

namespace Vli.Convert
{
    public class ChineseCalendarInfo
    {
        private DateTime m_SolarDate;
        private int m_LunarYear, m_LunarMonth, m_LunarDay;
        private bool m_IsLeapMonth = false;
        private string m_LunarYearSexagenary = null, m_LunarYearAnimal = null;
        private string m_LunarYearText = null, m_LunarMonthText = null, m_LunarDayText = null;
        private string m_SolarWeekText = null, m_SolarConstellation = null, m_SolarBirthStone = null;

        #region 构造函数

        public ChineseCalendarInfo()
            : this(DateTime.Now.Date)
        {

        }

        /// <summary>
        /// 从指定的阳历日期创建中国日历信息实体类
        /// </summary>
        /// <param name="date">指定的阳历日期</param>
        public ChineseCalendarInfo(DateTime date)
        {
            m_SolarDate = date;
            LoadFromSolarDate();
        }

        private void LoadFromSolarDate()
        {
            m_IsLeapMonth = false;
            m_LunarYearSexagenary = null;
            m_LunarYearAnimal = null;
            m_LunarYearText = null;
            m_LunarMonthText = null;
            m_LunarDayText = null;
            m_SolarWeekText = null;
            m_SolarConstellation = null;
            m_SolarBirthStone = null;

            m_LunarYear = calendar.GetYear(m_SolarDate);
            m_LunarMonth = calendar.GetMonth(m_SolarDate);
            int leapMonth = calendar.GetLeapMonth(m_LunarYear);

            if (leapMonth == m_LunarMonth)
            {
                m_IsLeapMonth = true;
                m_LunarMonth -= 1;
            }
            else if (leapMonth > 0 && leapMonth < m_LunarMonth)
            {
                m_LunarMonth -= 1;
            }

            m_LunarDay = calendar.GetDayOfMonth(m_SolarDate);

            CalcConstellation(m_SolarDate, out m_SolarConstellation, out m_SolarBirthStone);
        }

        #endregion

        #region 日历属性

        /// <summary>
        /// 阳历日期
        /// </summary>
        public DateTime SolarDate
        {
            get { return m_SolarDate; }
            set
            {
                if (m_SolarDate.Equals(value))
                    return;
                m_SolarDate = value;
                LoadFromSolarDate();
            }
        }
        /// <summary>
        /// 星期几
        /// </summary>
        public string SolarWeekText
        {
            get
            {
                if (string.IsNullOrEmpty(m_SolarWeekText))
                {
                    int i = (int)m_SolarDate.DayOfWeek;
                    m_SolarWeekText = ChineseWeekName[i];
                }
                return m_SolarWeekText;
            }
        }
        /// <summary>
        /// 阳历星座
        /// </summary>
        public string SolarConstellation
        {
            get { return m_SolarConstellation; }
        }
        /// <summary>
        /// 阳历诞生石
        /// </summary>
        public string SolarBirthStone
        {
            get { return m_SolarBirthStone; }
        }

        /// <summary>
        /// 阴历年份
        /// </summary>
        public int LunarYear
        {
            get { return m_LunarYear; }
        }
        /// <summary>
        /// 阴历月份
        /// </summary>
        public int LunarMonth
        {
            get { return m_LunarMonth; }
        }
        /// <summary>
        /// 是否阴历闰月
        /// </summary>
        public bool IsLeapMonth
        {
            get { return m_IsLeapMonth; }
        }
        /// <summary>
        /// 阴历月中日期
        /// </summary>
        public int LunarDay
        {
            get { return m_LunarDay; }
        }

        /// <summary>
        /// 阴历年干支
        /// </summary>
        public string LunarYearSexagenary
        {
            get
            {
                if (string.IsNullOrEmpty(m_LunarYearSexagenary))
                {
                    int y = calendar.GetSexagenaryYear(this.SolarDate);
                    m_LunarYearSexagenary = CelestialStem.Substring((y - 1) % 10, 1) + TerrestrialBranch.Substring((y - 1) % 12, 1);
                }
                return m_LunarYearSexagenary;
            }
        }
        /// <summary>
        /// 阴历年生肖
        /// </summary>
        public string LunarYearAnimal
        {
            get
            {
                if (string.IsNullOrEmpty(m_LunarYearAnimal))
                {
                    int y = calendar.GetSexagenaryYear(this.SolarDate);
                    m_LunarYearAnimal = Animals.Substring((y - 1) % 12, 1);
                }
                return m_LunarYearAnimal;
            }
        }


        /// <summary>
        /// 阴历年文本
        /// </summary>
        public string LunarYearText
        {
            get
            {
                if (string.IsNullOrEmpty(m_LunarYearText))
                {
                    m_LunarYearText = Animals.Substring(calendar.GetSexagenaryYear(new DateTime(m_LunarYear, 1, 1)) % 12 - 1, 1);
                    StringBuilder sb = new StringBuilder();
                    int year = this.LunarYear;
                    int d;
                    do
                    {
                        d = year % 10;
                        sb.Insert(0, ChineseNumber[d]);
                        year = year / 10;
                    } while (year > 0);
                    m_LunarYearText = sb.ToString();
                }
                return m_LunarYearText;
            }
        }
        /// <summary>
        /// 阴历月文本
        /// </summary>
        public string LunarMonthText
        {
            get
            {
                if (string.IsNullOrEmpty(m_LunarMonthText))
                {
                    m_LunarMonthText = (this.IsLeapMonth ? "闰" : "") + ChineseMonthName[this.LunarMonth - 1];
                }
                return m_LunarMonthText;
            }
        }

        /// <summary>
        /// 阴历月中日期文本
        /// </summary>
        public string LunarDayText
        {
            get
            {
                if (string.IsNullOrEmpty(m_LunarDayText))
                    m_LunarDayText = ChineseDayName[this.LunarDay - 1];
                return m_LunarDayText;
            }
        }

        #endregion

        /// <summary>
        /// 根据指定阳历日期计算星座＆诞生石
        /// </summary>
        /// <param name="date">指定阳历日期</param>
        /// <param name="constellation">星座</param>
        /// <param name="birthstone">诞生石</param>
        public static void CalcConstellation(DateTime date, out string constellation, out string birthstone)
        {
            int i = date.ToString("MMdd").ToInt();
            int j;
            if (i >= 321 && i <= 419)
                j = 0;
            else if (i >= 420 && i <= 520)
                j = 1;
            else if (i >= 521 && i <= 621)
                j = 2;
            else if (i >= 622 && i <= 722)
                j = 3;
            else if (i >= 723 && i <= 822)
                j = 4;
            else if (i >= 823 && i <= 922)
                j = 5;
            else if (i >= 923 && i <= 1023)
                j = 6;
            else if (i >= 1024 && i <= 1121)
                j = 7;
            else if (i >= 1122 && i <= 1221)
                j = 8;
            else if (i >= 1222 || i <= 119)
                j = 9;
            else if (i >= 120 && i <= 218)
                j = 10;
            else if (i >= 219 && i <= 320)
                j = 11;
            else
            {
                constellation = "未知星座";
                birthstone = "未知诞生石";
                return;
            }
            constellation = Constellations[j];
            birthstone = BirthStones[j];
        }


        #region 阴历转阳历

        /// <summary>
        /// 获取指定年份春节当日（正月初一）的阳历日期
        /// </summary>
        /// <param name="year">指定的年份</param>
        private static DateTime GetLunarNewYearDate(int year)
        {
            DateTime dt = new DateTime(year, 1, 1);
            int cnYear = calendar.GetYear(dt);
            int cnMonth = calendar.GetMonth(dt);

            int num1 = 0;
            int num2 = calendar.IsLeapYear(cnYear) ? 13 : 12;

            while (num2 >= cnMonth)
            {
                num1 += calendar.GetDaysInMonth(cnYear, num2--);
            }

            num1 = num1 - calendar.GetDayOfMonth(dt) + 1;
            return dt.AddDays(num1);
        }

        /// <summary>
        /// 阴历转阳历
        /// </summary>
        /// <param name="year">阴历年</param>
        /// <param name="month">阴历月</param>
        /// <param name="day">阴历日</param>
        /// <param name="IsLeapMonth">是否闰月</param>
        public static DateTime GetDateFromLunarDate(int year, int month, int day, bool IsLeapMonth)
        {
            if (year < 1902 || year > 2100)
                throw new Exception("只支持1902～2100期间的农历年");
            if (month < 1 || month > 12)
                throw new Exception("表示月份的数字必须在1～12之间");

            if (day < 1 || day > calendar.GetDaysInMonth(year, month))
                throw new Exception("农历日期输入有误");

            int num1 = 0, num2 = 0;
            int leapMonth = calendar.GetLeapMonth(year);

            if (((leapMonth == month + 1) && IsLeapMonth) || (leapMonth > 0 && leapMonth <= month))
                num2 = month;
            else
                num2 = month - 1;

            while (num2 > 0)
            {
                num1 += calendar.GetDaysInMonth(year, num2--);
            }

            DateTime dt = GetLunarNewYearDate(year);
            return dt.AddDays(num1 + day - 1);
        }

        /// <summary>
        /// 阴历转阳历
        /// </summary>
        /// <param name="date">阴历日期</param>
        /// <param name="IsLeapMonth">是否闰月</param>
        public static DateTime GetDateFromLunarDate(DateTime date, bool IsLeapMonth)
        {
            return GetDateFromLunarDate(date.Year, date.Month, date.Day, IsLeapMonth);
        }

        #endregion

        #region 从阴历创建日历

        /// <summary>
        /// 从阴历创建日历实体
        /// </summary>
        /// <param name="year">阴历年</param>
        /// <param name="month">阴历月</param>
        /// <param name="day">阴历日</param>
        /// <param name="IsLeapMonth">是否闰月</param>
        public static ChineseCalendarInfo FromLunarDate(int year, int month, int day, bool IsLeapMonth)
        {
            DateTime dt = GetDateFromLunarDate(year, month, day, IsLeapMonth);
            return new ChineseCalendarInfo(dt);
        }
        /// <summary>
        /// 从阴历创建日历实体
        /// </summary>
        /// <param name="date">阴历日期</param>
        /// <param name="IsLeapMonth">是否闰月</param>
        public static ChineseCalendarInfo FromLunarDate(DateTime date, bool IsLeapMonth)
        {
            return FromLunarDate(date.Year, date.Month, date.Day, IsLeapMonth);
        }

        /// <summary>
        /// 从阴历创建日历实体
        /// </summary>
        /// <param name="date">表示阴历日期的8位数字，例如：20070209</param>
        /// <param name="IsLeapMonth">是否闰月</param>
        public static ChineseCalendarInfo FromLunarDate(string date, bool IsLeapMonth)
        {
            Regex rg = new System.Text.RegularExpressions.Regex(@"^\d{7}(\d)$");
            Match mc = rg.Match(date);
            if (!mc.Success)
            {
                throw new Exception("日期字符串输入有误！");
            }
            DateTime dt = DateTime.Parse(string.Format("{0}-{1}-{2}", date.Substring(0, 4), date.Substring(4, 2), date.Substring(6, 2)));
            return FromLunarDate(dt, IsLeapMonth);
        }


        #endregion

        private static ChineseLunisolarCalendar calendar = new ChineseLunisolarCalendar();
        public const string ChineseNumber = "〇一二三四五六七八九";
        public const string CelestialStem = "甲乙丙丁戊己庚辛壬癸";
        public const string TerrestrialBranch = "子丑寅卯辰巳午未申酉戌亥";
        public const string Animals = "鼠牛虎兔龙蛇马羊猴鸡狗猪";
        public static readonly string[] ChineseWeekName = new string[] { "星期天", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六" };
        public static readonly string[] ChineseDayName = new string[] {
            "初一","初二","初三","初四","初五","初六","初七","初八","初九","初十",
            "十一","十二","十三","十四","十五","十六","十七","十八","十九","二十",
            "廿一","廿二","廿三","廿四","廿五","廿六","廿七","廿八","廿九","三十"};
        public static readonly string[] ChineseMonthName = new string[] { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二" };
        public static readonly string[] Constellations = new string[] { "白羊座", "金牛座", "双子座", "巨蟹座", "狮子座", "处女座", "天秤座", "天蝎座", "射手座", "摩羯座", "水瓶座", "双鱼座" };
        public static readonly string[] BirthStones = new string[] { "钻石", "蓝宝石", "玛瑙", "珍珠", "红宝石", "红条纹玛瑙", "蓝宝石", "猫眼石", "黄宝石", "土耳其玉", "紫水晶", "月长石，血石" };
    }
}
