﻿using Microsoft.AspNetCore.Mvc;
using JricaStudioWebApi.Entities;
using JricaStudioWebApi.Repositories.Contracts;
using JricaStudioWebApi.Extentions;
using JricaStudioWebApi.Services.Contracts;
using JricaStudioWebApi.Attributes;
using JricaStudioWebApi.Models.Dtos;
using JricaStudioWebApi.Models.enums;
using JricaStudioWebApi.Models.Dtos.Admin;
using JricaStudioWebApi.Models.Extentions;
using JricaStudioWebApi.Models.Constants;
using Microsoft.JSInterop.Infrastructure;

namespace JricaStudioWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentRepository _repository;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IImageAccessService _imageAccessService;
        private readonly IConfiguration _configuration;

        public AppointmentController(IAppointmentRepository appointmentRepository, IEmailSenderService emailSenderService, IStringEncryptionService encryptionService, IImageAccessService imageAccessService, IConfiguration configuration)
        {
            _repository = appointmentRepository;
            _emailSenderService = emailSenderService;
            _imageAccessService = imageAccessService;
            _configuration = configuration;
        }


        #region Get


        [HttpGet("Indemnity/{id:guid}")]
        public async Task<ActionResult<AppointmentIndemnityDto>> GetAppointmentIndemnity(Guid id)
        {
            try
            {
                var appointment = await _repository.GetAppointmentIndemnity(id);

                if (appointment == null)
                {
                    throw new Exception("Resource not found.");
                }

                var appointmentDto = appointment.ConvertToIndemnityDto();

                return Ok(appointmentDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("Exists/{id:guid}")]
        public async Task<ActionResult<AppointmentExistsDto>> GetAppointmentExistance(Guid id)
        {
            return new AppointmentExistsDto()
            {
                AppointmentExists = await _repository.GetAppointmentExists(id)
            };
        }

        [HttpGet("Service/{id:guid}")]
        public async Task<ActionResult<IEnumerable<AppointmentServiceDto>>> GetServices(Guid id)
        {
            try
            {
                var services = await _repository.GetServices(id);

                if (services.Count() == 0)
                {
                    return NoContent();
                }

                var justServiceEntities = new List<Service>();

                foreach (var service in services)
                {
                    justServiceEntities.Add(service.Service);
                }

                var imageData = await _imageAccessService.LoadServicesImages(justServiceEntities);

                var servicesDtos = services.ConvertToImageDtos(imageData);

                if (servicesDtos == null)
                {
                    throw new Exception("Conversion to DTO has Failed Please Check the Object calling the ConventToDto Method has all the necessary properties.");
                }

                return Ok(servicesDtos);


            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Product/{id:guid}")]
        public async Task<ActionResult<IEnumerable<AppointmentProductDto>>> GetProducts(Guid id)
        {
            try
            {
                var products = await _repository.GetProducts(id);

                if (products == null)
                {
                    return NotFound();
                }


                var imageData = await _imageAccessService.LoadProductsImages(products.Select(p => p.Product));

                var productDtos = products.ConvertToImageDtos(imageData);

                return Ok(productDtos);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<AppointmentDto>> GetAppointment(Guid id)
        {
            try
            {
                var appointment = await _repository.GetAppointment(id);

                if (appointment == null)
                {
                    return NoContent();
                }

                var services = ExtractServices(appointment);
                var products = ExtractProducts(appointment);

                var servicesImageData = await _imageAccessService.LoadServicesImages(services);
                var productImageData = await _imageAccessService.LoadProductsImages(products);

                var productDtos = appointment.AppointmentProducts.ConvertToImageDtos(productImageData);
                var serviceDtos = appointment.AppointmentServices.ConvertToImageDtos(servicesImageData);

                return Ok(appointment.ConvertToDto(serviceDtos, productDtos));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpGet("Admin/{id:guid}")]
        public async Task<ActionResult<AdminAppointmentDto>> GetEditAppointment(Guid id)
        {
            try
            {
                var appointment = await _repository.GetAdminAppointment(id);

                if (appointment == null)
                {
                    throw new Exception("Resource not found.");
                }

                var services = ExtractServices(appointment);
                var products = ExtractProducts(appointment);

                var serviceImageData = await _imageAccessService.LoadServicesImages(services);
                var productImageData = await _imageAccessService.LoadProductsImages(products);


                return Ok(appointment.ConvertToAdminImageDto(serviceImageData, productImageData));
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpGet("Upcoming")]
        public async Task<ActionResult<IEnumerable<AdminAppointmentWidgetDto>>> GetUpcomingAppointments()
        {
            try
            {
                var appointments = await _repository.GetUpcomingAppointments();

                if (!appointments.Any())
                {
                    return NoContent();
                }

                var appointmentDtos = appointments.ConvertToWidgetDtos();

                return Ok(appointmentDtos);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpGet("Requests")]
        public async Task<ActionResult<IEnumerable<AdminAppointmentWidgetDto>>> GetAppointmentRequests()
        {
            try
            {
                var appointments = await _repository.GetAppointmentRequests();

                if (!appointments.Any())
                {
                    return NoContent();
                }


                var appointmentDtos = appointments.ConvertToWidgetDtos();

                return Ok(appointmentDtos);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpGet("Finalization/{id:guid}")]
        public async Task<ActionResult<AppointmentFinalizationDto>> GetAppointmentFinalization(Guid id)
        {
            try
            {
                var appointment = await _repository.GetAppointmentFinalization(id);

                if (appointment == null)
                {
                    throw new Exception("Resource not found.");
                }



                var services = ExtractServices(appointment);
                var products = ExtractProducts(appointment);

                var servicesImageData = await _imageAccessService.LoadServicesImages(services);
                var productImageData = await _imageAccessService.LoadProductsImages(products);


                var appointmentDto = appointment.ConvertToFinalizationDto(servicesImageData, productImageData);

                return Ok(appointmentDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        #endregion

        #region Put

        #endregion

        #region Patch

        [AdminKey]
        [HttpPatch("Update/{appointmentId:guid}")]
        public async Task<ActionResult<AppointmentDto>> UpdateAppointment(Guid appointmentId, UpdateAppointmentDto dto)
        {
            try
            {
                dto = dto.ConvertDateTimesToUtcTime();

                var appointment = await _repository.UpdateAppointment(appointmentId, dto);

                if (appointment == null)
                {
                    return NotFound();
                }

                var appointmentDto = appointment.ConvertToDto();

                return appointmentDto;

            }
            catch (ArgumentException ae)
            {
                return StatusCode(StatusCodes.Status400BadRequest, ae.Message);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("UpdateUser/{id:guid}")]
        public async Task<ActionResult<AppointmentDto>> PatchAppointmentUser(Guid id, UpdateAppointmentUserDto dto)
        {
            try
            {
                var appointment = await _repository.UpdateAppointmentUser(id, dto);

                if (appointment == null)
                {
                    return NotFound();
                }

                var appointmentdto = appointment.ConvertToDto();

                return Ok(appointmentdto);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("Product/Quantity/{id:guid}")]
        public async Task<ActionResult<AppointmentServiceDto>> UpdateAppointmentProductQuantity(Guid id, AppointmentProductQuantityUpdateDto quantityUpdateDto)
        {
            try
            {
                if (quantityUpdateDto.Quantity > 0)
                {
                    var appointmanetProduct = await _repository.UpdateProductQty(id, quantityUpdateDto);

                    if (appointmanetProduct == null)
                    {
                        return NotFound();
                    }

                    var productdto = appointmanetProduct.ConvertToDto();

                    return Ok(productdto);
                }
                else
                {
                    throw new Exception("Quantity can not be less then 1");
                }

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("UpdateTimes/{id:guid}")]
        public async Task<ActionResult<AppointmentDto>> UpdateAppointmentTimes(Guid id, UpdateAppointmentTimesDto timesDto)
        {
            try
            {
                var cleanDto = timesDto.ConvertDateTimesToUtcTime();

                var appointment = await _repository.UpdateAppointmentTimes(id, cleanDto);

                if (appointment == null)
                {
                    return NotFound();
                }



                var services = ExtractServices(appointment);
                var products = ExtractProducts(appointment);

                var servicesImageData = await _imageAccessService.LoadServicesImages(services);
                var productImageData = await _imageAccessService.LoadProductsImages(products);

                var productDtos = appointment.AppointmentProducts.ConvertToImageDtos(productImageData);
                var serviceDtos = appointment.AppointmentServices.ConvertToImageDtos(servicesImageData);

                var appointmentDto = appointment.ConvertToDto(serviceDtos, productDtos);

                return Ok(appointmentDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("UpdateStatus/{id:guid}")]
        public async Task<ActionResult<AppointmentDto>> UpdateAppointmentStatus(Guid id, UpdateAppointmentStatusDto dto)
        {
            try
            {
                if (dto.Status >= AppointmentStatus.Confirmed)
                {
                    return Unauthorized();
                }

                var appointment = await _repository.UpdateAppointmentStatus(id, dto.Status);

                if (appointment == null)
                {
                    return NotFound();
                }

                var appointmentDto = appointment.ConvertToDto();

                return Ok(appointmentDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpPatch("UpdateStatusAdmin/{id:guid}")]
        public async Task<ActionResult<AppointmentDto>> UpdateAppointmentAdminStatus(Guid id, UpdateAppointmentStatusDto dto)
        {
            try
            {
                var appointment = await _repository.UpdateAppointmentStatus(id, dto.Status);

                if (appointment == null)
                {
                    return NotFound();
                }

                var appointmentDto = appointment.ConvertToDto();

                return Ok(appointmentDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("Indemnity/{id:guid}")]
        public async Task<ActionResult<AppointmentIndemnityDto>> PatchAppointmentIdemnity(Guid id, UpdateAppointmentIndemnityDto indemnityDto)
        {
            try
            {
                indemnityDto = indemnityDto.ConvertDateTimesToUtcTime();

                var appointment = await _repository.UpdateAppointmentIndemnityQuestions(id, indemnityDto);

                if (appointment == null)
                {
                    return NotFound();
                }
                var appointmentDto = appointment.ConvertToDto();

                return Ok(appointmentDto);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPatch("Submit/{id:guid}")]
        public async Task<ActionResult<AppointmentFinalizationDto>> PatchAppointmentSubmit(Guid id, UpdateAppointmentSubmissionDto dto)
        {
            dto = dto.ConvertDateTimesToUtcTime();

            var appointment = await _repository.GetAppointmentFinalization(id);


            if (appointment == null)
            {
                return NotFound();
            }

            if (!dto.Validate())
            {
                return BadRequest("Items in request were not valid inputs");
            }



            if (!dto.ValuesEquals(appointment))
            {
                return BadRequest("The submission you have provided does not match our records.");
            }


            try
            {
                await _repository.UpdateAppointmentStatusSubmission(id);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);

                throw;
            }




#if DEBUG
            await _emailSenderService.SendNotificationEmail("royce5862@gmail.com", $"Appointment for {appointment.StartTime.Value.DayOfWeek}",
                "<html>" +
                    "<body>" +
                        "<div>" +
                            $" {appointment.User.FirstName} has made and appointment for {appointment.StartTime.Value.ToLongDateString()}, at {appointment.StartTime.Value.ToShortTimeString()} Check the appointment details before approving this appointment." +
                        "</div>" +
                        "<br>" +
                        "<a href=\"https://www.JRicaStudio.com/Login\">" +
                            $" JricaStudio.com/Login" +
                        "</a>" +
                    "</body>" +
                "</html>");
#else
            await _emailSenderService.SendNotificationEmail(_configuration.GetValue<string>("EmailUsername"), $"Appointment for {appointment.StartTime.Value.DayOfWeek}",
                "<html>" +
                    "<body>" +
                        "<div>" +
                            $" {appointment.User.FirstName} has made and appointment for {appointment.StartTime.Value.ToLongDateString()}, at {appointment.StartTime.Value.ToShortTimeString()} Check the appointment details before approving this appointment." +
                        "</div>" +
                        "<br>" +
                        "<a href=\"https://www.JRicaStudio.com/Login\">" +
                            $" JricaStudio.com/Login" +
                        "</a>" +
                    "</body>" +
                "</html>");

#endif
            var services = new List<Service>();

            foreach (var item in appointment.AppointmentServices)
            {
                services.Add(item.Service);
            }

            var products = appointment.AppointmentProducts.Select(p => p.Product);

            var serviceImageData = await _imageAccessService.LoadServicesImages(services);
            var productsImageData = await _imageAccessService.LoadProductsImages(products);


            var appointmentFinDto = appointment.ConvertToFinalizationDto(serviceImageData, productsImageData);

            return Ok(appointmentFinDto);
        }

        #endregion

        #region Post

        [AdminKey]
        [HttpPost("Search")]
        public async Task<ActionResult<IEnumerable<AdminAppointmentDto>>> PostAppointmentQuery(AdminAppointmentSearchFilterDto filter)
        {
            try
            {
                var appointments = await _repository.GetAppointments(filter);

                if (appointments == null)
                {
                    return Ok(default);
                }

                var appointmentDtos = appointments.ConvertToAdminDtos();

                return Ok(appointmentDtos);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("Service")]
        public async Task<ActionResult<AppointmentServiceDto>> CreateServiceItem([FromBody] AppointmentServiceToAddDto addDto)
        {
            try
            {
                var result = await _repository.AddService(addDto);

                if (result == null)
                {
                    throw new Exception("Something went wrong when creating when Creating Resource");
                }

                var imageData = await _imageAccessService.LoadImage(result.ServiceId, FileResources.serviceImageFilePath);

                var resultDto = result.ConvertToDto();

                return CreatedAtAction(nameof(GetServices), new { id = resultDto.AppointmentId }, resultDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost("Product")]
        public async Task<ActionResult<AppointmentProductDto>> CreateProductItem([FromBody] AppointmentProductToAddDto addDto)
        {
            try
            {
                var result = await _repository.AddProduct(addDto);

                if (result == null)
                {
                    throw new Exception("Something went wrong when creating resource");
                }

                var imagedata = await _imageAccessService.LoadImage(result.ProductId, FileResources.productImageFilePath);


                var resultDto = result.ConvertToDto();

                resultDto.ProductImagePath = imagedata;

                return CreatedAtAction(nameof(GetProducts), new { id = resultDto.AppointmentId }, resultDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpPost("Admin/Service")]
        public async Task<ActionResult<AppointmentServiceDto>> AdminCreateServiceItem([FromBody] AppointmentServiceToAddDto addDto)
        {
            try
            {
                var result = await _repository.AdminAddService(addDto);

                if (result == null)
                {
                    throw new Exception("Something went wrong when creating when Creating Resource");
                }

                var resultDto = result.ConvertToDto();

                return CreatedAtAction(nameof(GetServices), new { id = resultDto.AppointmentId }, resultDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [AdminKey]
        [HttpPost("Admin/Product")]
        public async Task<ActionResult<AppointmentProductDto>> AdminCreateProductItem([FromBody] AppointmentProductToAddDto addDto)
        {
            try
            {
                var result = await _repository.AdminAddProduct(addDto);

                if (result == null)
                {
                    throw new Exception("Something went wrong when creating resource");
                }
                var resultDto = result.ConvertToDto();

                return CreatedAtAction(nameof(GetProducts), new { id = resultDto.AppointmentId }, resultDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<AppointmentDto>> CreateAppointment(AppointmentToAddDto toAddDto)
        {
            try
            {
                Appointment appointment = await _repository.AddAppointment(toAddDto);

                if (appointment == null)
                {
                    throw new Exception("There was an error while creating the Resource. Appointment");
                }

                var appointmentDto = appointment.ConvertToDto();

                return appointmentDto;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpPost("Admin")]
        public async Task<ActionResult<AppointmentDto>> CreateAppointmentAdmin(AppointmentAdminToAddDto dto)
        {
            try
            {

                Appointment appointment = await _repository.AddAppointment(dto);

                if (appointment == null)
                {
                    throw new Exception("There was an error while creating the Resource. Appointment");
                }



                foreach (var item in dto.ServicesToAdd)
                {
                    await _repository.AddService(new AppointmentServiceToAddDto()
                    {
                        AppointmentId = appointment.Id,
                        ServiceId = item.ServiceId
                    });
                }

                if (dto.ProductsToAdd.Count() > 0)
                {
                    foreach (var item in dto.ProductsToAdd)
                    {
                        await _repository.AddProduct(new AppointmentProductToAddDto()
                        {
                            AppointmentId = appointment.Id,
                            ProductId = item.ProductId
                        });

                    }
                }

                appointment = await _repository.UpdateAppointmentStatus(appointment.Id, AppointmentStatus.Confirmed);



                var appointmentDto = appointment.ConvertToDto();

                return appointmentDto;

            }
            catch (Exception e)
            {
                throw;
            }
        }

        #endregion

        #region Delete


        [HttpDelete("Product/{id:guid}")]
        public async Task<ActionResult<IEnumerable<AppointmentProductDto>>> DeleteAppointmentProduct(Guid id)
        {
            try
            {
                var appointmentProduct = await _repository.DeleteAppointmentProduct(id);
                if (appointmentProduct == null)
                {
                    return NotFound();
                }

                var appProdDto = appointmentProduct.ConvertToDtos();

                return Ok(appProdDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }

        [HttpDelete("Service/{id:guid}")]
        public async Task<ActionResult<IEnumerable<AppointmentServiceDto>>> DeleteAppointmentService(Guid id)
        {
            try
            {
                var appointmentService = await _repository.DeleteAppointmentService(id);
                if (appointmentService == null)
                {
                    return NotFound();
                }

                var appServDto = appointmentService.ConvertToDto();

                return Ok(appServDto);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }


        #endregion


        private IEnumerable<Service> ExtractServices(Appointment appointment)
        {
            var services = new List<Service>();
            foreach (var appointmentService in appointment.AppointmentServices)
            {
                services.Add(appointmentService.Service);
            }
            return services;
        }

        private IEnumerable<Product> ExtractProducts(Appointment appointment)
        {
            var products = new List<Product>();
            foreach (var appointmentProduct in appointment.AppointmentProducts)
            {
                products.Add(appointmentProduct.Product);
            }
            return products;
        }















    }
}
