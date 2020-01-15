using System;
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
            apiResponse.Validation = new ValidationResponseModel();
            apiResponse.RequestIdentifier = _contextAccessor.HttpContext.TraceIdentifier;
            try
            {
                 
                
                apiResponse.Data = _aboutService.GetCardInfoDataByAuthor(author) as CardInfoDataTransferModel;
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
        /*
         * var apiResponseModel = new MMSResponseModel();
            apiResponseModel.Validations = new Validations();
            apiResponseModel.DataModel = null;
            apiResponseModel.RequestIdentifier = _config.RequestIdentifier;
            try
            {
                #region [ ApiResponseModel]
                apiResponseModel.HttpStatusCode = HttpStatusCode.OK;
                apiResponseModel.ResultType = ResultType.Success;
                apiResponseModel.LanguageCode = GlobalDefinitions.MMS_DEFAULT_LANGUAGE_CODE;
                #endregion

                #region [SERVICE OPERATIONS]
                var languageList = _languageService.GetAllActiveLanguage();
                var responseModel = new CollectionResponseModel<LanguageDataTransferModel>()
                {
                    Data = new List<LanguageDataTransferModel>(),
                    Pagination = new Pagination()
                    {
                        Limit = limit,
                        Offset = offset,
                        TotalCount = languageList.Count()
                    }
                };

                //------------------------------
                if (offset != default(int) && limit != default(int))
                {
                    var languages = languageList.Skip(offset).Take(limit);
                    // validation
                    CheckEntityList(_config,_repositoryManager, languages, "anonymous");
                    responseModel.Data = languages.Select(ModelBinder.LanguageToLanguageDataTransferModel).ToList();
                }

                else if (limit == default(int))
                {
                    var languages = languageList.Skip(offset);
                    // validation
                    CheckEntityList(_config,_repositoryManager, languages, "anonymous");
                    responseModel.Data = languages.Select(ModelBinder.LanguageToLanguageDataTransferModel).ToList();
                    responseModel.Pagination.Limit = responseModel.Data.Count;
                }

                responseModel.Pagination.Returned = responseModel.Data.Count;
                #endregion

                apiResponseModel.DataModel = responseModel;

                apiResponseModel.Message = new TranslationCode
                {
                    LanguageCode = _config.ActiveLanguageCode,
                    TextCode = TranslateCode.LANGUAGE_SUCCESS_1, // Diller başarılı bir şekilde alındı.

                }.Translate();
            }
            catch (Exception exception)
            {
                apiResponseModel.HttpStatusCode = HttpStatusCode.InternalServerError;
                apiResponseModel.ResultType = ResultType.Fail;
                apiResponseModel.Message = new TranslationCode
                {
                    LanguageCode = _config.ActiveLanguageCode,
                    TextCode = TranslateCode.LANGUAGE_FAIL_1, // Diller başarılı bir şekilde alınamadı.

                }.Translate();

                apiResponseModel.ExceptionModel = new ExceptionModel()
                {
                    Message = exception.Message,
                    TypeName = exception.GetType().FullName
                };
            }
            finally
            {
                _contextAccessor.HttpContext.Response.StatusCode = (int)apiResponseModel.HttpStatusCode;
            }
            return apiResponseModel;
         */
    }
}