using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Contacts
{
    internal interface IContactsRepository
    {
        DataTable SelectAll();
        DataTable SelectRow(int contactid);
        DataTable Search(string parameter);
        bool Insert(string Name, string Family, int Age, string Mobile, string Email, string Address);
        bool Update(int contactId, string Name, string Family, int Age, string Mobile, string Email, string Address);
        bool Delete(int contactId);

    }
}
