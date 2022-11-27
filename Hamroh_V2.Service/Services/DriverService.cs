using AutoMapper;
using Hamroh_V2.Data.IRepositories;
using Hamroh_V2.Domain.Commons;
using Hamroh_V2.Domain.Entities.Drivers;
using Hamroh_V2.Service.DTOs.DriverDTO;
using Hamroh_V2.Service.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Services
{
    public class DriverService : IDriverService
    {
        private IUnitOfWork unitOfWork;
        private IMapper mapper;
        private IConfiguration config;
        private IWebHostEnvironment env;

        //Constuctor
        public DriverService(IUnitOfWork unitOfWork, IMapper mapper, IWebHostEnvironment env,IConfiguration config)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.env = env;
            this.config = config;
        }

        /// <summary>
        /// The sectionthat stores data to the server
        /// </summary>
        /// <param name="driverDto"></param>
        /// <returns></returns>
        public async Task<BaseResponse<Driver>> CreateAsync(DriverForCreationDto driverDto)
        {
            BaseResponse<Driver> response = new BaseResponse<Driver>();

            Driver mappedDriver = mapper.Map<Driver>(driverDto);

            mappedDriver.CarImage = await SaveFileAsync(driverDto.CarImage.OpenReadStream(), driverDto.CarImage.FileName);
            mappedDriver.DriverImage = await SaveFileAsync(driverDto.DriverImage.OpenReadStream(), driverDto.DriverImage.FileName);

            Driver result = await unitOfWork.Drivers.CreateAsync(mappedDriver);

            result.CarImage = "https://localhost:5001/Images/" + result.CarImage;
            result.DriverImage = "https://localhost:5001/Images/" + result.DriverImage;

            response.Data = result;

            return response;
        }

        /// <summary>
        /// this is used to delete unnecessary data from the database
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAsync(Expression<Func<Driver, bool>> pred)
        {
            return await unitOfWork.Drivers.DeleteAsync(pred);
        }

        /// <summary>
        /// We use it to get the necessary all information from the database
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        public IEnumerable<Driver> GetAll(Expression<Func<Driver, bool>> pred = null)
        {
            return unitOfWork.Drivers.GetAll(pred);
        }

        /// <summary>
        /// We use it to get the necessary information from the database
        /// </summary>
        /// <param name="pred"></param>
        /// <returns></returns>
        public async Task<Driver> GetAsync(Expression<Func<Driver, bool>> pred)
        {
            return await unitOfWork.Drivers.GetAsync(pred);
        }

        /// <summary>
        /// This is used to change the data from the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="driverDto"></param>
        /// <returns></returns>
        public async Task<Driver> UpdateAsync(long id, DriverForCreationDto driverDto)
        {
            var driver = await unitOfWork.Drivers.GetAsync(p => p.Id == id);

            if (driver != null)
            {
                driver.FullName = driverDto.FullName;
                driver.PhoneNumber = driverDto.PhoneNumber;
                driver.CarName = driverDto.CarName;
                //driver.CarImage = driverDto.CarImage;
                //driver.DriverImage = driverDto.DriverImage;
            }
            return await unitOfWork.Drivers.UpdateAsync(driver);
        }

        /// <summary>
        /// This partition is used to store file data i.e. videos, images, etc
        /// </summary>
        /// <param name="file"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public async Task<string> SaveFileAsync(Stream file, string fileName)
        {
            fileName = Guid.NewGuid().ToString("N") + "_" + fileName;
            string storagePath = config.GetSection("Storage:ImageUrl").Value;
            string filePath = Path.Combine(env.WebRootPath, $"{storagePath}/{fileName}");
            FileStream mainFile = File.Create(filePath);
            await file.CopyToAsync(mainFile);
            mainFile.Close();

            return fileName;
        }
    }
}
