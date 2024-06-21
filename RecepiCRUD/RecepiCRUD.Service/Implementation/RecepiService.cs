using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using RecepiCRUD.Entity;
using RecepiCRUD.Service.Interfaces;
using RecepiCRUD.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RecepiCRUD.Service.Implementation
{
    public class RecepiService : IRecepiService
    {
        private readonly RecepiContext _dbContext;
        private readonly string[] ACCEPTED_FILE_TYPES = new[] { ".jpg", ".jpeg", ".png" };

        public RecepiService(RecepiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ResponseVM AddRecepi(RecepiVM recepiVM)
        {

            ResponseVM responseVM = new ResponseVM();

            //if (file.Length == 0 || file != null)
            //{
            //    responseVM.IsSuccess = false;
            //    responseVM.Message = "File not found";
            //    return responseVM;
            //}

            //if (!ACCEPTED_FILE_TYPES.Any(s => s == Path.GetExtension(file.FileName).ToLower()))
            //{
            //    responseVM.IsSuccess = false;
            //    responseVM.Message = "File format not proper";
            //    return responseVM;
            //}
            //var uploadFilesPath = Path.Combine(host.WebRootPath, "RecepiImages");
            //if (!Directory.Exists(uploadFilesPath))
            //    Directory.CreateDirectory(uploadFilesPath);
            //var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            //var filePath = Path.Combine(uploadFilesPath, fileName);
            //using (var stream = new FileStream(filePath, FileMode.Create))
            //{
            //    file.CopyTo(stream);
            //}

            if (recepiVM != null)
            {
                if (recepiVM.RecepiId > 0)
                {
                    var data = new Recepi
                    {
                        RecepiId = recepiVM.RecepiId,
                        RecepiName = recepiVM.RecepiName,
                        RecepiDesc = recepiVM.RecepiDesc
                        //RecepiImage = fileName
                    };

                    _dbContext.Recepies.Update(data);
                }
                else
                {
                    var data = new Recepi
                    {
                        RecepiName = recepiVM.RecepiName,
                        RecepiDesc = recepiVM.RecepiDesc
                        //RecepiImage = fileName
                    };

                    _dbContext.Recepies.Add(data);
                }

                _dbContext.SaveChanges();
            }

            responseVM.IsSuccess = true;
            responseVM.Message = "Recepi added successfully";
            return responseVM;
        }

        public ResponseVM GetRecepi()
        {
            ResponseVM responseVM = new ResponseVM();
            var recepies = _dbContext.Recepies.ToList();

            if (recepies.Count() > 0)
            {
                responseVM.Content = recepies;
                responseVM.IsSuccess = true;
                responseVM.Message = "Success";
            }
            else
            {
                responseVM.Content = null;
                responseVM.IsSuccess = false;
                responseVM.Message = "Failed";
            }

            return responseVM;

        }

        public ResponseVM GetRecepiById(int Id)
        {
            ResponseVM responseVM = new ResponseVM();
            var recepies = _dbContext.Recepies.SingleOrDefault(s=>s.RecepiId == Id);

            if (recepies != null)
            {
                responseVM.Content = recepies;
                responseVM.IsSuccess = true;
                responseVM.Message = "Success";
            }
            else
            {
                responseVM.Content = null;
                responseVM.IsSuccess = false;
                responseVM.Message = "Failed";
            }

            return responseVM;

        }

        public ResponseVM DeleteRecepi(int Id)
        {
            ResponseVM responseVM = new ResponseVM();
            if (Id > 0)
            {
                var recepi = _dbContext.Recepies.SingleOrDefault(s => s.RecepiId == Id);
                if (recepi != null)
                {
                    _dbContext.Remove(recepi);
                    _dbContext.SaveChanges();
                    responseVM.IsSuccess = true;
                    responseVM.Content = null;
                    responseVM.Message = "Recepi Deleted Sucessfully!";
                }
                else
                {
                    responseVM.IsSuccess = false;
                    responseVM.Content = null;
                    responseVM.Message = "Recepi Not Found!";
                }
            }
            else
            {
                responseVM.IsSuccess = false;
                responseVM.Content = null;
                responseVM.Message = "Id Not Found";
            }
            return responseVM;
        }
    }
}
