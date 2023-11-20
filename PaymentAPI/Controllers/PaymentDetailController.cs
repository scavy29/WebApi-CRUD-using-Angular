using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using PaymentAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using Microsoft.Extensions.Logging;

namespace PaymentAPI.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    // [Route("api/Payment")]
    [ApiController]
    public class PaymentDetailController : ControllerBase
    {
        // private readonly ILogger<PaymentDetailController> _logger;

        // public PaymentDetailController(ILogger<PaymentDetailController> logger)
        // {
        //     _logger = logger;
        // }

        private PaymentDetailContext db;
        public PaymentDetailController(PaymentDetailContext _context)
        {
            this.db=_context;
        }

        [HttpGet("GetPaymentDetail")]
        public IActionResult GetPaymentDetail()
        {
            var list=db.PaymentDetails;
            if(list!=null)
            {
                return Ok(list);
            }
            return NotFound();
        }

        [HttpGet("GetPaymentDetail/{id}")]
        public IActionResult GetPaymentDetail(int id)
        {
            if(db.PaymentDetails==null)
            {
                return NotFound();
            }
            var gpd=db.PaymentDetails.Find(id);
            if(gpd==null)
            {
                return NotFound();
            }   
            return Ok(gpd);
        }

        [HttpPost]
        [Route("PostPaymentDetail")]
        public IActionResult PostPaymentDetail(PaymentDetail pd)
        {
            db.PaymentDetails.Add(pd);
            db.SaveChanges();
            return Ok();
        }

        [HttpPut("UpdatePaymentDetail/{id}")]
        public IActionResult UpdatePaymentDetail(int id,PaymentDetail pd)
        {
            var u=db.PaymentDetails.FirstOrDefault(c=>c.PaymentDetailId==id);
            if(u!=null)
            {
                u.CardOwnerName=pd.CardOwnerName;
                u.CardNumber=pd.CardNumber;
                u.ExpirationDate=pd.ExpirationDate;
                u.SecurityCode=pd.SecurityCode;
                db.SaveChanges();
                return Ok(pd);
            }
            return NotFound();
        }

        [HttpDelete("DeletePaymentDetail/{id}")]
        public IActionResult DeletePaymentDetail(int id)
        {
            var pd=db.PaymentDetails.Find(id);
            if(pd!=null)
            {
                db.Remove(pd);
                db.SaveChanges();
                return Ok();
            }
            return NotFound();
        }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View("Error!");
        // }
    }
}