
using JricaStudioWebApi.Models.Dtos;
using JricaStudioWebApi.Entities;
using JricaStudioWebApi.Models.Dtos.Admin;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Protocol.Plugins;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using JricaStudioWebApi.Models.Dtos.Admin.BusinessHours;
using JricaStudioWebApi.Models.Dtos.BusinessHours;

namespace JricaStudioWebApi.Extentions
{
    public static class DtoConversions
    {


        #region Product
        public static IEnumerable<ProductDto> ConvertToDtos(this IEnumerable<Product> products, Dictionary<Guid, string> productImageData)
        {
            var dtos = new List<ProductDto>();

            foreach (var product in products)
            {
                var imageData = productImageData[product.Id];

                dtos.Add(product.ConvertToDto(imageData));
            }

            return dtos;
        }

        public static ProductDto ConvertToDto(this Product product, string ImageData)
        {
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                CategoryId = product.ProductCategoryId,
                CategoryName = product.ProductCategory.Name,
                ImageData = ImageData

            };
        }

        public static ProductDto ConvertToDto(this Product product, ProductCategory productCategory)
        {
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Quantity = product.Quantity,
                CategoryId = productCategory.Id,
                CategoryName = productCategory.Name
            };
        }


        public static Product ConvertToEntity(this ProductToAddDto productToAddDto)
        {
            return new Product()
            {
                Name = productToAddDto.Name,
                Description = productToAddDto.Description,
                Price = productToAddDto.Price,
                ProductCategoryId = productToAddDto.ProductCategoryid,
                Quantity = productToAddDto.Quantity,
            };
        }

        public static Product ConvertToEntity(this ProductUpdateDto productUpdateDto, Guid id)
        {
            return new Product()
            {
                Id = id,
                Name = productUpdateDto.Name,
                Description = productUpdateDto.Description,
                Price = productUpdateDto.Price,
                ProductCategoryId = productUpdateDto.ProductCategoryId,
            };
        }

        public static AdminProductDto ConvertToAdminDto(this Product product)
        {
            return new AdminProductDto
            {
                CategoryId = product.ProductCategoryId,
                Id = product.Id,
                Created = product.Created,
                Name = product.Name,
                Price = product.Price
            };
        }

        public static IEnumerable<AdminProductDto> ConvertToAdminDtos(this IEnumerable<Product> products)
        {
            var dtos = new List<AdminProductDto>();
            foreach (var item in products)
            {
                dtos.Add(item.ConvertToAdminDto());
            }

            return dtos;
        }

        #endregion

        #region Service

        public static PreviousServiceDto ConvertToPreviousServiceDto(this Service service)
        {
            return new PreviousServiceDto
            {
                Id = service.Id
            };
        }

        public static AdminEditServiceDto ConvertToEditDto(this Service service)
        {
            return new AdminEditServiceDto
            {
                ServiceCategoryId = service.ServiceCategoryId,
                Name = service.Name,
                Description = service.Description,
                Duration = service.Duration,
                Price = service.Price,
            };
        }

        public static AdminServiceToAddDto<IFormFile> ConvertToDto(this Service entity)
        {
            return new AdminServiceToAddDto<IFormFile>()
            {
                Name = entity.Name,
                Description = entity.Description,
                Price = entity.Price,
                Duration = entity.Duration,
                ServiceCategoryId = entity.ServiceCategoryId,
            };
        }

        public static Service ConvertToEntity(this AdminServiceToAddDto<IFormFile> serviceDto, Guid ImageUploadId)
        {
            return new Service()
            {
                Name = serviceDto.Name,
                Description = serviceDto.Description,
                Price = serviceDto.Price,
                Duration = serviceDto.Duration,
                ServiceCategoryId = serviceDto.ServiceCategoryId,
                ImageUploadId = ImageUploadId
            };
        }

        public static ServiceDto ConvertToDto(this Service service, ServiceCategory serviceCategories, string imageData)
        {
            return new ServiceDto()
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                ImageData = imageData,
                Price = service.Price,
                Duration = service.Duration,
                ServiceCategoryId = service.ServiceCategoryId,
                CategoryName = serviceCategories.Name
            };
        }

        public static IEnumerable<ServiceDto> ConvertToDto(this IEnumerable<Service> services, IEnumerable<ServiceCategory> serviceCategories, Dictionary<Guid, string> imageData)
        {
            var dtos = new List<ServiceDto>();

            foreach (var item in services)
            {
                dtos.Add(new ServiceDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    ImageData = imageData.Single(u => u.Key == item.Id).Value,
                    Price = item.Price,
                    ServiceCategoryId = item.ServiceCategoryId,
                    CategoryName = serviceCategories.Single(n => n.Id == item.ServiceCategoryId).Name,
                    Duration = item.Duration

                });
            }
            return dtos;

        }
        #endregion

        #region AppointmentService

        public static AppointmentServiceDto ConvertToDto(this AppointmentService appointmentService)

        {
            return new AppointmentServiceDto()
            {
                Id = appointmentService.Id,
                ServiceId = appointmentService.Service.Id,
                ServiceName = appointmentService.Service.Name,
                ServiceDescription = appointmentService.Service.Description,
                Duration = appointmentService.Service.Duration,
                Price = appointmentService.Service.Price,
                AppointmentId = appointmentService.AppointmentId
            };
        }

        public static AppointmentServiceDto ConvertToImageDto(this AppointmentService appointmentService, string imageData)

        {
            return new AppointmentServiceDto()
            {
                Id = appointmentService.Id,
                ServiceId = appointmentService.Service.Id,
                ServiceName = appointmentService.Service.Name,
                ServiceDescription = appointmentService.Service.Description,
                ServiceImagePath = imageData,
                Duration = appointmentService.Service.Duration,
                Price = appointmentService.Service.Price,
                AppointmentId = appointmentService.AppointmentId
            };
        }

        public static AppointmentServiceDto ConvertToFinalizationDto(this AppointmentService appointmentService, string imageData)

        {
            return new AppointmentServiceDto()
            {
                Id = appointmentService.Id,
                ServiceId = appointmentService.Service.Id,
                ServiceName = appointmentService.Service.Name,
                ServiceDescription = appointmentService.Service.Description,
                ServiceImagePath = imageData,
                Duration = appointmentService.Service.Duration,
                Price = appointmentService.Service.Price,
                AppointmentId = appointmentService.AppointmentId
            };
        }

        public static IEnumerable<AppointmentServiceDto> ConvertToImageDtos(this IEnumerable<AppointmentService> appointmentServices, Dictionary<Guid, string> serviceImageData)
        {
            var dtos = new List<AppointmentServiceDto>();
            foreach (var appointmentService in appointmentServices)
            {
                var singleServiceImageData = serviceImageData[appointmentService.ServiceId];
                dtos.Add(appointmentService.ConvertToImageDto(singleServiceImageData));
            }
            return dtos;
        }

        public static IEnumerable<AppointmentServiceDto> ConvertToDto(this IEnumerable<AppointmentService> appointmentServices)
        {
            var dtos = new List<AppointmentServiceDto>();
            foreach (var appointmentService in appointmentServices)
            {
                dtos.Add(appointmentService.ConvertToDto());
            }
            return dtos;
        }

        public static IEnumerable<AppointmentServiceDto> ConvertToAdminDto(this IEnumerable<AppointmentService> appointmentServices)
        {
            var dtos = new List<AppointmentServiceDto>();
            foreach (var appointmentService in appointmentServices)
            {
                dtos.Add(appointmentService.ConvertToDto());
            }
            return dtos;
        }

        public static IEnumerable<AppointmentServiceDto> ConvertToFinalizationDto(this IEnumerable<AppointmentService> appointmentServices, Dictionary<Guid, string> serviceImageData)
        {
            var dtos = new List<AppointmentServiceDto>();
            foreach (var appointmentService in appointmentServices)
            {
                var singleServieImageData = serviceImageData[appointmentService.ServiceId];

                dtos.Add(appointmentService.ConvertToFinalizationDto(singleServieImageData));
            }
            return dtos;
        }

        #endregion

        #region AppointmentProduct

        public static AppointmentProductDto ConvertToDto(this AppointmentProduct appointmentProduct)
        {
            return new AppointmentProductDto()
            {
                Id = appointmentProduct.Id,
                ProductId = appointmentProduct.Product.Id,
                ProductName = appointmentProduct.Product.Name,
                ProductDescription = appointmentProduct.Product.Description,
                Quantity = appointmentProduct.Quantity,
                Price = appointmentProduct.Product.Price,
                AppointmentId = appointmentProduct.AppointmentId
            };
        }

        public static AppointmentProductDto ConvertToDto(this AppointmentProduct appointmentProduct, string ImageData)
        {
            return new AppointmentProductDto()
            {
                Id = appointmentProduct.Id,
                ProductId = appointmentProduct.Product.Id,
                ProductName = appointmentProduct.Product.Name,
                ProductDescription = appointmentProduct.Product.Description,
                Quantity = appointmentProduct.Quantity,
                Price = appointmentProduct.Product.Price,
                AppointmentId = appointmentProduct.AppointmentId,
                ProductImagePath = ImageData

            };
        }

        public static IEnumerable<AppointmentProductDto> ConvertToImageDtos(this IEnumerable<AppointmentProduct> appointmentProducts, Dictionary<Guid, string>
           imageData)
        {
            var dtos = new List<AppointmentProductDto>();
            foreach (var appointmentProduct in appointmentProducts)
            {
                var image = imageData[appointmentProduct.ProductId];
                dtos.Add(appointmentProduct.ConvertToDto(image));
            }
            return dtos;
        }

        public static IEnumerable<AppointmentProductDto> ConvertToDtos(this IEnumerable<AppointmentProduct> appointmentProducts)
        {
            var dtos = new List<AppointmentProductDto>();
            foreach (var appointmentProduct in appointmentProducts)
            {
                dtos.Add(appointmentProduct.ConvertToDto());
            }
            return dtos;
        }

        #endregion

        #region ServiceCategory

        public static IEnumerable<AdminServiceCategoryDto> ConvetToDtos(this IEnumerable<ServiceCategory> categories)
        {
            var newList = new List<AdminServiceCategoryDto>();

            foreach (var category in categories)
            {
                newList.Add(category.ConvertToDo());
            }

            return newList;
        }

        public static AdminServiceCategoryDto ConvertToDo(this ServiceCategory category)
        {
            return new AdminServiceCategoryDto()
            {
                Id = category.Id,
                Name = category.Name,
            };

        }

        public static IEnumerable<ServiceAdminPageDto> ConvertToAdminDtos(this IEnumerable<Service> services)
        {
            var dtos = new List<ServiceAdminPageDto>();
            foreach (var service in services)
            {
                dtos.Add(service.ConvertToAdminDto());
            }
            return dtos;
        }

        public static ServiceAdminPageDto ConvertToAdminDto(this Service service)
        {
            return new ServiceAdminPageDto()
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                ServiceCategoryId = service.ServiceCategoryId,
                Created = service.Created,
                Duration = service.Duration,
                Price = service.Price
            };
        }

        public static ServiceAdminPageDto ConvertToAdminImageDto(this Service service, string imageData)
        {
            return new ServiceAdminPageDto()
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                ServiceCategoryId = service.ServiceCategoryId,
                Created = service.Created,
                Duration = service.Duration,
                ImageData = imageData,
                Price = service.Price
            };
        }

        #endregion

        #region ProductCategory

        public static IEnumerable<AdminProductCategoryDto> ConvertToAdminDtos(this IEnumerable<ProductCategory> productCategories)
        {
            var dtos = new List<AdminProductCategoryDto>();

            foreach (var item in productCategories)
            {
                dtos.Add(item.ConvertToAdminDto());
            }
            return dtos;
        }

        public static AdminProductCategoryDto ConvertToAdminDto(this ProductCategory productCategory)
        {
            return new AdminProductCategoryDto
            {
                Id = productCategory.Id,
                Name = productCategory.Name
            };
        }

        #endregion

        #region Appointment

        public static Appointment ConvertToEntity(this AppointmentAdminToAddDto dto)
        {
            return new Appointment()
            {
                StartTime = dto.StartTime,
                IsDepositPaid = dto.IsDepositPaid,
                SampleSetCompleted = dto.SampleSetCompleted,
                IsSampleSetComplete = dto.IsSampleSetComplete,
                UserId = dto.UserId,
                HasHadEyelashExtentions = dto.HasHadEyelashExtentions,
                EndTime = dto.EndTime
            };

        }

        public static AppointmentDto ConvertToDto(this Appointment appointment)
        {
            return new AppointmentDto()
            {
                Id = appointment.Id,
                StartTime = appointment.StartTime,
                EndTime = appointment.EndTime,
                Status = appointment.Status,
                UserId = appointment.UserId,

            };
        }

        public static AppointmentDto ConvertToDto(this Appointment appointment, IEnumerable<AppointmentServiceDto> serviceDtos, IEnumerable<AppointmentProductDto> productDtos)
        {
            return new AppointmentDto()
            {
                Id = appointment.Id,
                StartTime = appointment.StartTime,
                EndTime = appointment.EndTime,
                Products = productDtos,
                Services = serviceDtos,
                Status = appointment.Status,
                UserId = appointment.UserId,
            };
        }

        public static AppointmentIndemnityDto ConvertToIndemnityDto(this Appointment appointment)
        {
            return new AppointmentIndemnityDto()
            {
                HasHadEyelashExtentions = appointment.HasHadEyelashExtentions,
                IsSampleSetComplete = appointment.IsSampleSetComplete,
                SampleSetCompleted = appointment.SampleSetCompleted,
                Status = appointment.Status
            };
        }

        public static AppointmentFinalizationDto ConvertToFinalizationDto(this Appointment appointment, Dictionary<Guid, string> serviceImageData, Dictionary<Guid, string> productImageData)
        {
            return new AppointmentFinalizationDto()
            {
                Id = appointment.Id,
                Products = appointment.AppointmentProducts.ConvertToImageDtos(productImageData),
                Services = appointment.AppointmentServices.ConvertToFinalizationDto(serviceImageData),
                FirstName = appointment.User.FirstName,
                LastName = appointment.User.LastName,
                Phone = appointment.User.Phone,
                Email = appointment.User.Email,
                DOB = appointment.User.DOB,
                StartTime = appointment.StartTime,
                EndTime = appointment.EndTime,
                IsWavierAcknowledged = appointment.User.IsWaiverAcknowledged,
                HasAllergies = appointment.User.HasAllergies,
                HasHadEyelashExtentions = appointment.HasHadEyelashExtentions,
                HasHadEyeProblems4Weeks = appointment.User.HasHadEyeProblems4Weeks,
                HasSensitiveSkin = appointment.User.HasSensitiveSkin,
                WearsContanctLenses = appointment.User.WearsContanctLenses,
                Status = appointment.Status
            };
        }

        public static AdminAppointmentWidgetDto ConvertToRequestDto(this Appointment appointment)
        {
            try
            {
                if (appointment.StartTime == null || appointment.EndTime == null)
                {
                    throw new NullReferenceException();
                }

                return new AdminAppointmentWidgetDto
                {
                    Id = appointment.Id,
                    FirstName = appointment.User.FirstName,
                    StartTime = (DateTime)appointment.StartTime,
                    EndTime = (DateTime)appointment.EndTime
                };
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public static IEnumerable<AdminAppointmentWidgetDto> ConvertToWidgetDtos(this IEnumerable<Appointment> appointments)
        {
            var dtos = new List<AdminAppointmentWidgetDto>();
            foreach (var item in appointments)
            {
                dtos.Add(item.ConvertToRequestDto());
            }
            return dtos;
        }

        public static AdminAppointmentDto ConvertToAdminImageDto(this Appointment appointment, Dictionary<Guid, string> serviceImageData, Dictionary<Guid, string> productImageData)
        {
            try
            {
                //if (appointment.StartTime == null || appointment.EndTime == null)
                //{
                //    throw new NullReferenceException();
                //}

                return new AdminAppointmentDto
                {
                    Id = appointment.Id,
                    User = appointment.User.ConvertToAdminDto(),
                    StartTime = appointment.StartTime,
                    EndTime = appointment.EndTime,
                    SampleSetCompleted = appointment.SampleSetCompleted,
                    IsDepositPaid = appointment.IsDepositPaid,
                    Services = appointment.AppointmentServices.ConvertToImageDtos(serviceImageData),
                    Products = appointment.AppointmentProducts.ConvertToImageDtos(productImageData),
                    HasHadEyelashExtentions = appointment.HasHadEyelashExtentions,
                    IsSampleSetComplete = appointment.IsSampleSetComplete,
                    Status = appointment.Status
                };
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public static AdminAppointmentDto ConvertToAdminDto(this Appointment appointment)
        {
            try
            {
                //if (appointment.StartTime == null || appointment.EndTime == null)
                //{
                //    throw new NullReferenceException();
                //}

                return new AdminAppointmentDto
                {
                    Id = appointment.Id,
                    User = appointment.User.ConvertToAdminDto(),
                    StartTime = appointment.StartTime,
                    EndTime = appointment.EndTime,
                    SampleSetCompleted = appointment.SampleSetCompleted,
                    IsDepositPaid = appointment.IsDepositPaid,
                    Services = appointment.AppointmentServices.ConvertToDto(),
                    Products = appointment.AppointmentProducts.ConvertToDtos(),
                    HasHadEyelashExtentions = appointment.HasHadEyelashExtentions,
                    IsSampleSetComplete = appointment.IsSampleSetComplete,
                    Status = appointment.Status
                };
            }
            catch (Exception e)
            {
                throw;
            }

        }

        public static IEnumerable<AdminAppointmentDto> ConvertToAdminDtos(this IEnumerable<Appointment> appointments)
        {
            var dtos = new List<AdminAppointmentDto>();
            foreach (var item in appointments)
            {
                dtos.Add(item.ConvertToAdminDto());
            }
            return dtos;
        }

        private static IEnumerable<Service> ExtractServices(Appointment appointment)
        {
            var services = new List<Service>();
            foreach (var appointmentService in appointment.AppointmentServices)
            {
                services.Add(appointmentService.Service);
            }
            return services;
        }

        #endregion

        #region Users

        public static User ConvertToEntity(this UserToAddDto addDto)
        {
            return new User()
            {
                Id = addDto.Id,
                FirstName = addDto.FirstName,
                LastName = addDto.LastName
            };
        }

        public static User ConvertToEntity(this UserAdminAddDto addDto)
        {
            return new User()
            {
                FirstName = addDto.FirstName,
                LastName = addDto.LastName,
                Phone = addDto.Phone,
                Email = addDto.Email,
                DOB = addDto.DOB,
                HasAllergies = addDto.HasAllergies,
                HasHadEyeProblems4Weeks = addDto.HasHadEyeProblems4Weeks,
                WearsContanctLenses = addDto.WearsContactLenses,
                HasSensitiveSkin = addDto.HasSensitiveSkin,
                IsWaiverAcknowledged = addDto.IsWaiverAcknowledged,
            };
        }

        public static UserDto ConvertToDto(this User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName

            };
        }
        public static AdminUserDto ConvertToAdminDto(this User user)
        {
            return new AdminUserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                DOB = user.DOB,
                HasSensitiveSkin = user.HasSensitiveSkin,
                HasAllergies = user.HasAllergies,
                HasHadEyeProblems4Weeks = user.HasHadEyeProblems4Weeks,
                IsWaiverAcknowledged = user.IsWaiverAcknowledged,
                WearsContanctLenses = user.WearsContanctLenses

            };
        }

        public static IEnumerable<AdminUserDto> ConvertToAdminDtos(this IEnumerable<User> users)
        {
            var convertedUsers = new List<AdminUserDto>();
            foreach (var user in users)
            {
                convertedUsers.Add(user.ConvertToAdminDto());
            }

            return convertedUsers;
        }

        public static AdminUserDetailsDto ConvertToAdminDetailsDto(this User user)
        {
            return new AdminUserDetailsDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Phone = user.Phone,
                DOB = user.DOB,
                HasSensitiveSkin = user.HasSensitiveSkin,
                HasAllergies = user.HasAllergies,
                HasHadEyeProblems4Weeks = user.HasHadEyeProblems4Weeks,
                IsWaiverAcknowledged = user.IsWaiverAcknowledged,
                WearsContanctLenses = user.WearsContanctLenses,
                Created = user.Created,
                Appointments = user.Appointments.ConvertToAdminDtos()
            };
        }


        public static IEnumerable<AdminUserDetailsDto> ConvertToAdminDetailsDtos(this IEnumerable<User> users)
        {
            var convertedUsers = new List<AdminUserDetailsDto>();
            foreach (var user in users)
            {
                convertedUsers.Add(user.ConvertToAdminDetailsDto());
            }

            return convertedUsers;
        }

        public static UserIndemnityDto ConvertToIndemnityDto(this User user)
        {
            return new UserIndemnityDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Phone = user.Phone,
                Email = user.Email,
                DOB = user.DOB,
                HasSensitiveSkin = user.HasSensitiveSkin,
                WearsContanctLenses = user.WearsContanctLenses,
                HasAllergies = user.HasAllergies,
                HasHadEyeProblems4Weeks = user.HasHadEyeProblems4Weeks
            };
        }

        public static UserWaiverDto ConvertToWaiverDto(this User user)
        {
            return new UserWaiverDto()
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsWavierAcknowledged = user.IsWaiverAcknowledged
            };
        }

        #endregion

        #region BusinessHours

        public static IEnumerable<BusinessHoursDto> ConvertToDto(this IEnumerable<BusinessHours> businessHours)
        {
            var dtos = new List<BusinessHoursDto>();
            foreach (var item in businessHours)
            {
                dtos.Add(new BusinessHoursDto()
                {
                    Day = item.Day,
                    OpenTime = item.OpenTime,
                    CloseTime = item.CloseTime,
                    LocalTimeOffset = item.LocalTimeOffset,
                    IsDisabled = item.IsDisabled,
                    AfterHoursGraceRange = item.AfterHoursGraceRange,
                });
            }
            return dtos;
        }

        public static IEnumerable<AdminBusinessHoursDto> ConvertToAdminDtoa(this IEnumerable<BusinessHours> businessHours)
        {
            var dtos = new List<AdminBusinessHoursDto>();
            foreach (var item in businessHours)
            {
                dtos.Add(item.ConvertToAdminDto());
            }
            return dtos;
        }

        public static AdminBusinessHoursDto ConvertToAdminDto(this BusinessHours businessHours)
        {
            return new AdminBusinessHoursDto
            {
                Id = businessHours.Id,
                OpenTime = businessHours.OpenTime,
                CloseTime = businessHours.CloseTime,
                LocalTimeOffset = businessHours.LocalTimeOffset,
                Day = businessHours.Day,
                AfterHoursGraceRange = businessHours.AfterHoursGraceRange,
                IsDisabled = businessHours.IsDisabled
            };

        }

        #endregion

        #region Admins

        public static AdminUserLoginDto ConvertToDto(this Admin admin)
        {
            return new AdminUserLoginDto()
            {
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Phone = admin.Phone,
                Id = admin.Id,
                AdminKey = admin.AdminKey,
                Updated = admin.Updated
            };

        }
        #endregion

        #region BlockOutDates

        public static BlockOutDatesAdminDto ConvertToAdminDto(this BlockOutDate entity)
        {
            return new BlockOutDatesAdminDto
            {
                Id = entity.Id,
                Date = entity.Date,
            };
        }

        public static IEnumerable<BlockOutDatesAdminDto> ConvertToAdminDtos(this IEnumerable<BlockOutDate> entities)
        {
            var dtos = new List<BlockOutDatesAdminDto>();
            foreach (var entity in entities)
            {
                dtos.Add(ConvertToAdminDto(entity));
            }
            return dtos;
        }

        #endregion

        #region Policies

        public static PolicyDto ConvertToDto(this Policy policy)
        {
            return new PolicyDto
            {
                PolicyArticle = policy.PolicyArticle,
                PolicyTitle = policy.PolicyTitle
            };
        }

        public static IEnumerable<PolicyDto> ConvertToDtos(this IEnumerable<Policy> policies)
        {
            var policiesDtos = new List<PolicyDto>();
            foreach (var item in policies)
            {
                policiesDtos.Add(item.ConvertToDto());
            }
            return policiesDtos;
        }

        public static PolicyAdminDto ConvertToAdminDto(this Policy policy)
        {
            return new PolicyAdminDto
            {
                Id = policy.Id,
                PolicyArticle = policy.PolicyArticle,
                PolicyTitle = policy.PolicyTitle
            };
        }

        public static IEnumerable<PolicyAdminDto> ConvertToAdminDtos(this IEnumerable<Policy> policies)
        {
            var policiesDtos = new List<PolicyAdminDto>();
            foreach (var item in policies)
            {
                policiesDtos.Add(item.ConvertToAdminDto());
            }
            return policiesDtos;
        }

        #endregion
    }


}
