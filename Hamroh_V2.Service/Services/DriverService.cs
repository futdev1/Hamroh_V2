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
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hamroh_V2.Service.Services
{
    public class DriverService : IDriverService
    {
        internal IDriverRepository driverRepository;
        internal IMapper mapper;
        internal IConfiguration config;
        internal IWebHostEnvironment env;

        public DriverService(IDriverRepository driverRepository, IMapper mapper, IWebHostEnvironment env)
        {
            this.driverRepository = driverRepository;
            this.mapper = mapper;   
            this.env = env;
        }
        public async Task<BaseResponse<Driver>> CreateAsync(DriverForCreationDto driverDto)
        {
            BaseResponse<Driver> response = new BaseResponse<Driver>();
            
            Driver mappedDriver = mapper.Map<Driver>(driverDto);

            mappedDriver.CarImage = await SaveFileAsync(driverDto.CarImage.OpenReadStream(), driverDto.CarImage.FileName);
            mappedDriver.DriverImage = await SaveFileAsync(driverDto.DriverImage.OpenReadStream(), driverDto.DriverImage.FileName);

            Driver result = await driverRepository.CreateAsync(mappedDriver);

            result.CarImage = "https://localhost:5001/Images/" + result.CarImage;
            result.DriverImage = "https://localhost:5001/Images/" + result.DriverImage;

            response.Data = result;

            return response;
        }

        public async Task<bool> DeleteAsync(Expression<Func<Driver, bool>> pred)
        {
            return await driverRepository.DeleteAsync(pred);
        }

        public IEnumerable<Driver> GetAll(Expression<Func<Driver, bool>> pred = null)
        {
            return driverRepository.GetAll(pred);
        }

        public async Task<Driver> GetAsync(Expression<Func<Driver, bool>> pred)
        {
            return await driverRepository.GetAsync(pred);
        }

        public async Task<Driver> UpdateAsync(long id, DriverForCreationDto driverDto)
        {
            var driver = await driverRepository.GetAsync(p => p.Id == id);

            if(driver != null)
            {
                driver.FullName = driverDto.FullName;
                driver.PhoneNumber = driverDto.PhoneNumber;
                driver.CarName = driverDto.CarName;
                //driver.CarImage = driverDto.CarImage;
                //driver.DriverImage = driverDto.DriverImage;
            }
            return await driverRepository.UpdateAsync(driver);
        }

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
