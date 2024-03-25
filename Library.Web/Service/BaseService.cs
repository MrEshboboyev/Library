﻿using Library.Web.Models;
using Library.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static Library.Web.Utility.SD;

namespace Library.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("LibraryAPI");
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");

                // token

                // url added
                message.RequestUri = new Uri(requestDto.Url);

                // sending data converting 
                if(requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");  
                }

                HttpResponseMessage? apiResponse = null;

                switch(requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get ;
                        break;
                }

                apiResponse = await client.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.Forbidden:
                        return new ResponseDto { IsSuccess = false, Message = "Access Denied" };
                    case HttpStatusCode.BadRequest:
                        return new ResponseDto { IsSuccess = false, Message = "Bad Request" };
                    case HttpStatusCode.Unauthorized:
                        return new ResponseDto { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.NotFound:
                        return new ResponseDto { IsSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.InternalServerError:
                        return new ResponseDto { IsSuccess = false, Message = "Internal Server Error" };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                ResponseDto dto = new()
                {
                    IsSuccess = false,
                    Message = ex.Message.ToString()
                };

                return dto;
            }
        }
    }
}
