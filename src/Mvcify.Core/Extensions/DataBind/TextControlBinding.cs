//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace MVCify.Extensions.DataBind
//{
//    public static class TextControlBinding
//    {
//        public static IMJValidate<T, string> TextBindTo<T>(this Control ctl, Expression<Func<T, string>> m)
//        {
//            var type = typeof(T);
//            var fv = Activator.CreateInstance<MtoCtl<T, string>>();
//            fv.obj = ctl;
//            fv.func = m.Compile();

//            var expression = GetMemberInfo(m);

//            fv.MemberName = expression == null ? null : expression.Member.Name;

//            if (txtforDict.ContainsKey(type))
//                txtforDict[type].Add(fv);
//            else
//            {
//                List<dynamic> list = new List<dynamic>();
//                list.Add(fv);
//                txtforDict.Add(type, list);
//            }

//            return fv;
//        }
//    }
//}
