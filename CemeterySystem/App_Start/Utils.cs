using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;

namespace CemeterySystem.App_Start
{
    public class Utils
    {
        public static void populateDropdownWithEnum(Type enumType, DropDownList dropDownList)
        {
            int i = 0;
            foreach (string enumValueName in Enum.GetNames(enumType))
            {
                MemberInfo[] memInfo = enumType.GetMember(enumValueName);
                string name = "";
                if (memInfo != null && memInfo.Length > 0)
                {
                    object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    
                    if (attrs != null && attrs.Length > 0)
                    {
                        name = ((DescriptionAttribute)attrs[0]).Description;
                    }

                    if (string.IsNullOrEmpty(name))
                    {
                        name = "---";
                    }
                }

                dropDownList.Items.Add(new ListItem(name, ((int)(Enum.GetValues(enumType).GetValue(i++))).ToString()));                
            }
        }
    }
}