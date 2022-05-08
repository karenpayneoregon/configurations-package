using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShadowProperties.Data;
using ShadowProperties.Models;

namespace HasQueryFilterApp.Classes
{
    public class Operations
    {
        public static void Remove(Contact1 contact1)
        {
            using var context = new ShadowContext();
            context.Add(contact1).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public static List<Contact1> Contacts()
        {
            using var context = new ShadowContext();
            return context.Contacts1.ToList();
        }
    }
}
