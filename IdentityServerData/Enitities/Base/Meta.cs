﻿using System;

namespace IdentityServerData.Enitities.Base
{
    public class Meta
    {
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public DateTime? Deleted { get; set; }

        public Meta()
        {
            Updated = Created = DateTime.UtcNow;
        }
    }
}
