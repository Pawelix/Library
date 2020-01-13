using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Pawel.Cms.Common.Enums
{
    public enum BookType
    {
        [Display(Name ="fajna gazeta")]
        NewspaperCodzienna = 1,

        [Display(Name = "fajna encyklopedia !")]
        Encyclopedia = 2,
        Type3 = 3,
        Type4 = 4
    }
}
