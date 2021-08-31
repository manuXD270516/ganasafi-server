using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.helpers.HelpersDatabase;

namespace Domain
{
    public class AuditableBaseEntity
    {

        [Key]
        public int id { get; set; }

        public string registrationUser { get; set; }

        public DateTime? registrationDate { get; set; }

        public string modificationUser { get; set; }

        public DateTime? modificationDate { get; set; }

        public string state { get; set; }

        public long tzLock { get; set; }

        public AuditableBaseEntity()
        {
            /*if (id == ID_FOR_CREATE)
            {
                registrationDate = DateTime.UtcNow;
                registrationUser = "root";
                state = "A";
            } else
            {
                if (state.Equals("I"))
                {
                    tzLock = 100000000; // Temp
                }      
            }
            modificationUser = "root";
            modificationDate = DateTime.UtcNow;*/
            // Temp
        }





    }
}
