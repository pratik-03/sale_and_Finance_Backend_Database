using ExcelDataReader;
using Sales_and_Finance.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Sales_and_Finance.Controllers
{
    public class FinancesController : ApiController
    {

        [HttpPost]
        public string ExcelUpload()
        {
            string message = "";
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;
            using (ApplicationDbContext db = new ApplicationDbContext())
            {

                if (httpRequest.Files.Count > 0)
                {
                    HttpPostedFile file = httpRequest.Files[0];
                    Stream stream = file.InputStream;

                    IExcelDataReader reader = null;

                    if (file.FileName.EndsWith(".xls"))
                    {
                        reader = ExcelReaderFactory.CreateBinaryReader(stream);
                    }
                    else if (file.FileName.EndsWith(".xlsx"))
                    {
                        reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }
                    else
                    {
                        message = "This file format is not supported";
                    }

                    DataSet excelRecords = reader.AsDataSet();
                    reader.Close();

                    var finalRecords = excelRecords.Tables[0];
                    for (int i = 0; i < finalRecords.Rows.Count; i++)
                    {
                        Finance finance = new Finance();
                        finance.Date = finalRecords.Rows[i][0].ToString();
                        finance.Party = finalRecords.Rows[i][1].ToString();
                        finance.Debit = finalRecords.Rows[i][2].ToString();
                        finance.Credit = finalRecords.Rows[i][3].ToString();
                        finance.Balance = finalRecords.Rows[i][4].ToString();


                        db.Finances.Add(finance);

                    }

                    int output = db.SaveChanges();
                    if (output > 0)
                    {
                        message = "Excel file has been successfully uploaded";
                    }
                    else
                    {
                        message = "Excel file uploaded has fiald";
                    }

                }

                else
                {
                    result = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            return message;
        }

        [HttpGet]
        public List<Finance> getSale()
        {
            List<Finance> finances = new List<Finance>();
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                finances = db.Finances.ToList();
            }
            return finances;
        }

    }
}
