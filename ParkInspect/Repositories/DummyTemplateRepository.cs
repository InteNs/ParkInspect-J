using System;
using System.Collections.Generic;
using ParkInspect.ViewModel;

namespace ParkInspect.Repositories
{
    public class DummyTemplateRepository : ITemplateRepository
    {
        public TemplateViewModel Find(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TemplateViewModel> All()
        {
            throw new NotImplementedException();
        }

        public TemplateViewModel Create(TemplateViewModel template)
        {
            throw new NotImplementedException();
        }

        public TemplateViewModel Update(TemplateViewModel template)
        {
            throw new NotImplementedException();
        }
    }
}
