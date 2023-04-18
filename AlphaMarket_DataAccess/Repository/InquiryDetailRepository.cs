using AlphaMarket_DataAccess.Data;
using AlphaMarket_DataAccess.Repository.IRepository;
using AlphaMarket_Models;
using AlphaMarket_Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphaMarket_DataAccess.Repository
{
    public class InquiryDetailRepository : Repository<InquiryDetails>, IInquiryDetailRepository
    {
        private readonly ApplicationDbContext _db;
        public InquiryDetailRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        

        public void Update(InquiryDetails obj)
        {
            _db.InquiryDetails.Update(obj);
        }
    }
}
