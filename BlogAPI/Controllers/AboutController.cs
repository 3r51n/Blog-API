using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Blog.Model;
using Blog.Model.ApiResponseModels;
using Blog.Model.DataTransferModels;
using Blog.Model.Enums;
using Blog.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Core.Controllers
{
    [Route(Routes.About)]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IAboutService _aboutService;
        public AboutController(IHttpContextAccessor contextAccessor, IAboutService aboutService)
        {
            _contextAccessor = contextAccessor;
            _aboutService = aboutService;
        }

        [AllowAnonymous]
        [Route("{author}/card")]
        [HttpGet]
        public SingleDataResponseModel<CardInfoDataTransferModel> GetCardInfoDataByAuthor(string author)
        {
            var apiResponse = new SingleDataResponseModel<CardInfoDataTransferModel>();
            apiResponse.LanguageCode = "tr-TR";
            apiResponse.Validation = new ValidationResponseModel();
            apiResponse.RequestIdentifier = _contextAccessor.HttpContext.TraceIdentifier;
            try
            {
                //TODO: Exception handling
                apiResponse.Data = _aboutService.GetCardInfoDataByAuthor(author) as CardInfoDataTransferModel;
                apiResponse.HttpStatusCode = HttpStatusCode.OK;
                apiResponse.ResultType = ResultTypes.Success;
                apiResponse.Message = "Kart bilgileri alındı";
            }
            catch (Exception exception)
            {
                apiResponse.HttpStatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ResultType = ResultTypes.Fail;
                apiResponse.Message = "Kart bilgileri hazırlanırken hata oluştu";

                apiResponse.Exception = new ExceptionResponseModel()
                {
                    Message = exception.Message,
                    TypeName = exception.GetType().FullName
                };
            }
            finally
            {
                _contextAccessor.HttpContext.Response.StatusCode = (int)apiResponse.HttpStatusCode;
            }
            return apiResponse;
        }

        [AllowAnonymous]
        [Route("{author}/xp")]
        [HttpGet]
        public CollectionDataResponseModel<ExperienceDataTransferModel> GetExperienceByAuthor(string author)
        {
            var apiResponse = new CollectionDataResponseModel<ExperienceDataTransferModel>();
            apiResponse.LanguageCode = "tr-TR";
            apiResponse.Validation = new ValidationResponseModel();
            apiResponse.RequestIdentifier = _contextAccessor.HttpContext.TraceIdentifier;
            try
            {
                //TODO: Exception handling
                var dataList = _aboutService.GetExperiencesByAuthor(author) as IEnumerable<ExperienceDataTransferModel>;
                apiResponse.Data = dataList;
                apiResponse.Pagination = new Pagination
                {
                    Limit = dataList.Count(),
                    Offset = 0,
                    Returned = dataList.Count(),
                    TotalCount = dataList.Count()
                };

                apiResponse.HttpStatusCode = HttpStatusCode.OK;
                apiResponse.ResultType = ResultTypes.Success;
                apiResponse.Message = "İş/Deneyim bilgileri alındı";
            }
            catch (Exception exception)
            {
                apiResponse.HttpStatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ResultType = ResultTypes.Fail;
                apiResponse.Message = "İş/Deneyim bilgileri hazırlanırken hata oluştu";

                apiResponse.Exception = new ExceptionResponseModel()
                {
                    Message = exception.Message,
                    TypeName = exception.GetType().FullName
                };
            }
            finally
            {
                _contextAccessor.HttpContext.Response.StatusCode = (int)apiResponse.HttpStatusCode;
            }
            return apiResponse;
        }

        [AllowAnonymous]
        [Route("{author}/education")]
        [HttpGet]
        public CollectionDataResponseModel<EducationDataTransferModel> GetEducationByAuthor(string author)
        {
            var apiResponse = new CollectionDataResponseModel<EducationDataTransferModel>();
            apiResponse.LanguageCode = "tr-TR";
            apiResponse.Validation = new ValidationResponseModel();
            apiResponse.RequestIdentifier = _contextAccessor.HttpContext.TraceIdentifier;
            try
            {
                //TODO: Exception handling
                var dataList = _aboutService.GetEducationsByAuthor(author) as IEnumerable<EducationDataTransferModel>;
                apiResponse.Data = dataList;
                apiResponse.Pagination = new Pagination
                {
                    Limit = dataList.Count(),
                    Offset = 0,
                    Returned = dataList.Count(),
                    TotalCount = dataList.Count()
                };

                apiResponse.HttpStatusCode = HttpStatusCode.OK;
                apiResponse.ResultType = ResultTypes.Success;
                apiResponse.Message = "Eğitim bilgileri alındı";
            }
            catch (Exception exception)
            {
                apiResponse.HttpStatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ResultType = ResultTypes.Fail;
                apiResponse.Message = "Eğitim bilgileri hazırlanırken hata oluştu";

                apiResponse.Exception = new ExceptionResponseModel()
                {
                    Message = exception.Message,
                    TypeName = exception.GetType().FullName
                };
            }
            finally
            {
                _contextAccessor.HttpContext.Response.StatusCode = (int)apiResponse.HttpStatusCode;
            }
            return apiResponse;
        }

        [AllowAnonymous]
        [Route("{author}/interest")]
        [HttpGet]
        public CollectionDataResponseModel<InterestDataTransferModel> GetInterestsByAuthor(string author)
        {
            var apiResponse = new CollectionDataResponseModel<InterestDataTransferModel>();
            apiResponse.LanguageCode = "tr-TR";
            apiResponse.Validation = new ValidationResponseModel();
            apiResponse.RequestIdentifier = _contextAccessor.HttpContext.TraceIdentifier;
            try
            {
                //TODO: Exception handling
                var dataList = _aboutService.GetAbilityAndInterestsByAuthor(author) as IEnumerable<InterestDataTransferModel>;
                apiResponse.Data = dataList;
                apiResponse.Pagination = new Pagination
                {
                    Limit = dataList.Count(),
                    Offset = 0,
                    Returned = dataList.Count(),
                    TotalCount = dataList.Count()
                };

                apiResponse.HttpStatusCode = HttpStatusCode.OK;
                apiResponse.ResultType = ResultTypes.Success;
                apiResponse.Message = "Yetenek ve ilgi bilgileri alındı";
            }
            catch (Exception exception)
            {
                apiResponse.HttpStatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ResultType = ResultTypes.Fail;
                apiResponse.Message = "Yetenek ve ilgi bilgileri hazırlanırken hata oluştu";

                apiResponse.Exception = new ExceptionResponseModel()
                {
                    Message = exception.Message,
                    TypeName = exception.GetType().FullName
                };
            }
            finally
            {
                _contextAccessor.HttpContext.Response.StatusCode = (int)apiResponse.HttpStatusCode;
            }
            return apiResponse;
        }

        [AllowAnonymous]
        [Route("{author}/success")]
        [HttpGet]
        public CollectionDataResponseModel<SuccessDateTransferModel> GetSuccessesByAuthor(string author)
        {
            var apiResponse = new CollectionDataResponseModel<SuccessDateTransferModel>();
            apiResponse.LanguageCode = "tr-TR";
            apiResponse.Validation = new ValidationResponseModel();
            apiResponse.RequestIdentifier = _contextAccessor.HttpContext.TraceIdentifier;
            try
            {
                //TODO: Exception handling
                var dataList = _aboutService.GetSuccessesByAuthor(author) as IEnumerable<SuccessDateTransferModel>;
                apiResponse.Data = dataList;
                apiResponse.Pagination = new Pagination
                {
                    Limit = dataList.Count(),
                    Offset = 0,
                    Returned = dataList.Count(),
                    TotalCount = dataList.Count()
                };

                apiResponse.HttpStatusCode = HttpStatusCode.OK;
                apiResponse.ResultType = ResultTypes.Success;
                apiResponse.Message = "Başarı bilgileri alındı";
            }
            catch (Exception exception)
            {
                apiResponse.HttpStatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ResultType = ResultTypes.Fail;
                apiResponse.Message = "Başarı bilgileri hazırlanırken hata oluştu";

                apiResponse.Exception = new ExceptionResponseModel()
                {
                    Message = exception.Message,
                    TypeName = exception.GetType().FullName
                };
            }
            finally
            {
                _contextAccessor.HttpContext.Response.StatusCode = (int)apiResponse.HttpStatusCode;
            }
            return apiResponse;
        }

        [AllowAnonymous]
        [Route("{author}/reference")]
        [HttpGet]
        public CollectionDataResponseModel<ReferenceDataTransferModel> GetReferencesByAuthor(string author)
        {
            var apiResponse = new CollectionDataResponseModel<ReferenceDataTransferModel>();
            apiResponse.LanguageCode = "tr-TR";
            apiResponse.Validation = new ValidationResponseModel();
            apiResponse.RequestIdentifier = _contextAccessor.HttpContext.TraceIdentifier;
            try
            {
                //TODO: Exception handling
                var dataList = _aboutService.GetReferencesByAuthor(author) as IEnumerable<ReferenceDataTransferModel>;
                apiResponse.Data = dataList;
                apiResponse.Pagination = new Pagination
                {
                    Limit = dataList.Count(),
                    Offset = 0,
                    Returned = dataList.Count(),
                    TotalCount = dataList.Count()
                };

                apiResponse.HttpStatusCode = HttpStatusCode.OK;
                apiResponse.ResultType = ResultTypes.Success;
                apiResponse.Message = "Referans bilgileri alındı";
            }
            catch (Exception exception)
            {
                apiResponse.HttpStatusCode = HttpStatusCode.InternalServerError;
                apiResponse.ResultType = ResultTypes.Fail;
                apiResponse.Message = "Referans bilgileri hazırlanırken hata oluştu";

                apiResponse.Exception = new ExceptionResponseModel()
                {
                    Message = exception.Message,
                    TypeName = exception.GetType().FullName
                };
            }
            finally
            {
                _contextAccessor.HttpContext.Response.StatusCode = (int)apiResponse.HttpStatusCode;
            }
            return apiResponse;
        }
    }
}