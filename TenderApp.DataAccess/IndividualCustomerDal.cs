using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Core.DataAccess;
using TenderApp.DataAccess.Abstract;
using TenderApp.DataAccess.Context;
using TenderApp.Entities;

namespace TenderApp.DataAccess
{
    public class IndividualCustomerDal:BaseRepository<IndividualCustomer,TenderAppContext>,IIndividualCustomerDal
    {

    }
}
