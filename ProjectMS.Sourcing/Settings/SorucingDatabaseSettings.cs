﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMS.Sourcing.Settings
{
    public class SorucingDatabaseSettings : ISourcingDatabaseSettings
    {
        public string ConnectionString { get ; set ; }
        public string DatabaseName { get ; set; }
    }
}
