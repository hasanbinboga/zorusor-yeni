using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanYonetim.Codes
{
    public delegate void AddEntityHandler<T>(T Entity, string Mesaj);
    public delegate void EditEntityHandler<T>(T oldEntity, T NewEntity, string Mesaj);
}
