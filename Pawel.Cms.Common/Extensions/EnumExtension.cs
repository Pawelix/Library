using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Pawel.Cms.Common.Enums;

namespace Pawel.Cms.Common.Extensions
{
    public static class EnumExtension
    {
        /// <summary>
        ///     A generic extension method that aids in reflecting 
        ///     and retrieving any attribute that is applied to an `Enum`.
        /// </summary>
        public static TDupe GetXXX<TDupe>(this BookType  enumValue) where TDupe : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TDupe>();
        }
    }
}
