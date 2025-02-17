﻿using ParkInspect.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Data;

namespace ParkInspect.Repository.Entity
{
    public class EntityRegionRepository : IRegionRepository
    {
        private readonly ParkInspectEntities _context;
        private readonly ObservableCollection<string> _regions;

        public EntityRegionRepository(ParkInspectEntities context)
        {
            _context = context;
            _regions = new ObservableCollection<string>();
        }

        public bool Add(string item)
        {
            // TODO deze function implementeren of weggooien
            throw new NotImplementedException();

        }

        public bool Delete(string item)
        {
            // TODO deze function implementeren of weggooien
            throw new NotImplementedException();
        }

        public ObservableCollection<string> GetAll()
        {
            // TODO deze function implementeren of weggooien
            _regions.Clear();
            _context.Region.ToList().ForEach(r => _regions.Add(r.RegionName));
            return _regions;
        }

        public bool Update(string item)
        {
            // TODO deze function implementeren of weggooien
            throw new NotImplementedException();
        }
    }
}
