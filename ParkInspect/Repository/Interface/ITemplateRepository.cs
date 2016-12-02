using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParkInspect.ViewModel;

namespace ParkInspect.Repositories
{
    public interface ITemplateRepository
    {
        TemplateViewModel Find(int id);
        IEnumerable<TemplateViewModel> All();
        TemplateViewModel Create(TemplateViewModel template);
        TemplateViewModel Update(TemplateViewModel template);

    }
}
